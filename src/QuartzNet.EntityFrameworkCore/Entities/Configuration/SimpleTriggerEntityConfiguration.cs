using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace QuartzNet.EntityFrameworkCore.Entities.Configuration;

public class SimpleTriggerEntityConfiguration : IEntityTypeConfiguration<SimpleTrigger>
{
    public void Configure(EntityTypeBuilder<SimpleTrigger> builder)
    {
        builder.ToTable("SimpleTriggers", "Quartz");
        builder.HasKey("SchedulerName", "TriggerName", "TriggerGroup");
        builder.Property(x => x.SchedulerName).IsRequired().HasMaxLength(120);
        builder.Property(x => x.TriggerName).IsRequired().HasMaxLength(150);
        builder.Property(x => x.TriggerGroup).IsRequired().HasMaxLength(150);
        builder.Property(x => x.RepeatCount).IsRequired();
        builder.Property(x => x.RepeatInterval).IsRequired();
        builder.Property(x => x.TimesTriggered).IsRequired();
    }
}