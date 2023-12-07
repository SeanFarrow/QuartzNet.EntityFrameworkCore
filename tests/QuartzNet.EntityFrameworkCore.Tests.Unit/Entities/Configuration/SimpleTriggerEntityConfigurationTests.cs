using FluentAssertions.Execution;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using QuartzNet.EntityFrameworkCore.Entities;
using QuartzNet.EntityFrameworkCore.Entities.Configuration;

namespace QuartzNet.EntityFrameworkCore.Tests.Unit.Entities.Configuration;

public class SimpleTriggerEntityConfigurationTests : EntityTypeConfigurationTestsBase<SimpleTriggerEntityConfiguration, SimpleTrigger>
{
    [Fact]
    public void Configure_ConfiguresTheSimpleTriggerEntityAsExpected()
    {
        var sut = CreateSut();
        var entityBuilder = GetEntityBuilder();

        sut.Configure(entityBuilder);
        var metadata = entityBuilder.Metadata;

        using var scope = new AssertionScope();
        metadata.GetSchema().Should().Be("Quartz");
        metadata.GetTableName().Should().Be("SimpleTriggers");
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

        var triggerGroupNameProperty = metadata.FindDeclaredProperty("TriggerGroup");
        ValidateModelProperty(triggerGroupNameProperty, x =>
        {
            x?.IsNullable.Should().BeFalse();
            x?.GetMaxLength().Should().Be(150);
            x?.GetContainingKeys().Should().HaveCount(1);
        });

        var RepeatCountProperty = metadata.FindDeclaredProperty("RepeatCount");
        ValidateModelProperty(RepeatCountProperty, x =>
        {
            x?.IsNullable.Should().BeFalse();
            x?.GetContainingKeys().Should().BeEmpty();
        });

        var RepeatIntervalProperty = metadata.FindDeclaredProperty("RepeatCount");
        ValidateModelProperty(RepeatIntervalProperty, x =>
        {
            x?.IsNullable.Should().BeFalse();
            x?.GetContainingKeys().Should().BeEmpty();
        });

        var TimesTriggeredProperty = metadata.FindDeclaredProperty("RepeatCount");
        ValidateModelProperty(TimesTriggeredProperty, x =>
        {
            x?.IsNullable.Should().BeFalse();
            x?.GetContainingKeys().Should().BeEmpty();
        });
    }
}