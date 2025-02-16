//Created by DbContextForCarcassClassCreator at 2/15/2025 11:07:44 AM

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer.Infrastructure.Internal;
using System;
using System.Linq;
using CarcassDb;

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

    //ბაზაში არსებული ცხრილები წარმოდგენილი DbSet-ების სახით
    // public virtual DbSet<ActantCombination> ActantCombinations => Set<ActantCombination>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //Console.WriteLine("MimosiGeDbContext OnModelCreating Start...");

        base.OnModelCreating(modelBuilder);

        //Console.WriteLine("MimosiGeDbContext OnModelCreating Pass 1...");

        modelBuilder.ApplyConfigurationsFromAssembly(AssemblyReference.Assembly);
    }
}