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
