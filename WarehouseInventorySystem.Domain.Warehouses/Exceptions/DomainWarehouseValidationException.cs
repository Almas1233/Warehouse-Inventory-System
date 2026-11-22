using WarehouseInventorySystem.Contracts;
using WarehouseInventorySystem.Contracts.Enums;
using WarehouseInventorySystem.Domain.Common.Exceptions;
using ResponseCode = WarehouseInventorySystem.Contracts.Enums.ResponseCode;

namespace WarehouseInventorySystem.Domain.Warehouses.Exceptions;

public class DomainWarehouseValidationException : BaseDomainException
{
    public DomainWarehouseValidationException(
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