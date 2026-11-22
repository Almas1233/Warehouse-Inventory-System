using System.Collections.ObjectModel;

namespace WarehouseInventorySystem.Application.Handlers.Features.Inventories.ReceiveStock.GetStorageOptions;

public record GetStorageOptionsResponse(ReadOnlyCollection<StorageOptionsDto> Options);