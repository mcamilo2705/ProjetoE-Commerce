//A criacao do DTO serve para ocultar propriedades de outras classes, neste exemplo estamos usando alguns campos da classe Models.Cliente, onde nao ha necessidade de usar os campos IdCliente e Pedido


namespace API_ECommerce.DTO.Cliente
{
    public class CadastrarClienteDTO
    {
        public string NomeCompleto { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string? Telefone { get; set; }

        public string? Endereco { get; set; }

        public string Senha { get; set; } = null!;

        public DateOnly? DataCadastro { get; set; }
    }
}
