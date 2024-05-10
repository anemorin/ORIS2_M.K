FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["PokemonsAPI/PokemonsAPI.csproj", "PokemonsAPI/"]
RUN dotnet restore "PokemonsAPI/PokemonsAPI.csproj"
COPY . .
WORKDIR "/src/PokemonsAPI"
RUN dotnet build "PokemonsAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PokemonsAPI.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PokemonsAPI.dll"]
