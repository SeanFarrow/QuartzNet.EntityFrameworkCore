using FluentAssertions;
using QuartzNet.EntityFrameworkCore.Entities;

namespace QuartzNet.EntityFrameworkCore.Tests.Unit.Entities;

public class CronTriggerTests
{
    #region Private members.
    private string _schedulerName ="test scheduler";
    private string _triggerName ="test trigger";
    private string _triggerGroup ="test group";
    private string _cronExpression ="test expression";
    private string? _timezoneId ="test id";
    
    private CronTrigger CreateSut() => new(_schedulerName, _triggerName, _triggerGroup, _cronExpression, _timezoneId);
    #endregion
    
    #region Constructor tests.
    [Fact]
    public void AnArgumentNullExceptionShouldBeThrownWhenTheSchedulerNamePassedInIsNull()
    {
        _schedulerName = null!;

        var act =CreateSut;

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
    public void AnArgumentNullExceptionShouldBeThrownWhenTheCronExpressionPassedInIsNull()
    {
        _cronExpression = null!;

        var act = CreateSut;

        act.Should().Throw<ArgumentNullException>();
    }

    [Fact]
    public void AnArgumentExceptionShouldBeThrownWhenTheCronExpressionPassedInIsAnEmptyString()
    {
        _cronExpression = String.Empty;

        var act = CreateSut;

        act.Should().Throw<ArgumentException>();
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    public void ACronTriggerInstanceShouldBeEnstantiatedWhenAllParametersAreValid(string? timezoneId)
    {
        _timezoneId =timezoneId;

        var result = CreateSut();

        result.Should().NotBeNull();
    }
    #endregion
}