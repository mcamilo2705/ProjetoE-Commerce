using System.Globalization;
using API_ECommerce.Models;
namespace API_ECommerce.Interfaces
{
    public interface IClienteRepository
    {
        List<Cliente> ListarTodos();
        Cliente BuscarPorEmailSenha(string email, string senha);
        Cliente BuscarPorId(int id);

        void Cadastrar(Cliente cliente);

        void Atualizar(int id, Cliente cliente);

        void Deletar(int id);
    }
}
