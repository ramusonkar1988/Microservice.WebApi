#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["GeoIP.Microservice/GeoIP.Microservice.csproj", "GeoIP.Microservice/"]
COPY ["GeoIP.Service/GeoIP.Service.csproj", "GeoIP.Service/"]
COPY ["GeoIP.Model/GeoIP.Model.csproj", "GeoIP.Model/"]
RUN dotnet restore "GeoIP.Microservice/GeoIP.Microservice.csproj"
COPY . .
WORKDIR "/src/GeoIP.Microservice"
RUN dotnet build "GeoIP.Microservice.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "GeoIP.Microservice.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "GeoIP.Microservice.dll"]