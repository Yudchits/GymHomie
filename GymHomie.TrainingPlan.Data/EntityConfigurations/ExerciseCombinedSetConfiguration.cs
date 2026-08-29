using GymHomie.TrainingPlan.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GymHomie.TrainingPlan.Data.EntityConfigurations
{
    internal sealed class ExerciseCombinedSetConfiguration : IEntityTypeConfiguration<ExerciseCombinedSetDb>
    {
        public void Configure(EntityTypeBuilder<ExerciseCombinedSetDb> builder)
        {
            builder
                .ToTable("ExerciseCombinedSets")
                .HasKey(cs => cs.Id);

            builder
                .Property(cs => cs.Id)
                .ValueGeneratedOnAdd();

            builder
                .Property(cs => cs.Rounds)
                .IsRequired();

            builder
                .Property(cs => cs.RestTimeSeconds)
                .IsRequired();

            builder
                .HasMany(cs => cs.Sets)
                .WithOne(s => s.CombinedSet!)
                .HasForeignKey(s => s.CombinedSetId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
