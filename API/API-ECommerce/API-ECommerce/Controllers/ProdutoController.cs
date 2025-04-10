using API_ECommerce.Context;
using API_ECommerce.Interfaces;
using API_ECommerce.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API_ECommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly EcommerceContext _context;
        private IProdutoRepository _produtoRepository;
        public ProdutoController(EcommerceContext context)
        {
            _context = context;
            _produtoRepository = new ProdutoRepository(_context);
        }

        // para listar, vamos usar o metodo GET
        [HttpGet]
        public IActionResult ListarProdutos()
        {
            return Ok(_produtoRepository.ListarTodos());
        }

    }
}
