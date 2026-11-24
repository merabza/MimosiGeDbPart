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

    //SCHEMA_MAPPING.md §2.3; BankTransactions და StudentPayers Access-ში არ იყო (TBC_INTEGRATION.md, D164, D169),
    //არც ბრძანებების ცხრილები GroupOrder* (GROUP_ORDERS.md §6)
    private static readonly string[] MimosiTableNames =
    [
        "AcademicYears", "BankAccounts", "BankTransactions", "Courses", "CrmAnswerTypes", "CrmCalls", "CrmCallTypes", "ErrorLogTexts",
        "GeoMonths", "GroupDayTimePlaces", "GroupOrderDayTimePlaces", "GroupOrderNumbers", "GroupOrders", "GroupOrdersMode",
        "GroupOrderStudents", "GroupOrderTeachers", "Groups", "GroupsByStudents", "GroupsByTeachers", "GroupSizes", "Humans",
        "Lessons", "LessonsByStudents", "LessonsCheckCreateErrorLogs", "LessonStartTimes", "LessonStatuses",
        "OperationMonths", "Payments", "Rooms", "RsCountries", "RsQuoteTypes", "SalaryHeaders", "SalaryLines",
        "SalaryLinesDetails", "SalaryParts", "SalaryPartTypes",
        "StudentContractDetails", "StudentContracts", "StudentPayers", "StudentStatuses", "TeacherContracts", "TeacherSalarySchemes",
        "WeekDays", "WorkHourGroups", "WorkHours"
    ];

    private static readonly string[] CarcassTableNames =
    [
        "AppClaims", "CrudRightTypes", "DataTypes", "EmailVerifications", "ManyToManyJoins", "Menu", "MenuGroups",
        "RefreshTokens", "Roles", "Users"
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

    //SQL Server-ის შეცდომა 1785 ("may cause cycles or multiple cascade paths"): კასკადური FK-ებით (CASCADE, SET NULL)
    //ერთი ცხრილიდან მეორემდე მხოლოდ ერთი გზა შეიძლება იყოს, წრე კი საერთოდ არ შეიძლება
    [Fact]
    public void CascadingForeignKeys_Always_HaveNoMultiplePathsOrCycles()
    {
        // Arrange
        IModel model = CreateDesignTimeModel();
        ILookup<string, string> cascades = model.GetEntityTypes().SelectMany(e => e.GetForeignKeys())
            .Where(fk => fk.DeleteBehavior is DeleteBehavior.Cascade or DeleteBehavior.SetNull).ToLookup(
                fk => fk.PrincipalEntityType.GetTableName() ?? fk.PrincipalEntityType.DisplayName(),
                fk => fk.DeclaringEntityType.GetTableName() ?? fk.DeclaringEntityType.DisplayName());

        // Act
        string[] tablesWithMultiplePaths =
            [.. cascades.Select(g => g.Key).Where(table => !HasSingleCascadePathToEveryTable(cascades, table))];

        // Assert
        Assert.Empty(tablesWithMultiplePaths);
    }

    //ბრძანების ხაზები ბრძანებასთან ერთად იშლება, ბრძანებისა და ხაზების დანარჩენი კავშირები კი Restrict-ია
    [Theory]
    [InlineData(typeof(GroupOrder))]
    [InlineData(typeof(GroupOrderTeacher))]
    [InlineData(typeof(GroupOrderStudent))]
    [InlineData(typeof(GroupOrderDayTimePlace))]
    public void GroupOrderForeignKeys_Always_CascadeOnlyFromLineToOrder(Type entityType)
    {
        // Arrange
        IModel model = CreateDesignTimeModel();
        IForeignKey[] foreignKeys = [.. model.FindEntityType(entityType)!.GetForeignKeys()];

        // Act
        string[] wrongDeleteBehaviors =
        [
            .. foreignKeys.Where(fk =>
                    fk.DeleteBehavior != (fk.PrincipalEntityType.ClrType == typeof(GroupOrder)
                        ? DeleteBehavior.Cascade
                        : DeleteBehavior.Restrict))
                .Select(fk => $"{fk.PrincipalEntityType.DisplayName()}: {fk.DeleteBehavior}")
        ];

        // Assert
        Assert.NotEmpty(foreignKeys);
        Assert.Empty(wrongDeleteBehaviors);
    }

    //ჯგუფის სტრიქონის კავშირი ბრძანების ხაზთან: ჯგუფების რეჟიმში ცარიელია, ხაზი თავის სტრიქონზე ადრე არ იშლება, ერთი ხაზი
    //კი ერთ სტრიქონს ქმნის (GROUP_ORDERS.md §10, A2)
    [Theory]
    [InlineData(typeof(GroupByTeacher), nameof(GroupByTeacher.GroupOrderTeacherId))]
    [InlineData(typeof(GroupByStudent), nameof(GroupByStudent.GroupOrderStudentId))]
    [InlineData(typeof(GroupDayTimePlace), nameof(GroupDayTimePlace.GroupOrderDayTimePlaceId))]
    public void GroupRowOrderLineLink_Always_IsOptionalRestrictAndUnique(Type rowType, string linkPropertyName)
    {
        // Arrange
        IModel model = CreateDesignTimeModel();
        IEntityType row = model.FindEntityType(rowType)!;

        // Act
        IForeignKey link = row.GetForeignKeys()
            .Single(fk => fk.Properties.Count == 1 && fk.Properties[0].Name == linkPropertyName);
        IIndex index = row.GetIndexes().Single(i => i.Properties.Count == 1 && i.Properties[0].Name == linkPropertyName);

        // Assert
        Assert.False(link.IsRequired);
        Assert.Equal(DeleteBehavior.Restrict, link.DeleteBehavior);
        Assert.True(index.IsUnique);
        Assert.Equal($"[{linkPropertyName}] IS NOT NULL", index.GetFilter());
    }

    //ბრძანების ნომერი არასოდეს მეორდება, საწყის ბრძანებას კი ნომერი არ აქვს (D192)
    [Fact]
    public void GroupOrderNumber_Always_IsUniqueAmongNumberedOrders()
    {
        // Arrange
        IModel model = CreateDesignTimeModel();

        // Act
        IIndex index = model.FindEntityType(typeof(GroupOrder))!.GetIndexes().Single(i =>
            string.Join(",", i.Properties.Select(p => p.Name)) ==
            $"{nameof(GroupOrder.NumberYear)},{nameof(GroupOrder.Number)}");

        // Assert
        Assert.True(index.IsUnique);
        Assert.Equal("[NumberYear] IS NOT NULL AND [Number] IS NOT NULL", index.GetFilter());
    }

    //ერთდროული შენახვისას მთვლელი ერთ ნომერს ორჯერ არ გასცემს (D192): UPDATE მთვლელის ძველ მნიშვნელობასაც ამოწმებს
    [Fact]
    public void GroupOrderNumberLastNumber_Always_IsConcurrencyToken()
    {
        // Arrange
        IModel model = CreateDesignTimeModel();

        // Act
        IProperty lastNumber = model.FindEntityType(typeof(GroupOrderNumber))!
            .FindProperty(nameof(GroupOrderNumber.LastNumber))!;

        // Assert
        Assert.True(lastNumber.IsConcurrencyToken);
    }

    //რეჟიმის ცხრილში მხოლოდ ერთი სტრიქონი შეიძლება იყოს (D183)
    [Fact]
    public void GroupOrdersMode_Always_AllowsOnlySingleRow()
    {
        // Arrange
        IModel model = CreateDesignTimeModel();

        // Act
        string[] checkConstraints =
            [.. model.FindEntityType(typeof(GroupOrdersMode))!.GetCheckConstraints().Select(c => c.Sql)];

        // Assert
        Assert.Equal(["[Id] = 1"], checkConstraints);
    }

    //ნომრის წელს და რეჟიმის სტრიქონის Id-ს პროგრამა წერს, ბაზა მათ არ აგენერირებს
    [Theory]
    [InlineData(typeof(GroupOrderNumber))]
    [InlineData(typeof(GroupOrdersMode))]
    public void ApplicationKeyedGroupOrderTables_Always_HaveKeyWithoutGeneratedValues(Type entityType)
    {
        // Arrange
        IModel model = CreateDesignTimeModel();

        // Act
        IProperty key = model.FindEntityType(entityType)!.FindPrimaryKey()!.Properties.Single();

        // Assert
        Assert.Equal(ValueGenerated.Never, key.ValueGenerated);
    }

    //sourceTable-იდან კასკადური გზებით ყოველი ცხრილი მაქსიმუმ ერთხელ მიიღწევა, sourceTable კი არცერთხელ (წრე)
    private static bool HasSingleCascadePathToEveryTable(ILookup<string, string> cascades, string sourceTable)
    {
        HashSet<string> reached = [sourceTable];
        Stack<string> pending = new([sourceTable]);
        while (pending.Count > 0)
        {
            foreach (string dependentTable in cascades[pending.Pop()])
            {
                if (!reached.Add(dependentTable))
                {
                    return false;
                }

                pending.Push(dependentTable);
            }
        }

        return true;
    }
}
