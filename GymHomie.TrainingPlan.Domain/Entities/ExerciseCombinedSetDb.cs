using GymHomie.TrainingPlan.Domain.Primitives;
using System.Collections.Generic;

namespace GymHomie.TrainingPlan.Domain.Entities
{
    public class ExerciseCombinedSetDb : Entity
    {
        public int Rounds { get; private set; }
        public int RestTimeSeconds { get; private set; }
        public virtual ICollection<ExerciseSetDb> Sets { get; private set; } = new List<ExerciseSetDb>();

        //EF core
        protected ExerciseCombinedSetDb() { }

        private ExerciseCombinedSetDb(long id, int rounds, int restTimeSeconds) : base(id)
        {
            Rounds = rounds;
            RestTimeSeconds = restTimeSeconds;
        }

        public static ExerciseCombinedSetDb Create(long id, int rounds, int restTimeSeconds)
        {
            return new(id: id, rounds: rounds, restTimeSeconds: restTimeSeconds);
        }
    }
}
