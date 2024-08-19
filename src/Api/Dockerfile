FROM mcr.microsoft.com/dotnet/sdk:7.0-alpine AS build-env
WORKDIR /app

COPY . ./
RUN dotnet restore
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:7.0-alpine
WORKDIR /app
COPY --from=build-env /app/out .

ENTRYPOINT ["dotnet", "AlbertoSouza.BackendChallengeApplication.Api.dll"]

#	FROM mcr.microsoft.com/dotnet/sdk:7.0-alpine AS build-env
#	WORKDIR /app
#	
#	# Copy project files
#	COPY ./src/AlbertoSouza.BackendChallengeApplication.Adapters/*.csproj ./src/AlbertoSouza.BackendChallengeApplication.Adapters/
#	COPY ./src/AlbertoSouza.BackendChallengeApplication.Domain/*.csproj ./src/AlbertoSouza.BackendChallengeApplication.Domain/
#	COPY ./src/AlbertoSouza.BackendChallengeApplication.Infra/*.csproj ./src/AlbertoSouza.BackendChallengeApplication.Infra/
#	COPY ./src/AlbertoSouza.BackendChallengeApplication.Ports/*.csproj ./src/AlbertoSouza.BackendChallengeApplication.Ports/
#	COPY ./src/AlbertoSouza.BackendChallengeApplication.Api/*.csproj ./src/AlbertoSouza.BackendChallengeApplication.Api/
#	
#	# Restore dependencies
#	RUN dotnet restore ./src/AlbertoSouza.BackendChallengeApplication.Api/AlbertoSouza.BackendChallengeApplication.Api.csproj
#	
#	# Copy the rest of the code
#	COPY ./src ./src
#	
#	# Build the application
#	RUN dotnet publish -c Release -o out ./src/AlbertoSouza.BackendChallengeApplication.Api/AlbertoSouza.BackendChallengeApplication.Api.csproj
#	
#	FROM mcr.microsoft.com/dotnet/aspnet:7.0-alpine
#	WORKDIR /app
#	COPY --from=build-env /app/out .
#	ENTRYPOINT ["dotnet", "AlbertoSouza.BackendChallengeApplication.Api.dll"]