using Microsoft.AspNetCore.Mvc;
using WarehouseInventorySystem.Infrastructure.Common.Exceptions;

namespace WarehouseInventorySystem.WebApi.Filter.InfrastructureExceptionResponse;

public class InfrastructureExceptionResponseCreator
{
    public static ObjectResult Create(BaseInfrastructureException exception)
    {
        var result = new ObjectResult(new
        {
            exception.ResponseCode,
            Message = exception.ClientMessage
        })
        {
            StatusCode = exception.StatusCode
        };

        return result;
    }
}