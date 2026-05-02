# CP2 - Locadora de Carros com API REST

Esta é a Checkpoint 2 (CP2) desenvolvida em ASP.NET Core Web API. O objetivo do projeto é gerenciar uma frota de veículos e fornecer um simulador de custos de locação com lógica de descontos progressivos, utilizando **Oracle Database** e **Entity Framework Core**.

## Tecnologias Utilizadas
- **Framework:** ASP.NET Core 10.0
- **Linguagem:** C# 13
- **ORM:** Entity Framework Core
- **Banco de Dados:** Oracle Database (via `Oracle.EntityFrameworkCore`)
- **Documentação:** Swagger (OpenAPI)

## Configuração e Execução

### 1. Requisitos
- SDK .NET 10.0 instalado.
- Instância de banco de dados Oracle acessível.
- Ferramenta `dotnet-ef` (instalar via `dotnet tool install --global dotnet-ef`).

### 2. Conexão com Banco de Dados
Atualize a string de conexão no arquivo `appsettings.json`:
```json
"ConnectionStrings": {
  "OracleConnection": "User Id=SEU_USUARIO;Password=SUA_SENHA;Data Source=localhost:1521/ORCL"
}
```

### 3. Migrações
Execute os comandos abaixo no terminal, na pasta raiz do projeto, para criar as tabelas:
```bash
dotnet ef migrations add InitialCreate
dotnet ef database update
```

### 4. Rodar a Aplicação
```bash
dotnet run --project CP2/CP2.csproj
```
Acesse a documentação interativa em: `http://localhost:5005/swagger` (ou porta exibida no console).

## Endpoints da API

### Gerenciamento de Carros (CRUD)
| Método | Endpoint | Descrição |
| :--- | :--- | :--- |
| **GET** | `/api/carros` | Lista todos os carros cadastrados. |
| **GET** | `/api/carros/{id}` | Busca um carro específico pelo ID. |
| **POST** | `/api/carros` | Cadastra um novo carro. |
| **PUT** | `/api/carros/{id}` | Atualiza os dados de um carro. |
| **DELETE** | `/api/carros/{id}` | Remove um carro do sistema. |

### Simulador de Locação
| Método | Endpoint | Descrição |
| :--- | :--- | :--- |
| **POST** | `/api/locacoes/calcular` | Calcula o custo de locação com descontos. |

## Regras de Negócio (Descontos)
O cálculo do valor total da locação segue as seguintes regras de desconto baseadas na duração:
- **3 a 6 dias:** 5% de desconto.
- **7 dias ou mais:** 10% de desconto.
- **Menos de 3 dias:** Sem desconto (valor integral).

### Exemplo de Uso (Simulador)

**Entrada (JSON):**
```json
{
  "carroId": 1,
  "dataInicio": "2025-04-25",
  "dataFim": "2025-04-30"
}
```

**Saída (JSON):**
```json
{
  "carro": "Civic",
  "marca": "Honda",
  "dataInicio": "2025-04-25T00:00:00",
  "dataFim": "2025-04-30T00:00:00",
  "valorDiaria": 150.00,
  "subtotal": 750.00,
  "desconto": "5%",
  "valorFinal": 712.50
}
```

## Estrutura do Projeto
- `Controllers/`: Camada de entrada da API e lógica de roteamento.
- `Data/`: Contexto do Entity Framework (`AppDbContext`).
- `Models/`: Entidades persistidas no banco de dados.
- `DTOs/`: Objetos de transferência para requisições e respostas.

---
**Repositório do Projeto:** [Repositório](https://github.com/devfreitas/Checkpoint2.NET)
**Desenvolvido por:** [DevFreitas](https://github.com/devfreitas)
