using Microsoft.AspNetCore.Mvc;
using WarehouseInventorySystem.Domain.Common.Exceptions;

namespace WarehouseInventorySystem.WebApi.Filter.DomainExceptionResponse;

public class DomainExceptionResponseCreator
{
    public static ObjectResult Create(BaseDomainException exception)
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
