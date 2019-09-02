FROM mcr.microsoft.com/dotnet/core/aspnet:2.2 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:2.2 AS build
WORKDIR /src
COPY ["20.azds.hpa.csproj", "."]
RUN dotnet restore "20.azds.hpa.csproj"
COPY . .
RUN dotnet build "20.azds.hpa.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "20.azds.hpa.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "20.azds.hpa.dll"]