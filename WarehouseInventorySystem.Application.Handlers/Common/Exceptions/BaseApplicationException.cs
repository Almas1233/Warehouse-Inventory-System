using WarehouseInventorySystem.Contracts.Enums;

namespace WarehouseInventorySystem.Application.Handlers.Common.Exceptions;

public class BaseApplicationException : Exception
{
    public ResponseCode ResponseCode { get; init; }
    public string ClientMessage { get; init; }
    public int StatusCode { get; init; }
    
    public BaseApplicationException(
        string message, 
        ResponseCode responseCode,
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