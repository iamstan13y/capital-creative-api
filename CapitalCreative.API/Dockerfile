FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["CapitalCreative.API/CapitalCreative.API.csproj", "CapitalCreative.API/"]
RUN dotnet restore "CapitalCreative.API/CapitalCreative.API.csproj"
COPY . .
WORKDIR "/src/CapitalCreative.API"
RUN dotnet build "CapitalCreative.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CapitalCreative.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CapitalCreative.API.dll"]