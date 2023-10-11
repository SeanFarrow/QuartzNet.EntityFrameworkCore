using System.Diagnostics.CodeAnalysis;
using FluentAssertions;
using FluentAssertions.Execution;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace QuartzNet.EntityFrameworkCore.Tests.Unit.Entities.Configurations;

public abstract class EntityTypeConfigurationTestsBase<T, U> where T : class, new()
where U: class
{
    protected T CreateSut() => new T();

    protected EntityTypeBuilder<U> GetEntityBuilder() 
    {
#pragma warning disable EF1001 // Internal EF Core API usage.
        var entityType = new EntityType(typeof(U).Name, typeof(U), new Model(), false, ConfigurationSource.Convention);

        var builder = new EntityTypeBuilder<U>(entityType);
        return builder;
#pragma warning restore EF1001 // Internal EF Core API usage.
    }

    protected void ValidateModelProperty(IMutableProperty?  propertyToValidate, Action<IMutableProperty?> propertyValidator)
    {
        propertyToValidate.Should().NotBeNull();
        propertyValidator(propertyToValidate);
    }
}