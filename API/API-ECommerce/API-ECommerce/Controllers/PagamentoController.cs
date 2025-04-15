using API_ECommerce.Context;
using API_ECommerce.Interfaces;
using API_ECommerce.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace API_ECommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PagamentoController : ControllerBase
    {
        //private readonly EcommerceContext _context;
        private IPagamentoRepository _pagamentoRepository;

        //public PagamentoController(EcommerceContext context)
        public PagamentoController(PagamentoRepository pagamentoRepository) //INJECAO DE DEPENDENCIA... Ao inves de eu instaciar a classe eu aviso que dependo dela e a resposabilidade de criar vem para a classe que chama(C#)
        {
            //_context = context;
            _pagamentoRepository = pagamentoRepository;
        }

        //Primeiro passo, definir o verbo, get, post, put
        [HttpGet()]
        public IActionResult ListarTodos() //Metodo criado para listar tudo
        {
            return Ok(_pagamentoRepository.ListarTodos()); //Vai retornar as informacoes com base no repository
        }
    }
}
