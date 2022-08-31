FROM mcr.microsoft.com/dotnet/sdk:6.0-alpine AS publish
WORKDIR /src
COPY ["AgentApplication.WebAPI/AgentApplication.WebAPI.csproj", "AgentApplication.WebAPI/"]

RUN dotnet restore "AgentApplication.WebAPI/AgentApplication.WebAPI.csproj" --runtime alpine-x64
COPY . .
RUN dotnet publish "AgentApplication.WebAPI/AgentApplication.WebAPI.csproj" -c Release -o /app/publish \
    --no-restore \
    --runtime alpine-x64 \
    --self-contained true \
    /p:PublishTrimmed=true \
    /p:PublishSingleFile=true

FROM mcr.microsoft.com/dotnet/runtime-deps:6.0-alpine AS final
WORKDIR /app

EXPOSE 80
COPY --from=publish /app/publish .

ENTRYPOINT ["./AgentApplication.WebAPI"]