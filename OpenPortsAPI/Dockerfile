#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["OpenPortsAPI/OpenPortsAPI.csproj", "OpenPortsAPI/"]
COPY ["OpenPorts.Service/OpenPorts.Service.csproj", "OpenPorts.Service/"]
COPY ["OpenPorts.Model/OpenPorts.Model.csproj", "OpenPorts.Model/"]
RUN dotnet restore "OpenPortsAPI/OpenPortsAPI.csproj"
COPY . .
WORKDIR "/src/OpenPortsAPI"
RUN dotnet build "OpenPortsAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "OpenPortsAPI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "OpenPortsAPI.dll"]