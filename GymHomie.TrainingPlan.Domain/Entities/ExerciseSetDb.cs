using GymHomie.TrainingPlan.Domain.Primitives;

namespace GymHomie.TrainingPlan.Domain.Entities
{
    public class ExerciseSetDb : Entity
    {
        public long ExerciseId { get; private set; }
        public int Reps { get; private set; }
        public decimal Weight { get; private set; }
        public int RestTimeSeconds { get; private set; }
        public long? CombinedSetId { get; private set; }
        public long SessionId { get; private set; }
        public virtual ExerciseDb? Exercise { get; private set; }
        public virtual ExerciseCombinedSetDb? CombinedSet { get; private set; }
        public virtual TrainingSessionDb? Session { get; private set; }

        //EF core
        protected ExerciseSetDb() { }

        private ExerciseSetDb(long id, 
            long exerciseId, 
            int reps, 
            decimal weight, 
            int restTimeSeconds,
            long? combinedSetId, 
            long sessionId) : base (id)
        {
            ExerciseId = exerciseId;
            Reps = reps;
            Weight = weight;
            RestTimeSeconds = restTimeSeconds;
            CombinedSetId = combinedSetId;
            SessionId = sessionId;
        }

        public static ExerciseSetDb Create(long exerciseId, 
            int reps, 
            decimal weight, 
            int restTimeSeconds,
            long? combinedSetId, 
            long sessionId)
        {
            return new(id: 0,
                exerciseId: exerciseId,
                reps: reps,
                weight: weight,
                restTimeSeconds: restTimeSeconds,
                combinedSetId: combinedSetId,
                sessionId: sessionId);
        }
    }
}
