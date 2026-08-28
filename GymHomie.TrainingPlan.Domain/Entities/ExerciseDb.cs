using System.Collections.Generic;

namespace GymHomie.TrainingPlan.Domain.Entities
{
    public class ExerciseDb
    {
        public long Id { get; set; }
        public string Name { get; set; } = null!;
        public virtual ICollection<ExerciseSetDb> Sets { get; set; } = new List<ExerciseSetDb>();
    }
}
