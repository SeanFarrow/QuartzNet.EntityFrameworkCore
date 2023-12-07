using FluentAssertions;
using QuartzNet.EntityFrameworkCore.Entities;

namespace QuartzNet.EntityFrameworkCore.Tests.Unit.Entities;

public class SimpleTriggerTests
{
    #region Private members.
    private string _schedulerName = "test scheduler";
    private string _triggerName = "test trigger";
    private string _triggerGroup = "test group";
    private uint _repeatCount =0;
    private TimeSpan _repeatInterval=TimeSpan.FromMinutes(1);
    private uint _timesTriggered = 0;

    private SimpleTrigger CreateSut() => new(_schedulerName, _triggerName, _triggerGroup, _repeatCount, _repeatInterval, _timesTriggered);
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
    public void AnArgumentNullExceptionShouldBeThrownWhenTheTriggerNamePassedInIsNull()
    {
        _triggerName = null!;

        var act = CreateSut;

        act.Should().Throw<ArgumentNullException>();
    }

    [Fact]
    public void AnArgumentExceptionShouldBeThrownWhenTheTriggerNamePassedInIsAnEmptyString()
    {
        _triggerName = String.Empty;

        var act = CreateSut;

        act.Should().Throw<ArgumentException>();
    }

    [Fact]
    public void AnArgumentNullExceptionShouldBeThrownWhenTheTriggerGroupPassedInIsNull()
    {
        _triggerGroup = null!;

        var act = CreateSut;

        act.Should().Throw<ArgumentNullException>();
    }

    [Fact]
    public void AnArgumentExceptionShouldBeThrownWhenTheTriggerGroupPassedInIsAnEmptyString()
    {
        _triggerGroup = String.Empty;

        var act = CreateSut;

        act.Should().Throw<ArgumentException>();
    }
    
    [Fact]
    public void AnArgumentOutOfRangeExceptionIsThrownWhenTheRepeatIntervalIsZero()
    {
        _repeatInterval = TimeSpan.Zero;

        var act = CreateSut;

        act.Should().Throw<ArgumentOutOfRangeException>();
    }

    [Fact]
    public void ASimpleTriggerInstanceShouldBeEnstantiatedWhenAllParametersAreValid()
    {
        var result = CreateSut();

        result.Should().NotBeNull();
    }
    #endregion
}