using WarehouseInventorySystem.Contracts.Enums;

namespace WarehouseInventorySystem.Application.Handlers.Features.Products.Validations;

public record ValidationErrorInfo(
    string Message,
    ResponseCode Code,
    string Description,
    int StatusCode
);