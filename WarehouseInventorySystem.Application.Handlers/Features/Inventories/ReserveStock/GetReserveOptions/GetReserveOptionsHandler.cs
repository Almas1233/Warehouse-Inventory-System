using System.Text.RegularExpressions;
using WarehouseInventorySystem.Application.Handlers.Common.Interfaces;
using WarehouseInventorySystem.Application.Handlers.Enums;
using WarehouseInventorySystem.Application.Handlers.Exceptions;

namespace WarehouseInventorySystem.Application.Handlers.Features.Inventories.ShippingStock.ReserveStock.GetReserveOptions;

public class GetReserveOptionsHandler :
    IRequestHandler<GetReserveOptionsRequest, GetReserveOptionsResponse>
{
    private readonly IProductRepository _productRepository;
    private readonly IInventoryRepository _inventoryRepository;

    public GetReserveOptionsHandler(
        IProductRepository productRepository,
        IInventoryRepository inventoryRepository)
    {
        _productRepository = productRepository;
        _inventoryRepository = inventoryRepository;
    }

    public async Task<GetReserveOptionsResponse> Handle(GetReserveOptionsRequest request)
    {
        if (string.IsNullOrWhiteSpace(request.Sku)
            || request.Unit <= 0
           )
        {
            throw new InvalidValidation(
                "Sku is empty or unit is below 0.",
                ErrorCodes.InvalidInput
            );
        }

        if (!Regex.IsMatch(request.Sku, @"^[a-zA-Z0-9]{8}$"))
        {
            throw new InvalidValidation(
                "Sku should have 8 signs.",
                ErrorCodes.InvalidInput
            );
        }

        var product = await _productRepository.GetBySkuAsync(request.Sku);

        if (product == null)
        {
            throw new NotFoundException(
                "Product not found.",
                ErrorCodes.ProductNotFound
            );
        }
        
        var balances = await _inventoryRepository.GetReserveOptionsAsync(
            product.Id,
            request.Unit
        );

        var options = balances
            .Select(balance => new ReserveOptionDto(
                balance.StorageCellId,
                balance.WarehouseName, //я гружу полный InventoryBalance, но 
                balance.RackCode,
                balance.CellCode,
                balance.AvailableQuantity)
            ).ToList();

        var result = new GetReserveOptionsResponse(options);
        
        return result;
    }
}