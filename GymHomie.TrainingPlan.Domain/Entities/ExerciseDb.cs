using GymHomie.TrainingPlan.Domain.Primitives;
using System.Collections.Generic;

namespace GymHomie.TrainingPlan.Domain.Entities
{
    public class ExerciseDb : Entity
    {
        public string Name { get; private set; } = null!;
        public long IconId { get; private set; }
        public virtual IconDb? Icon { get; private set; }
        public virtual ICollection<ExerciseSetDb> Sets { get; private set; } = new List<ExerciseSetDb>();

        //EF core
        protected ExerciseDb() { }

        private ExerciseDb(long id, string name, long iconId) 
            : base(id)
        {
            Name = name;
            IconId = iconId;
        }

        public static ExerciseDb Create(long id, string name, long iconId)
        {
            return new(id: id, name: name, iconId: iconId);
        }
    }
}
