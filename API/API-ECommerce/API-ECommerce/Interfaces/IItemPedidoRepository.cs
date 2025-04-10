using API_ECommerce.Models;

namespace API_ECommerce.Interfaces
{
    public interface IItemPedidoRepository
    {
        List<ItemPedido> ListarTodos();

        ItemPedido BuscarPorId(int id);

        void Cadastrar(ItemPedido itempedido);

        void Atualizar(int id, ItemPedido itempedido);

        void Deletar(int id);

    }
}
