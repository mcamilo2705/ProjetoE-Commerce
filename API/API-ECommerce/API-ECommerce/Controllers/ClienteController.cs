using System.Diagnostics.CodeAnalysis;
using API_ECommerce.Context;
using API_ECommerce.Interfaces;
using API_ECommerce.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using API_ECommerce.Models;

namespace API_ECommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly EcommerceContext _context;
        private IClienteRepository _clienteRepository;

        public ClienteController(EcommerceContext context)
        {
            _context = context;
            _clienteRepository = new ClienteRepository(_context);
        }

        [HttpGet]
        public IActionResult ListarTodos()
        {
            return Ok(_clienteRepository.ListarTodos());
        }

        [HttpPost]
        public IActionResult CadastrarCliente(Cliente cli) 
        {
            _clienteRepository.Cadastrar(cli);
            return Created();
        }

        [HttpGet("{id}")]
        public IActionResult ListarPorId(int id)
        {
            Cliente cli = _context.Clientes.FirstOrDefault(c => c.IdCliente == id);
            if (cli == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(cli);
            }
        }

        [HttpGet("/Busca/{nome}")]
        public IActionResult ListarPorNome(string nome)
        {
            Cliente cli = _context.Clientes.FirstOrDefault(c => c.NomeCompleto == nome);
            if (cli == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(cli);
            }
        }

        [HttpGet("/Ordenado")]
        public IActionResult ListarTodosOrdenados()
        {
            return Ok(_clienteRepository.ListarTodos());
        }

        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, Cliente cli)
        {
            try //Se encontrar o produto
            {
                //_produtoRepository (acessar o context/banco de dados)
                //Editar (id) editar o produto pelo id
                _clienteRepository.Atualizar(id, cli);
                // Retornar 200
                return Ok(cli);
            }
            //Caso dar erro ou nao encontrao o produto
            catch (Exception ex)
            {
                return NotFound("Cliente nao encontrado");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            try //Se encontrar o produto
            {
                //_produtoRepository (acessar o context/banco de dados)
                //Deletar (id) deletar o produto pelo id
                _clienteRepository.Deletar(id);
                // Retornar 204
                return NoContent();
            }
            //Caso dar erro ou nao encontrao o produto
            catch (Exception ex)
            {
                return NotFound("Cliente nao encontrado");
            }
        }



    }
}
