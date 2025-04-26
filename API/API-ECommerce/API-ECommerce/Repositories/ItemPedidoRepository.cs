using API_ECommerce.Context;
using API_ECommerce.DTO.Produto;
using API_ECommerce.Interfaces;
using API_ECommerce.Models;

namespace API_ECommerce.Repositories
{
    //Primeiro passo, primeiro herdar da inteface
    //Segundo passo, implementa a interface( os metodos)
    //Terceiro passo, Injetar o Contexto
    public class ItemPedidoRepository : IItemPedidoRepository
    { 
        //Injetar o contexto
        private readonly EcommerceContext _context;
        public ItemPedidoRepository(EcommerceContext context)//--> O metodo construtor e um metodo que tem o mesmo nome da classe, no construtor define o que a classe precisa ter
        {
            _context = context;
        }

        public void Atualizar(int id, ItemPedido itemPedido)//neste cenario esta usando a classe CadastrarProdutosDTO para o cadastro do produto apenas com os campos necessarios
        {
            //Primeiro passo, encontra quem eu quero atualizar 
            //-->Produto produtoEncontrato (declarando uma variavel do tipo Produto)
            //-->_context.Produto (Acesso a tabela produto do contexto/banco de dados).
            //-->Find(id) (O metodo find vai buscar exatamente o id/chave_primaria passado para ele)
            ItemPedido produtoEncontrado = _context.ItemPedidos.Find(id);

            //Caso o retorno for null, sera apresentado a excessao com o throw, neste caso sera preciso tratar no controle
            if (produtoEncontrado == null)
            {
                throw new Exception();
            }

            //A variavel produtoEncontrado recebe o novo valor da variavel produto.
            //O EntityFramework verifica se na variavel produto contem valores diferentes dos atuais, se for diferente ele atualiza, se nao for ele nao atualiza
            produtoEncontrado.IdPedido = itemPedido.IdPedido;
            produtoEncontrado.IdProduto = itemPedido.IdProduto;
            produtoEncontrado.IdItemPedido = itemPedido.IdItemPedido;
            produtoEncontrado.Quantidade = itemPedido.Quantidade;

            //Efetivar a atualizacao
            _context.SaveChanges();

        }

        public ItemPedido BuscarPorId(int id)
        {
            //O metodo FirstOrDefault() serve para trazer o primeiro que encontrar ou null. Dentro do parenteses informar qual a condicao deve acontecer para filtrar, sera utilizado a expressao lambda ou predicado
            //--> _contect.Produto (Acesso a tabela produto do contexto/banco de dados).
            //--> FirstOrDefault (Pegue o primeiro que encontrar)
            //--> p => p.IdProduto == id (Para cada produto p, me retorne aquele que tem o IdProduto igual ao id)
            return _context.ItemPedidos.FirstOrDefault(p => p.IdItemPedido == id);
        }

        public void Cadastrar(ItemPedido itemPedido)//neste cenario esta usando a classe CadastrarProdutosDTO para o cadastro do produto apenas com os campos necessarios
        {
            //Com a utilizacao do DTO, sera preciso criar o objeto produto e alocar os atributos do produto nos atributos do produtoCadastro
            ItemPedido produtoCadastro = new ItemPedido //Instanciar o produto
            {

                IdPedido = itemPedido.IdPedido, //Nome do produtoCadastro recebe Nome do CadastrarProdutoDTO
                IdProduto = itemPedido.IdProduto,
                IdItemPedido = itemPedido.IdItemPedido,
                Quantidade = itemPedido.Quantidade
            };
            _context.ItemPedidos.Add(produtoCadastro);
            _context.SaveChanges();
        }

        public void Deletar(int id)
        {
            //Primeiro passo, encontra quem eu quero excluir
            //-->Produto produtoEncontrato (declarando uma variavel do tipo Produto)
            //-->_context.Produto (Acesso a tabela produto do contexto/banco de dados).
            //-->Find(id) (O metodo find vai buscar exatamente o id/chave_primaria passado para ele)
            ItemPedido produtoEncontrado = _context.ItemPedidos.Find(id);

            //Caso o retorn for null, sera apresentado a excessao com o throw, neste caso sera preciso tratar no controle
            if (produtoEncontrado == null)
            {
                throw new Exception();
            }
            //Se o produto for encontrado, sera removido
            _context.ItemPedidos.Remove(produtoEncontrado);
            //Efetivar a remocao
            _context.SaveChanges();

        }


        public List<ItemPedido> ListarTodos()
        {
            return _context.ItemPedidos.ToList(); ;
        }
    }
}
