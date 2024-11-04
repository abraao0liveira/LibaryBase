# LibaryBase

## Tecnologias
- C#
- .NET
- ADO.NET
- MySQL
- DBeaver

## O que é o LibaryBase?
A ideia principal do LibraryBase era simular o controle de estoque de uma livraria, utilizando o conceito de CRUD: Create (criar), Read (ler), Update (atualizar) e Delete (excluir).

## Pré-requisitos
- .NET

## Como rodar o Banco de Dados?

1. Abra o MySQL
2. Crie a conexão com o banco de dados
3. Adicione a tabela e os dados de cada coluna pelo DBeaver

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

### Menu
Bem-vindo a biblioteca
-----------------------
1 - Adicionar livro
2 - Atualizar livro
3 - Remover livro
4 - Listar livros
5 - Listar livro por id
6 - Sair
-----------------------

### Listar livros

Id: 1
Nome: O último desejo - The Witcher
Data de publicação: 19/12/2019 00:00:00
Quantidade: 1087
-----------------------
-----------------------
Id: 2
Nome: Duna
Data de publicação: 28/04/2017 00:00:00
Quantidade: 3201
-----------------------
-----------------------
Id: 3
Nome: Trilogia da Fundação
Data de publicação: 08/04/2019 00:00:00
Quantidade: 230
-----------------------
