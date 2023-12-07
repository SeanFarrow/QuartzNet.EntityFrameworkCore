using FluentAssertions;
using FluentAssertions.Execution;
using Microsoft.EntityFrameworkCore;
using QuartzNet.EntityFrameworkCore.Entities;
using QuartzNet.EntityFrameworkCore.Entities.Configuration;

namespace QuartzNet.EntityFrameworkCore.Tests.Unit.Entities.Configuration;

public class CronTriggerEntityConfigurationTests : EntityTypeConfigurationTestsBase<CronTriggerEntityConfiguration, CronTrigger>
{
    [Fact]
    public void Configure_ConfiguresTheCronTriggerEntotyeAsExpected()
    {
        var sut = CreateSut();
        var entityBuilder = GetEntityBuilder();

        sut.Configure(entityBuilder);
        var metadata = entityBuilder.Metadata;

        using var scope = new AssertionScope();
        metadata.GetSchema().Should().Be("Quartz");
        metadata.GetTableName().Should().Be("CronTriggers");
        var schedulerNameProperty = metadata.FindDeclaredProperty("SchedulerName");
        ValidateModelProperty(schedulerNameProperty, x =>
        {
            x?.IsNullable.Should().BeFalse();
            x?.GetMaxLength().Should().Be(120);
            x?.GetContainingKeys().Should().HaveCount(1);
        });

        var triggerNameProperty = metadata.FindDeclaredProperty("TriggerName");
        ValidateModelProperty(triggerNameProperty, x =>
        {
            x?.IsNullable.Should().BeFalse();
            x?.GetMaxLength().Should().Be(150);
            x?.GetContainingKeys().Should().HaveCount(1);
        });

        var triggerGroupProperty = metadata.FindDeclaredProperty("TriggerGroup");
        ValidateModelProperty(triggerGroupProperty, x =>
        {
            x?.IsNullable.Should().BeFalse();
            x?.GetMaxLength().Should().Be(150);
            x?.GetContainingKeys().Should().HaveCount(1);
        });

        var CronExpressionProperty = metadata.FindDeclaredProperty("CronExpression");
        ValidateModelProperty(CronExpressionProperty, x =>
        {
            x?.IsNullable.Should().BeFalse();
            x?.GetMaxLength().Should().Be(120);
        });

        var timezoneIDProperty = metadata.FindDeclaredProperty("TimezoneId");
        ValidateModelProperty(timezoneIDProperty, x =>
        {
            x?.IsNullable.Should().BeFalse();
            x?.GetMaxLength().Should().Be(80);
        });
    }
}