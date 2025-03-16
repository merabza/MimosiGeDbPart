using System;
using System.Linq;
using CarcassDb;
using DatabaseToolsShared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer.Infrastructure.Internal;
using MimosiGeDb.Models;

namespace MimosiGeDb;

public sealed class MimosiGeDbContext : CarcassDbContext
{
    public MimosiGeDbContext(DbContextOptions<MimosiGeDbContext> options, bool isDesignTime) : base(options,
        isDesignTime)
    {
        //Console.WriteLine("MimosiGeDbContext Constructor 2...");
    }

    public MimosiGeDbContext(DbContextOptions<MimosiGeDbContext> options, int int1) : base(
        ChangeOptionsType<CarcassDbContext>(options), int1)
    {
        //Console.WriteLine("MimosiGeDbContext Constructor 3...");
    }

    public MimosiGeDbContext(DbContextOptions<MimosiGeDbContext> options) : base(
        ChangeOptionsType<CarcassDbContext>(options))
    {
        //Console.WriteLine("MimosiGeDbContext Constructor 4...");
    }

    //ბაზაში არსებული ცხრილები წარმოდგენილი DbSet-ების სახით
    public DbSet<AcademicYear> AcademicYears { get; set; }

    public DbSet<BankAccount> BankAccounts { get; set; }

    public DbSet<BookOrMaterial> BooksOrMaterials { get; set; }

    public DbSet<BookOrMaterialType> BookOrMaterialTypes { get; set; }

    public DbSet<Course> Courses { get; set; }

    public DbSet<CrmAnswerType> CrmAnswerType { get; set; }

    public DbSet<CrmCallType> CrmCallType { get; set; }

    public DbSet<CrmCall> CrmCalls { get; set; }

    public DbSet<ErrorLogText> ErrorLogTexts { get; set; }

    public DbSet<GeoMonth> GeoMonths { get; set; }

    public DbSet<GeoPhrase> GeoPhrases { get; set; }

    public DbSet<GroupBookOrMaterial> GroupBooksAndMaterials { get; set; }

    public DbSet<GroupDayTimePlace> GroupDayTimePlace { get; set; }

    public DbSet<GroupLessonsCountByMonths> GroupLessonsCountByMonths { get; set; }

    public DbSet<GroupSize> GroupSizes { get; set; }

    public DbSet<Group> Groups { get; set; }

    public DbSet<GroupsByStudent> GroupsByStudents { get; set; }

    public DbSet<GroupsByTeachers> GroupsByTeachers { get; set; }

    public DbSet<Humans> Humans { get; set; }

    public DbSet<LessonMaterial> LessonBooksAndMaterials { get; set; }

    public DbSet<LessonStatuses> LessonStatuses { get; set; }

    public DbSet<Lessons> Lessons { get; set; }

    public DbSet<LessonsByStudents> LessonsByStudents { get; set; }

    public DbSet<LessonsCheckCreateErrorLogs> LessonsCheckCreateErrorLogs { get; set; }

    public DbSet<MonthDaies> MonthDaies { get; set; }

    public DbSet<OperationMonths> OperationMonths { get; set; }

    public DbSet<Payments> Payments { get; set; }

    public DbSet<ReportCategories> ReportCategories { get; set; }

    public DbSet<ReportParameterDates> ReportParameterDates { get; set; }

    public DbSet<ReportParameterNumbers> ReportParameterNumbers { get; set; }

    public DbSet<Reports> Reports { get; set; }

    public DbSet<ReportsByCategories> ReportsByCategories { get; set; }

    public DbSet<Rooms> Rooms { get; set; }

    public DbSet<RsBenefCategories> RsBenefCategories { get; set; }

    public DbSet<RsCountries> RsCountries { get; set; }

    public DbSet<RsQuoteTypes> RsQuoteTypes { get; set; }

    public DbSet<RsTaxRates> RsTaxRates { get; set; }

    public DbSet<SalaryCharges> SalaryCharges { get; set; }

    public DbSet<SalaryChargesChanges> SalaryChargesChanges { get; set; }

    public DbSet<SalaryHeaders> SalaryHeaders { get; set; }

    public DbSet<SalaryLines> SalaryLines { get; set; }

    public DbSet<SalaryLineDetail> SalaryLinesDetails { get; set; }

    public DbSet<SalaryPartTypes> SalaryPartTypes { get; set; }

    public DbSet<SalaryParts> SalaryParts { get; set; }

    public DbSet<StudentContractDetails> StudentContractDetails { get; set; }

    public DbSet<StudentContract> StudentContracts { get; set; }

    public DbSet<StudentStatus> StudentStatuses { get; set; }

    public DbSet<Stuff> Stuff { get; set; }

    public DbSet<SummaryComments> SummaryComments { get; set; }

    public DbSet<TeacherContracts> TeacherContracts { get; set; }

    public DbSet<TeacherSalarySchemes> TeacherSalarySchemes { get; set; }

    public DbSet<Time> Times { get; set; }

    public DbSet<WeekDay> WeekDaies { get; set; }

    public DbSet<WeekNumbers> WeekNumbers { get; set; }

    public DbSet<WorkHourGroups> WorkHourGroups { get; set; }

    public DbSet<WorkHours> WorkHours { get; set; }

    private static DbContextOptions<T> ChangeOptionsType<T>(DbContextOptions options) where T : DbContext
    {
        //Console.WriteLine("MimosiGeDbContext ChangeOptionsType Start...");

        var sqlExt = options.Extensions.FirstOrDefault(e => e is SqlServerOptionsExtension) ??
                     throw new Exception("Failed to retrieve SQL connection string for base Context");
        var connectionString = ((SqlServerOptionsExtension)sqlExt).ConnectionString ??
                               throw new Exception("Connection string for base Context dos not specified");
        //Console.WriteLine("MimosiGeDbContext ChangeOptionsType Pass 2...");

        return new DbContextOptionsBuilder<T>().UseSqlServer(connectionString).EnableSensitiveDataLogging().Options;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //Console.WriteLine("MimosiGeDbContext OnModelCreating Start...");

        base.OnModelCreating(modelBuilder);

        //Console.WriteLine("MimosiGeDbContext OnModelCreating Pass 1...");

        modelBuilder.ApplyConfigurationsFromAssembly(AssemblyReference.Assembly);
    }

    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        configurationBuilder.Conventions.Add(_ => new DatabaseEntitiesDefaultConvention());
    }
}