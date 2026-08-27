using GymHomie.Domain.Core.Events;
using System.Threading.Tasks;

namespace GymHomie.Domain.Core.Bus
{
    public interface IEventHandler<in TEvent> : IEventHandler
        where TEvent : Event
    {
        Task HandleAsync(TEvent @event);
    }

    public interface IEventHandler
    {
    }
}
