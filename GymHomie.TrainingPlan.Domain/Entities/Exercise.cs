using System.Collections.Generic;

namespace GymHomie.TrainingPlan.Domain.Entities
{
    public class Exercise
    {
        public long Id { get; set; }
        public string Name { get; set; } = null!;
        public virtual ICollection<ExerciseSet> Sets { get; set; } = new List<ExerciseSet>();
    }
}
