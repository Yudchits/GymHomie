using System.Collections.Generic;

namespace GymHomie.TrainingPlan.Domain.Entities
{
    public class ExerciseCombineSet
    {
        public long Id { get; set; }
        public int Rounds { get; set; }
        public int RestTimeSeconds { get; set; }

        public virtual ICollection<ExerciseSet> Sets { get; set; } = new List<ExerciseSet>();
    }
}
