using WarehouseInventorySystem.Application.Handlers.Common.Exceptions;
using WarehouseInventorySystem.Contracts.Enums;

namespace WarehouseInventorySystem.Application.Handlers.Exceptions;

public class ValidationException : BaseApplicationException
{
    public ValidationException(
        string message, 
        ResponseCode responseCode,
        string clientMessage,
        int statusCode
    ) 
        : base(
            message, 
            responseCode,
            clientMessage,
            statusCode
        )
    {}
}