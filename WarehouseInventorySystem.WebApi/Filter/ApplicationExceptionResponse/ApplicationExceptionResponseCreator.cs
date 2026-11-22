using Microsoft.AspNetCore.Mvc;
using WarehouseInventorySystem.Application.Handlers.Common.Exceptions;

namespace WarehouseInventorySystem.WebApi.Filter.ApplicationExceptionResponse;

public static class ApplicationExceptionResponseCreator
{
    public static ObjectResult Create(BaseApplicationException exception)
    {
        var result = new ObjectResult(new
        {
            ResponseCode = exception.ResponseCode,
            Message = exception.ClientMessage
        })
        {
            StatusCode = exception.StatusCode
        };

        return result;
    }
}