//No repository e definida as regras, ou seja, os metodos que acessam o banco de dados
//Sera preciso INJETAR o CONTEXT, injecao de dependencia

using API_ECommerce.Interfaces;
using API_ECommerce.Context;
using API_ECommerce.Models;
using API_ECommerce.DTO.Produto;

namespace API_ECommerce.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        //readonly serve apenas para leitura no contexto
        private readonly EcommerceContext _context;
        //ctor significa que esta montando um metodo constutor com o mesmo nome da classe, ou seja, quando criar um objeto, obrigatoriamente 
        public ProdutoRepository(EcommerceContext context)//--> O metodo construtor e um metodo que tem o mesmo nome da classe, no construtor define o que a classe precisa ter
        {
            _context = context;
        }

        public void Atualizar(int id, CadastrarProdutoDTO produto)//neste cenario esta usando a classe CadastrarProdutosDTO para o cadastro do produto apenas com os campos necessarios
        {
            //Primeiro passo, encontra quem eu quero atualizar 
            //-->Produto produtoEncontrato (declarando uma variavel do tipo Produto)
            //-->_context.Produto (Acesso a tabela produto do contexto/banco de dados).
            //-->Find(id) (O metodo find vai buscar exatamente o id/chave_primaria passado para ele)
            Produto produtoEncontrado = _context.Produtos.Find(id);
            
            //Caso o retorno for null, sera apresentado a excessao com o throw, neste caso sera preciso tratar no controle
            if (produtoEncontrado == null)
            {
                throw new Exception();
            }

            //A variavel produtoEncontrado recebe o novo valor da variavel produto.
            //O EntityFramework verifica se na variavel produto contem valores diferentes dos atuais, se for diferente ele atualiza, se nao for ele nao atualiza
            produtoEncontrado.Nome = produto.Nome;
            produtoEncontrado.Descricao = produto.Descricao;   
            produtoEncontrado.Preco = produto.Preco;
            produtoEncontrado.Categoria = produto.Categoria;
            produtoEncontrado.Imagem = produto.Imagem;
            produtoEncontrado.EstoqueDisponivel = produto.EstoqueDisponivel;

            //Efetivar a atualizacao
            _context.SaveChanges();

        }

        public Produto BuscarPorId(int id)
        {
            //O metodo FirstOrDefault() serve para trazer o primeiro que encontrar ou null. Dentro do parenteses informar qual a condicao deve acontecer para filtrar, sera utilizado a expressao lambda ou predicado
            //--> _contect.Produto (Acesso a tabela produto do contexto/banco de dados).
            //--> FirstOrDefault (Pegue o primeiro que encontrar)
            //--> p => p.IdProduto == id (Para cada produto p, me retorne aquele que tem o IdProduto igual ao id)
            return _context.Produtos.FirstOrDefault(p => p.IdProduto == id); 
        }

        public void Cadastrar(CadastrarProdutoDTO produto)//neste cenario esta usando a classe CadastrarProdutosDTO para o cadastro do produto apenas com os campos necessarios
        {
            //Com a utilizacao do DTO, sera preciso criar o objeto produto e alocar os atributos do produto nos atributos do produtoCadastro
            Produto produtoCadastro = new Produto //Instanciar o produto
            { 
                
                Nome = produto.Nome, //Nome do produtoCadastro recebe Nome do CadastrarProdutoDTO
                Descricao = produto.Descricao,
                Preco = produto.Preco,
                EstoqueDisponivel = produto.EstoqueDisponivel,
                Categoria = produto.Categoria,
                Imagem = produto.Imagem,
            };
            _context.Produtos.Add(produtoCadastro);
            _context.SaveChanges();
        }

        public void Deletar(int id)
        {
            //Primeiro passo, encontra quem eu quero excluir
            //-->Produto produtoEncontrato (declarando uma variavel do tipo Produto)
            //-->_context.Produto (Acesso a tabela produto do contexto/banco de dados).
            //-->Find(id) (O metodo find vai buscar exatamente o id/chave_primaria passado para ele)
            Produto produtoEncontrado = _context.Produtos.Find(id);
            
            //Caso o retorn for null, sera apresentado a excessao com o throw, neste caso sera preciso tratar no controle
            if(produtoEncontrado == null)
            {
                throw new Exception();
            }
            //Se o produto for encontrado, sera removido
            _context.Produtos.Remove(produtoEncontrado);
            //Efetivar a remocao
            _context.SaveChanges();

        }

        public List<Produto> ListarTodos()
        {
            // o metodo ToList() serve para pegar todos os registros do banco de dados
            return _context.Produtos.ToList();
        }
    }
}
