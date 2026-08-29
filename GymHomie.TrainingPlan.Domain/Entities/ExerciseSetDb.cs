namespace GymHomie.TrainingPlan.Domain.Entities
{
    public class ExerciseSetDb
    {
        public long Id { get; set; }
        public long ExerciseId { get; set; }
        public int Reps { get; set; }
        public decimal Weight { get; set; }
        public int RestTimeSeconds { get; set; }
        public long? CombinedSetId { get; set; }
        public long SessionId { get; set; }

        public virtual ExerciseDb? Exercise { get; set; }
        public virtual ExerciseCombinedSetDb? CombinedSet { get; set; }
        public virtual TrainingSessionDb? Session { get; set; }
    }
}
