using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace QuartzNet.EntityFrameworkCore.Entities.Configuration;

public class CalendarEntityConfiguration : IEntityTypeConfiguration<Calendar>
{
    public void Configure(EntityTypeBuilder<Calendar> builder)
    {
        builder.ToTable("Calendars", "Quartz");
        builder.HasKey("SchedulerName", "CalendarName");
        builder.Property(x => x.SchedulerName).IsRequired().HasMaxLength(120);
        builder.Property(x => x.CalendarName).IsRequired().HasMaxLength(200);
        builder.Property(x => x.SerializedCalendar).IsRequired();
    }
}