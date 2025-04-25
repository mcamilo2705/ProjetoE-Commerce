﻿//Neste cenario foi criada essa classe, para ocultar alguns campos quando for listar todos os cliente ,como por exemplo: ocultar o campo senha e pedidos. Obs pode usar ViewModel ou DTO, amabas tem a mesma funcao de ocultar propriedades/campos

using API_ECommerce.Models;

namespace API_ECommerce.ViewModels
{
    public class ListarClienteViewModel
    {
        public int IdCliente { get; set; }

        public string NomeCompleto { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string? Telefone { get; set; }

        public string? Endereco { get; set; }

        public DateOnly? DataCadastro { get; set; }

    }
}
