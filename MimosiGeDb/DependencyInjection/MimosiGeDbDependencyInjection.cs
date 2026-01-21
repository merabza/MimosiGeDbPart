//Created by DatabaseInstallerClassCreator at 2/15/2025 11:07:44 AM

using System;
using BackendCarcass.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MimosiGeDb.DependencyInjection;

// ReSharper disable once UnusedType.Global
public static class MimosiGeDbDependencyInjection
{
    public static IServiceCollection AddMimosiGeDb(this IServiceCollection services, IConfiguration configuration,
        bool debugMode)
    {
        const string connectionStringConfigurationKey = "Data:MimosiGeDatabase:ConnectionString";
        if (debugMode) Console.WriteLine($"{nameof(AddMimosiGeDb)} Started");

        var connectionString = configuration[connectionStringConfigurationKey];

        if (string.IsNullOrWhiteSpace(connectionString) && !debugMode)
        {
            Console.WriteLine($"{connectionStringConfigurationKey} is empty");
            return services;
        }

        services.AddDbContext<CarcassDbContext>(options => options.UseSqlServer(connectionString));
        services.AddDbContext<MimosiGeDbContext>(options => options.UseSqlServer(connectionString));
        if (debugMode) Console.WriteLine($"{nameof(AddMimosiGeDb)} Finished");

        return services;
    }
}