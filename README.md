# TransformeseSolution  
Integração completa entre **API**, **MVC Web** e **Aplicação Desktop**, utilizando arquitetura em camadas para centralizar regras de negócio e acesso a dados.

---

## 📌 Status do Projeto  
![Static Badge](https://img.shields.io/badge/Status-Em%20Desenvolvimento-blue)  
![Static Badge](https://img.shields.io/badge/.NET-8.0-blueviolet)  
![Static Badge](https://img.shields.io/badge/Arquitetura-Camadas-green)  
![Static Badge](https://img.shields.io/badge/API-REST-orange)

---

## 📘 Visão Geral  
O projeto **TransformeseSolution** demonstra uma arquitetura moderna formada por:

- **Transformese.Api** → API REST centralizada  
- **Transformese.Web (MVC)** → Aplicação Web que consome a API  
- **Transformese.Desktop** → Aplicação Desktop consumindo a API  
- **Transformese.Domain** → Entidades e regras de negócio  
- **Transformese.Data** → Acesso a dados, EF Core e repositórios  
- **Transformese.DTO** → Objetos de transferência usados pela API

A regra principal:  
**toda comunicação com o banco ocorre exclusivamente pela API**.  
Web e Desktop são apenas clientes.

---

## 🧱 Estrutura da Solução

```
TransformeseSolution.sln
│
├── Transformese.Api
│     └─ API REST (Controllers, Endpoints, Swagger)
│
├── Transformese.Web
│     └─ Projeto MVC consumindo API via HttpClient
│
├── Transformese.Desktop
│     └─ Aplicação Desktop (WinForms ou WPF) consumindo API
│
├── Transformese.Domain
│     └─ Entidades e regras de negócio
│
├── Transformese.Data
│     └─ EF Core, contexto, migrations, repositórios
│
└── Transformese.DTO
      └─ Objetos de Transferência (DTOs)
```

---

## 🛠 Tecnologias Utilizadas

- .NET 7 / 8  
- ASP.NET Core Web API  
- ASP.NET MVC  
- Windows Forms / WPF  
- Entity Framework Core  
- SQL Server  
- Swagger / OpenAPI  
- HttpClient  
- Arquitetura em camadas

---

## 🚀 Como Executar o Projeto

### 1. Clone o repositório  
```bash
git clone https://github.com/luanps2/TransformeseSolution.git
```

### 2. Abra no Visual Studio  
Abra o arquivo `TransformeseSolution.sln`.

### 3. Configure o banco  
Edite a connection string no arquivo:

```
Transformese.Api/appsettings.json
```

### 4. Execute a API  
A API deve ser iniciada primeiro.

Ela abrirá o Swagger em:

```
https://localhost:5001/swagger
```

### 5. Execute o MVC  
Após a API estar rodando:

```
Transformese.Web
```

### 6. Execute o Desktop  
Certifique-se de que o Desktop esteja configurado para chamar a mesma URL base da API.

---

## 🔌 Fluxo de Comunicação

```
[MVC]  ────┐
           ├──→  API  → Domain → Data → Banco
[Desktop] ─┘
```

---

## 📄 Documentação da API — Swagger

A documentação fica disponível automaticamente em:

```
/swagger
```

Inclui:

- Modelos  
- Endpoints  
- Exemplos de requisição  
- Testes diretos no navegador  

---

## 📊 Roadmap

### Em andamento  
- Padronização dos endpoints  
- Refatoração completa do MVC para consumir somente a API  
- Normalização dos DTOs

### Próximas etapas  
- Implementar autenticação JWT  
- Criar testes unitários (xUnit)  
- Criar Dockerfile para a API  
- Publicar a API no Azure

---

## 🔐 Segurança (Planejado)

- JWT Authentication  
- Refresh Tokens  
- Perfis de usuário

---

## 🧪 Testes (Planejado)

- Testes unitários (xUnit)  
- Testes de repositório com banco em memória  
- Testes de integração dos endpoints

---

## 🧩 Boas Práticas da Solução

- Não expor entidades do domínio pela API  
- Controllers finos, lógicos em services  
- MVC e Desktop consomem somente a API  
- Uso correto de DTOs  
- Repositórios separados  
- Endpoints REST padronizados  
- Uso de async/await em toda I/O  
- Migrations organizadas

---

## 📜 Licença  
Este repositório pode utilizar a licença MIT ou outra de sua preferência.

---

## ✨ Autor  
Projeto desenvolvido por **Luan Costa** para fins educacionais e demonstração de arquitetura profissional para os alunos do projeto **Transforme-se**.

