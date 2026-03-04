# Comercial API

Uma API RESTful desenvolvida em .NET 8 para gerenciamento de clientes, endereços e contatos comerciais.

## 📋 Sobre o Projeto

O projeto Comercial é uma aplicação web API que permite o cadastro e gerenciamento de informações de clientes, incluindo seus endereços e contatos telefônicos. A aplicação utiliza Entity Framework Core com SQL Server LocalDB e segue uma arquitetura em camadas.

## 🚀 Tecnologias Utilizadas

- **.NET 8.0**
- **C# 12.0**
- **ASP.NET Core Web API**
- **Entity Framework Core** (com Lazy Loading Proxies)
- **SQL Server LocalDB**
- **Swagger/OpenAPI** (para documentação da API)

## 🏗️ Arquitetura do Projeto

O projeto está organizado em três camadas principais:

```
Comercial/
├── Comercial.API/              # Camada de apresentação (Controllers e API)
├── Comercial.Shared.Dados/     # Camada de acesso a dados (DbContext, DAL, Migrations)
└── Comercial.Shared.Modelos/   # Camada de domínio (Entidades e Models)
```

### Estrutura de Entidades

- **Cliente**: Informações básicas do cliente (Nome, Email, CPF, RG)
- **Endereco**: Endereços associados aos clientes
- **Contato**: Telefones de contato dos clientes

## 🔧 Pré-requisitos

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [SQL Server LocalDB](https://learn.microsoft.com/sql/database-engine/configure-windows/sql-server-express-localdb)
- Visual Studio 2022 ou superior (ou Visual Studio Code com extensões C#)

## ⚙️ Configuração e Instalação

1. **Clone o repositório**
   ```bash
   git clone https://github.com/marcelodewiz/Comercial.git
   cd Comercial
   ```

2. **Restaure as dependências**
   ```bash
   dotnet restore
   ```

3. **Configure o banco de dados**
   
   A string de conexão padrão já está configurada para usar LocalDB:
   ```
   Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Comercial;Integrated Security=True
   ```

4. **Execute as migrations**
   ```bash
   cd Comercial.Shared.Dados
   dotnet ef database update
   ```

5. **Execute a aplicação**
   ```bash
   cd ../Comercial.API
   dotnet run
   ```

6. **Acesse a documentação Swagger**
   
   Abra o navegador em: `https://localhost:<porta>/swagger`

## 📡 Endpoints da API

### Clientes

- **GET** `/Cliente` - Lista todos os clientes
  - Parâmetros de filtro: `nome`, `email`, `cpf`, `rg`
- **POST** `/Cliente` - Cria um novo cliente
- **PUT** `/Cliente` - Atualiza um cliente existente
- **DELETE** `/Cliente/{id}` - Remove um cliente

### Endereços

- **GET** `/Endereco` - Lista todos os endereços
- **POST** `/Endereco` - Cria um novo endereço
- **PUT** `/Endereco` - Atualiza um endereço existente
- **DELETE** `/Endereco/{id}` - Remove um endereço

### Contatos

- **GET** `/Contato` - Lista todos os contatos
- **POST** `/Contato` - Cria um novo contato
- **PUT** `/Contato` - Atualiza um contato existente
- **DELETE** `/Contato/{id}` - Remove um contato

## 📦 Modelos de Dados

### Cliente
```csharp
{
  "nome": "string",
  "email": "string",
  "cpf": "string",
  "rg": "string"
}
```

### Endereço
```csharp
{
  "tipo": "string",
  "cep": "string",
  "logradouro": "string",
  "numero": 0,
  "bairro": "string",
  "complemento": "string",
  "cidade": "string",
  "estado": "string",
  "referencia": "string",
  "clienteId": 0
}
```

### Contato
```csharp
{
  "tipo": "string",
  "ddd": 0,
  "telefone": 0,
  "clienteId": 0
}
```

## 🔨 Comandos Úteis

### Criar uma nova migration
```bash
cd Comercial.Shared.Dados
dotnet ef migrations add NomeDaMigration
```

### Atualizar o banco de dados
```bash
dotnet ef database update
```

### Compilar a solução
```bash
dotnet build
```

### Executar testes (se houver)
```bash
dotnet test
```

## 🛠️ Desenvolvimento

### Padrões Utilizados

- **Repository Pattern**: Implementado através da classe genérica `DAL<T>`
- **Dependency Injection**: Configurado no `Program.cs`
- **Lazy Loading**: Habilitado para relacionamentos entre entidades
- **Data Annotations**: Para validação e configuração de modelos

## 📝 Licença

Este projeto está sob a licença MIT. Veja o arquivo [LICENSE](LICENSE) para mais detalhes.

## 👤 Autor

**Marcelo Dewiz**

- GitHub: [@marcelodewiz](https://github.com/marcelodewiz)




