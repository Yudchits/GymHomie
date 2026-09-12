using GymHomie.Domain.Core.Constants;
using GymHomie.TrainingPlan.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GymHomie.TrainingPlan.Data.EntityConfigurations
{
    internal sealed class IconConfiguration : IEntityTypeConfiguration<IconDb>
    {
        public void Configure(EntityTypeBuilder<IconDb> builder)
        {
            builder
                .ToTable(name: "icons", schema: PostgreDbSchemas.TrainingPlan)
                .HasKey(i => i.Id);

            builder
                .Property(i => i.Id)
                .ValueGeneratedOnAdd();

            builder
                .Property(i => i.Name)
                .HasMaxLength(64)
                .IsRequired();

            builder
                .HasIndex(i => i.Name)
                .IsUnique();

            builder
                .HasMany(i => i.Exercises)
                .WithOne(e => e.Icon!)
                .HasForeignKey(e => e.IconId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
