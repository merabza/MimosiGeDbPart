//Created by DatabaseInstallerClassCreator at 2/15/2025 11:07:44 AM
using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using WebInstallers;
using CarcassDb;
using MimosiGeDb;

namespace AppMimosiGeDb.Installers;

// ReSharper disable once UnusedType.Global
public sealed class AppMimosiGeDatabaseInstaller : IInstaller
{
    public int InstallPriority => 30;
    public int ServiceUsePriority => 30;
    
    public bool InstallServices(WebApplicationBuilder builder, bool debugMode, string[] args, Dictionary<string, string> parameters)
    {
        if (debugMode)
        {
            Console.WriteLine($"{GetType().Name}.{nameof(InstallServices)} Started");
        }
        var connectionString = builder.Configuration["Data:AppMimosiGeDatabase:ConnectionString"];
        
        if (string.IsNullOrWhiteSpace(connectionString) && !debugMode)
        {
            Console.WriteLine("AppMimosiGeDatabaseInstaller.InstallServices connectionString is empty");
            return false;
        }
        
        builder.Services.AddDbContext<CarcassDbContext>(options => options.UseSqlServer(connectionString));
        builder.Services.AddDbContext<MimosiGeDbContext>(options => options.UseSqlServer(connectionString));
        if (debugMode)
        {
            Console.WriteLine($"{GetType().Name}.{nameof(InstallServices)} Finished");
        }
        return true;
    }
    
    public bool UseServices(WebApplication app, bool debugMode)
    {
        return true;
    }
}
