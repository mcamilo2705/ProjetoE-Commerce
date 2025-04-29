//Neste cenario essa classe sera responsavel por tratar a senha do usuario, vamos usar o Hash ao inves de usar a criptografia.

using API_ECommerce.Models;
using Microsoft.AspNetCore.Identity;

namespace API_ECommerce.Services
{
    public class PasswordService
    {
        //Criar um objeto chamado PasswordHasher, e uma classe propria do .net
        // O PasswordHasher usa o algoritmo PBKDF2

        private readonly PasswordHasher<Cliente> _hasher = new(); //nessa classe PasswordHasher enter os parenteses, sempre vai receber a model que esta tratando a senha. Feito isso, foi criado um objeto _hasher = new();

        //1- Metodo para gerar um hash
        public string HashPassword(Cliente cliente) //Este metodo vai receber o cliente
        {
            return _hasher.HashPassword(cliente, cliente.Senha);// ao passar a senha do cliente sera gerada a hash
        }

        //2- Metodo para verificar o hash
        public bool VerficarSenha(Cliente cliente, string senhaInformada)//neste metodos vai retornar um booleano, onde vai receber como parametro o cliente e a senha
        {
            var resultado = _hasher.VerifyHashedPassword(cliente, cliente.Senha, senhaInformada); //na variavel vai receber o metodos VerifyHashedPassword com os 3 parametros, o cliente, a senha do cliente e a senha informada.

            //Opcao com if else
            //if(resultado == PasswordVerificationResult.Success)
            //{
            //    return true;
            //}
            //else
            //{
            //    return false;
            //}

            return resultado == PasswordVerificationResult.Success;
        }


    }
}
