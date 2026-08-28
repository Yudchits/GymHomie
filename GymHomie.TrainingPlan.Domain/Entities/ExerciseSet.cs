namespace GymHomie.TrainingPlan.Domain.Entities
{
    public class ExerciseSet
    {
        public long Id { get; set; }
        public long ExerciseId { get; set; }
        public int Reps { get; set; }
        public decimal Weight { get; set; }
        public int RestTimeSeconds { get; set; }
        public long? ExerciseCombineSetId { get; set; }

        public virtual Exercise? Exercise { get; set; }
        public virtual ExerciseCombineSet? CombineSet { get; set; }
    }
}
