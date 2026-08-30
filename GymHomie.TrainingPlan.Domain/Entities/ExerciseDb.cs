using GymHomie.TrainingPlan.Domain.Primitives;
using System.Collections.Generic;

namespace GymHomie.TrainingPlan.Domain.Entities
{
    public class ExerciseDb : Entity
    {
        public string Name { get; private set; } = null!;
        public virtual ICollection<ExerciseSetDb> Sets { get; private set; } = new List<ExerciseSetDb>();

        //EF core
        protected ExerciseDb() { }

        private ExerciseDb(long id, string name) : base(id)
        {
            Name = name;
        }

        public static ExerciseDb Create(string name)
        {
            return new(id: 0, name: name);
        }
    }
}
