﻿//A interface informa quais metodos serao usados, mas nao informa as funcoes que o repository poderia fazer
using API_ECommerce.DTO.Produto;
using API_ECommerce.Models;
namespace API_ECommerce.Interfaces
{
    public interface IProdutoRepository
    {
        //criar 5 metodos para o CRUD
        //R - Read (Leitura) -> criar uma listar para retornar todos os produtos
        //retorno
        List<Produto> ListarTodos();
        
        // Receber um identificador e retorna o produto correspondete -> o id representa para buscar um produto especifico
        Produto BuscarPorId(int id);

        //C - Create (Cadastro)
        void Cadastrar(CadastrarProdutoDTO produto); //neste cenario esta usando a classe CadastrarProdutosDTO para o cadastro do produto apenas com os campos necessarios

        //U - Update (Atualizar) -> o id representa qual produto deve atualizar e a variavel produto sao os valores para atualizar
        void Atualizar(int id, CadastrarProdutoDTO produto);//neste cenario esta usando a classe CadastrarProdutosDTO para o cadastro do produto apenas com os campos necessarios

        //D - Delete (Deletar) -> o id representa qual produto vai ser deletado
        void Deletar (int id);

    }
}
