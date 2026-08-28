using System.Collections.Generic;

namespace GymHomie.TrainingPlan.Domain.Entities
{
    public class TrainingSession
    {
        public long Id { get; set; }
        public long PlanId { get; set; }

        public virtual TrainingPlan? Plan { get; set; }
        public virtual ICollection<ExerciseSet> Sets { get; set; } = new List<ExerciseSet>();
    }
}
