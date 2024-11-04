# LibaryBase

## Tecnologias
![C#](https://img.shields.io/badge/c%23-%23239120.svg?style=for-the-badge&logo=csharp&logoColor=white)
![.Net](https://img.shields.io/badge/.NET-5C2D91?style=for-the-badge&logo=.net&logoColor=white)
![MySQL](https://img.shields.io/badge/mysql-4479A1.svg?style=for-the-badge&logo=mysql&logoColor=white)
![Git](https://img.shields.io/badge/git-%23F05033.svg?style=for-the-badge&logo=git&logoColor=white)
![GitHub](https://img.shields.io/badge/github-%23121011.svg?style=for-the-badge&logo=github&logoColor=white)

## O que é o LibaryBase?
A ideia principal do LibraryBase era simular o controle de estoque de uma livraria, utilizando o conceito de CRUD: Create (criar), Read (ler), Update (atualizar) e Delete (excluir).

## Pré-requisitos
- .NET
- MySQL

## Como rodar o Banco de Dados?

1. Abra o MySQL
2. Crie a conexão com o banco de dados
3. Adicione a tabela e os dados de cada coluna

## Como rodar o código?

### [1] Primeiro, rodar os comandos dotnet
```bash
dotnet restore
dotnet build
dotnet clean 
```

### [2] Segundo, intalar package do MySQL
```bash
dotnet add package MySql.Data
```

### [3] Terceiro, adicionar caminho do Banco de Dados MySQL
- Adicione a rota do seu banco de dados dentro da variável 'connectionString'
- Crie a conexão
```bash
using MySql.Data.MySqlClient;

namespace LibaryBase.DataAccess
{
  public class DataBase
  {
    private const string connectionString = @"Server=localhost;Database=libary;User ID=SEUUSER;Password=SUASENHA;Port=3306;";

    public static MySqlConnection GetConnection()
    {
      return new MySqlConnection(connectionString);
    }

  }
}
```

### [4] Quarto, rodar a aplicação
```bash
dotnet run
```

## Terminal Menu
![Captura de tela 2024-11-04 193732](https://github.com/user-attachments/assets/5f773409-ffad-4d43-9e7d-98ffd2085282)

## Terminal Listar livros
