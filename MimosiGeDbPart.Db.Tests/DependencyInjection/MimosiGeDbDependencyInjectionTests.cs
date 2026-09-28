using System;
using System.IO;
using BackendCarcass.Application;
using BackendCarcass.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MimosiGeDbPart.Db.DependencyInjection;
using Moq;
using Serilog;
using SystemTools.Domain.Abstractions;
using SystemTools.SharedKernel;
using SystemTools.SystemToolsShared;
using Xunit;

namespace MimosiGeDbPart.Db.Tests.DependencyInjection;

public sealed class MimosiGeDbDependencyInjectionTests
{
    private const string ConnectionStringKey = "Data:MimosiGeDatabase:ConnectionString";

    private const string FakeConnectionString =
        "Server=(local);Database=MimosiGeModelTests;Integrated Security=true;TrustServerCertificate=true";

    private static IConfiguration CreateConfiguration(string? connectionString)
    {
        var configuration = new Mock<IConfiguration>();
        configuration.Setup(c => c[ConnectionStringKey]).Returns(connectionString);
        return configuration.Object;
    }

    private static ServiceCollection RegisterMimosiGeDb(ILogger? debugLogger, string? connectionString)
    {
        var services = new ServiceCollection();
        services.AddMimosiGeDb(debugLogger, CreateConfiguration(connectionString));
        return services;
    }

    private static T ResolveInScope<T>(ILogger? debugLogger) where T : notnull
    {
        using ServiceProvider provider = RegisterMimosiGeDb(debugLogger, FakeConnectionString).BuildServiceProvider();
        using IServiceScope scope = provider.CreateScope();
        return scope.ServiceProvider.GetRequiredService<T>();
    }

    [Fact]
    public void AddMimosiGeDb_WithConnectionString_ReturnsSameServiceCollection()
    {
        // Arrange
        var services = new ServiceCollection();

        // Act
        IServiceCollection result = services.AddMimosiGeDb(null, CreateConfiguration(FakeConnectionString));

        // Assert
        Assert.Same(services, result);
    }

    [Fact]
    public void AddMimosiGeDb_WithConnectionString_RegistersMimosiGeDbContextAsCarcassApplicationDbContext()
    {
        // Arrange
        using ServiceProvider provider = RegisterMimosiGeDb(null, FakeConnectionString).BuildServiceProvider();
        using IServiceScope scope = provider.CreateScope();

        // Act
        ICarcassApplicationDbContext applicationDbContext =
            scope.ServiceProvider.GetRequiredService<ICarcassApplicationDbContext>();

        // Assert
        Assert.Same(scope.ServiceProvider.GetRequiredService<MimosiGeDbContext>(), applicationDbContext);
    }

    [Fact]
    public void AddMimosiGeDb_WithConnectionString_RegistersMimosiGeUnitOfWork()
    {
        // Act
        IUnitOfWork unitOfWork = ResolveInScope<IUnitOfWork>(null);

        // Assert
        Assert.IsType<MimosiGeUnitOfWork>(unitOfWork);
    }

    [Fact]
    public void AddMimosiGeDb_WithConnectionString_RegistersMimosiGeDatabaseAbstractionRepository()
    {
        // Act
        IDatabaseAbstraction databaseAbstraction = ResolveInScope<IDatabaseAbstraction>(null);

        // Assert
        Assert.IsType<MimosiGeDatabaseAbstractionRepository>(databaseAbstraction);
    }

    [Fact]
    public void AddMimosiGeDb_WithConnectionString_RegistersDomainEventsDispatcher()
    {
        // Act
        IDomainEventsDispatcher dispatcher = ResolveInScope<IDomainEventsDispatcher>(null);

        // Assert
        Assert.IsType<DomainEventsDispatcher>(dispatcher);
    }

    [Fact]
    public void AddMimosiGeDb_WithConnectionString_ConfiguresCarcassDbContextConnectionString()
    {
        // Act
        DbContextOptions<CarcassDbContext> options = ResolveInScope<DbContextOptions<CarcassDbContext>>(null);

        // Assert
        Assert.Equal(FakeConnectionString, RelationalOptionsExtension.Extract(options).ConnectionString);
    }

    [Fact]
    public void AddMimosiGeDb_WithConnectionString_ConfiguresMimosiGeDbContextConnectionString()
    {
        // Act
        DbContextOptions<MimosiGeDbContext> options = ResolveInScope<DbContextOptions<MimosiGeDbContext>>(null);

        // Assert
        Assert.Equal(FakeConnectionString, RelationalOptionsExtension.Extract(options).ConnectionString);
    }

    [Fact]
    public void AddMimosiGeDb_WithDebugLogger_EnablesSensitiveDataLogging()
    {
        // Act
        DbContextOptions<MimosiGeDbContext> options =
            ResolveInScope<DbContextOptions<MimosiGeDbContext>>(Mock.Of<ILogger>());

        // Assert
        Assert.True(options.FindExtension<CoreOptionsExtension>()?.IsSensitiveDataLoggingEnabled);
    }

    [Fact]
    public void AddMimosiGeDb_WithoutDebugLogger_DisablesSensitiveDataLogging()
    {
        // Act
        DbContextOptions<MimosiGeDbContext> options = ResolveInScope<DbContextOptions<MimosiGeDbContext>>(null);

        // Assert
        Assert.False(options.FindExtension<CoreOptionsExtension>()?.IsSensitiveDataLoggingEnabled);
    }

    [Fact]
    public void AddMimosiGeDb_WithDebugLogger_LogsStartAndFinish()
    {
        // Arrange
        var debugLogger = new Mock<ILogger>();

        // Act
        RegisterMimosiGeDb(debugLogger.Object, FakeConnectionString);

        // Assert
        debugLogger.Verify(l => l.Information("{MethodName} Started", "AddMimosiGeDb"), Times.Once);
        debugLogger.Verify(l => l.Information("{MethodName} Finished", "AddMimosiGeDb"), Times.Once);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("   ")]
    public void AddMimosiGeDb_WithoutConnectionStringAndWithDebugLogger_RegistersNothing(string? connectionString)
    {
        // Act
        ServiceCollection services = RegisterMimosiGeDb(Mock.Of<ILogger>(), connectionString);

        // Assert
        Assert.Empty(services);
    }

    [Fact]
    public void AddMimosiGeDb_WithoutConnectionStringAndWithDebugLogger_DoesNotLogFinish()
    {
        // Arrange
        var debugLogger = new Mock<ILogger>();

        // Act
        RegisterMimosiGeDb(debugLogger.Object, null);

        // Assert
        debugLogger.Verify(l => l.Information("{MethodName} Finished", "AddMimosiGeDb"), Times.Never);
    }

    [Fact]
    public void AddMimosiGeDb_WithoutConnectionStringAndWithDebugLogger_WritesMissingKeyToConsole()
    {
        // Arrange
        TextWriter originalOut = Console.Out;
        using var output = new StringWriter();
        Console.SetOut(output);

        // Act
        try
        {
            RegisterMimosiGeDb(Mock.Of<ILogger>(), null);
        }
        finally
        {
            Console.SetOut(originalOut);
        }

        // Assert
        Assert.Contains($"{ConnectionStringKey} is empty", output.ToString());
    }

    [Fact]
    public void AddMimosiGeDb_WithoutConnectionStringAndWithoutDebugLogger_StillRegistersMimosiGeDbContext()
    {
        // Act
        ServiceCollection services = RegisterMimosiGeDb(null, null);

        // Assert
        Assert.Contains(services, d => d.ServiceType == typeof(MimosiGeDbContext));
    }
}
