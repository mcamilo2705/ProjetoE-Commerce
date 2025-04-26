using API_ECommerce.DTO.Cliente;
using API_ECommerce.DTO.Pedido;
using API_ECommerce.Interfaces;
using API_ECommerce.Models;
using API_ECommerce.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_ECommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidoController : ControllerBase
    {
        //private readonly EcommerceContext _context;
        private IPedidoRepository _pedidoRepository;

        //public PagamentoController(EcommerceContext context)
        public PedidoController(IPedidoRepository pedidoRepository) //INJECAO DE DEPENDENCIA... Ao inves de eu instaciar a classe eu aviso que dependo dela e a resposabilidade de criar vem para a classe que chama(C#)
        {
            //_context = context;
            _pedidoRepository = pedidoRepository;
        }


        //Primeiro passo, definir o verbo, get, post, put
        [HttpGet]
        public IActionResult ListarTodos() //Metodo criado para listar tudo
        {
            return Ok(_pedidoRepository.ListarTodos()); //Vai retornar as informacoes com base no repository
        }

        [HttpPost]
        public IActionResult CadastrarPedido(CadastrarPedidoDTO pedido)
        {
            _pedidoRepository.Cadastrar(pedido);
            return Created();
        }
    }
}
