namespace WarehouseInventorySystem.WebApi.Storage;

public interface IKvStorage
{
    Task SetAsync(string key, string value);

    Task<string?> GetAsync(string key);

    Task<bool> RemoveAsync(string key);

    Task<IReadOnlyDictionary<string, string>> GetAllAsync();
}