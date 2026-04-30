# CP2 - API de Locação de Veículos

API REST desenvolvida em ASP.NET Core para gerenciamento de frotas e simulação de custos de locação com descontos progressivos.

## Tecnologias
- **Framework:** ASP.NET Core 10.0 (Web API)
- **Banco de Dados:** Oracle Database
- **ORM:** Entity Framework Core
- **Documentação:** Swagger (OpenAPI)
- **Linguagem:** C#

## Funcionalidades

### Gestão de Carros (CRUD)
- Cadastro de veículos (Modelo, Marca, Ano, Valor da Diária).
- Listagem, consulta por ID, atualização e exclusão de registros.
- Persistência de dados em base Oracle.

### Simulador de Locação
- Endpoint especializado: `POST /api/locacoes/calcular`.
- Lógica de negócio integrada:
  - **3 a 6 dias:** 5% de desconto.
  - **7 dias ou mais:** 10% de desconto.
- Retorno formatado com subtotal, percentual de desconto aplicado e valor final.

## Requisitos de Execução
- SDK .NET 10.0
- Instância Oracle Database ativa.
- Ferramenta `dotnet-ef` instalada globalmente.

## Configuração

1. **Conexão com Banco:**
   Atualize a string de conexão no arquivo `appsettings.json`:
   ```json
   "ConnectionStrings": {
     "OracleConnection": "User Id=SEU_USUARIO;Password=SUA_SENHA;Data Source=localhost:1521/ORCL"
   }
   ```

2. **Migrações e Banco de Dados:**
   Execute os comandos abaixo na raiz do projeto para criar a estrutura das tabelas:
   ```bash
   dotnet ef migrations add InitialCreate
   dotnet ef database update
   ```

3. **Execução:**
   ```bash
   dotnet run --project CP2/CP2.csproj
   ```

## Documentação da API
Após iniciar a aplicação, a interface do Swagger estará disponível em:
`http://localhost:5005/swagger` (ou porta padrão configurada).

## Estrutura do Projeto
- `Controllers/`: Endpoints da API.
- `Data/`: Contexto do Entity Framework.
- `Models/`: Entidades de banco de dados.
- `DTOs/`: Objetos de transferência de dados para requisições e respostas.

#### Desenvovimento
Desenvolvido por 
<a href="https://github.com/devfreitas">DevFreitas<a/>
