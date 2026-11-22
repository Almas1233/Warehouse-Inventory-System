using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using WarehouseInventorySystem.Infrastructure.SQLServer.Repositories.Context;
using WarehouseInventorySystem.WebApi.DiExtensions;

var builder = WebApplication.CreateBuilder(args);
var services =  builder.Services;

//CONFIGURATION
var configurationBuilder = new ConfigurationBuilder();

configurationBuilder
    .AddJsonFile("appsettings.json")
    .Build();

//REGISTER SERVICES
services.AddServicesWithScrutor();

//REGISTER FILTER
services.AddControllers(options =>
{
    options.Filters.AddService<IExceptionFilter>();
});

//REGISTER DB
services.AddDbContext<WarehouseDbContext>(options =>
{
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("WarehouseDb")
    );
});

//REGISTER HTTP
services.AddControllers();
services.AddSwaggerGen();

//BUILD
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();

app.Run();

