using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace QuartzNet.EntityFrameworkCore.Entities.Configurations;

public class CronTriggerEntityConfiguration : IEntityTypeConfiguration<CronTrigger>
{
    public void Configure(EntityTypeBuilder<CronTrigger> builder)
    {
        builder.ToTable("CronTriggers", "Quartz");
        builder.HasKey("SchedulerName", "TriggerName", "TriggerGroup");
        builder.Property(x =>x.SchedulerName).IsRequired().HasMaxLength(120);
        builder.Property(x => x.TriggerName).IsRequired().HasMaxLength(150);
        builder.Property(x => x.TriggerGroup).IsRequired().HasMaxLength(150);
        builder.Property(x => x.CronExpression).IsRequired().HasMaxLength(120);
        builder.Property(x => x.TimezoneId).IsRequired().HasMaxLength(80);
    }
}