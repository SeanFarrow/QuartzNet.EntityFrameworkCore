using FluentAssertions;
using QuartzNet.EntityFrameworkCore.Entities;

namespace QuartzNet.EntityFrameworkCore.Tests.Unit.Entities;

public class SchedulerStateTestse
{
    #region Private members.
    private string _schedulerName = "test scheduler";
    private string _instanceName = "test instance";
    private DateTimeOffset _lastCheckinTime =DateTimeOffset.UtcNow;
    private TimeSpan _checkinInterval =TimeSpan.FromSeconds(5);
    
    private SchedulerState CreateSut() => new(_schedulerName, _instanceName, _lastCheckinTime, _checkinInterval);
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
    public void AnArgumentNullExceptionShouldBeThrownWhenTheInstanceNamePassedInIsNull()
    {
        _instanceName = null!;

        var act = CreateSut;

        act.Should().Throw<ArgumentNullException>();
    }

    [Fact]
    public void AnArgumentExceptionShouldBeThrownWhenTheInstanceNamePassedInIsAnEmptyString()
    {
        _instanceName = String.Empty;

        var act = CreateSut;

        act.Should().Throw<ArgumentException>();
    }

    [Fact]
    public void AnArgumentExceptionShouldBeThrownWhenTheLastCheckinTimeIsInTheFuture()
    {
        _lastCheckinTime =DateTimeOffset.UtcNow.AddDays(1);
        var act = CreateSut;
        
        act.Should().Throw<ArgumentException>();
    }

    [Fact]
    public void AnArgumentExceptionIsThrownWhenTheCheckingIntervalPassedInIsZero()
    {
        _checkinInterval = TimeSpan.Zero;
        var act = CreateSut;
        
        act.Should().Throw<ArgumentException>();
    }
    
    [Fact]
    public void ASchedulerStateInstanceShouldBeEnstantiatedWhenAllParametersAreValid()
    {
        var result = CreateSut();

        result.Should().NotBeNull();
    }
    #endregion
}