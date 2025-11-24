TransformeseSolution

Sistema modular composto por API, MVC Web e Aplicação Desktop, integrados por uma arquitetura em camadas para centralizar regras de negócio e acesso a dados.

📘 Visão Geral

O projeto TransformeseSolution demonstra um ecossistema completo com:

Transformese.Api → API REST centralizada

Transformese.Web (MVC) → Cliente web consumindo a API

Transformese.Desktop → Cliente Desktop também consumindo a API

Transformese.Domain → Entidades e regras de negócio

Transformese.Data → Repositórios, EF e persistência

Transformese.DTO → Objetos de transferência usados entre clientes e API

Todos os clientes consomem apenas a API como porta única para manipulação de dados.

🧱 Estrutura da Solução
/TransformeseSolution.sln
│
├── Transformese.Api
│     └─ API REST (Controllers, Endpoints, Swagger)
│
├── Transformese.Web
│     └─ Projeto MVC que consome a API via HttpClient
│
├── Transformese.Desktop
│     └─ Aplicação Desktop (WinForms ou WPF) consumindo a API
│
├── Transformese.Domain
│     └─ Entidades e regras de negócio
│
├── Transformese.Data
│     └─ EF Core, contexto, migrations, repositórios
│
└── Transformese.DTO
      └─ Objetos de Transferência (DTOs)

🛠 Tecnologias Utilizadas

.NET 7 / 8

ASP.NET Core Web API

ASP.NET MVC

Windows Forms / WPF

Entity Framework Core

SQL Server / SQL Express

Swagger / OpenAPI

HttpClient

Arquitetura em camadas (Domain → Data → API → Clientes)

🚀 Executando o Projeto Localmente
1. Clonar o repositório
git clone https://github.com/luanps2/TransformeseSolution.git

2. Abrir a solução

Abra TransformeseSolution.sln no Visual Studio 2022 ou superior.

3. Configurar o banco

Edite a connection string no projeto da API:
Transformese.Api/appsettings.json

4. Restaurar pacotes e compilar

O Visual Studio fará isso automaticamente.

5. Executar a API

Defina o projeto Transformese.Api como “Start Project” e execute.

Ela exporá os endpoints e abrirá o Swagger em:

https://localhost:5001/swagger

6. Executar o cliente Web (MVC)

Após a API estar no ar, execute Transformese.Web.

7. Executar o cliente Desktop

Certifique-se de que o Desktop esteja apontando para a mesma URL da API.

🔌 Fluxo de Comunicação

Web e Desktop enviam requisições para a API

A API valida, processa e chama a camada Domain

Domain utiliza a camada Data para persistência

Retorno volta para Web ou Desktop em forma de DTO

📄 Documentação da API (Swagger)

Ao executar a API, a documentação ficará disponível em:

/swagger/index.html


Inclui:

Endpoints

Modelos

Exemplos de requisição/resposta

Testes diretos pelo navegador

📊 Roadmap
Em andamento

Padronização dos endpoints

Separação clara entre DTOs e entidades

Refatoração do MVC para consumir apenas a API

Próximos passos

Implementar autenticação (JWT)

Criar testes unitários (xUnit ou MSTest)

Adicionar camadas de Service para regras mais complexas

Criar Dockerfile para API

Disponibilizar versão publicada da API no Azure

🔐 Segurança (Planejado)

JWT Authentication

Refresh Tokens

Perfis de usuário (Admin, Aluno, Professor)

🧪 Testes (Planejado)

Testes de API com xUnit

Testes de repositório com InMemoryDatabase

Testes de integração para endpoints críticos

🧩 Padrões e Boas Práticas Utilizados

DTOs entre API ↔ Clientes

Repository Pattern

Separação Domain/Data

MVC usando exclusivamente HttpClient

Centralização de serviços na API

Respostas padronizadas (status codes + mensagens)
