using FluentAssertions;
using QuartzNet.EntityFrameworkCore.Entities;
using QuartzNet.EntityFrameworkCore.Entities.Enumerations;

namespace QuartzNet.EntityFrameworkCore.Tests.Unit.Entities;

public class FiredTriggerTests
{
    #region Private members
    private string _schedulerName = "test scheduler";
    private string _entryId = "Test entry";
    private string _triggerName ="Test trigger";
    private string _triggerGroup = "Test trigger group";
    private string _instanceName ="Test instance";
    private DateTimeOffset _firedTime =DateTimeOffset.UtcNow.AddDays(1);
    private DateTimeOffset _scheduledTime=DateTimeOffset.UtcNow;
    private uint _priority =1;
    private TriggerState _state =TriggerState.None;
    private string? _jobName =null;
    private string? _jobGroup=null;
    private bool? _isNonConcurrent=null;
    private bool? _requestsRecovery=null;

    private FiredTrigger CreateSut() => new(_schedulerName, _entryId, _triggerName, _triggerGroup, _instanceName, _firedTime, _scheduledTime, _priority, _state, _jobName, _jobGroup, _isNonConcurrent, _requestsRecovery);
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
    public void AnArgumentNullExceptionShouldBeThrownWhenTheEntryIdPassedInIsNull()
    {
        _entryId =null!;

        var act = CreateSut;

        act.Should().Throw<ArgumentNullException>();
    }

    [Fact]
    public void AnArgumentExceptionShouldBeThrownWhenTheEntryIdPassedInIsAnEmptyString()
    {
        _entryId = string.Empty;

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
    public void AnArgumentOutOfRangeExceptionShouldBeThrownWhenTheFiredTimeIsLessThanTheScheduledTime()
    {
        _firedTime = _scheduledTime.Subtract(TimeSpan.FromDays(1));
        
        var act = CreateSut;

        act.Should().Throw<ArgumentOutOfRangeException>();
    }
    
    [Fact]
    public void AFiredTriggerInstanceShouldBeInstantiatedWhenAllParametersAreValid()
    {
        var result = CreateSut();

        result.Should().NotBeNull();
    }
    #endregion
}