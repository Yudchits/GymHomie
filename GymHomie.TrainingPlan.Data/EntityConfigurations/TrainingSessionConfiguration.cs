using GymHomie.Domain.Core.Constants;
using GymHomie.TrainingPlan.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GymHomie.TrainingPlan.Data.EntityConfigurations
{
    internal sealed class TrainingSessionConfiguration : IEntityTypeConfiguration<TrainingSessionDb>
    {
        public void Configure(EntityTypeBuilder<TrainingSessionDb> builder)
        {
            builder
                .ToTable(name:  "training_sessions", schema: PostgreDbSchemas.TrainingPlan)
                .HasKey(ts => ts.Id);

            builder
                .Property(ts => ts.Id)
                .ValueGeneratedOnAdd();

            builder
                .HasOne(ts => ts.Plan)
                .WithMany(p => p!.Sessions)
                .HasForeignKey(ts => ts.PlanId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
