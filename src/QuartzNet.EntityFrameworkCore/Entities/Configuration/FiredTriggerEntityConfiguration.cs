using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.DependencyInjection;

namespace QuartzNet.EntityFrameworkCore.Entities.Configuration;

public class FiredTriggerEntityConfiguration : IEntityTypeConfiguration<FiredTrigger>
{
    public void Configure(EntityTypeBuilder<FiredTrigger> builder)
    {
        builder.ToTable("FiredTriggers", "Quartz");
        builder.HasKey("SchedulerName", "EntryID");
        builder.Property(x => x.SchedulerName).IsRequired().HasMaxLength(120);
        builder.Property(x => x.EntryID).IsRequired().HasMaxLength(140);
        builder.Property(x => x.TriggerName).IsRequired().HasMaxLength(150);
        builder.Property(x => x.TriggerGroup).IsRequired().HasMaxLength(150);
        builder.Property(x => x.InstanceName).IsRequired().HasMaxLength(200);
        builder.Property(x => x.FiredTime).IsRequired();
        builder.Property(x => x.ScheduledTime).IsRequired();
        builder.Property(x => x.Priority).IsRequired();
        builder.Property(x => x.State).IsRequired();
        builder.Property(x => x.JobName).HasMaxLength(150);
        builder.Property(x => x.JobGroup).HasMaxLength(150);
        builder.Property(x => x.IsNonConcurrent);
        builder.Property(x => x.RequestsRecovery);
    }
}