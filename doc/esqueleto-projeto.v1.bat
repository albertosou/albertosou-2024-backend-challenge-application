echo Criando Estrutura

dotnet new sln -n AlbertoSouza.BackendChallengeApplication
dotnet new webapi   -n AlbertoSouza.BackendChallengeApplication.Api       -o src/AlbertoSouza.BackendChallengeApplication.Api      -f net8.0 -controllers  
dotnet new classlib -n AlbertoSouza.BackendChallengeApplication.Domain    -o src/AlbertoSouza.BackendChallengeApplication.Domain   -f net8.0 
dotnet new classlib -n AlbertoSouza.BackendChallengeApplication.Adapters  -o src/AlbertoSouza.BackendChallengeApplication.Adapters -f net8.0 
dotnet new classlib -n AlbertoSouza.BackendChallengeApplication.Ports     -o src/AlbertoSouza.BackendChallengeApplication.Ports    -f net8.0 
dotnet new classlib -n AlbertoSouza.BackendChallengeApplication.Infra     -o src/AlbertoSouza.BackendChallengeApplication.Infra    -f net8.0 

dotnet sln add ./src/AlbertoSouza.BackendChallengeApplication.Api/AlbertoSouza.BackendChallengeApplication.Api.csproj
dotnet sln add ./src/AlbertoSouza.BackendChallengeApplication.Domain/AlbertoSouza.BackendChallengeApplication.Domain.csproj
dotnet sln add ./src/AlbertoSouza.BackendChallengeApplication.Adapters/AlbertoSouza.BackendChallengeApplication.Adapters.csproj
dotnet sln add ./src/AlbertoSouza.BackendChallengeApplication.Ports/AlbertoSouza.BackendChallengeApplication.Ports.csproj
dotnet sln add ./src/AlbertoSouza.BackendChallengeApplication.Infra/AlbertoSouza.BackendChallengeApplication.Infra.csproj

echo Adicionando Referencias Aplicacao
dotnet add ./src/AlbertoSouza.BackendChallengeApplication.Api/AlbertoSouza.BackendChallengeApplication.Api.csproj reference ./src/AlbertoSouza.BackendChallengeApplication.Infra/AlbertoSouza.BackendChallengeApplication.Infra.csproj ./src/AlbertoSouza.BackendChallengeApplication.Ports/AlbertoSouza.BackendChallengeApplication.Ports.csproj
dotnet add ./src/AlbertoSouza.BackendChallengeApplication.Adapters/AlbertoSouza.BackendChallengeApplication.Adapters.csproj reference ./src/AlbertoSouza.BackendChallengeApplication.Domain/AlbertoSouza.BackendChallengeApplication.Domain.csproj ./src/AlbertoSouza.BackendChallengeApplication.Ports/AlbertoSouza.BackendChallengeApplication.Ports.csproj
dotnet add ./src/AlbertoSouza.BackendChallengeApplication.Infra/AlbertoSouza.BackendChallengeApplication.Infra.csproj reference ./src/AlbertoSouza.BackendChallengeApplication.Adapters/AlbertoSouza.BackendChallengeApplication.Adapters.csproj ./src/AlbertoSouza.BackendChallengeApplication.Ports/AlbertoSouza.BackendChallengeApplication.Ports.csproj

echo Adicionando Referencias Pacotes
