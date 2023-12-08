using FluentAssertions.Execution;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using QuartzNet.EntityFrameworkCore.Entities;
using QuartzNet.EntityFrameworkCore.Entities.Configuration;

namespace QuartzNet.EntityFrameworkCore.Tests.Unit.Entities.Configuration;

public class FiredTriggerEntityConfigurationTests : EntityTypeConfigurationTestsBase<FiredTriggerEntityConfiguration, FiredTrigger>
{
    [Fact]
    public void Configure_ConfiguresTheFiredTriggerEntityAsExpected()
    {
        var sut = CreateSut();
        var entityBuilder = GetEntityBuilder();

        sut.Configure(entityBuilder);
        var metadata = entityBuilder.Metadata;

        using var scope = new AssertionScope();
        metadata.GetSchema().Should().Be("Quartz");
        metadata.GetTableName().Should().Be("FiredTriggers");
        var schedulerNameProperty = metadata.FindDeclaredProperty("SchedulerName");
        ValidateModelProperty(schedulerNameProperty, x =>
        {
            x?.IsNullable.Should().BeFalse();
            x?.GetMaxLength().Should().Be(120);
            x?.GetContainingKeys().Should().HaveCount(1);
        });

        var entryIDProperty = metadata.FindDeclaredProperty("EntryID");
        ValidateModelProperty(entryIDProperty, x =>
        {
            x?.IsNullable.Should().BeFalse();
            x?.GetMaxLength().Should().Be(140);
            x?.GetContainingKeys().Should().HaveCount(1);
        });

        var triggerNameProperty = metadata.FindDeclaredProperty("TriggerName");
        ValidateModelProperty(triggerNameProperty, x =>
        {
            x?.IsNullable.Should().BeFalse();
            x?.GetMaxLength().Should().Be(150);
            x?.GetContainingKeys().Should().BeEmpty();
        });

        var triggerGroupProperty = metadata.FindDeclaredProperty("TriggerGroup");
        ValidateModelProperty(triggerGroupProperty, x =>
        {
            x?.IsNullable.Should().BeFalse();
            x?.GetMaxLength().Should().Be(150);
            x?.GetContainingKeys().Should().BeEmpty();
        });
        
        var instanceNameProperty = metadata.FindDeclaredProperty("InstanceName");
        ValidateModelProperty(instanceNameProperty, x =>
        {
            x?.IsNullable.Should().BeFalse();
            x?.GetMaxLength().Should().Be(200);
            x?.GetContainingKeys().Should().BeEmpty();
        });

        var firedTimeProperty = metadata.FindDeclaredProperty("FiredTime");
        ValidateModelProperty(firedTimeProperty, x =>
        {
            x?.IsNullable.Should().BeFalse();
            x?.GetContainingKeys().Should().BeEmpty();
        });

        var scheduledTimeProperty = metadata.FindDeclaredProperty("ScheduledTime");
        ValidateModelProperty(scheduledTimeProperty, x =>
        {
            x?.IsNullable.Should().BeFalse();
            x?.GetContainingKeys().Should().BeEmpty();
        });

        var priorityProperty = metadata.FindDeclaredProperty("Priority");
        ValidateModelProperty(priorityProperty, x =>
        {
            x?.IsNullable.Should().BeFalse();
            x?.GetContainingKeys().Should().BeEmpty();
        });

        var stateProperty = metadata.FindDeclaredProperty("State");
        ValidateModelProperty(stateProperty, x =>
        {
            x?.IsNullable.Should().BeFalse();
            x?.GetContainingKeys().Should().BeEmpty();
        });

        var jobNameProperty = metadata.FindDeclaredProperty("JobName");
        ValidateModelProperty(jobNameProperty, x =>
        {
            x?.IsNullable.Should().BeTrue();
            x?.GetMaxLength().Should().Be(150);
            x?.GetContainingKeys().Should().BeEmpty();
        });
        
        var jobGroupProperty = metadata.FindDeclaredProperty("JobName");
        ValidateModelProperty(jobGroupProperty, x =>
        {
            x?.IsNullable.Should().BeTrue();
            x?.GetMaxLength().Should().Be(150);
            x?.GetContainingKeys().Should().BeEmpty();
        });

        var isNonConcurrentProperty = metadata.FindDeclaredProperty("IsNonConcurrent");
        ValidateModelProperty(isNonConcurrentProperty, x =>
        {
            x?.IsNullable.Should().BeTrue();
            x?.GetContainingKeys().Should().BeEmpty();
        });
        
        var requestsRecoveryProperty = metadata.FindDeclaredProperty("IsNonConcurrent");
        ValidateModelProperty(requestsRecoveryProperty, x =>
        {
            x?.IsNullable.Should().BeTrue();
            x?.GetContainingKeys().Should().BeEmpty();
        });
    }
}