using WarehouseInventorySystem.Application.Handlers.Exceptions;
using WarehouseInventorySystem.Contracts.Enums;

namespace WarehouseInventorySystem.Application.Handlers.Utilities;

public static class StringToGuid
{
    public static Guid ParseRequired(string stringGuid)
    {
        if (!Guid.TryParse(stringGuid, out var guid))
        {
            throw new ValidationException(
                "Invalid id.", 
                ResponseCode.InvalidInput,
                "Invalid ID format.",
                400
            );
        }
        
        return guid;
    }
}