using WarehouseInventorySystem.Contracts.Enums;
using WarehouseInventorySystem.Domain.Common.Exceptions;
using ResponseCode = WarehouseInventorySystem.Contracts.Enums.ResponseCode;

namespace InventoryBalances.Exceptions;

public class DomainInventoryBalanceValidationException : BaseDomainException
{
    public DomainInventoryBalanceValidationException(
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