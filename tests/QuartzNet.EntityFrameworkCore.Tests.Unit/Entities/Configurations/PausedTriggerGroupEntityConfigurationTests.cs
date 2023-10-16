using FluentAssertions;
using FluentAssertions.Execution;
using Microsoft.EntityFrameworkCore;
using QuartzNet.EntityFrameworkCore.Entities;
using QuartzNet.EntityFrameworkCore.Entities.Configurations;

namespace QuartzNet.EntityFrameworkCore.Tests.Unit.Entities.Configurations;

public class PausedTriggerGroupEntityConfigurationTests : EntityTypeConfigurationTestsBase<PausedTriggerGroupEntityConfiguration, PausedTriggerGroup>
{
    [Fact]
    public void Configure_ConfiguresThePausedTriggerGroupEntityAsExpected()
    {
        var sut = CreateSut();
        var entityBuilder = GetEntityBuilder();

        sut.Configure(entityBuilder);
        var metadata = entityBuilder.Metadata;

        using var scope = new AssertionScope();
        metadata.GetSchema().Should().Be("Quartz");
        metadata.GetTableName().Should().Be("PausedTriggerGroups");
        var schedulerNameProperty = metadata.FindDeclaredProperty("SchedulerName");
        ValidateModelProperty(schedulerNameProperty, x =>
        {
            x?.IsNullable.Should().BeFalse();
            x?.GetMaxLength().Should().Be(120);
            x?.GetContainingKeys().Should().HaveCount(1);
        });

        var triggerGroupProperty = metadata.FindDeclaredProperty("TriggerGroup");
        ValidateModelProperty(triggerGroupProperty, x =>
        {
            x?.IsNullable.Should().BeFalse();
            x?.GetMaxLength().Should().Be(150);
            x?.GetContainingKeys().Should().HaveCount(1);
        });
    }
}