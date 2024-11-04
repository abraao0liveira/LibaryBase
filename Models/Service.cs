namespace LibaryBase.Models
{
  public class Service
  {
    public int id_book { get; set; }
    public required string name_book { get; set; }
    public DateTime publication_date { get; set; }
    public int count_book { get; set; }
  }
}
