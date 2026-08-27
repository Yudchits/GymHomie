using GymHomie.Domain.Core.Commands;
using GymHomie.Domain.Core.Events;
using System.Threading.Tasks;

namespace GymHomie.Domain.Core.Bus
{
    public interface IEventBus
    {
        Task SendAsync<T>(T command) where T : Command;
        Task PublishAsync<T>(T @event) where T : Event;
        Task SubscribeAsync<T, TH>()
            where T : Event
            where TH : IEventHandler<T>;
    }
}
