FROM mcr.microsoft.com/dotnet/sdk:8.0.101 AS build-env
WORKDIR /app

EXPOSE 8080
EXPOSE 8081

# Copiar csproj e restaurar dependencias
COPY *.csproj ./
RUN dotnet restore

# Build da aplicacao
COPY . ./
RUN dotnet publish -c Release -o out

# Build da imagem
FROM mcr.microsoft.com/dotnet/aspnet:8.0.1
WORKDIR /app
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "AlbertoSouza.BackendChallengeApplication.Api.dll"]