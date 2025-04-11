using API_ECommerce.Interfaces;
using API_ECommerce.Context;
using API_ECommerce.Models;

namespace API_ECommerce.Repositories
{
    //Primeiro passo, primeiro herdar da inteface
    //Segundo passo, implementa a interface( os metodos)
    //Terceiro passo, Injetar o Contexto
    internal class ClienteRepository : IClienteRepository
    {
        //Injetar o contexto
        private readonly EcommerceContext _context;
        public ClienteRepository(EcommerceContext context)
        {
            _context = context;
        }
        //Implementar a interface( os metodos)
        public void Atualizar(int id, Cliente cliente)
        {
            throw new NotImplementedException();
        }
        //Implementar a interface( os metodos)
        public Cliente BuscarPorEmailSenha(string email, string senha)
        {
            throw new NotImplementedException();
        }
        //Implementar a interface( os metodos)
        public Cliente BuscarPorId(int id)
        {
            throw new NotImplementedException();
        }
        //Implementar a interface( os metodos)
        public void Cadastrar(Cliente cliente)
        {
            throw new NotImplementedException();
        }
        //Implementar a interface( os metodos)
        public void Deletar(int id)
        {
            throw new NotImplementedException();
        }
        //Implementar a interface( os metodos)
        public List<Cliente> ListarTodos()
        {
            throw new NotImplementedException();
        }
    }
}