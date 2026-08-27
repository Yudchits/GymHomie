using MediatR;
using System;

namespace GymHomie.Domain.Core.Commands
{
    public abstract record Command : IRequest<bool>
    {
        public DateTime Timestamp { get; protected set; }

        public Command()
        {
            Timestamp = DateTime.Now;
        }
    }
}
