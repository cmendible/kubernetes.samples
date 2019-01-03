FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY ["temperature-azds.csproj", "."]
RUN dotnet restore "temperature-azds.csproj"
COPY . .
RUN dotnet build "temperature-azds.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "temperature-azds.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "temperature-azds.dll"]