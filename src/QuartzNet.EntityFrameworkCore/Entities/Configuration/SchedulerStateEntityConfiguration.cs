using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace QuartzNet.EntityFrameworkCore.Entities.Configuration;

public class SchedulerStateEntityConfiguration : IEntityTypeConfiguration<SchedulerState>
{
    public void Configure(EntityTypeBuilder<SchedulerState> builder)
    {
        builder.ToTable("SchedulerState", "Quartz");
        builder.HasKey("SchedulerName", "InstanceName");
        builder.Property(x => x.SchedulerName).IsRequired().HasMaxLength(120);
        builder.Property(x => x.InstanceName).IsRequired().HasMaxLength(200);
        builder.Property(x => x.LastCheckinTime).IsRequired();
        builder.Property(x => x.CheckinInterval).HasConversion<long>();
    }
}