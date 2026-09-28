using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Moq;
using SystemTools.SharedKernel;
using Xunit;

namespace MimosiGeDbPart.Db.Tests;

//MimosiGeDbContext ბაზისური კლასისთვის options-ს თავიდან აგებს. პარამეტრების მნიშვნელობების ლოგირება
//(EnableSensitiveDataLogging) შემოსული options-იდან უნდა გადავიდეს და თვითონ არ უნდა ჩაირთოს
public sealed class MimosiGeDbContextOptionsTests
{
    private const string FakeConnectionString =
        "Server=(local);Database=MimosiGeModelTests;Integrated Security=true;TrustServerCertificate=true";

    private static DbContextOptions<MimosiGeDbContext> CreateOptions(bool sensitiveDataLoggingEnabled)
    {
        return new DbContextOptionsBuilder<MimosiGeDbContext>().UseSqlServer(FakeConnectionString)
            .EnableSensitiveDataLogging(sensitiveDataLoggingEnabled).Options;
    }

    private static bool IsSensitiveDataLoggingEnabled(DbContext context)
    {
        return context.GetService<IDbContextOptions>().FindExtension<CoreOptionsExtension>()
            ?.IsSensitiveDataLoggingEnabled ?? false;
    }

    private static RelationalOptionsExtension GetRelationalOptions(DbContext context)
    {
        return RelationalOptionsExtension.Extract(context.GetService<IDbContextOptions>());
    }

    private static bool IsSensitiveDataLoggingEnabledInContext(bool enabledInIncomingOptions)
    {
        using var context =
            new MimosiGeDbContext(CreateOptions(enabledInIncomingOptions), Mock.Of<IDomainEventsDispatcher>());
        return IsSensitiveDataLoggingEnabled(context);
    }

    [Fact]
    public void Constructor_WithSensitiveDataLoggingEnabled_KeepsItEnabled()
    {
        // Act
        bool enabled = IsSensitiveDataLoggingEnabledInContext(true);

        // Assert
        Assert.True(enabled);
    }

    [Fact]
    public void Constructor_WithSensitiveDataLoggingDisabled_KeepsItDisabled()
    {
        // Act
        bool enabled = IsSensitiveDataLoggingEnabledInContext(false);

        // Assert
        Assert.False(enabled);
    }

    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    public void Constructor_WithIntParameter_KeepsSensitiveDataLoggingFlag(bool enabledInIncomingOptions)
    {
        // Arrange
        DbContextOptions<MimosiGeDbContext> options = CreateOptions(enabledInIncomingOptions);

        // Act
        using var context = new MimosiGeDbContext(options, 0);

        // Assert
        Assert.Equal(enabledInIncomingOptions, IsSensitiveDataLoggingEnabled(context));
    }

    [Fact]
    public void Constructor_WithDomainEventsDispatcher_KeepsConnectionString()
    {
        // Arrange
        DbContextOptions<MimosiGeDbContext> options = CreateOptions(false);

        // Act
        using var context = new MimosiGeDbContext(options, Mock.Of<IDomainEventsDispatcher>());

        // Assert
        Assert.Equal(FakeConnectionString, GetRelationalOptions(context).ConnectionString);
    }

    [Fact]
    public void Constructor_WithIntParameter_KeepsConnectionString()
    {
        // Arrange
        DbContextOptions<MimosiGeDbContext> options = CreateOptions(false);

        // Act
        using var context = new MimosiGeDbContext(options, 0);

        // Assert
        Assert.Equal(FakeConnectionString, GetRelationalOptions(context).ConnectionString);
    }

    [Fact]
    public void Constructor_WithoutCoreOptions_DisablesSensitiveDataLogging()
    {
        // Arrange
        DbContextOptions<MimosiGeDbContext> options = new DbContextOptions<MimosiGeDbContext>(CreateOptions(true)
            .Extensions.Where(e => e is not CoreOptionsExtension).ToDictionary(e => e.GetType()));

        // Act
        using var context = new MimosiGeDbContext(options, 0);

        // Assert
        Assert.False(IsSensitiveDataLoggingEnabled(context));
    }

    [Fact]
    public void Constructor_WithoutSqlServerProvider_ThrowsException()
    {
        // Arrange
        DbContextOptions<MimosiGeDbContext> options = new DbContextOptionsBuilder<MimosiGeDbContext>().Options;

        // Act
        Exception exception = Assert.Throws<Exception>(() => new MimosiGeDbContext(options, 0));

        // Assert
        Assert.Equal("Failed to retrieve SQL connection string for base Context", exception.Message);
    }

    [Fact]
    public void Constructor_WithSqlServerWithoutConnectionString_ThrowsException()
    {
        // Arrange
        DbContextOptions<MimosiGeDbContext> options =
            new DbContextOptionsBuilder<MimosiGeDbContext>().UseSqlServer().Options;

        // Act
        Exception exception = Assert.Throws<Exception>(() => new MimosiGeDbContext(options, 0));

        // Assert
        Assert.Equal("Connection string for base Context dos not specified", exception.Message);
    }

    [Fact]
    public void Constructor_ForDesignTime_KeepsIncomingOptions()
    {
        // Arrange
        DbContextOptions<MimosiGeDbContext> options = new DbContextOptionsBuilder<MimosiGeDbContext>()
            .UseSqlServer(FakeConnectionString, b => b.MigrationsAssembly("MimosiGeDbTools.DbMigration")).Options;

        // Act
        using var context = new MimosiGeDbContext(options, true);

        // Assert
        Assert.Equal("MimosiGeDbTools.DbMigration", GetRelationalOptions(context).MigrationsAssembly);
    }
}
