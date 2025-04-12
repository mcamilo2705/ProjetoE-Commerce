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
        public ClienteRepository(EcommerceContext context)//--> O metodo construtor e um metodo que tem o mesmo nome da classe, no construtor define o que a classe precisa ter
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
            _context.Clientes.Add(cliente); // o context acessa a tabela cliente para poder adicionar/cadastrar
        }
        //Implementar a interface( os metodos)
        public void Deletar(int id)
        {
            throw new NotImplementedException();
        }
        //Implementar a interface( os metodos)
        public List<Cliente> ListarTodos()
        {
            return _context.Clientes.ToList(); // o context acessa a tabela Clietes e lista
        }
    }
}