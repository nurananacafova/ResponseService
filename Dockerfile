#FROM nurananajafova/responseservice:v1
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["ResponseService/ResponseService.csproj", "ResponseService/"]
RUN dotnet restore "ResponseService/ResponseService.csproj"
COPY . .
WORKDIR "/src/ResponseService"
RUN dotnet build "ResponseService.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ResponseService.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ResponseService.dll"]
