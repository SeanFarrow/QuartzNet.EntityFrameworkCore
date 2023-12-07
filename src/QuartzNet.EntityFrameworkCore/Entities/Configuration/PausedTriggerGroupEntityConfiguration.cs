using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace QuartzNet.EntityFrameworkCore.Entities.Configuration;

public class PausedTriggerGroupEntityConfiguration : IEntityTypeConfiguration<PausedTriggerGroup>
{
    public void Configure(EntityTypeBuilder<PausedTriggerGroup> builder)
    {
        builder.ToTable("PausedTriggerGroups", "Quartz");
        builder.HasKey("SchedulerName", "TriggerGroup");
        builder.Property(x => x.SchedulerName).IsRequired().HasMaxLength(120);
        builder.Property(x => x.TriggerGroup).IsRequired().HasMaxLength(150);
    }
}