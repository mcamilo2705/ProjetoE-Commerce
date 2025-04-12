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
        private readonly EcommerceContext _context;
        private IPagamentoRepository _pagamentoRepository;

        public PagamentoController(EcommerceContext context)
        {
            _context = context;
            _pagamentoRepository = new PagamentoRepository(_context);
        }

        //Primeiro passo, definir o verbo, get, post, put
        [HttpGet()]
        public IActionResult ListarTodos() //Metodo criado para listar tudo
        {
            return Ok(_pagamentoRepository.ListarTodos()); //Vai retornar as informacoes com base no repository
        }
    }
}
