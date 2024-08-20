# Desafio de Habilidades e Conhecimento T�cnico

## Descri��o do Projeto

Este projeto consiste na constru��o de um micro servi�o em .NET que realiza uma s�rie de valida��es em um token JWT. A arquitetura adotada � a hexagonal, que separa as camadas em API, Adapters, Ports, Domain e Infrastructure. Al�m disso, foram criados projetos para Testes Unit�rios e Testes de Integra��o.

## Autor

**Nome:** Alberto Souza  
**GitHub:** [albertosou](https://github.com/albertosou)

## Estrutura do Projeto

- **API:** Camada respons�vel pela interface com o usu�rio e controle das requisi��es.
- **Adapters:** Implementa��es que conectam a API com o dom�nio e outras partes do sistema.
- **Ports:** Interfaces que definem as opera��es que podem ser realizadas.
- **Domain:** Cont�m a l�gica de neg�cio e as regras de valida��o.
- **Infrastructure:** Implementa��es de infraestrutura, como acesso a banco de dados e servi�os externos.
- **Testes:** Projetos dedicados a testes unit�rios e de integra��o.

# Massa de teste 

### Caso 1:
Entrada:
```
eyJhbGciOiJIUzI1NiJ9.eyJSb2xlIjoiQWRtaW4iLCJTZWVkIjoiNzg0MSIsIk5hbWUiOiJUb25pbmhvIEFyYXVqbyJ9.QY05sIjtrcJnP533kQNk8QXcaleJ1Q01jWY_ZzIZuAg
```
Saida:
```
verdadeiro
```
Justificativa:
Abrindo o JWT, as informa��es contidas atendem a descri��o:
```json
{
  "Role": "Admin",
  "Seed": "7841",
  "Name": "Toninho Araujo"
}
```

### Caso 2:
Entrada:
```
eyJhbGciOiJzI1NiJ9.dfsdfsfryJSr2xrIjoiQWRtaW4iLCJTZrkIjoiNzg0MSIsIk5hbrUiOiJUb25pbmhvIEFyYXVqbyJ9.QY05fsdfsIjtrcJnP533kQNk8QXcaleJ1Q01jWY_ZzIZuAg
```
Saida:
```
falso
```
Justificativa:
JWT invalido

### Caso 3:
Entrada:
```
eyJhbGciOiJIUzI1NiJ9.eyJSb2xlIjoiRXh0ZXJuYWwiLCJTZWVkIjoiODgwMzciLCJOYW1lIjoiTTRyaWEgT2xpdmlhIn0.6YD73XWZYQSSMDf6H0i3-kylz1-TY_Yt6h1cV2Ku-Qs
```
Saida:
```
falso
```
Justificativa:
Abrindo o JWT, a Claim Name possui caracter de n�meros
```json
{
  "Role": "External",
  "Seed": "72341",
  "Name": "M4ria Olivia"
}
```

### Caso 4:
Entrada:
```
eyJhbGciOiJIUzI1NiJ9.eyJSb2xlIjoiTWVtYmVyIiwiT3JnIjoiQlIiLCJTZWVkIjoiMTQ2MjciLCJOYW1lIjoiVmFsZGlyIEFyYW5oYSJ9.cmrXV_Flm5mfdpfNUVopY_I2zeJUy4EZ4i3Fea98zvY
```
Saida:
```
falso
```
Justificativa:
Abrindo o JWT, foi encontrado mais de 3 claims.
```json
{
  "Role": "Member",
  "Org": "BR",
  "Seed": "14627",
  "Name": "Valdir Aranha"
}
```


## Passos Realizados

1. **Cria��o do Reposit�rio:** Iniciei o projeto criando um reposit�rio no GitHub.
2. **Documenta��o:** Adicionei arquivos de documenta��o em formato Markdown (*.md).
3. **Esqueleto da Arquitetura:** Criei a estrutura base da arquitetura hexagonal utilizando um BAT.
4. **Health Check:** Implementei um servi�o b�sico de Health Check.
5. **Controller:** Desenvolvi um Controller na camada API que atende ao enunciado do desafio.
6. **Teste de Integra��o:** Implementei testes de integra��o utilizando o padr�o Given-When-Then (GWT).
7. **Refatora��o:** Refatorei os projetos "Domain" e "Adapter", incluindo testes unit�rios com o padr�o DDD.
8. **Inje��o de Depend�ncia:** Configurei a inje��o de depend�ncia no projeto "Infrastructure".
9. **Refatora��o da API:** Ajustei o projeto "API" para aderir ao modelo de arquitetura idealizado com DDD.
10. **Logging:** Configurei o Serilog para logging na aplica��o.
11. **Postman:** Criei uma cole��o de testes no Postman.
12. **Swagger:** Atualizei a documenta��o no Swagger.
13. **OpenTelemetry:** Substitu� o Serilog por AWS Distro for OpenTelemetry (ADOT).

## Desafios Encontrados

- **Docker e AWS:** Ao utilizar a vers�o .NET 8 com o template de Dockerfile, enfrentei dificuldades ao integrar com AWS e executar o comando `docker compose up -d`. Ap�s v�rias tentativas, resolvi o problema utilizando .NET 7 e uma solu��o simplificada.
  
- **OpenTelemetry:** A configura��o do container Docker do collector (imagem: amazon/aws-otel-collector:latest) estava incorreta, o que atrasou a implementa��o. Embora tenha conseguido implementar o AWS X-Ray Collector, n�o alcancei todos os objetivos planejados.

- **Implanta��o na AWS:** Iniciei a implanta��o diretamente em uma m�quina EC2 e, ap�s a valida��o, tentei migrar para um modelo ECS com ECR. Enfrentei problemas de mem�ria provisionada para as tarefas, o que limitou o tempo dispon�vel para concluir a implementa��o.

## Pr�-requisitos

Para rodar o projeto, � necess�rio ter:

- Linux, MacOS ou Windows (Docker Desktop ou WSL)
- .NET 7 SDK / .NET 8 SDK
- dotnet CLI e/ou Visual Studio Code e/ou Microsoft Visual Studio 2022
- Docker
- Git

## Conclus�o

Este desafio proporcionou uma rica experi�ncia em desenvolvimento de micro servi�os, arquitetura hexagonal, testes e integra��o com servi�os da AWS. Apesar dos desafios enfrentados, consegui implementar a maior parte das funcionalidades planejadas e adquirir novos conhecimentos valiosos ao longo do processo.
