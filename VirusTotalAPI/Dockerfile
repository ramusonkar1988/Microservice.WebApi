#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["VirusTotalAPI/VirusTotalAPI.csproj", "VirusTotalAPI/"]
COPY ["VirusTotal.Service/VirusTotal.Service.csproj", "VirusTotal.Service/"]
COPY ["VirusTotal.Model/VirusTotal.Model.csproj", "VirusTotal.Model/"]
RUN dotnet restore "VirusTotalAPI/VirusTotalAPI.csproj"
COPY . .
WORKDIR "/src/VirusTotalAPI"
RUN dotnet build "VirusTotalAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "VirusTotalAPI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "VirusTotalAPI.dll"]