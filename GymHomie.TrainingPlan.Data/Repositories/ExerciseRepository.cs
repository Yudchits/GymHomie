using GymHomie.TrainingPlan.Data.Context;
using GymHomie.TrainingPlan.Domain.Entities;
using GymHomie.TrainingPlan.Domain.Repositories;

namespace GymHomie.TrainingPlan.Data.Repositories
{
    internal sealed class ExerciseRepository : Repository<ExerciseDb, long>, IExerciseRepository
    {
        public ExerciseRepository(TrainingPlanContext context) : base(context)
        {
        }
    }
}
