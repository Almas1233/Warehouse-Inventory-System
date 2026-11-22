using FluentValidation;
using WarehouseInventorySystem.Application.Handlers.Common.Interfaces;
using WarehouseInventorySystem.Infrastructure.Common.Base;
using WarehouseInventorySystem.Telemetry.Logging.Common;
using WarehouseInventorySystem.WebApi.Filter;

namespace WarehouseInventorySystem.WebApi.DiExtensions;

public static class ServiceRegistrationWithScrutorExtensions
{
    public static void AddServicesWithScrutor(this IServiceCollection services)
    {
        services.Scan(scan => scan
            .FromAssemblies()
            .FromApplicationDependencies()
            .AddClasses(classes => classes.AssignableTo(typeof(IRepository)))
            .AsImplementedInterfaces()
            .WithScopedLifetime()
            .AddClasses(classes => classes.AssignableTo(typeof(IRequestHandler<,>)))
            .AsImplementedInterfaces()
            .WithScopedLifetime()
            .AddClasses(classes => classes.AssignableTo(typeof(IEntityMapper<,>)))
            .AsImplementedInterfaces()
            .WithScopedLifetime()
            .AddClasses(classes => classes.AssignableTo<ExceptionFilter>())
            .AsImplementedInterfaces()
            .WithScopedLifetime()
            .AddClasses(classes => classes.AssignableTo<ILogService>())
            .AsImplementedInterfaces()
            .WithSingletonLifetime()
            .AddClasses(classes => classes.AssignableTo<ILogSink>())
            .AsImplementedInterfaces()
            .WithSingletonLifetime()
            .AddClasses(classes => classes.AssignableTo(typeof(IValidator<>)))
            .AsImplementedInterfaces()
            .WithSingletonLifetime()
        
        );
    }
}