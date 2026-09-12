using GymHomie.TrainingPlan.Domain.Primitives;
using System.Collections.Generic;

namespace GymHomie.TrainingPlan.Domain.Entities
{
    public class IconDb : Entity
    {
        public string Name { get; private set; }
        public virtual ICollection<ExerciseDb> Exercises { get; private set; } = new List<ExerciseDb>();

        //EF core
        protected IconDb() { }

        private IconDb(long id, string name)
            : base(id)
        {
            Name = name;
        }

        public static IconDb Create(long id, string name)
        {
            return new(id: id, name: name);
        }
    }
}
