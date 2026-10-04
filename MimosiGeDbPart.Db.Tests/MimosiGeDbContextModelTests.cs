using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using MimosiGeCore.Domain.Models;
using Xunit;

namespace MimosiGeDbPart.Db.Tests;

//მოდელი მოწმდება Access-ის მიგრაციის SCHEMA_MAPPING.md-ის წესებით.
//მოდელი იგება UseSqlServer-ით ფიქტიური connection string-ით, ბაზასთან კავშირი არ მყარდება.
//კომენტარები და სიგრძეები მხოლოდ design-time მოდელშია, ამიტომ IDesignTimeModel გამოიყენება
public sealed class MimosiGeDbContextModelTests
{
    private const string FakeConnectionString =
        "Server=(local);Database=MimosiGeModelTests;Integrated Security=true;TrustServerCertificate=true";

    //SCHEMA_MAPPING.md §2.3
    private static readonly string[] MimosiTableNames =
    [
        "AcademicYears", "BankAccounts", "Courses", "CrmAnswerTypes", "CrmCalls", "CrmCallTypes", "ErrorLogTexts",
        "GeoMonths", "GroupDayTimePlaces", "Groups", "GroupsByStudents", "GroupsByTeachers", "GroupSizes", "Humans",
        "Lessons", "LessonsByStudents", "LessonsCheckCreateErrorLogs", "LessonStartTimes", "LessonStatuses",
        "OperationMonths", "Payments", "Rooms", "RsCountries", "RsQuoteTypes", "SalaryHeaders", "SalaryLines",
        "SalaryLinesDetails", "SalaryParts", "SalaryPartTypes",
        "StudentContractDetails", "StudentContracts", "StudentStatuses", "TeacherContracts", "TeacherSalarySchemes",
        "WeekDays", "WorkHourGroups", "WorkHours"
    ];

    private static readonly string[] CarcassTableNames =
    [
        "AppClaims", "CrudRightTypes", "DataTypes", "ManyToManyJoins", "Menu", "MenuGroups", "Roles", "Users"
    ];

    //განზრახ nvarchar(max) სვეტები (SCHEMA_MAPPING.md §1.1)
    private static readonly string[] IntentionalMaxColumnNames = ["CrmCalls.CallConversation"];

    private static IModel CreateDesignTimeModel()
    {
        //EF აგებულ მოდელს პროცესის დონეზე ინახავს. ქეშის გარეშე ყოველი ტესტი მოდელს თავიდან აგებს,
        //ამიტომ OnModelCreating და ConfigureConventions ყოველ ტესტში სრულდება
        DbContextOptions<MimosiGeDbContext> options = new DbContextOptionsBuilder<MimosiGeDbContext>()
            .UseSqlServer(FakeConnectionString).EnableServiceProviderCaching(false).Options;
        using var context = new MimosiGeDbContext(options, true);
        return context.GetService<IDesignTimeModel>().Model;
    }

    private static List<IEntityType> GetMimosiEntityTypes(IModel model)
    {
        return [.. model.GetEntityTypes().Where(e => e.ClrType.Namespace == typeof(AcademicYear).Namespace)];
    }

    private static List<(string Name, IProperty Property)> GetMimosiColumns(IModel model)
    {
        return
        [
            .. GetMimosiEntityTypes(model).SelectMany(e =>
                e.GetProperties().Select(p => ($"{e.GetTableName()}.{p.GetColumnName()}", p)))
        ];
    }

