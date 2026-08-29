using GymHomie.TrainingPlan.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace GymHomie.TrainingPlan.Data.Context
{
    public class TrainingPlanContext : DbContext
    {
        public TrainingPlanContext(DbContextOptions<TrainingPlanContext> options)
            : base(options)
        {
        }

        public DbSet<TrainingPlanDb> TrainingPlans { get; set; }
        public DbSet<TrainingSessionDb> TrainingSessions { get; set; }
        public DbSet<ExerciseDb> Exercises { get; set; }
        public DbSet<ExerciseSetDb> ExerciseSets { get; set; }
        public DbSet<ExerciseCombinedSetDb> ExerciseCombinedSets { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(TrainingPlanContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
