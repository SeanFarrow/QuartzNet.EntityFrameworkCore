using FluentAssertions;
using QuartzNet.EntityFrameworkCore.Entities;

namespace QuartzNet.EntityFrameworkCore.Tests.Unit.Entities;

public class PausedTriggerGroupTests
{
    #region Private members.
    private string _schedulerName ="test scheduler";
    private string _triggerGroup ="test group";

    private PausedTriggerGroup CreateSut() => new(_schedulerName, _triggerGroup);
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
    public void APausedTriggerGroupInstanceShouldBeEnstantiatedWhenAllParametersAreValid()
    {
        var result = CreateSut();

        result.Should().NotBeNull();
    }
    #endregion
}