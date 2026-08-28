using System.Collections.Generic;

namespace GymHomie.TrainingPlan.Domain.Entities
{
    public class TrainingPlan
    {
        public long Id { get; set; }
        public string Title { get; set; } = null!;

        public virtual ICollection<TrainingSession> Sessions { get; set; } = new List<TrainingSession>();
    }
}
