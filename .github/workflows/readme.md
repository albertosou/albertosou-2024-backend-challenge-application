# CI/CD Pipeline

Este workflow realiza as seguintes etapas:
1. Faz checkout do código-fonte.
2. Configura o ambiente .NET.
3. Instalação do Docker Compose.
4. Restaura as dependências do projeto.
5. Compila a aplicação.
6. Executa os testes.
7. Constrói as imagens Docker.
8. Faz login no Amazon ECR.
9. Faz push das imagens Docker para o ECR.
10. Atualiza o serviço do ECS para usar a nova imagem.
11. Notifica o sucesso do pipeline
12. Notifica a falha do pipeline

## Lista de secrets necessárias
1. AWS_ACCESS_KEY_ID
2. AWS_SECRET_ACCESS_KEY
3. AWS_REGION
4. AWS_XRAY_ACCESS_KEY_ID
5. AWS_XRAY_SECRET_ACCESS_KEY
6. AWS_XRAY_REGION
7. AWS_USER_ID

## Fluxo de Trabalho
Este pipeline é acionado quando há um push ou um pull request para a branch `master`. Ele executa os seguintes passos:

1. **Checkout do código-fonte**: Faz o checkout do código-fonte do repositório.
2. **Configuração do ambiente .NET**: Configura o ambiente .NET com a versão especificada.
3. **Instalação do Docker Compose**: Instala o Docker Compose no ambiente.
4. **Restauração de dependências**: Restaura as dependências do projeto.
5. **Compilação da aplicação**: Compila a aplicação.
6. **Execução dos testes**: Executa os testes da aplicação.
7. **Construção das imagens Docker**: Constrói as imagens Docker da aplicação.
8. **Login no Amazon ECR**: Faz login no Amazon ECR usando as credenciais fornecidas pelos secrets.
9. **Push das imagens Docker para o ECR**: Faz o push das imagens Docker construídas para o Amazon ECR.
10. **Atualização do serviço do ECS**: Atualiza o serviço do ECS para usar a nova imagem.
11. **Notificação de sucesso**: Envia uma notificação de sucesso, caso o pipeline seja executado com êxito.
12. **Notificação de falha**: Envia uma notificação de falha, caso o pipeline falhe em alguma etapa.

## Configuração
Para utilizar este pipeline, é necessário configurar os seguintes secrets no seu repositório:

- `AWS_ACCESS_KEY_ID`: Chave de acesso da sua conta AWS.
- `AWS_SECRET_ACCESS_KEY`: Chave secreta da sua conta AWS.
- `AWS_REGION`: Região da sua conta AWS.
- `AWS_XRAY_ACCESS_KEY_ID`: Chave de acesso do AWS X-Ray.
- `AWS_XRAY_SECRET_ACCESS_KEY`: Chave secreta do AWS X-Ray.
- `AWS_XRAY_REGION`: Região do AWS X-Ray.
- `AWS_USER_ID`: ID do usuário da sua conta AWS.

Certifique-se de que esses secrets estejam configurados corretamente para que o pipeline possa ser executado com sucesso.