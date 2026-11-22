namespace WarehouseInventorySystem.WebApi.Storage.ConnectionStringProvider;

public class ConnectionStringProvider
{
    private readonly IKvStorage _storage;
    private readonly IConfiguration _configuration;

    public ConnectionStringProvider(
        IKvStorage storage,
        IConfiguration configuration)
    {
        _storage = storage;
        _configuration = configuration;
    }

    public async Task<string?> GetConnectionStringAsync()
    {
        var appSettingsValue = _configuration
            .GetConnectionString("DefaultConnection");

        var storageValue = await _storage
            .GetAsync("ConnectionString");

        return storageValue ?? appSettingsValue;
    }
}