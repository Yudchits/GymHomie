using GymHomie.Domain.Core.Constants;
using GymHomie.TrainingPlan.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GymHomie.TrainingPlan.Data.EntityConfigurations
{
    internal sealed class ExerciseSetConfiguration : IEntityTypeConfiguration<ExerciseSetDb>
    {
        public void Configure(EntityTypeBuilder<ExerciseSetDb> builder)
        {
            builder
                .ToTable(name: "exercise_sets", schema: PostgreDbSchemas.TrainingPlan)
                .HasKey(s => s.Id);

            builder
                .Property(s => s.Id)
                .ValueGeneratedOnAdd();

            builder
                .Property(s => s.Sets)
                .IsRequired();

            builder
                .Property(s => s.Reps)
                .IsRequired();

            builder
                .Property(s => s.Weight)
                .HasPrecision(8, 2)
                .IsRequired();

            builder
                .Property(s => s.RestTimeSeconds)
                .IsRequired();

            builder
                .HasOne(s => s.Exercise)
                .WithMany(e => e!.Sets)
                .HasForeignKey(s => s.ExerciseId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(s => s.CombinedSet)
                .WithMany(cs => cs!.Sets)
                .HasForeignKey(s => s.CombinedSetId)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasOne(s => s.Plan)
                .WithMany(p => p!.Sets)
                .HasForeignKey(s => s.PlanId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
