using System.Collections.Generic;

namespace GymHomie.TrainingPlan.Domain.Entities
{
    public class TrainingPlanDb
    {
        public long Id { get; set; }
        public string Title { get; set; } = null!;

        public virtual ICollection<TrainingSessionDb> Sessions { get; set; } = new List<TrainingSessionDb>();
    }
}
