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
