//Created by DatabaseInstallerClassCreator at 2/15/2025 11:07:44 AM

using System;
using System.Collections.Generic;
using CarcassDb;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WebInstallers;

namespace MimosiGeDb.Installers;

// ReSharper disable once UnusedType.Global
public sealed class MimosiGeDatabaseInstaller : IInstaller
{
    public int InstallPriority => 30;
    public int ServiceUsePriority => 30;

    public bool InstallServices(WebApplicationBuilder builder, bool debugMode, string[] args,
        Dictionary<string, string> parameters)
    {
        if (debugMode) Console.WriteLine($"{GetType().Name}.{nameof(InstallServices)} Started");

        var connectionString = builder.Configuration["Data:MimosiGeDatabase:ConnectionString"];

        if (string.IsNullOrWhiteSpace(connectionString) && !debugMode)
        {
            Console.WriteLine("MimosiGeDatabaseInstaller.InstallServices connectionString is empty");
            return false;
        }

        builder.Services.AddDbContext<CarcassDbContext>(options => options.UseSqlServer(connectionString));
        builder.Services.AddDbContext<MimosiGeDbContext>(options => options.UseSqlServer(connectionString));
        if (debugMode) Console.WriteLine($"{GetType().Name}.{nameof(InstallServices)} Finished");

        return true;
    }

    public bool UseServices(WebApplication app, bool debugMode)
    {
        return true;
    }
}

/*
public sealed class YourDbContext : DbContext
   {
       protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
       {
           optionsBuilder.UseSqlServer("YourConnectionString", options =>
           {
               options.AddCustomConventionSetBuilder<CustomConventionSetBuilder>();
           });
       }

       // Your DbSets...
   }
    */