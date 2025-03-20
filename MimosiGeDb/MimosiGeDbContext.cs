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

    public DbSet<GroupByStudent> GroupsByStudents { get; set; }

    public DbSet<GroupByTeachers> GroupsByTeachers { get; set; }

    public DbSet<Human> Humans { get; set; }

    public DbSet<LessonMaterial> LessonBooksAndMaterials { get; set; }

    public DbSet<LessonStatus> LessonStatuses { get; set; }

    public DbSet<Lesson> Lessons { get; set; }

    public DbSet<LessonByStudent> LessonsByStudents { get; set; }

    public DbSet<LessonCheckCreateErrorLog> LessonsCheckCreateErrorLogs { get; set; }

    public DbSet<MonthDey> MonthDaies { get; set; }

    public DbSet<OperationMonth> OperationMonths { get; set; }

    public DbSet<Payment> Payments { get; set; }

    public DbSet<ReportCategory> ReportCategories { get; set; }

    public DbSet<ReportParameterDate> ReportParameterDates { get; set; }

    public DbSet<ReportParameterNumber> ReportParameterNumbers { get; set; }

    public DbSet<Report> Reports { get; set; }

    public DbSet<ReportByCategory> ReportsByCategories { get; set; }

    public DbSet<Room> Rooms { get; set; }

    public DbSet<RsBenefCategory> RsBenefCategories { get; set; }

    public DbSet<RsCountry> RsCountries { get; set; }

    public DbSet<RsQuoteType> RsQuoteTypes { get; set; }

    public DbSet<RsTaxRate> RsTaxRates { get; set; }

    public DbSet<SalaryCharge> SalaryCharges { get; set; }

    public DbSet<SalaryChargeChange> SalaryChargesChanges { get; set; }

    public DbSet<SalaryHeader> SalaryHeaders { get; set; }

    public DbSet<SalaryLine> SalaryLines { get; set; }

    public DbSet<SalaryLineDetail> SalaryLinesDetails { get; set; }

    public DbSet<SalaryPartType> SalaryPartTypes { get; set; }

    public DbSet<SalaryPart> SalaryParts { get; set; }

    public DbSet<StudentContractDetail> StudentContractDetails { get; set; }

    public DbSet<StudentContract> StudentContracts { get; set; }

    public DbSet<StudentStatus> StudentStatuses { get; set; }

    public DbSet<Stuff> Stuff { get; set; }

    public DbSet<SummaryComment> SummaryComments { get; set; }

    public DbSet<TeacherContract> TeacherContracts { get; set; }

    public DbSet<TeacherSalaryScheme> TeacherSalarySchemes { get; set; }

    public DbSet<Time> Times { get; set; }

    public DbSet<WeekDay> WeekDaies { get; set; }

    public DbSet<WeekNumber> WeekNumbers { get; set; }

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