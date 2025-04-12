using API_ECommerce.Context;
using API_ECommerce.Interfaces;
using API_ECommerce.Models;

namespace API_ECommerce.Repositories
{
    //Primeiro passo, primeiro herdar da inteface
    //Segundo passo, implementa a interface( os metodos)
    //Terceiro passo, Injetar o Contexto
    public class ItemPedidoRepository : IItemPedidoRepository
    { 
        //Injetar o contexto
        private readonly EcommerceContext _context;
        public ItemPedidoRepository(EcommerceContext context)//--> O metodo construtor e um metodo que tem o mesmo nome da classe, no construtor define o que a classe precisa ter
        {
            _context = context;
        }
        //Implementar a interface( os metodos)
        public void Atualizar(int id, ItemPedido itempedido)
        {
            throw new NotImplementedException();
        }
        //Implementar a interface( os metodos)
        public ItemPedido BuscarPorId(int id)
        {
            throw new NotImplementedException();
        }
        //Implementar a interface( os metodos)
        public void Cadastrar(ItemPedido itempedido)
        {
            throw new NotImplementedException();
        }
        //Implementar a interface( os metodos)
        public void Deletar(int id)
        {
            throw new NotImplementedException();
        }
        //Implementar a interface( os metodos)
        public List<ItemPedido> ListarTodos()
        {
            throw new NotImplementedException();
        }
    }
}
