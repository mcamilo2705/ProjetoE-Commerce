namespace API_ECommerce.DTO.Pedido
{
    //Recebo os dados do pedido
    //e recebo os dados dos produtos comprados
    public class CadastrarPedidoDTO
    {
        public DateOnly DataPedido { get; set; }

        public string Status { get; set; } = null!;

        public decimal? ValorTotal { get; set; }

        public int IdCliente { get; set; }

        // Produtos comprados
        public List<int> Produtos { get; set; } // criar a lista int, ou seja, ter o Id dos produtos.
    }
}
