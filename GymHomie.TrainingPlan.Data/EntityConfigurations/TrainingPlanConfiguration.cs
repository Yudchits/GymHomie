using GymHomie.TrainingPlan.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GymHomie.TrainingPlan.Data.EntityConfigurations
{
    internal sealed class TrainingPlanConfiguration : IEntityTypeConfiguration<TrainingPlanDb>
    {
        public void Configure(EntityTypeBuilder<TrainingPlanDb> builder)
        {
            builder
                .ToTable("TrainingPlans")
                .HasKey(tp => tp.Id);

            builder
                .Property(tp => tp.Id)
                .ValueGeneratedOnAdd();

            builder
                .Property(tp => tp.Title)
                .HasMaxLength(64)
                .IsRequired();

            builder
                .Property(tp => tp.Notes)
                .HasMaxLength(64);

            builder
                .HasIndex(tp => tp.Title)
                .IsUnique();

            builder
                .HasMany(tp => tp.Sets)
                .WithOne(s => s.Plan!)
                .HasForeignKey(s => s.PlanId)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasMany(tp => tp.Sessions)
                .WithOne(s => s.Plan!)
                .HasForeignKey(s => s.PlanId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
