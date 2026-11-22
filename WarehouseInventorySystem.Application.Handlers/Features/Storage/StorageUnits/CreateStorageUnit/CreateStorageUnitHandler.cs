using WarehouseInventorySystem.Application.Handlers.Common.Interfaces;
using WarehouseInventorySystem.Application.Handlers.Enums;
using WarehouseInventorySystem.Application.Handlers.Exceptions;
using WarehouseInventorySystem.Application.Handlers.Utilities;
using WarehouseInventorySystem.Domain.Warehouses.Models;

namespace WarehouseInventorySystem.Application.Handlers.Features.Storage.StorageUnits.CreateStorageUnit;

public class CreateStorageUnitHandler:
    IRequestHandler<CreateStorageUnitRequest,CreateStorageUnitResponse>
{
    private readonly IStorageCellRepository _storageCellRepository;

    public CreateStorageUnitHandler(IStorageCellRepository storageCellRepository)
    {
        _storageCellRepository = storageCellRepository;
    }

    public async Task<CreateStorageUnitResponse> Handle(CreateStorageUnitRequest request)
    {
        if (string.IsNullOrWhiteSpace(request.RackId))
        {
            throw new InvalidValidation(
                "Choose the Rack.",
                ErrorCodes.RackNotFound
            );
        }

        var rack = await _storageCellRepository.GetByIdAsync(request.RackId);

        if (rack == null)
        {
            throw new NotFoundException(
                "Rack not found.",
                ErrorCodes.RackNotFound
                );
        }

        var rackId = StringToGuid.ParseRequired(request.RackId);

        var storageUnitCode = await _storageCellRepository.GetCellCodeAsync(request.RackId);

        var storageCell = new StorageUnit(
            storageUnitCode,
            request.Length,
            request.Width,
            request.Height,
            rackId
        );

        await _storageCellRepository.Insert(storageCell);

        var result = new CreateStorageUnitResponse(storageCell.Id.ToString());

        return result;
    }
}