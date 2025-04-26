using API_ECommerce.Context;
using API_ECommerce.DTO.Produto;
using API_ECommerce.Interfaces;
using API_ECommerce.Models;
using API_ECommerce.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_ECommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemPedidoController : ControllerBase
    {

        //private readonly EcommerceContext _context;
        private IItemPedidoRepository _itemPedidoRepository;

        public ItemPedidoController(IItemPedidoRepository itemPedidoRepository)
        {
            //_context = context;
            _itemPedidoRepository = itemPedidoRepository;
        }

        [HttpGet]
        public ActionResult ListarTodos() 
        {
            return Ok(_itemPedidoRepository.ListarTodos());
        }

        //Cadastrar produto
        [HttpPost]
        public IActionResult CadastrarItemPedido(ItemPedido itemPedido)
        {
            //1-Colocar o produto no banco de dados, chamar a variavel do repository, acessar o metodos e passar o prod
            _itemPedidoRepository.Cadastrar(itemPedido);
            //2-Salvar a informacao afirmando para o entity framework confirmar a operacao,
            //_context.SaveChanges(); -> esse comando foi para a classe ProdutoRepository no metodo cadastrar
            //3-Retonar o resultado
            //Retorno 201- Created
            return Created();
        }

        //Buscar produto por id, verbo HttpGet
        // /api/produtos -->Lista todos os produtos
        // /api/produto/2 --> Buscar por id
        [HttpGet("{id}")]
        //Criar o metodo de listar por id
        public IActionResult ListarPorId(int id)
        {
            //Declarando uma variavel do tipo Produto para receber o produto do repository
            ItemPedido itemPedido = _itemPedidoRepository.BuscarPorId(id);

            if (itemPedido == null)
            {
                //Se o produto for nullo, apresentar o retorno 404-Nao Encontrado
                return NotFound();

            }
            else
            {
                //Se o produto foi encontrado, apresentar o retorno 200-Sucesso e o produto
                return Ok(itemPedido);
            }
        }

        //Verbo atualizar

        [HttpPut("{id}")]
        //neste metodos sera preciso receber o id do produto e compara com o prod para poder atualizar
        public IActionResult Editar(int id, ItemPedido itemPedido)
        {
            try //Se encontrar o produto
            {
                //_produtoRepository (acessar o context/banco de dados)
                //Editar (id) editar o produto pelo id
                _itemPedidoRepository.Atualizar(id, itemPedido);
                // Retornar 200
                return Ok(itemPedido);
            }
            //Caso dar erro ou nao encontrao o produto
            catch (Exception ex)
            {
                return NotFound("Item pedido nao encontrado");
            }
        }


        //Deletar

        [HttpDelete("{id}")]

        public IActionResult Deletar(int id)
        {
            try //Se encontrar o produto
            {
                //_produtoRepository (acessar o context/banco de dados)
                //Deletar (id) deletar o produto pelo id
                _itemPedidoRepository.Deletar(id);
                // Retornar 204
                return NoContent();
            }
            //Caso dar erro ou nao encontrao o produto
            catch (Exception ex)
            {
                return NotFound("Item pedido nao encontrado");
            }
        }
    }
}
