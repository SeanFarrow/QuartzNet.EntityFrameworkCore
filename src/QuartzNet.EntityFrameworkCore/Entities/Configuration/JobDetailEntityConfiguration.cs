using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace QuartzNet.EntityFrameworkCore.Entities.Configuration;

public class JobDetailEntityConfiguration : IEntityTypeConfiguration<JobDetail>
{
    public void Configure(EntityTypeBuilder<JobDetail> builder)
    {
        builder.ToTable("JobDetails", "Quartz");
        builder.HasKey("SchedulerName", "JobName", "JobGroup");
        builder.Property(x => x.SchedulerName).IsRequired().HasMaxLength(120);
        builder.Property(x => x.JobName).IsRequired().HasMaxLength(150);
        builder.Property(x => x.JobGroup).IsRequired().HasMaxLength(150);
        builder.Property(x =>x.Description).HasMaxLength(250);
        builder.Property(x => x.JobClassName).IsRequired().HasMaxLength(250);
        builder.Property(x => x.IsDurable).IsRequired();
        builder.Property(x => x.IsNonConcurrent).IsRequired();
        builder.Property(x => x.IsUpdateData).IsRequired();
        builder.Property(x => x.RequestsRecovery).IsRequired();
        builder.Property(x => x.JobData);
    }
}