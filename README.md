# Plataforma de Geração de Leads MRV

Este projeto tem como objetivo fornecer uma solução robusta para gerenciamento de leads, implementando diversas tecnologias e práticas avançadas. Abaixo estão listados os principais desafios abordados no projeto:

## Desafios

1. **Conexão com SQL Server**: Implementação de uma conexão eficiente com o banco de dados SQL Server para armazenamento e recuperação de dados.

2. **CQRS com MediatR**: Utilização do padrão CQRS (Command Query Responsibility Segregation) em conjunto com a biblioteca MediatR para separação de comandos e consultas, promovendo uma arquitetura mais coesa e escalável.

3. **Mensageria com RabbitMQ**: Utilização do RabbitMQ como serviço de mensageria, garantindo uma comunicação assíncrona e desacoplada.

4. **Registro de Log com MongoDb (EventSourcing)**: Implementação de um sistema de registro de logs utilizando o banco de dados NoSQL MongoDb, visando uma melhor rastreabilidade e monitoramento da aplicação.

5. **Docker Compose**: Utilização do Docker Compose para facilitar o ambiente de desenvolvimento, permitindo a criação e configuração automatizada dos serviços necessários, tais como SQL Server, MongoDb e RabbitMQ.

## Instruções de Uso

### Pré-requisitos
- Clone este repositório em sua máquina local.

- Instale o Docker Desktop ou Docker CLI em seu ambiente de desenvolvimento.

### Configuração do Ambiente
1. Navegue até a pasta do projeto onde está localizado o arquivo `docker-compose.yml`.

2. Execute o seguinte comando no terminal para iniciar os serviços Docker necessários:
   ```
   docker-compose up -d
   ```

### Configuração do Banco de Dados
1. Abra o console de gerenciador de pacotes em sua IDE e selecione o projeto `src\MRV.Leads.Platform.Infrastructure`.

2. Execute o comando `dotnet ef database update --project src\MRV.Leads.Platform.Infrastructure\MRV.Leads.Platform.Infrastructure.csproj --startup-project src\MRV.Leads.Platform.Api\MRV.Leads.Platform.Api.csproj` para criar o banco de dados `MRV` no SQL Server.

### Dados de Conexão

#### Banco de Dados (SQL Server)
- **Host:** localhost
- **Database:** MRV
- **Username:** sa
- **Password:** Secret@123

#### RabbitMQ
- **Host:** http://localhost:15672
- **Username:** guest
- **Password:** guest

#### MongoDB (Mongo DB Compass)
- **Host:** mongodb://localhost:27017
- **Database:** MRVLeadLogs

# Plano de Execução

## BackEnd
Ao executar a API MRV.Leads.Platform.Api, e acionar um POST pelo swagger de `Intents/{id}/accept`, o sistema irá:
1. setar o intent para accept (status 0);
2. verificar aplicação de desconto;
3. persistir o objeto intent no banco de dados;
4. produzir uma mensagem RabbitMQ que será enfileirada na fila denominada `intent.accepted.queue`;
5. registrar um log da operação com event sourcing;

   -Foi Criado uma background para processar a leitura das mensagens no rabbitMQ, após essa leitura
    será feito o "envio de e-mail" - escrita em uma arquivo fake_email.txt (estará no diretório MRV.Leads.Platform.Api);

## FrontEnd
1. Clone o repositório;
2. Execute o comando: npm i;
3. Execute o comando: ng serve
