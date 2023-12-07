using FluentAssertions;
using FluentAssertions.Execution;
using Microsoft.EntityFrameworkCore;
using QuartzNet.EntityFrameworkCore.Entities;
using QuartzNet.EntityFrameworkCore.Entities.Configuration;

namespace QuartzNet.EntityFrameworkCore.Tests.Unit.Entities.Configuration;

public class SchedulerStateEntityConfigurationTests : EntityTypeConfigurationTestsBase<SchedulerStateEntityConfiguration, SchedulerState>
{
    [Fact]
public void Configure_ConfiguresTheSchedulerStateEntityAsExpected()
{
    var sut = CreateSut();
    var entityBuilder = GetEntityBuilder();

    sut.Configure(entityBuilder);
    var metadata = entityBuilder.Metadata;

    using var scope = new AssertionScope();
    metadata.GetSchema().Should().Be("Quartz");
    metadata.GetTableName().Should().Be("SchedulerState");
    var schedulerNameProperty = metadata.FindDeclaredProperty("SchedulerName");
    ValidateModelProperty(schedulerNameProperty, x =>
    {
        x?.IsNullable.Should().BeFalse();
        x?.GetMaxLength().Should().Be(120);
        x?.GetContainingKeys().Should().HaveCount(1);
    });

    var instanceNameProperty = metadata.FindDeclaredProperty("InstanceName");
    ValidateModelProperty(instanceNameProperty, x =>
    {
        x?.IsNullable.Should().BeFalse();
        x?.GetMaxLength().Should().Be(200);
        x?.GetContainingKeys().Should().HaveCount(1);
    });
    
        var lastCheckinTimeProperty = metadata.FindDeclaredProperty("LastCheckinTime");
        ValidateModelProperty(lastCheckinTimeProperty, x =>
        {
            x?.IsNullable.Should().BeFalse();
            x?.GetContainingKeys().Should().BeEmpty();
        });

        var checkinIntervalProperty = metadata.FindDeclaredProperty("CheckinInterval");
        ValidateModelProperty(checkinIntervalProperty, x =>
        {
            x?.IsNullable.Should().BeFalse();
            x?.GetContainingKeys().Should().BeEmpty();
        });
    }
}