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

    private static bool IsSensitiveDataLoggingEnabledInContext(bool enabledInIncomingOptions)
    {
        DbContextOptions<MimosiGeDbContext> options = new DbContextOptionsBuilder<MimosiGeDbContext>()
            .UseSqlServer(FakeConnectionString).EnableSensitiveDataLogging(enabledInIncomingOptions).Options;
        using var context = new MimosiGeDbContext(options, Mock.Of<IDomainEventsDispatcher>());
        return context.GetService<IDbContextOptions>().FindExtension<CoreOptionsExtension>()
            ?.IsSensitiveDataLoggingEnabled ?? false;
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
}
