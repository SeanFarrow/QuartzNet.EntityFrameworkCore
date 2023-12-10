using QuartzNet.EntityFrameworkCore.Entities;
using QuartzNet.EntityFrameworkCore.Entities.Configuration;
using FluentAssertions;
using FluentAssertions.Execution;
using Microsoft.EntityFrameworkCore;

namespace QuartzNet.EntityFrameworkCore.Tests.Unit.Entities.Configuration;

public class JobDetailEntityConfigurationTests : EntityTypeConfigurationTestsBase<JobDetailEntityConfiguration, JobDetail>
{
    [Fact]
    public void Configure_ConfiguresTheJobDetailEntityAsExpected()
    {
        var sut = CreateSut();
        var entityBuilder = GetEntityBuilder();

        sut.Configure(entityBuilder);
        var metadata = entityBuilder.Metadata;

        using var scope = new AssertionScope();
        metadata.GetSchema().Should().Be("Quartz");
        metadata.GetTableName().Should().Be("JobDetails");
        var schedulerNameProperty = metadata.FindDeclaredProperty("SchedulerName");
        ValidateModelProperty(schedulerNameProperty, x =>
        {
            x?.IsNullable.Should().BeFalse();
            x?.GetMaxLength().Should().Be(120);
            x?.GetContainingKeys().Should().HaveCount(1);
        });

        var jobNameProperty = metadata.FindDeclaredProperty("JobName");
        ValidateModelProperty(jobNameProperty, x =>
        {
            x?.IsNullable.Should().BeFalse();
            x?.GetMaxLength().Should().Be(150);
            x?.GetContainingKeys().Should().HaveCount(1);
        });

        var jobGroupProperty = metadata.FindDeclaredProperty("JobGroup");
        ValidateModelProperty(jobGroupProperty, x =>
        {
            x?.IsNullable.Should().BeFalse();
            x?.GetMaxLength().Should().Be(150);
            x?.GetContainingKeys().Should().HaveCount(1);
        });

        var descriptionProperty = metadata.FindDeclaredProperty("Description");
        ValidateModelProperty(descriptionProperty, x =>
        {
            x?.IsNullable.Should().BeTrue();
            x?.GetMaxLength().Should().Be(250);
            x?.GetContainingKeys().Should().BeEmpty();
        });

        var jobClassNameProperty = metadata.FindDeclaredProperty("JobClassName");
        ValidateModelProperty(jobClassNameProperty, x =>
        {
            x?.IsNullable.Should().BeFalse();
            x?.GetMaxLength().Should().Be(250);
            x?.GetContainingKeys().Should().BeEmpty();
        });

        var isDurableProperty = metadata.FindDeclaredProperty("IsDurable");
        ValidateModelProperty(isDurableProperty, x =>
        {
            x?.IsNullable.Should().BeFalse();
            x?.GetContainingKeys().Should().BeEmpty();
        });

        var isNonConcurrentProperty = metadata.FindDeclaredProperty("IsNonConcurrent");
        ValidateModelProperty(isNonConcurrentProperty, x =>
        {
            x?.IsNullable.Should().BeFalse();
            x?.GetContainingKeys().Should().BeEmpty();
        });

        var isUpdateDataProperty = metadata.FindDeclaredProperty("IsUpdateData");
        ValidateModelProperty(isUpdateDataProperty, x =>
        {
            x?.IsNullable.Should().BeFalse();
            x?.GetContainingKeys().Should().BeEmpty();
        });

        var requestsRecoveryProperty = metadata.FindDeclaredProperty("RequestsRecovery");
        ValidateModelProperty(requestsRecoveryProperty, x =>
        {
            x?.IsNullable.Should().BeFalse();
            x?.GetContainingKeys().Should().BeEmpty();
        });

        var jobDataProperty = metadata.FindDeclaredProperty("JobData");
        ValidateModelProperty(jobDataProperty, x =>
        {
            x?.IsNullable.Should().BeTrue();
            x?.GetContainingKeys().Should().BeEmpty();
        });
    }
}