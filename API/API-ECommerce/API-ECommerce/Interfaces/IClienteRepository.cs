﻿using System.Globalization;
using API_ECommerce.DTO.Cliente;
using API_ECommerce.Models;
using API_ECommerce.ViewModels;
namespace API_ECommerce.Interfaces
{
    public interface IClienteRepository
    {
        List<ListarClienteViewModel> ListarTodos();
        List<Cliente> BuscarClientePorNome(string nome);
        List<Cliente> BuscarClienteNomeParcial(string nome);
        List<Cliente> ListarTodosOrdenados();
        Cliente BuscarPorEmailSenha(string email, string senha);
        Cliente BuscarPorId(int id);
        void Cadastrar(CadastrarClienteDTO cliente);
        void Atualizar(int id, CadastrarClienteDTO cliente);
        void Deletar(int id);
       
    }
}
