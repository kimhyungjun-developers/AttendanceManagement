FROM mcr.microsoft.com/dotnet/sdk:6.0-alpine AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0-alpine AS build
WORKDIR /src
COPY ["backend/WebAPI/WebAPI.csproj", "backend/WebAPI"]
RUN dotnet restore "backend/WebAPI/WebAPI.csproj"
COPY . .
WORKDIR "/src/backend/WebAPI"
RUN dotnet build -c "WebAPI.csproj"　Release -o /app/build

FROM build AS publish
RUN dotnet publish -c "WebAPI.csproj" Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WebAPI.dll"]
