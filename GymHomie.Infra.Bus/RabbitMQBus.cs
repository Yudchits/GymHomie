using GymHomie.Domain.Core.Bus;
using GymHomie.Domain.Core.Commands;
using GymHomie.Domain.Core.Events;
using MediatR;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymHomie.Infra.Bus
{
    public class RabbitMQBus : IEventBus
    {
        private readonly IMediator _mediator;
        private readonly IServiceProvider _serviceProvider;
        private readonly ConnectionFactory _connectionFactory;
        private readonly Dictionary<string, List<Type>> _eventHandlers;

        public RabbitMQBus(IMediator mediator, IServiceProvider serviceProvider)
        {
            _mediator = mediator;
            _serviceProvider = serviceProvider;
            _connectionFactory = new ConnectionFactory
            {
                HostName = "localhost",
                DispatchConsumersAsync = true
            };
            _eventHandlers = new();
        }

        public async Task SendAsync<T>(T command) where T : Command
        {
            await _mediator.Send(command);
        }

        public Task PublishAsync<T>(T @event) where T : Event
        {
            using var connection = _connectionFactory.CreateConnection();
            using var channel = connection.CreateModel();

            string eventName = typeof(T).Name;

            string json = JsonConvert.SerializeObject(@event);
            var body = Encoding.UTF8.GetBytes(json);

            channel.QueueDeclare(queue: eventName,
                durable: false,
                exclusive: false,
                autoDelete: false,
                arguments: null);

            channel.BasicPublish(exchange: string.Empty,
                routingKey: eventName,
                basicProperties: null,
                body: body);

            return Task.CompletedTask;
        }

        public async Task SubscribeAsync<T, TH>()
            where T : Event
            where TH : IEventHandler<T>
        {
            string eventName = typeof(T).Name;
            var handlerType = typeof(TH);

            if (!_eventHandlers.ContainsKey(eventName))
                _eventHandlers.Add(eventName, new());

            if (_eventHandlers[eventName].Any(handler => handler.GetType().Name == handlerType.Name))
                throw new InvalidOperationException($"The handler '{handlerType.Name}' is already registered for the event '{eventName}'");

            _eventHandlers[eventName].Add(handlerType);

            await StartBasicConsumeAsync<T, TH>();
        }

        private Task StartBasicConsumeAsync<T, TH>()
            where T : Event
            where TH : IEventHandler<T>
        {
            string eventName = typeof(T).Name;

            var connection = _connectionFactory.CreateConnection();
            var channel = connection.CreateModel();

            channel.QueueDeclare(queue: eventName,
                durable: false,
                exclusive: false,
                autoDelete: false,
                arguments: null);

            var consumer = new AsyncEventingBasicConsumer(channel);
            consumer.Received += Consumer_Received<T>;

            channel.BasicConsume(queue: eventName,
                autoAck: false,
                consumer: consumer);

            return Task.CompletedTask;
        }

        private async Task Consumer_Received<T>(object sender, BasicDeliverEventArgs args)
            where T : Event
        {
            var routingKey = args.RoutingKey;

            var hasHandlers = _eventHandlers.TryGetValue(routingKey, out var eventHandlers);
            if (!hasHandlers)
                return;

            if (eventHandlers is null || eventHandlers.Count < 1)
                return;

            var body = args.Body.ToArray();
            string message = Encoding.UTF8.GetString(body);
            var @event = JsonConvert.DeserializeObject<T>(message);

            foreach (var eventHandler in eventHandlers)
            {
                var handler = _serviceProvider.GetService(eventHandler);
                if (handler is null)
                    continue;

                var concreteHandler = typeof(IEventHandler<>).MakeGenericType(typeof(T));
                if (concreteHandler is null)
                    return;

                await (Task) concreteHandler
                    .GetMethod(nameof(IEventHandler<T>.HandleAsync))
                    .Invoke(handler, new object[] { @event });
            }
        }
    }
}
