using API_ECommerce.Context;
using API_ECommerce.Interfaces;
using API_ECommerce.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API_ECommerce.Controllers
{
    [Route("api/[controller]")] //-> trecho para acessar o endpoint atraves do controlador, a palavra controle ja reconhece a classe controller, ou seja, essa classe e ProdutoController, entao o endipoit sera api/Produto
    [ApiController]//-> esta linha so indica que e um controller
    public class ProdutoController : ControllerBase //-> esta classe faz o controle das requisicoes
    {
        private readonly EcommerceContext _context; //-> criar um variavel pro context para poder conectar no banco de dados
        private IProdutoRepository _produtoRepository;//-> criar uma variavel para o repository para poder fazer o crud
        public ProdutoController(EcommerceContext context) //-> Metodo contrutor para sempre que o produto for criado, precisa de um contexto e um repository
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
