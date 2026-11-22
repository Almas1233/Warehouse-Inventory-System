using WarehouseInventorySystem.Contracts;
using WarehouseInventorySystem.Contracts.Enums;
using WarehouseInventorySystem.Domain.Common.Exceptions;
using ResponseCode = WarehouseInventorySystem.Contracts.Enums.ResponseCode;

namespace WarehouseInventorySystem.Products.Exception;

public class DomainProductsValidationException : BaseDomainException
{
    public DomainProductsValidationException(
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