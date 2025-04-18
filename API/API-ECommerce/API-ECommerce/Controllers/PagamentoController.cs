using API_ECommerce.Context;
using API_ECommerce.Interfaces;
using API_ECommerce.Models;
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
        public PagamentoController(IPagamentoRepository pagamentoRepository) //INJECAO DE DEPENDENCIA... Ao inves de eu instaciar a classe eu aviso que dependo dela e a resposabilidade de criar vem para a classe que chama(C#)
        {
            //_context = context;
            _pagamentoRepository = pagamentoRepository;
        }

        //Primeiro passo, definir o verbo, get, post, put
        [HttpGet]
        public IActionResult ListarTodos() //Metodo criado para listar tudo
        {
            return Ok(_pagamentoRepository.ListarTodos()); //Vai retornar as informacoes com base no repository
        }

        [HttpPost]
        public IActionResult CadastrarPagamento(Pagamento pag)
        {
            //1-Colocar o produto no banco de dados, chamar a variavel do repository, acessar o metodos e passar o prod
            _pagamentoRepository.Cadastrar(pag);
            //2-Salvar a informacao afirmando para o entity framework confirmar a operacao,
            //_context.SaveChanges(); -> esse comando foi para a classe ProdutoRepository no metodo cadastrar
            //3-Retonar o resultado
            //Retorno 201- Created
            return Created();
        }

        [HttpGet("{id}")]
        //Criar o metodo de listar por id
        public IActionResult ListarPorId(int id)
        {
            //Declarando uma variavel do tipo Produto para receber o produto do repository
            Pagamento pag = _pagamentoRepository.BuscarPorid(id);

            if (pag == null)
            {
                //Se o produto for nullo, apresentar o retorno 404-Nao Encontrado
                return NotFound();

            }
            else
            {
                //Se o produto foi encontrado, apresentar o retorno 200-Sucesso e o produto
                return Ok(pag);
            }
        }

        [HttpPut("{id}")]
        //neste metodos sera preciso receber o id do produto e compara com o prod para poder atualizar
        public IActionResult Editar(int id, Pagamento pag)
        {
            try //Se encontrar o produto
            {
                //_produtoRepository (acessar o context/banco de dados)
                //Editar (id) editar o produto pelo id
                _pagamentoRepository.Atualizar(id, pag);
                // Retornar 200
                return Ok(pag);
            }
            //Caso dar erro ou nao encontrao o produto
            catch (Exception ex)
            {
                return NotFound("Pagamento nao encontrado");
            }
        }

        [HttpDelete("{id}")]

        public IActionResult Deletar(int id)
        {
            try //Se encontrar o produto
            {
                //_produtoRepository (acessar o context/banco de dados)
                //Deletar (id) deletar o produto pelo id
                _pagamentoRepository.Deletar(id);
                // Retornar 204
                return NoContent();
            }
            //Caso dar erro ou nao encontrao o produto
            catch (Exception ex)
            {
                return NotFound("Pagamento nao encontrado");
            }
        }
    }
}
