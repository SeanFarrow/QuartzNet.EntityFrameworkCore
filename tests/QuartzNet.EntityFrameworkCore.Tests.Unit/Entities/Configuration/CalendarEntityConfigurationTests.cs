using FluentAssertions;
using FluentAssertions.Execution;
using Microsoft.EntityFrameworkCore;
using QuartzNet.EntityFrameworkCore.Entities;
using QuartzNet.EntityFrameworkCore.Entities.Configuration;

namespace QuartzNet.EntityFrameworkCore.Tests.Unit.Entities.Configuration;

public class CalendarEntityConfigurationTests : EntityTypeConfigurationTestsBase<CalendarEntityConfiguration, Calendar>
{
    [Fact]
    public void Configure_ConfiguresTheCalendarEntityAsExpected()
    {
        var sut = CreateSut();
        var entityBuilder = GetEntityBuilder();

        sut.Configure(entityBuilder);
        var metadata = entityBuilder.Metadata;

        using var scope = new AssertionScope();
        metadata.GetSchema().Should().Be("Quartz");
        metadata.GetTableName().Should().Be("Calendars");
        var schedulerNameProperty = metadata.FindDeclaredProperty("SchedulerName");
        ValidateModelProperty(schedulerNameProperty, x =>
        {
            x?.IsNullable.Should().BeFalse();
            x?.GetMaxLength().Should().Be(120);
            x?.GetContainingKeys().Should().HaveCount(1);
        });

        var calendarNameProperty = metadata.FindDeclaredProperty("CalendarName");
        ValidateModelProperty(calendarNameProperty, x =>
        {
            x?.IsNullable.Should().BeFalse();
            x?.GetMaxLength().Should().Be(200);
            x?.GetContainingKeys().Should().HaveCount(1);
        });

        var serializedCalendarProperty = metadata.FindDeclaredProperty("SerializedCalendar");
        ValidateModelProperty(serializedCalendarProperty, x =>
        {
            x?.IsNullable.Should().BeFalse();
            x?.GetMaxLength().Should().BeNull();
            x?.GetContainingKeys().Should().BeEmpty();
        });
    }
}