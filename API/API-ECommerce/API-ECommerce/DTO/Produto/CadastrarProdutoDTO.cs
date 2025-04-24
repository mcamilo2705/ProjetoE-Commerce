//A criacao do DTO serve para ocultar propriedades de outras classes, neste exemplo estamos usando alguns campos da classe Models.Produtos, onde nao ha necessidade de usar os campos IdProduto e ItemPedido

namespace API_ECommerce.DTO.Produto
{
    public class CadastrarProdutoDTO
    {
        public string Nome { get; set; } = null!;

        public string? Descricao { get; set; }

        public decimal Preco { get; set; }

        public int EstoqueDisponivel { get; set; }

        public string Categoria { get; set; } = null!;

        public string? Imagem { get; set; }

    }
}
