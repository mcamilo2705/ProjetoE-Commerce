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
        public PagamentoRepository(EcommerceContext context) //--> O metodo construtor e um metodo que tem o mesmo nome da classe, no construtor define o que a classe precisa ter
        {
            _context = context;
        }
        //Implementar a interface( os metodos)
        public void Atualizar(int id, Pagamento pagamento)
        {
            Pagamento pag = _context.Pagamentos.Find(id);

            if (pagamento == null)
            {
                throw new Exception();
            }

            pag.Status = pagamento.Status;
            pag.Data = pagamento.Data;
            pag.FormaPagamento = pagamento.FormaPagamento;

            //Efetivar a atualizacao
            _context.SaveChanges();
        }
        //Implementar a interface( os metodos)
        public Pagamento BuscarPorid(int id)
        {
            return _context.Pagamentos.FirstOrDefault(pag => pag.IdPagamento == id);
        }
        //Implementar a interface( os metodos)
        public void Cadastrar(Pagamento pagamento)
        {
            _context.Pagamentos.Add(pagamento);// o context acessa a tabela cliente para poder adicionar/cadastrar
            _context.SaveChanges();
        }
        //Implementar a interface( os metodos)
        public void Deletar(int id)
        {
            Pagamento pag = _context.Pagamentos.Find(id);

            if (pag == null) 
            {
                throw new Exception();
            }

            _context.Pagamentos.Remove(pag);
            _context.SaveChanges();
        }
        //Implementar a interface( os metodos)
        public List<Pagamento> ListarTodos()
        {
            return _context.Pagamentos.ToList(); //-> atraves do context e acessada a tabela de pagamentos para listar
        }
    }
}
