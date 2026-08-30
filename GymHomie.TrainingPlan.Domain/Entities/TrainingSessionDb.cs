using GymHomie.TrainingPlan.Domain.Primitives;
using System.Collections.Generic;

namespace GymHomie.TrainingPlan.Domain.Entities
{
    public class TrainingSessionDb : Entity
    {
        public long PlanId { get; private set; }
        public virtual TrainingPlanDb? Plan { get; private set; }
        public virtual ICollection<ExerciseSetDb> Sets { get; private set; } = new List<ExerciseSetDb>();

        //EF core
        protected TrainingSessionDb() { }

        private TrainingSessionDb(long id, long planId) : base(id)
        {
            PlanId = planId;
        }

        public static TrainingSessionDb Create(long planId)
        {
            return new(id: 0, planId: planId);
        }
    }
}
