using API_ECommerce.Context;
using API_ECommerce.Interfaces;
using API_ECommerce.Models;
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
       // private readonly EcommerceContext _context; //-> criar um variavel pro context para poder conectar no banco de dados
        private IProdutoRepository _produtoRepository;//-> criar uma variavel para o repository para poder fazer o crud
        //public ProdutoController(EcommerceContext context) //-> Metodo contrutor para sempre que o produto for criado, precisa de um contexto e um repository
        public ProdutoController(IProdutoRepository produtoRepository) //-> modelo de boa pratica com INJECAO DE DEPENDECIA
        {
            // _context = context;
            // _produtoRepository = new ProdutoRepository(_context); //esta linha nao e uma boa pratica, foi criada apenas para exemplo, pois o controlador nao precisa criar um repositorio
            _produtoRepository = produtoRepository;
        }

        // para listar, vamos usar o metodo GET
        [HttpGet]
        public IActionResult ListarProdutos()
        {
            return Ok(_produtoRepository.ListarTodos());
        }

        //Cadastrar produto
        [HttpPost]
        public IActionResult CadastrarProduto(Produto prod)
        {
            //1-Colocar o produto no banco de dados, chamar a variavel do repository, acessar o metodos e passar o prod
            _produtoRepository.Cadastrar(prod);
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
            Produto produto = _produtoRepository.BuscarPorId(id);

            if (produto == null)
            {
                //Se o produto for nullo, apresentar o retorno 404-Nao Encontrado
                return NotFound();

            }
            else
            {
                //Se o produto foi encontrado, apresentar o retorno 200-Sucesso e o produto
                return Ok(produto);
            }
        }

        //Verbo atualizar

        [HttpPut("{id}")]
        //neste metodos sera preciso receber o id do produto e compara com o prod para poder atualizar
        public IActionResult Editar(int id, Produto prod)
        {
            try //Se encontrar o produto
            {
                //_produtoRepository (acessar o context/banco de dados)
                //Editar (id) editar o produto pelo id
                _produtoRepository.Atualizar(id, prod);
                // Retornar 200
                return Ok(prod);
            }
            //Caso dar erro ou nao encontrao o produto
            catch (Exception ex)
            {
                return NotFound("Produto nao encontrado");
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
                _produtoRepository.Deletar(id);
                // Retornar 204
                return NoContent();
            }
            //Caso dar erro ou nao encontrao o produto
            catch (Exception ex)
            {
                return NotFound("Produto nao encontrado");
            }
        }
    }
}
