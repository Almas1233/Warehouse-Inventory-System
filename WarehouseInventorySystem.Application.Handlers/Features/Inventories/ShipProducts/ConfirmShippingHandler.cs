using WarehouseInventorySystem.Application.Handlers.Common.Interfaces;
using WarehouseInventorySystem.Application.Handlers.Enums;
using WarehouseInventorySystem.Application.Handlers.Exceptions;

namespace WarehouseInventorySystem.Application.Handlers.Features.Inventories.ShipProducts;

public class ConfirmShippingHandler :
    IRequestHandler<ConfirmShippingRequest, ConfirmShippingResponse>
{
    private readonly IProductRepository _productRepository;
    private readonly IInventoryRepository _inventoryRepository;
    private readonly IStorageCellRepository _storageCellRepository;

    public ConfirmShippingHandler(
        IProductRepository productRepository,
        IInventoryRepository inventoryRepository,
        IStorageCellRepository storageCellRepository
    )
    {
        _productRepository = productRepository;
        _inventoryRepository = inventoryRepository;
        _storageCellRepository = storageCellRepository;
    }

    public async Task<ConfirmShippingResponse> Handle(ConfirmShippingRequest request)
    {
        if (string.IsNullOrWhiteSpace(request.StorageCellId))
        {
            throw new InvalidValidation(
                "Storage cell is empty.",
                ErrorCodes.InvalidInput
            );
        }
        
        if (string.IsNullOrWhiteSpace(request.ProductId))
        {
            throw new InvalidValidation(
                "Product Id is empty.",
                ErrorCodes.InvalidInput
            );
        }

        if (request.Quantity <= 0)
        {
            throw new InvalidValidation(
                "Quantity must be greater than zero.", 
                ErrorCodes.InvalidInput
            );
        }

        var product = await _productRepository.GetBydAsync(request.ProductId);

        if (product == null)
        {
            throw new NotFoundException(
                "Product not found.",
                ErrorCodes.ProductNotFound
            );
        }

        var storageCell = await _storageCellRepository.GetByIdAsync(request.StorageCellId);
        
        if (storageCell == null)
        {
            throw new NotFoundException(
                "Storage cell not found.",
                ErrorCodes.StorageCellNotFound
            );
        }

        var inventoryBalance = await _inventoryRepository.GetInventoryBalanceByStorageCellIdAsync(request.StorageCellId);

        if (inventoryBalance == null)
        {
            throw new NotFoundException(
                "Inventory balance not found.", 
                ErrorCodes.InventoryBalanceNotFound 
            );
        }
        
        inventoryBalance.RemoveQuantity(request.Quantity);

        await _inventoryRepository.SaveChangesAsync();
        
        var result = new ConfirmShippingResponse(
            product.Id.ToString(), 
            storageCell.Id.ToString(), 
            request.Quantity
        );

        return result;
    }
}