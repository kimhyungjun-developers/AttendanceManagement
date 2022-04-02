#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/sdk:6.0-alpine AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0-alpine AS build
WORKDIR /src
COPY ["Model/Model.csproj", "Model/"]
COPY ["Service/BuySellApi.Core.csproj", "Service/"]
COPY ["UnitTest/BuySellApi.Data.csproj", "UnitTest/"]
RUN dotnet restore "backend/WebAPI/WebAPI.csproj"
COPY . .
WORKDIR "/src/"
RUN dotnet build "WebAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "WebAPI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WebAPI.dll"]
