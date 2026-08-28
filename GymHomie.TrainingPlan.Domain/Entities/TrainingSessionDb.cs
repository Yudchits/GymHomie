using System.Collections.Generic;

namespace GymHomie.TrainingPlan.Domain.Entities
{
    public class TrainingSessionDb
    {
        public long Id { get; set; }
        public long PlanId { get; set; }

        public virtual TrainingPlanDb? Plan { get; set; }
        public virtual ICollection<ExerciseSetDb> Sets { get; set; } = new List<ExerciseSetDb>();
    }
}
