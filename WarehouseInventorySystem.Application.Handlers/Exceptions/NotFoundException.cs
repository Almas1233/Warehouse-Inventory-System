using WarehouseInventorySystem.Application.Handlers.Common.Exceptions;
using WarehouseInventorySystem.Contracts.Enums;

namespace WarehouseInventorySystem.Application.Handlers.Exceptions;

public class NotFoundException : BaseApplicationException
{
    public NotFoundException(
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