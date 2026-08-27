using System;

namespace GymHomie.Domain.Core.Events
{
    public abstract record Event
    {
        public DateTime Timestamp { get; protected set; }

        public Event()
        {
            Timestamp = DateTime.Now;
        }
    }
}
