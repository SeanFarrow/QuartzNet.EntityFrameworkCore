using FluentAssertions;
using QuartzNet.EntityFrameworkCore.Entities;

namespace QuartzNet.EntityFrameworkCore.Tests.Unit.Entities;

public class JobDetailTests
{
    #region Private members.
    private string _schedulerName ="test scheduler";
    private string _jobName ="test job";
    private string _jobGroup ="test job group";
    private readonly string? _description ="Test job description";
    private string _jobClassName = "QuartzNet.EntityFrameworkCore.Tests.Unit.Fakes.FakeJob";
    private readonly bool _isDurable =false;
    private readonly bool _isNonConcurrent =false;
    private readonly bool _isUpdateData =false;
    private readonly bool _requestsRecovery =false;
    private string? _jobData="TestJobData";

    private JobDetail CreateSut() =>new(_schedulerName, _jobName, _jobGroup, _description, _jobClassName, _isDurable, _isNonConcurrent, _isUpdateData, _requestsRecovery, _jobData);
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
    public void AnArgumentNullExceptionShouldBeThrownWhenTheJobNamePassedInIsNull()
    {
        _jobName = null!;

        var act = CreateSut;

        act.Should().Throw<ArgumentNullException>();
    }

    [Fact]
    public void AnArgumentExceptionShouldBeThrownWhenTheJobNamePassedInIsAnEmptyString()
    {
        _jobName = String.Empty;

        var act = CreateSut;

        act.Should().Throw<ArgumentException>();
    }
    
    [Fact]
    public void AnArgumentNullExceptionShouldBeThrownWhenTheJobGroupPassedInIsNull()
    {
        _jobGroup = null!;

        var act = CreateSut;

        act.Should().Throw<ArgumentNullException>();
    }

    [Fact]
    public void AnArgumentExceptionShouldBeThrownWhenTheJobGroupPassedInIsAnEmptyString()
    {
        _jobGroup = String.Empty;

        var act = CreateSut;

        act.Should().Throw<ArgumentException>();
    }

    [Fact]
    public void AnArgumentNullExceptionShouldBeThrownWhenTheJobClassNamePassedInIsNull()
    {
        _jobClassName = null!;

        var act = CreateSut;

        act.Should().Throw<ArgumentNullException>();
    }

    [Fact]
    public void AnArgumentExceptionShouldBeThrownWhenTheJobClassNamePassedInIsAnEmptyString()
    {
        _jobClassName = String.Empty;

        var act = CreateSut;

        act.Should().Throw<ArgumentException>();
    }

    [Fact]
    public void AJobDetailInstanceShouldBeInstantiatedWhenAllParametersAreValid()
    {
        var result = CreateSut();

        result.Should().NotBeNull();
    }
    #endregion
}