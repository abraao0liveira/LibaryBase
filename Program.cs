using LibaryBase.DataAccess;

namespace LibaryBase
{
  public class Program
  {
    static void Main(string[] args)
    {
      while (true)
      {
        Menu();
      }
    }

    static void Menu()
    {
      var dao = new ServiceDAO();

      Console.Clear();
      Console.WriteLine("Bem-vindo a biblioteca");

      Console.WriteLine("-----------------------");
      Console.WriteLine("1 - Adicionar livro");
      Console.WriteLine("2 - Atualizar livro");
      Console.WriteLine("3 - Remover livro");
      Console.WriteLine("4 - Listar livros");
      Console.WriteLine("5 - Listar livro por id");
      Console.WriteLine("6 - Sair");
      Console.WriteLine("-----------------------");
      var option = Console.ReadLine();

      switch (option)
      {
        case "1":
          Adicionar(dao);
          break;
        case "2":
          Atualizar(dao);
          break;
        case "3":
          Remover(dao);
          break;
        case "4":
          Listar(dao);
          break;
        case "5":
          ListId(dao);
          break;
        case "6":
          Environment.Exit(0);
          break;
        default:
          Console.WriteLine("Opção inválida");
          Console.ReadKey();
          Console.Clear();
          break;
      }
    }

    static void Adicionar(ServiceDAO dao)
    {
      Console.WriteLine("Funcionalidade em desenvolvimento");
      Thread.Sleep(3000);
      Menu();
    }

    static void Listar(ServiceDAO dao)
    {
      Console.Clear();
      Console.WriteLine("Listar livros");

      var services = dao.Listar();

      if (services.Count == 0)
      {
        Console.WriteLine("Nenhum livro cadastrado");
        Console.ReadKey();
        Menu();
      }
      else
      {
        foreach (var service in services)
        {
          Console.WriteLine("-----------------------");
          Console.WriteLine($"Id: {service.id_book}");
          Console.WriteLine($"Nome: {service.name_book}");
          Console.WriteLine($"Data de publicação: {service.publication_date}");
          Console.WriteLine($"Quantidade: {service.count_book}");
          Console.WriteLine("-----------------------");
        }
      }

      Console.ReadKey();
      Menu();
    }

    static void Atualizar(ServiceDAO dao)
    {
      Console.WriteLine("Funcionalidade em desenvolvimento");
      Thread.Sleep(3000);
      Menu();
    }

    static void Remover(ServiceDAO dao)
    {
      Console.WriteLine("Funcionalidade em desenvolvimento");
      Thread.Sleep(3000);
      Menu();
    }

    static void ListId(ServiceDAO dao)
    {
      Console.WriteLine("Funcionalidade em desenvolvimento");
      Thread.Sleep(3000);
      Menu();
    }
  }
}
