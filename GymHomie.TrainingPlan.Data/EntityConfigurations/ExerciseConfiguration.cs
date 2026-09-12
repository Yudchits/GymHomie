using GymHomie.Domain.Core.Constants;
using GymHomie.TrainingPlan.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GymHomie.TrainingPlan.Data.EntityConfigurations
{
    internal sealed class ExerciseConfiguration : IEntityTypeConfiguration<ExerciseDb>
    {
        public void Configure(EntityTypeBuilder<ExerciseDb> builder)
        {
            builder
                .ToTable(name: "exercises", schema: PostgreDbSchemas.TrainingPlan)
                .HasKey(e => e.Id);

            builder
                .Property(e => e.Id)
                .ValueGeneratedOnAdd();

            builder
                .Property(e => e.Name)
                .HasMaxLength(64)
                .IsRequired();

            builder
                .HasIndex(e => e.Name)
                .IsUnique();

            builder
                .HasOne(e => e.Icon)
                .WithMany(i => i.Exercises)
                .HasForeignKey(e => e.IconId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasMany(e => e.Sets)
                .WithOne(s => s.Exercise!)
                .HasForeignKey(e => e.ExerciseId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
