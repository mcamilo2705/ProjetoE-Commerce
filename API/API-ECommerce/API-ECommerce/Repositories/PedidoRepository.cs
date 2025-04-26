using System.Text.Json.Serialization;
using API_ECommerce.Context;
using API_ECommerce.DTO.Pedido;
using API_ECommerce.Interfaces;
using API_ECommerce.Models;
using API_ECommerce.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace API_ECommerce.Repositories
{
    public class PedidoRepository : IPedidoRepository
    {
        private readonly EcommerceContext _context;

        public PedidoRepository(EcommerceContext context)
        {
            _context = context;
        }
        public void Atualizar(int id, Pedido pedido)
        {
            throw new NotImplementedException();
        }

        public Pedido BuscarPorId(int id)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(CadastrarPedidoDTO pedidoDTO)
        {
            //1- Cadastrar o pedido
            //Criar uma variavel pedido para guardar as informacoes do pedido 
            var pedido = new Pedido
            {
                DataPedido = pedidoDTO.DataPedido,
                Status = pedidoDTO.Status,
                IdCliente = pedidoDTO.IdCliente,
                ValorTotal = pedidoDTO.ValorTotal,
            };

            _context.Pedidos.Add(pedido);  
            _context.SaveChanges();

            //2- Cadastrar os ItensPedido
            //Para cada produto eu crio um item pedido
            for (int i = 0; i < pedidoDTO.Produtos.Count; i++) //O for vai percorrer todos os itens do produto
            {
                var produto = _context.Produtos.Find(pedidoDTO.Produtos[i]); //variavel produto que vai receber o contexto do banco

                // TODO: Lancar erro se o produto nao existir 

                var itemPedido = new ItemPedido //declarar variavel para armazenar os itens nos pedidos
                {
                    IdPedido = pedido.IdPedido,
                    IdProduto = produto.IdProduto,
                    Quantidade = 0
                };

                _context.ItemPedidos.Add(itemPedido); //adicionando alteracao
                _context.SaveChanges();//salvando alteracao
            }
        }

        public void Deletar(int id)
        {
            throw new NotImplementedException();
        }

        public List<Pedido> ListarTodos()
        {
            //Para listar os pedidos com a lista de itens pedidos, precisamos usar o .incluse para fazer o join da tabela itens pedido
            return _context.Pedidos
                .Include(p => p.ItemPedidos) // quando incuir os itens do pedidos, precisa usar o ThenInclude, desta forma vai incluir os produtos relacionados ao itens produtos
                .ThenInclude(p => p.IdProdutoNavigation)
                .ToList();
                 
        }

    }
}
