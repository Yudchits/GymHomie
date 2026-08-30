using GymHomie.TrainingPlan.Domain.Primitives;
using System.Collections.Generic;

namespace GymHomie.TrainingPlan.Domain.Entities
{
    public class TrainingPlanDb : Entity
    {
        public string Title { get; private set; } = null!;
        public virtual ICollection<TrainingSessionDb> Sessions { get; private set; } = new List<TrainingSessionDb>();

        //EF core
        protected TrainingPlanDb() { }

        private TrainingPlanDb(long id, string title) : base(id)
        {
            Title = title;
        }

        public static TrainingPlanDb Create(string title)
        {
            return new(id: 0, title: title);
        }
    }
}
