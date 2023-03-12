#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/B3Test.Api/B3Test.Api.csproj", "src/B3Test.Api/"]
COPY ["BuildingBlocks/B3Test.MessageBus.MassTransit/B3Test.MessageBus.MassTransit.csproj", "BuildingBlocks/B3Test.MessageBus.MassTransit/"]
COPY ["BuildingBlocks/B3Test.Monitoring.AspNetCore/B3Test.Monitoring.AspNetCore.csproj", "BuildingBlocks/B3Test.Monitoring.AspNetCore/"]
COPY ["BuildingBlocks/B3Test.Monitoring.Prometheus/B3Test.Monitoring.Prometheus.csproj", "BuildingBlocks/B3Test.Monitoring.Prometheus/"]
COPY ["BuildingBlocks/B3Test.Monitoring/B3Test.Monitoring.Abstractions.csproj", "BuildingBlocks/B3Test.Monitoring/"]
COPY ["src/B3Test.Application/B3Test.Application.csproj", "src/B3Test.Application/"]
COPY ["src/B3Test.Shared/B3Test.Shared.csproj", "src/B3Test.Shared/"]
COPY ["src/B3Test.Infrastructure/B3Test.Infrastructure.csproj", "src/B3Test.Infrastructure/"]
COPY ["src/B3Test.Domain/B3Test.Domain.csproj", "src/B3Test.Domain/"]
RUN dotnet restore "src/B3Test.Api/B3Test.Api.csproj"
COPY . .
WORKDIR "/src/src/B3Test.Api"
RUN dotnet build "B3Test.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "B3Test.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "B3Test.Api.dll"]