using System.Collections.Generic;

namespace GymHomie.TrainingPlan.Domain.Entities
{
    public class ExerciseCombineSetDb
    {
        public long Id { get; set; }
        public int Rounds { get; set; }
        public int RestTimeSeconds { get; set; }

        public virtual ICollection<ExerciseSetDb> Sets { get; set; } = new List<ExerciseSetDb>();
    }
}
