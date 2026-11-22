FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["WarehouseInventorySystem.WebApi/WarehouseInventorySystem.WebApi.csproj", "WarehouseInventorySystem.WebApi/"]
COPY ["WarehouseInventorySystem.Application.Handlers/WarehouseInventorySystem.Application.Handlers.csproj", "WarehouseInventorySystem.Application.Handlers/"]
COPY ["WarehouseInventorySystem.Domain.Products/WarehouseInventorySystem.Domain.Products.csproj", "WarehouseInventorySystem.Domain.Products/"]
COPY ["WarehouseInventorySystem.Domain.Common/WarehouseInventorySystem.Domain.Common.csproj", "WarehouseInventorySystem.Domain.Common/"]
COPY ["WarehouseInventorySystem.Domain.Warehouses/WarehouseInventorySystem.Domain.Warehouses.csproj", "WarehouseInventorySystem.Domain.Warehouses/"]
COPY ["WarehouseInventorySystem.Domain.InventoryBalance/WarehouseInventorySystem.Domain.InventoryBalance.csproj", "WarehouseInventorySystem.Domain.InventoryBalance/"]
COPY ["WarehouseInventorySystem.Infrastructure.SQLServer/WarehouseInventorySystem.Infrastructure.SQLServer.csproj", "WarehouseInventorySystem.Infrastructure.SQLServer/"]
COPY ["WarehouseInventorySystem.Infrastructure.Common/WarehouseInventorySystem.Infrastructure.Common.csproj", "WarehouseInventorySystem.Infrastructure.Common/"]
RUN dotnet restore "WarehouseInventorySystem.WebApi/WarehouseInventorySystem.WebApi.csproj"
COPY . .
WORKDIR "/src/WarehouseInventorySystem.WebApi"
RUN dotnet build "./WarehouseInventorySystem.WebApi.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./WarehouseInventorySystem.WebApi.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WarehouseInventorySystem.WebApi.dll"]
