using System;
using System.Linq;
using BackendCarcass.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.SqlServer.Infrastructure.Internal;
using MimosiGeCore.Application.Abstractions;
using MimosiGeCore.Domain.Models;
using SystemTools.DatabaseToolsShared;
using SystemTools.SharedKernel;

namespace MimosiGeDbPart.Db;

public sealed class MimosiGeDbContext : CarcassDbContext, IMimosiGeDbContext
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

    public MimosiGeDbContext(DbContextOptions<MimosiGeDbContext> options,
        IDomainEventsDispatcher domainEventsDispatcher) : base(ChangeOptionsType<CarcassDbContext>(options),
        domainEventsDispatcher)
    {
        //Console.WriteLine("MimosiGeDbContext Constructor 4...");
    }

    //ბაზაში არსებული ცხრილები წარმოდგენილი DbSet-ების სახით
    public DbSet<AcademicYear> AcademicYears { get; set; }
    public DbSet<BankAccount> BankAccounts { get; set; }
    public DbSet<Course> Courses { get; set; }
    public DbSet<CrmAnswerType> CrmAnswerTypes { get; set; }
    public DbSet<CrmCallType> CrmCallTypes { get; set; }
    public DbSet<CrmCall> CrmCalls { get; set; }
    public DbSet<ErrorLogText> ErrorLogTexts { get; set; }
    public DbSet<GeoMonth> GeoMonths { get; set; }
    public DbSet<GroupDayTimePlace> GroupDayTimePlaces { get; set; }
    public DbSet<GroupSize> GroupSizes { get; set; }
    public DbSet<Group> Groups { get; set; }
    public DbSet<GroupByStudent> GroupsByStudents { get; set; }
    public DbSet<GroupByTeacher> GroupsByTeachers { get; set; }
    public DbSet<Human> Humans { get; set; }
    public DbSet<LessonStatus> LessonStatuses { get; set; }
    public DbSet<Lesson> Lessons { get; set; }
    public DbSet<LessonByStudent> LessonsByStudents { get; set; }
    public DbSet<LessonCheckCreateErrorLog> LessonsCheckCreateErrorLogs { get; set; }
    public DbSet<OperationMonth> OperationMonths { get; set; }
    public DbSet<Payment> Payments { get; set; }
    public DbSet<Room> Rooms { get; set; }
    public DbSet<RsCountry> RsCountries { get; set; }
    public DbSet<RsQuoteType> RsQuoteTypes { get; set; }
    public DbSet<SalaryHeader> SalaryHeaders { get; set; }
    public DbSet<SalaryLine> SalaryLines { get; set; }
    public DbSet<SalaryLineDetail> SalaryLinesDetails { get; set; }
    public DbSet<SalaryPartType> SalaryPartTypes { get; set; }
    public DbSet<SalaryPart> SalaryParts { get; set; }
    public DbSet<StudentContractDetail> StudentContractDetails { get; set; }
    public DbSet<StudentContract> StudentContracts { get; set; }
    public DbSet<StudentStatus> StudentStatuses { get; set; }
    public DbSet<TeacherContract> TeacherContracts { get; set; }
    public DbSet<TeacherSalaryScheme> TeacherSalarySchemes { get; set; }
    public DbSet<LessonStartTime> LessonStartTimes { get; set; }
    public DbSet<WeekDay> WeekDays { get; set; }
    public DbSet<WorkHourGroup> WorkHourGroups { get; set; }
    public DbSet<WorkHour> WorkHours { get; set; }

    private static DbContextOptions<T> ChangeOptionsType<T>(DbContextOptions options) where T : DbContext
    {
        //Console.WriteLine("MimosiGeDbContext ChangeOptionsType Start...");

        IDbContextOptionsExtension sqlExt = options.Extensions.FirstOrDefault(e => e is SqlServerOptionsExtension) ??
                                            throw new Exception(
                                                "Failed to retrieve SQL connection string for base Context");
        string connectionString = ((SqlServerOptionsExtension)sqlExt).ConnectionString ??
                                  throw new Exception("Connection string for base Context dos not specified");
        //Console.WriteLine("MimosiGeDbContext ChangeOptionsType Pass 2...");

        //პარამეტრების მნიშვნელობების ლოგირება მხოლოდ მაშინ ირთვება, როცა შემოსულ options-ში ჩართულია
        //(AddMimosiGeDb მას მხოლოდ Development-ში რთავს)
        bool sensitiveDataLoggingEnabled =
            options.FindExtension<CoreOptionsExtension>()?.IsSensitiveDataLoggingEnabled ?? false;
        return new DbContextOptionsBuilder<T>().UseSqlServer(connectionString)
            .EnableSensitiveDataLogging(sensitiveDataLoggingEnabled).Options;
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
