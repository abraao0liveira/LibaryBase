using MySql.Data.MySqlClient;

namespace LibaryBase.DataAccess
{
  public class DataBase
  {
    private const string connectionString = @"Server=localhost;Database=libary;User ID=abraao0liveira;Password=SkyP1ll@r_384;Port=3306;";

    public static MySqlConnection GetConnection()
    {
      return new MySqlConnection(connectionString);
    }

  }
}
