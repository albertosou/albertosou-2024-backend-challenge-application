FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["src/AlbertoSouza.BackendChallengeApplication.Api/AlbertoSouza.BackendChallengeApplication.Api.csproj", "src/AlbertoSouza.BackendChallengeApplication.Api/"]
COPY ["src/AlbertoSouza.BackendChallengeApplication.Ports/AlbertoSouza.BackendChallengeApplication.Ports.csproj", "src/AlbertoSouza.BackendChallengeApplication.Ports/"]
COPY ["src/AlbertoSouza.BackendChallengeApplication.Adapters/AlbertoSouza.BackendChallengeApplication.Adapters.csproj", "src/AlbertoSouza.BackendChallengeApplication.Adapters/"]
COPY ["src/AlbertoSouza.BackendChallengeApplication.Domain/AlbertoSouza.BackendChallengeApplication.Domain.csproj", "src/AlbertoSouza.BackendChallengeApplication.Domain/"]
COPY ["src/AlbertoSouza.BackendChallengeApplication.Infra/AlbertoSouza.BackendChallengeApplication.Infra.csproj", "src/AlbertoSouza.BackendChallengeApplication.Infra/"]
RUN dotnet restore "src/AlbertoSouza.BackendChallengeApplication.Api/AlbertoSouza.BackendChallengeApplication.Api.csproj"
COPY . .
WORKDIR "/src/src/AlbertoSouza.BackendChallengeApplication.Api"
RUN dotnet build "AlbertoSouza.BackendChallengeApplication.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "AlbertoSouza.BackendChallengeApplication.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

ENTRYPOINT ["dotnet", "AlbertoSouza.BackendChallengeApplication.Api.dll"]