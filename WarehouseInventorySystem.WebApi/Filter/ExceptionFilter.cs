using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using WarehouseInventorySystem.Application.Handlers.Common.Exceptions;
using WarehouseInventorySystem.Domain.Common.Exceptions;
using WarehouseInventorySystem.Infrastructure.Common.Exceptions;
using WarehouseInventorySystem.Telemetry.Logging.Common;
using WarehouseInventorySystem.WebApi.Filter.ApplicationExceptionResponse;
using WarehouseInventorySystem.WebApi.Filter.DomainExceptionResponse;
using WarehouseInventorySystem.WebApi.Filter.InfrastructureExceptionResponse;

namespace WarehouseInventorySystem.WebApi.Filter;

public class ExceptionFilter : IExceptionFilter
{
    private readonly ILogService _logger;

    public ExceptionFilter(ILogService logger)
    {
        _logger = logger;
    }

    public void OnException(ExceptionContext context)
    {
        switch (context.Exception)
        {
            case BaseApplicationException handlerException:
                
                _logger.LogWarning(
                    $"Application exception: {handlerException.Message}"
                );

                context.Result = ApplicationExceptionResponseCreator.Create(handlerException);

                break;
            
            case BaseDomainException  domainException:
                
                _logger.LogWarning(
                    $"Domain exception: {domainException.Message}"
                );

                context.Result = DomainExceptionResponseCreator.Create(domainException);
                
                break;
            
            case BaseInfrastructureException infrastructureException: 
                
                _logger.LogWarning(
                    $"Infrastructure exception: {infrastructureException.Message}"
                );

                context.Result = InfrastructureExceptionResponseCreator.Create(infrastructureException);
                
                break;
            
            default: 
                
                _logger.LogError(
                    $"Unhandled exception: {context.Exception.Message}",
                    context.Exception
                );
                
                context.Result = new ObjectResult(new
                {
                    Message = "An unexpected error occurred. Please try again later."
                })
                {
                    StatusCode = StatusCodes.Status500InternalServerError
                };

                break;
        }
        
        context.ExceptionHandled = true;
    }
}