using LibaryBase.Models;
using LibaryBase.Interface;
using MySql.Data.MySqlClient;

namespace LibaryBase.DataAccess
{
  public class ServiceDAO : IServiceDAO
  {
    public void Adicionar(Service service)
    {
      using (var connection = DataBase.GetConnection())
      {
        connection.Open();

        string sql = "INSERT INTO libary.book_store (name_book, publication_date, count_book) VALUES (@name_book, @publication_date, @count_book)";

        using (var cmd = new MySqlCommand(sql, connection))
        {
          cmd.Parameters.AddWithValue("@name_book", service.name_book);
          cmd.Parameters.AddWithValue("@publication_date", service.publication_date);
          cmd.Parameters.AddWithValue("@count_book", service.count_book);

          cmd.ExecuteNonQuery();
        }
      }
    }

    public void Atualizar(Service service)
    {
      using (var connection = DataBase.GetConnection())
      {
        connection.Open();

        string sql = "UPDATE libary.book_store SET name_book = @name_book, publication_date = @publication_date, count_book = @count_book WHERE id_book = @id_book";

        using (var cmd = new MySqlCommand(sql, connection))
        {
          cmd.Parameters.AddWithValue("@id_book", service.id_book);
          cmd.Parameters.AddWithValue("@name_book", service.name_book);
          cmd.Parameters.AddWithValue("@publication_date", service.publication_date);
          cmd.Parameters.AddWithValue("@count_book", service.count_book);

          cmd.ExecuteNonQuery();
        }
      }
    }

    public List<Service> Listar()
    {
      var services = new List<Service>();

      using (var connection = DataBase.GetConnection())
      {
        connection.Open();

        string sql = "SELECT * FROM libary.book_store";

        using (var cmd = new MySqlCommand(sql, connection))
        using (var reader = cmd.ExecuteReader())
        {
          while (reader.Read())
          {
            var service = new Service
            {
              id_book = reader.GetInt32("id_book"),
              name_book = reader.GetString("name_book"),
              publication_date = reader.GetDateTime("publication_date"),
              count_book = reader.GetInt32("count_book")
            };
            services.Add(service);
          }
        }
      }
      return services;
    }

    public Service ListId(int id_book)
    {
      using (var connection = DataBase.GetConnection())
      {
        connection.Open();

        string sql = "SELECT * FROM libary.book_store WHERE id_book = @id_book";

        using (var cmd = new MySqlCommand(sql, connection))
        {
          cmd.Parameters.AddWithValue("@id_book", id_book);
          using (var reader = cmd.ExecuteReader())
          {
            if (reader.Read())
            {
              return new Service
              {
                id_book = reader.GetInt32("id_book"),
                name_book = reader.GetString("name_book"),
                publication_date = reader.GetDateTime("publication_date"),
                count_book = reader.GetInt32("count_book")
              };
            }
            else
            {
              throw new Exception("Book not found");
            }
          }
        }
      }
    }

    public void Remover(int id_book)
    {
      using (var connection = DataBase.GetConnection())
      {
        connection.Open();

        string sql = "DELETE FROM libaty.book_store WHERE id_book = @id_book";

        using (var cmd = new MySqlCommand(sql, connection))
        {
          cmd.Parameters.AddWithValue("@id_book", id_book);

          cmd.ExecuteNonQuery();
        }
      }
    }
  }
}
