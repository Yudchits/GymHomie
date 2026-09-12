using GymHomie.TrainingPlan.Domain.Primitives;

namespace GymHomie.TrainingPlan.Domain.Entities
{
    public class TrainingSessionDb : Entity
    {
        public long PlanId { get; private set; }
        public virtual TrainingPlanDb? Plan { get; private set; }

        //EF core
        protected TrainingSessionDb() { }

        private TrainingSessionDb(long id, long planId) : base(id)
        {
            PlanId = planId;
        }

        public static TrainingSessionDb Create(long id, long planId)
        {
            return new(id: id, planId: planId);
        }
    }
}
