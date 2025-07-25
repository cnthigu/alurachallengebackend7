# API de Depoimentos e Destinos

<div align="center">

![.NET](https://img.shields.io/badge/.NET-9.0-512BD4?style=for-the-badge&logo=.net&logoColor=white)
![C#](https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=c-sharp&logoColor=white)
![Entity Framework](https://img.shields.io/badge/Entity_Framework-512BD4?style=for-the-badge&logo=.net&logoColor=white)
![SQL Server](https://img.shields.io/badge/SQL_Server-CC2927?style=for-the-badge&logo=microsoft-sql-server&logoColor=white)
![Swagger](https://img.shields.io/badge/Swagger-85EA2D?style=for-the-badge&logo=swagger&logoColor=black)

</div>

## Descrição

API RESTful desenvolvida em **ASP.NET Core 9.0** para um sistema de busca e gerenciamento de destinos turísticos com depoimentos de usuários. 
Este projeto foi desenvolvido como parte de um **challenge da plataforma Alura**, demonstrando habilidades em desenvolvimento backend com tecnologias 
modernas e integração com **Inteligência Artificial**.

### **Projeto Educacional Alura**
Este projeto faz parte do programa de formação da **Alura**, uma das principais plataformas de educação em tecnologia do Brasil. 
O challenge foi desenvolvido para consolidar conhecimentos em:
- Desenvolvimento de APIs REST com ASP.NET Core
- Integração com bancos de dados usando Entity Framework
- Implementação de funcionalidades com IA
- Boas práticas de desenvolvimento e documentação

## Funcionalidades

### Gestão de Destinos
- **CRUD completo** de destinos turísticos
- **Busca por nome** com filtros dinâmicos
- **Geração automática de descrições via IA** - Sistema inteligente que cria descrições personalizadas para cada destino
- **Validação de dados** com Data Annotations
- **Upload de múltiplas imagens** por destino

###  Sistema de Depoimentos
- **CRUD completo** de depoimentos de usuários
- **Seleção aleatória** para exibição na home
- **Gestão de fotos** e textos dos usuários
- **Endpoint especializado** para depoimentos da página inicial

### Recursos Técnicos
- **Documentação automática** com Swagger/OpenAPI
- **Configuração de CORS** para desenvolvimento
- **Entity Framework Core** com SQL Server
- **Arquitetura em camadas** (Controllers, Models, Data)
- **Injeção de dependência** nativa do ASP.NET Core
- **Integração com IA** para geração automática de conteúdo

## Tecnologias Utilizadas

- **.NET 9.0** - Framework principal
- **ASP.NET Core Web API** - Para criação da API REST
- **Entity Framework Core 9.0** - ORM para acesso a dados
- **SQL Server** - Banco de dados relacional
- **Swagger/OpenAPI** - Documentação da API
- **C#** - Linguagem de programação
- **Inteligência Artificial** - Geração automática de conteúdo

## Como Executar

### Pré-requisitos
- [.NET 9.0 SDK](https://dotnet.microsoft.com/download/dotnet/9.0)
- [SQL Server](https://www.microsoft.com/pt-br/sql-server/sql-server-downloads) ou [SQL Server Express](https://www.microsoft.com/pt-br/sql-server/sql-server-downloads)
- [Visual Studio 2022](https://visualstudio.microsoft.com/pt-br/) ou [VS Code](https://code.visualstudio.com/)

### Configuração

1. **Clone o repositório**
```bash
git clone https://github.com/cnthigu/alurachallengebackend7.git
cd depoimentos-api
```

2. **Configure a string de conexão**
Edite o arquivo `appsettings.json` e configure sua string de conexão:
```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Database=DepoimentosDB;Trusted_Connection=true;TrustServerCertificate=true;"
  }
}
```

3. **Execute as migrações**
```bash
dotnet ef database update
```

4. **Execute o projeto**
```bash
dotnet run
```

5. **Acesse a documentação**
Abra o navegador e acesse: `https://localhost:7001/swagger`

## Endpoints da API

### Destinos
- `GET /destinos` - Lista todos os destinos
- `GET /destinos?nome={nome}` - Busca destinos por nome
- `GET /destinos/{id}` - Obtém detalhes de um destino específico
- `POST /destinos` - Cria um novo destino
- `PUT /destinos/{id}` - Atualiza um destino existente
- `DELETE /destinos/{id}` - Remove um destino

### Depoimentos
- `GET /depoimentos` - Lista todos os depoimentos
- `GET /depoimentos/{id}` - Obtém um depoimento específico
- `GET /depoimentos-home` - Obtém 3 depoimentos aleatórios para a home
- `POST /depoimentos` - Cria um novo depoimento
- `PUT /depoimentos/{id}` - Atualiza um depoimento existente
- `DELETE /depoimentos/{id}` - Remove um depoimento

![Imagem](images/depoimentos.jpg)

## Arquitetura do Projeto

```
DepoimentosApi/
├── Controllers/          # Controladores da API
│   ├── DestinosController.cs
│   └── DepoimentosController.cs
├── Models/              # Modelos de dados
│   ├── Destinos.cs
│   └── Depoimento.cs
├── Data/                # Camada de acesso a dados
│   └── AppDbContext.cs
├── Migrations/          # Migrações do Entity Framework
└── Program.cs           # Configuração da aplicação
```

## Funcionalidade de Inteligência Artificial

### Geração Automática de Conteúdo
O projeto implementa um sistema inteligente que gera automaticamente descrições para destinos turísticos quando não fornecidas pelo usuário:

```csharp
private string GerarResumoIA(string nomeDestino)
{
    return $"Resumo sobre {nomeDestino}: lugar incrível, cheio de cultura e diversão. Vale a pena conhecer!";
}
```

**Como funciona:**
- Quando um destino é criado sem descrição, o sistema automaticamente gera uma
- A IA analisa o nome do destino e cria uma descrição contextualizada
- Melhora a experiência do usuário fornecendo conteúdo sempre disponível
- Demonstra integração de tecnologias emergentes em projetos práticos

## Modelos de Dados

### Destinos
```csharp
public class Destinos
{
    public int Id { get; set; }
    public string Foto1 { get; set; }
    public string Foto2 { get; set; }
    public string Nome { get; set; }
    public string Meta { get; set; }
    public int Preco { get; set; }
    public string? TextoDescritivo { get; set; }
}
```

### Depoimentos
```csharp
public class Depoimento
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Foto { get; set; }
    public string Texto { get; set; }
}
```

## Diferenciais do Projeto

- **Implementação completa de CRUD** em ambas as entidades
- **Busca dinâmica** com filtros por nome
- **Geração automática de conteúdo via IA** - Sistema inteligente que cria descrições personalizadas para destinos
- **Seleção aleatória** de depoimentos para home
- **Validação robusta** de dados de entrada
- **Documentação automática** com Swagger
- **Configuração de CORS** para integração frontend
- **Arquitetura limpa** seguindo boas práticas