    [Fact]
    public void Tables_Always_MatchSchemaMappingList()
    {
        // Arrange
        IModel model = CreateDesignTimeModel();
        string[] expected = [.. MimosiTableNames.Concat(CarcassTableNames).Order(StringComparer.Ordinal)];

        // Act
        string[] actual =
        [
            .. model.GetEntityTypes().Select(e => e.GetTableName()).OfType<string>().Distinct()
                .Order(StringComparer.Ordinal)
        ];

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void MimosiEntities_Always_MapToMimosiTables()
    {
        // Arrange
        IModel model = CreateDesignTimeModel();

        // Act
        string[] actual =
        [
            .. GetMimosiEntityTypes(model).Select(e => e.GetTableName() ?? e.DisplayName())
                .Order(StringComparer.Ordinal)
        ];

        // Assert
        Assert.Equal([.. MimosiTableNames.Order(StringComparer.Ordinal)], actual);
    }

    [Fact]
    public void MimosiEntities_Always_HaveNoShadowProperties()
    {
        // Arrange
        IModel model = CreateDesignTimeModel();

        // Act
        string[] shadowProperties =
        [
            .. GetMimosiEntityTypes(model).SelectMany(e => e.GetProperties()).Where(p => p.IsShadowProperty())
                .Select(p => $"{p.DeclaringType.DisplayName()}.{p.Name}")
        ];

        // Assert
        Assert.Empty(shadowProperties);
    }

    [Fact]
    public void MimosiStringColumns_Always_HaveMaxLengthOrAreIntentionallyMax()
    {
        // Arrange
        IModel model = CreateDesignTimeModel();

        // Act
        string[] columnsWithoutMaxLength =
        [
            .. GetMimosiColumns(model)
                .Where(c => c.Property.ClrType == typeof(string) && c.Property.GetMaxLength() is null)
                .Select(c => c.Name).Except(IntentionalMaxColumnNames)
        ];

        // Assert
        Assert.Empty(columnsWithoutMaxLength);
    }

    [Fact]
    public void IntentionalMaxColumns_Always_AreStringsWithoutMaxLength()
    {
        // Arrange
        IModel model = CreateDesignTimeModel();

        // Act
        string[] actual =
        [
            .. GetMimosiColumns(model)
                .Where(c => c.Property.ClrType == typeof(string) && c.Property.GetMaxLength() is null)
                .Select(c => c.Name).Intersect(IntentionalMaxColumnNames).Order(StringComparer.Ordinal)
        ];

        // Assert
        Assert.Equal([.. IntentionalMaxColumnNames.Order(StringComparer.Ordinal)], actual);
    }

    [Fact]
    public void MimosiTables_Always_HaveComment()
    {
        // Arrange
        IModel model = CreateDesignTimeModel();

        // Act
        string[] tablesWithoutComment =
        [
            .. GetMimosiEntityTypes(model).Where(e => string.IsNullOrWhiteSpace(e.GetComment()))
                .Select(e => e.GetTableName() ?? e.DisplayName())
        ];

        // Assert
        Assert.Empty(tablesWithoutComment);
    }

    [Fact]
    public void MimosiColumns_Always_HaveComment()
    {
        // Arrange
        IModel model = CreateDesignTimeModel();

        // Act
        string[] columnsWithoutComment =
        [
            .. GetMimosiColumns(model).Where(c => string.IsNullOrWhiteSpace(c.Property.GetComment()))
                .Select(c => c.Name)
        ];

        // Assert
        Assert.Empty(columnsWithoutComment);
    }

    [Fact]
    public void MimosiDateTimeColumns_Always_MapToDatetime()
    {
        // Arrange
        IModel model = CreateDesignTimeModel();

        // Act
        string[] columnsWithOtherType =
        [
            .. GetMimosiColumns(model)
                .Where(c => (Nullable.GetUnderlyingType(c.Property.ClrType) ?? c.Property.ClrType) == typeof(DateTime))
                .Where(c => c.Property.GetColumnType() != "datetime").Select(c => c.Name)
        ];

        // Assert
        Assert.Empty(columnsWithOtherType);
    }

    [Fact]
    public void MimosiDecimalColumns_Always_MapToMoney()
    {
        // Arrange
        IModel model = CreateDesignTimeModel();

        // Act
        string[] columnsWithOtherType =
        [
            .. GetMimosiColumns(model)
                .Where(c => (Nullable.GetUnderlyingType(c.Property.ClrType) ?? c.Property.ClrType) == typeof(decimal))
                .Where(c => c.Property.GetColumnType() != "money").Select(c => c.Name)
        ];

        // Assert
        Assert.Empty(columnsWithOtherType);
    }
}
