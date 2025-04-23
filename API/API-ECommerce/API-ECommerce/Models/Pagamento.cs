using System;
using System.Collections.Generic;

namespace API_ECommerce.Models;

public partial class Pagamento
{
    public int IdPagamento { get; set; } //chave primaria

    public int IdPedido { get; set; } //chave estrangeira

    public string FormaPagamento { get; set; } = null!;

    public string Status { get; set; } = null!;

    public DateTime Data { get; set; }

    //O EF por padrao segue a seguinte forma <nome da tabela>Id. Exemplo PedidoId
    public virtual Pedido? IdPedidoNavigation { get; set; } = null!; //Propriedade de navegacao, ou seja, neste caso existe um relacionamento entre pagamento e pedido. A partir do pagamento e possivel navegar da classe pagamento para a classe do pedido

}
