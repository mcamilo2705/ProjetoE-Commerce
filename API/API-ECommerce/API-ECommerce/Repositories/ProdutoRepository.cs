//No repository e definida as regras, ou seja, os metodos que acessam o banco de dados
//Sera preciso INJETAR o CONTEXT, injecao de dependencia

using API_ECommerce.Interfaces;
using API_ECommerce.Context;
using API_ECommerce.Models;

namespace API_ECommerce.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        //readonly serve apenas para leitura no contexto
        private readonly EcommerceContext _context;
        //ctor significa que esta montando um metodo constutor com o mesmo nome da classe, ou seja, quando criar um objeto, obrigatoriamente 
        public ProdutoRepository(EcommerceContext context)
        {
            _context = context;
        }

        public void Atualizar(int id, Produto produto)
        {
            throw new NotImplementedException();
        }

        public Produto BuscarPorId(int id)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(Produto produto)
        {
            _context.Produtos.Add(produto);
        }

        public void Deletar(int id)
        {
            throw new NotImplementedException();
        }

        public List<Produto> ListarTodos()
        {
            return _context.Produtos.ToList();
        }
    }
}
