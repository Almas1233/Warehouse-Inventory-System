using WarehouseInventorySystem.Contracts;
using WarehouseInventorySystem.Contracts.Enums;

namespace WarehouseInventorySystem.Domain.Common.Exceptions;

public class BaseDomainException : Exception
{
    public Contracts.Enums.ResponseCode ResponseCode { get; init; }
    public string ClientMessage { get; init; }
    public int StatusCode { get; init; }
    
    public BaseDomainException(
        string message, 
        Contracts.Enums.ResponseCode responseCode,
        string clientMessage,
        int statusCode
    ) 
        : base(message)
    {
        ResponseCode = responseCode;
        ClientMessage = clientMessage;
        StatusCode = statusCode;
    }
}