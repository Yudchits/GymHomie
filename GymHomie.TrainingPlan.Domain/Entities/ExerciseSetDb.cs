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
        public long PlanId { get; private set; }
        public virtual ExerciseDb? Exercise { get; private set; }
        public virtual ExerciseCombinedSetDb? CombinedSet { get; private set; }
        public virtual TrainingPlanDb? Plan { get; private set; }

        //EF core
        protected ExerciseSetDb() { }

        private ExerciseSetDb(long id, 
            long exerciseId, 
            int sets,
            int reps, 
            decimal weight, 
            int restTimeSeconds,
            long? combinedSetId, 
            long planId) : base (id)
        {
            ExerciseId = exerciseId;
            Sets = sets;
            Reps = reps;
            Weight = weight;
            RestTimeSeconds = restTimeSeconds;
            CombinedSetId = combinedSetId;
            PlanId = planId;
        }

        public static ExerciseSetDb Create(long id, 
            long exerciseId, 
            int sets,
            int reps,
            decimal weight,
            int restTimeSeconds,
            long? combinedSetId, 
            long planId)
        {
            if (sets < 1)
                throw new ArgumentOutOfRangeException(nameof(sets), "Sets number can't be less than 1");

            if (reps < 1)
                throw new ArgumentOutOfRangeException(nameof(reps), "Reps number can't be less than 1");

            return new(id: id,
                exerciseId: exerciseId,
                sets: sets,
                reps: reps,
                weight: weight,
                restTimeSeconds: restTimeSeconds,
                combinedSetId: combinedSetId,
                planId: planId);
        }
    }
}
