using System.Text.Json;

namespace WarehouseInventorySystem.WebApi.Storage;

public class JsonKvStorage : IKvStorage
{
    private readonly string _filePath;
    private readonly SemaphoreSlim _semaphore = new(1, 1);

    private Dictionary<string, string> _data = new();
    private bool _initialized;

    public JsonKvStorage(string filePath)
    {
        _filePath = filePath;
    }

    private async Task EnsureInitializedAsync()
    {
        if (_initialized)
            return;

        var directory = Path.GetDirectoryName(_filePath);

        if (directory is not null)
            Directory.CreateDirectory(directory);

        if (File.Exists(_filePath))
        {
            var json = await File.ReadAllTextAsync(_filePath);

            _data = JsonSerializer.Deserialize<Dictionary<string, string>>(json)
                    ?? new Dictionary<string, string>();
        }

        _initialized = true;
    }

    public async Task SetAsync(string key, string value)
    {
        await _semaphore.WaitAsync();

        try
        {
            await EnsureInitializedAsync();

            _data[key] = value;

            await SaveAsync();
        }
        finally
        {
            _semaphore.Release();
        }
    }

    public async Task<string?> GetAsync(string key)
    {
        await _semaphore.WaitAsync();

        try
        {
            await EnsureInitializedAsync();

            return _data.GetValueOrDefault(key);
        }
        finally
        {
            _semaphore.Release();
        }
    }

    public async Task<bool> RemoveAsync(string key)
    {
        await _semaphore.WaitAsync();

        try
        {
            await EnsureInitializedAsync();

            if (!_data.Remove(key))
                return false;

            await SaveAsync();

            return true;
        }
        finally
        {
            _semaphore.Release();
        }
    }

    public async Task<IReadOnlyDictionary<string, string>> GetAllAsync()
    {
        await _semaphore.WaitAsync();

        try
        {
            await EnsureInitializedAsync();

            return new Dictionary<string, string>(_data);
        }
        finally
        {
            _semaphore.Release();
        }
    }

    private async Task SaveAsync()
    {
        var json = JsonSerializer.Serialize(
            _data,
            new JsonSerializerOptions { WriteIndented = true });

        var tempPath = _filePath + ".tmp";

        await File.WriteAllTextAsync(tempPath, json);

        File.Move(tempPath, _filePath, overwrite: true);
    }
}