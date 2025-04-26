using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace API_ECommerce.Models;

public partial class ItemPedido
{
    public int IdItemPedido { get; set; }

    public int Quantidade { get; set; }

    public int IdPedido { get; set; }

    public int IdProduto { get; set; }
    
    [JsonIgnore] //usado para nao entrar no loop quando der um GET no pedido
    public virtual Pedido IdPedidoNavigation { get; set; } = null!;

    public virtual Produto IdProdutoNavigation { get; set; } = null!;
}
