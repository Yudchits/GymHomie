namespace GymHomie.TrainingPlan.Domain.Primitives
{
    public abstract class Entity
    {
        public long Id { get; private init; }

        //EF core
        protected Entity() { }

        protected Entity(long id)
        {
            Id = id;
        }

        public static bool operator ==(Entity? first, Entity? second)
        {
            return first is not null && second is not null && first.Equals(second);
        }

        public static bool operator !=(Entity? first, Entity? second) => !(first == second);

        public override bool Equals(object? obj)
        {
            if (obj is null)
                return false;

            if (obj.GetType() != GetType())
                return false;

            if (obj is not Entity entity)
                return false;

            return entity.Id == Id;
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}
