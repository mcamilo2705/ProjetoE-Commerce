using API_ECommerce.Interfaces;
using API_ECommerce.Context;
using API_ECommerce.Models;
using System.Linq;

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
        public void Atualizar(int id, Cliente clienteNovo)
        {

            //Cliente cli = _context.Clientes.Find(id); //o tipo Cliente pode ser substituido por var
            var clienteAntigo = _context.Clientes.Find(id); //o tipo Cliente pode ser substituido por var

            if (clienteAntigo == null)
            {
                throw new ArgumentNullException("Cliente nao encontrado");
            }

            clienteAntigo.DataCadastro = clienteNovo.DataCadastro; //DateTime.Now();
            clienteAntigo.NomeCompleto = clienteNovo.NomeCompleto;
            clienteAntigo.Email = clienteNovo.Email;
            clienteAntigo.Telefone = clienteNovo.Telefone;
            clienteAntigo.Endereco = clienteNovo.Endereco; 
            clienteAntigo.Senha = clienteNovo.Senha;
            
            _context.SaveChanges();

        }
        //Implementar a interface( os metodos)
        /// <summary>
        /// Acessa o banco de dados e encontra o cliente com emai e senha fornecidos
        /// </summary>
        /// <param name="email"></param> //dentro do param serve para informar o significado do parametro
        /// <param name="senha"></param> //dentro do param serve para informar o significado do parametro
        /// <returns>Retorna um cliente ou nulo</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public Cliente? BuscarPorEmailSenha(string email, string senha) // ao colocar interrogacao indica que pode retornar nulo.
        {
            //Encontrar o cliente que possue o email e senha fornecidos
            var clienteEncontrado = _context.Clientes.FirstOrDefault(cli => cli.Email == email && cli.Senha == senha);
            
            if (clienteEncontrado == null)
            {
                throw new ArgumentNullException("Cliente nao encontrado");
            }
            
            return clienteEncontrado;
            
        }
        //Implementar a interface( os metodos)
        public Cliente BuscarPorId(int id)
        {
            return _context.Clientes.FirstOrDefault(c => c.IdCliente == id);
        }

        public Cliente BuscarPorNome(string nome)
        {
            return _context.Clientes.FirstOrDefault(c => c.NomeCompleto == nome); //o firstordefault pesquisa por qualquer campo da tabela
        }


        //Implementar a interface( os metodos)
        public void Cadastrar(Cliente cliente)
        {
            _context.Clientes.Add(cliente); // o context acessa a tabela cliente para poder adicionar/cadastrar
            _context.SaveChanges();
        }
        //Implementar a interface( os metodos)
        public void Deletar(int id)
        {
            Cliente cliente = _context.Clientes.Find(id); //O find pesquisa somente pela chave primaria

            if (cliente == null) 
            {
                throw new ArgumentNullException("Cliente nao encontrado"); // caso eu nao encontre o cliente lanco um erro
            }

            _context.Clientes.Remove(cliente);
            _context.SaveChanges();

        }
        //Implementar a interface( os metodos)
        public List<Cliente> ListarTodos()
        {
            return _context.Clientes.ToList(); // o context acessa a tabela Clietes e lista
        }

        public List<Cliente> ListarTodosOrdenados()
        {
            return _context.Clientes.OrderBy(cli => cli.NomeCompleto).ToList();
        }

      
    }
}