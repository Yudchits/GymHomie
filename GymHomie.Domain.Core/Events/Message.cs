namespace GymHomie.Domain.Core.Events
{
    public abstract record Message
    {
        public string MessageType { get; protected set; }

        public Message()
        {
            MessageType = GetType().Name;
        }
    }
}
