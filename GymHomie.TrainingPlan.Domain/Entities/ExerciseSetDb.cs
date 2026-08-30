using GymHomie.TrainingPlan.Domain.Primitives;
using System;

namespace GymHomie.TrainingPlan.Domain.Entities
{
    public class ExerciseSetDb : Entity
    {
        public long ExerciseId { get; private set; }
        public int Sets { get; private set; }
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
            int sets,
            int reps, 
            decimal weight, 
            int restTimeSeconds,
            long? combinedSetId, 
            long sessionId) : base (id)
        {
            ExerciseId = exerciseId;
            Sets = sets;
            Reps = reps;
            Weight = weight;
            RestTimeSeconds = restTimeSeconds;
            CombinedSetId = combinedSetId;
            SessionId = sessionId;
        }

        public static ExerciseSetDb Create(long exerciseId, 
            int sets,
            int reps,
            decimal weight,
            int restTimeSeconds,
            long? combinedSetId, 
            long sessionId)
        {
            if (sets < 1)
                throw new ArgumentOutOfRangeException(nameof(sets), "Sets number can't be less than 1");

            if (reps < 1)
                throw new ArgumentOutOfRangeException(nameof(reps), "Reps number can't be less than 1");

            return new(id: 0,
                exerciseId: exerciseId,
                sets: sets,
                reps: reps,
                weight: weight,
                restTimeSeconds: restTimeSeconds,
                combinedSetId: combinedSetId,
                sessionId: sessionId);
        }
    }
}
