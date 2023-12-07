using FluentAssertions;
using QuartzNet.EntityFrameworkCore.Entities;

namespace QuartzNet.EntityFrameworkCore.Tests.Unit.Entities;

public class CalendarTests
{
    #region Private members.
    private string _schedulerName ="test scheduler";
    private string _calendarName ="test calendar";
    private string _serializedCalendar ="serialized calendar";

    private Calendar CreateSut() => new(_schedulerName, _calendarName, _serializedCalendar);
    #endregion

    #region Constructor tests.
    [Fact]
    public void AnArgumentNullExceptionShouldBeThrownWhenTheSchedulerNamePassedInIsNull()
    {
        _schedulerName = null!;

        var act = CreateSut;

        act.Should().Throw<ArgumentNullException>();
    }

    [Fact]
    public void AnArgumentExceptionShouldBeThrownWhenTheSchedulerNamePassedInIsAnEmptyString()
    {
        _schedulerName = String.Empty;

        var act = CreateSut;

        act.Should().Throw<ArgumentException>();
    }

    [Fact]
    public void AnArgumentNullExceptionShouldBeThrownWhenTheCalendarNamePassedInIsNull()
    {
        _calendarName = null!;

        var act = CreateSut;

        act.Should().Throw<ArgumentNullException>();
    }

    [Fact]
    public void AnArgumentExceptionShouldBeThrownWhenTheCalendarNamePassedInIsAnEmptyString()
    {
        _calendarName = String.Empty;

        var act = CreateSut;

        act.Should().Throw<ArgumentException>();
    }

    [Fact]
    public void AnArgumentNullExceptionShouldBeThrownWhenTheSerializedCalendarPassedInIsNull()
    {
        _serializedCalendar = null!;

        var act = CreateSut;

        act.Should().Throw<ArgumentNullException>();
    }

    [Fact]
    public void AnArgumentExceptionShouldBeThrownWhenTheSerializerCalendarPassedInIsAnEmptyString()
    {
        _serializedCalendar = String.Empty;

        var act = CreateSut;

        act.Should().Throw<ArgumentException>();
    }
    [Fact]
    public void ACalendarInstanceShouldBeInstantiatedWhenAllParametersAreValid()
    {
        var result = CreateSut();

        result.Should().NotBeNull();
    }
    #endregion
}