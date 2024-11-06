using LibaryBase.DataAccess;
using LibaryBase.Models;

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
          ListarId(dao);
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
      Console.Clear();
      Console.WriteLine("Adicionar novo livro");
      Console.WriteLine("-----------------------");

      Console.WriteLine("Nome do livro: (ou 0 para voltar)");
      string name = Console.ReadLine() ?? string.Empty;

      if (name == "0")
      {
        Menu();
      }

      Console.WriteLine("Data de publicação:");
      var date = Console.ReadLine() ?? string.Empty;

      Console.WriteLine("Quantidade:");
      var count = Console.ReadLine() ?? string.Empty;

      var service = new Service
      {
        name_book = name,
        publication_date = DateTime.Parse(date),
        count_book = int.Parse(count)
      };
      dao.Adicionar(service);
      Console.WriteLine("-----------------------");

      Console.WriteLine($"Livro {name} adicionado com sucesso");
      Console.ReadKey();
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
      Console.Clear();
      Console.WriteLine("Atualizar livro");
      Console.WriteLine("-----------------------");

      int id = ReadId();
      if (id == 0)
      {
        Menu();
      }

      var serviceExist = dao.ListId(id);
      if (serviceExist == null)
      {
        Console.WriteLine("Livro não encontrado");
        Console.ReadKey();
        return;
      }

      Console.WriteLine("Nome do livro: (ou deixe em branco para manter o mesmo)");
      string name = Console.ReadLine() ?? string.Empty;

      Console.WriteLine("Data de publicação: (ou deixe em branco para manter a mesma)");
      var date = Console.ReadLine() ?? string.Empty;

      Console.WriteLine("Quantidade: (ou deixe em branco para manter a mesma)");
      var count = Console.ReadLine() ?? string.Empty;

      if (!string.IsNullOrEmpty(name))
      {
        serviceExist.name_book = name;
      }
      if (!string.IsNullOrEmpty(date))
      {
        serviceExist.publication_date = DateTime.Parse(date);
      }
      if (!string.IsNullOrEmpty(count))
      {
        serviceExist.count_book = int.Parse(count);
      }
      dao.Atualizar(serviceExist);

      Console.WriteLine("-----------------------");
      Console.WriteLine($"Livro {serviceExist.name_book} atualizado com sucesso");
      Console.ReadKey();
      Menu();
    }

    static void Remover(ServiceDAO dao)
    {
      Console.Clear();
      Console.WriteLine("Remover livro");
      Console.WriteLine("-----------------------");

      int id = ReadId();
      if (id == 0)
      {
        Menu();
      }

      var serviceExist = dao.ListId(id);
      if (serviceExist == null)
      {
        Console.WriteLine("Livro não encontrado");
        Console.ReadKey();
        return;
      }

      Console.WriteLine($"Confirma a remoção do livro {serviceExist.name_book}? (S/N)");
      var confirm = Console.ReadLine() ?? string.Empty;

      if (confirm.ToLower() == "s")
      {
        dao.Remover(id);
        Console.WriteLine("Livro removido com sucesso");
      }
      else
      {
        Console.WriteLine("Operação cancelada");
      }

      Console.WriteLine("-----------------------");
      Console.ReadKey();
      Menu();
    }

    static void ListarId(ServiceDAO dao)
    {
      Console.Clear();
      Console.WriteLine("Listar livro por id");
      Console.WriteLine("-----------------------");

      int id = ReadId();
      if (id == 0)
      {
        Menu();
      }

      var service = dao.ListId(id);
      if (service == null)
      {
        Console.WriteLine("Livro não encontrado");
      }
      else
      {
        Console.WriteLine("-----------------------");
        Console.WriteLine($"Id: {service.id_book}");
        Console.WriteLine($"Nome: {service.name_book}");
        Console.WriteLine($"Data de publicação: {service.publication_date}");
        Console.WriteLine($"Quantidade: {service.count_book}");
        Console.WriteLine("-----------------------");
      }

      Console.ReadKey();
      Menu();
    }

    static int ReadId()
    {
      string entry;
      int id;

      while (true)
      {
        Console.WriteLine("Digite o id do livro: (ou 0 para voltar)");
        entry = Console.ReadLine() ?? string.Empty;

        if (entry == "0")
        {
          return 0;
        }

        if (int.TryParse(entry, out id))
        {
          return id;
        }
        else
        {
          Console.WriteLine("Id inválido");
        }
      }
    }
  }
}
