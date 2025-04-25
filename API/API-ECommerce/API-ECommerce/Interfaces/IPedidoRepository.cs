using API_ECommerce.DTO.Pedido;
using API_ECommerce.Models;

namespace API_ECommerce.Interfaces
{
    public interface IPedidoRepository
    {
        List<Pedido> ListarTodos();

        Pedido BuscarPorId(int id);

        void Cadastrar(CadastrarPedidoDTO pedido); //Implementar a classe CadastrarPedidoDTO

        void Atualizar(int id, Pedido pedido);

        void Deletar(int id);

    }
}
