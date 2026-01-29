//Created by DatabaseInstallerClassCreator at 2/15/2025 11:07:44 AM

using System;
using BackendCarcass.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;

namespace MimosiGeDb.DependencyInjection;

// ReSharper disable once UnusedType.Global
public static class MimosiGeDbDependencyInjection
{
    public static IServiceCollection AddMimosiGeDb(this IServiceCollection services, ILogger? debugLogger, IConfiguration configuration)
    {
        const string connectionStringConfigurationKey = "Data:MimosiGeDatabase:ConnectionString";
        debugLogger?.Information("{MethodName} Started", nameof(AddMimosiGeDb));

        string? connectionString = configuration[connectionStringConfigurationKey];

        if (string.IsNullOrWhiteSpace(connectionString) && debugLogger is not null)
        {
            Console.WriteLine($"{connectionStringConfigurationKey} is empty");
            return services;
        }

        services.AddDbContext<CarcassDbContext>(options => options.UseSqlServer(connectionString));
        services.AddDbContext<MimosiGeDbContext>(options => options.UseSqlServer(connectionString));
        debugLogger?.Information("{MethodName} Finished", nameof(AddMimosiGeDb));

        return services;
    }
}
