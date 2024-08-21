# Desafio de Habilidades e Conhecimento Técnico

[![CI/CD Pipeline](https://github.com/albertosou/albertosou-2024-backend-challenge-application/actions/workflows/build-and-deploy.v1.yml/badge.svg)](https://github.com/albertosou/albertosou-2024-backend-challenge-application/actions/workflows/build-and-deploy.v1.yml) [![LinkedIn](https://img.shields.io/badge/LinkedIn-%230077B5.svg?logo=linkedin&logoColor=white)](https://linkedin.com/in/albertosouza) [![GitHub](https://img.shields.io/badge/github-%23121011.svg?logo=github&logoColor=white)](https://github.com/albertosou)

## Descrição do Projeto

Este projeto consiste na construção de um micro serviço em .NET que realiza uma série de validações em um token JWT. A arquitetura adotada é a hexagonal, que separa as camadas em API, Adapters, Ports, Domain e Infrastructure. Além disso, foram criados projetos para Testes Unitários e Testes de Integração.

## Autor

- **Nome:** Alberto Souza  
- **GitHub:** [albertosou](https://github.com/albertosou)
- **LinkedIn:** [albertosouza](https://www.linkedin.com/in/albertosouza/)

## Estrutura do Projeto

- **API:** Camada responsável pela interface com o usuário e controle das requisições.
- **Adapters:** Implementações que conectam a API com o domínio e outras partes do sistema.
- **Ports:** Interfaces que definem as operações que podem ser realizadas.
- **Domain:** Contém a lógica de negócio e as regras de validação.
- **Infrastructure:** Implementações de infraestrutura, como acesso a banco de dados e serviços externos.
- **Testes:** Projetos dedicados a testes unitários e de integração.

## Variáveis de Ambiente
As seguintes variáveis de ambiente precisam ser definidas:
- `AWS_USER_ID=000000000000`
- `AWS_XRAY_REGION=aa-bbbb-1`
- `AWS_XRAY_ACCESS_KEY_ID=22222222222222222222`
- `AWS_XRAY_SECRET_ACCESS_KEY=1111111111111111111111111111111111111111`

# CI/CD Pipeline

Este repositório contém um pipeline CI/CD que automatiza o processo de build, teste e deploy de uma aplicação .NET para o AWS ECS.

## Etapas do Pipeline

1. **Checkout do Código**: Faz checkout do código-fonte do repositório.
2. **Configuração do Ambiente .NET**: Configura o ambiente para a versão do .NET especificada.
3. **Restauração de Dependências**: Restaura as dependências do projeto.
4. **Compilação da Aplicação**: Compila a aplicação.
5. **Execução de Testes**: Executa os testes automatizados.
6. **Construção de Imagens Docker**: Constrói as imagens Docker necessárias.
7. **Login no Amazon ECR**: Faz login no Amazon Elastic Container Registry.
8. **Push das Imagens Docker**: Faz push das imagens Docker para o ECR.
9. **Deploy no AWS ECS**: Atualiza o serviço do ECS para usar a nova imagem.
10. **Notificações**: Notifica o sucesso ou a falha do pipeline.

## Como Usar o Pipeline 

Para usar este pipeline, certifique-se de que as chaves de acesso e outras configurações necessárias estão definidas como segredos no repositório.

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
Abrindo o JWT, as informações contidas atendem a descrição:
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
Abrindo o JWT, a Claim Name possui caracter de números
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
# Documentação Swagger

<img src="doc/img/swagger.png">

## Passos Realizados

1. **Criação do Repositório:** Iniciei o projeto criando um repositório no GitHub.
2. **Documentação:** Adicionei arquivos de documentação em formato Markdown (*.md).
3. **Esqueleto da Arquitetura:** Criei a estrutura base da arquitetura hexagonal utilizando um BAT.
4. **Health Check:** Implementei um serviço básico de Health Check.
5. **Controller:** Desenvolvi um Controller na camada API que atende ao enunciado do desafio.
6. **Teste de Integração:** Implementei testes de integração utilizando o padrão Given-When-Then (GWT).
7. **Refatoração:** Refatorei os projetos "Domain" e "Adapter", incluindo testes unitários com o padrão DDD.
8. **Injeção de Dependência:** Configurei a injeção de dependência no projeto "Infrastructure".
9. **Refatoração da API:** Ajustei o projeto "API" para aderir ao modelo de arquitetura idealizado com DDD.
10. **Logging:** Configurei o Serilog para logging na aplicação.
11. **Postman:** Criei uma coleção de testes no Postman.
12. **Swagger:** Atualizei a documentação no Swagger.
13. **OpenTelemetry:** Substituí o Serilog por AWS Distro for OpenTelemetry (ADOT).

## Desafios Encontrados

- **Docker e AWS:** Ao utilizar a versão .NET 8 com o template de Dockerfile, enfrentei dificuldades ao integrar com AWS e executar o comando `docker compose up -d`. Após várias tentativas, resolvi o problema utilizando .NET 7 e uma solução simplificada.
  
- **OpenTelemetry:** A configuração do container Docker do collector (imagem: amazon/aws-otel-collector:latest) estava incorreta, o que atrasou a implementação. Embora tenha conseguido implementar o AWS X-Ray Collector e deixei a solução bastante evoluida para integrações OpenTelemetry, com soluções como Grafana, Jaeger, Prometheus, Datadog, etc. Não alcancei todos os objetivos planejados.

- **Implantação na AWS:** Iniciei a implantação diretamente em uma máquina EC2 e, após a validação, tentei migrar para um modelo ECS com ECR. Enfrentei problemas de memória provisionada para as tarefas, o que limitou o tempo disponível para concluir a implementação e não consegui terminar de implementar o GitHub Actions.

## Pré-requisitos

Para rodar o projeto, é necessário ter:

- Linux, MacOS ou Windows (Docker Desktop ou WSL)
- .NET 7 SDK / .NET 8 SDK
- dotnet CLI e/ou Visual Studio Code e/ou Microsoft Visual Studio 2022
- Docker
- Git

## Conclusão

Este desafio proporcionou uma rica experiência em desenvolvimento de micro serviços, arquitetura hexagonal, testes e integração com serviços da AWS. Apesar dos desafios enfrentados, consegui implementar a maior parte das funcionalidades planejadas e adquirir novos conhecimentos valiosos ao longo do processo.
