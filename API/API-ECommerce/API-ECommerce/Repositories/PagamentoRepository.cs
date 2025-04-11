using API_ECommerce.Context;
using API_ECommerce.Interfaces;
using API_ECommerce.Models;

namespace API_ECommerce.Repositories
{
    //Primeiro passo, primeiro herdar da inteface
    //Segundo passo, implementa a interface( os metodos)
    //Terceiro passo, Injetar o Contexto
    public class PagamentoRepository : IPagamentoRepository //-> o PagamentoRepository precisa herdar da Interface
    {
        //Injetar o contexto
        private readonly EcommerceContext _context;
        public PagamentoRepository(EcommerceContext context)
        {
            _context = context;
        }
        //Implementar a interface( os metodos)
        public void Atualizar(int id, Pagamento pagamento)
        {
            throw new NotImplementedException();
        }
        //Implementar a interface( os metodos)
        public Pagamento BuscarPorid(int id)
        {
            throw new NotImplementedException();
        }
        //Implementar a interface( os metodos)
        public void Cadastrar(Pagamento pagamento)
        {
            throw new NotImplementedException();
        }
        //Implementar a interface( os metodos)
        public void Deletar(int id)
        {
            throw new NotImplementedException();
        }
        //Implementar a interface( os metodos)
        public List<Pagamento> ListarTodos()
        {
            throw new NotImplementedException();
        }
    }
}
