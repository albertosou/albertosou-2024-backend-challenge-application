FROM mcr.microsoft.com/dotnet/sdk:7.0-alpine AS build-env
WORKDIR /app

COPY ./ ./

WORKDIR /app/test/AlbertoSouza.AppBackendChallenge.Test/
RUN dotnet restore | dotnet test

WORKDIR /app/src/AlbertoSouza.AppBackendChallenge/
RUN dotnet publish -c Release -o /app/out

FROM mcr.microsoft.com/dotnet/aspnet:7.0-alpine
WORKDIR /app
COPY --from=build-env /app/out .

ENTRYPOINT ["dotnet", "AlbertoSouza.AppBackendChallenge.dll"]