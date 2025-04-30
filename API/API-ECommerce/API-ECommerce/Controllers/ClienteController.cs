using System.Diagnostics.CodeAnalysis;
using API_ECommerce.Context;
using API_ECommerce.Interfaces;
using API_ECommerce.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using API_ECommerce.Models;
using API_ECommerce.DTO.Cliente;
using Microsoft.VisualBasic;
using API_ECommerce.Services;
using System.Net;
using Microsoft.AspNetCore.Authorization;

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
        [Authorize] // so sera possivel listar todos os cliente, caso o usuario tenha gerado o token
        public IActionResult ListarTodos()
        {
            return Ok(_clienteRepository.ListarTodos());
        }

        [HttpPost]
        public IActionResult CadastrarCliente(CadastrarClienteDTO cli) 
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
            //Cliente cli = _context.Clientes.FirstOrDefault(c => c.NomeCompleto == nome);
            var cli = _clienteRepository.BuscarClientePorNome(nome);
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
            return Ok(_clienteRepository.ListarTodosOrdenados());
        }

        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, CadastrarClienteDTO cli)
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


        // exemplo: /api/cliente/marcos@gmail.com/12345
        [HttpPost("login")]
        public IActionResult Login(LoginDTO loginDTO)
        {;
            var cli = _clienteRepository.BuscarPorEmailSenha(loginDTO.Email, loginDTO.Senha);
            if (cli == null)
            {

                return Unauthorized("Email ou Senha invalidos");
            }
            else
            {
                //criar o token
                var tokenService = new TokenServices();

                var token = tokenService.GenereteToken(cli.Email);
                return Ok(token);
            }
        }
    }
}
