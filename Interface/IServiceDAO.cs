using LibaryBase.Models;

namespace LibaryBase.Interface
{
  public interface IServiceDAO
  {
    void Adicionar(Service service);
    void Atualizar(Service service);
    void Remover(int id_book);
    List<Service> Listar();
    Service ListId(int id_book);
  }
}
