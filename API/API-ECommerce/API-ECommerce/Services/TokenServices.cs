//Classe para cria o token de autenticacao

using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace API_ECommerce.Services
{
    public class TokenServices
    {
        public string GenereteToken(string email)
        {
            //Criar as Claims --> sao informacoes do usuario que eu quero guardar
            var claims = new[]
            {
                new Claim(ClaimTypes.Email, email) //nesse token sera guardado o email do usuario
                               
            };

            //Criar uma chave de seguranca e criptografar ela
            var chave = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("minha-chave-secreta-senai")); //Classe padrao do C#, serve para guardar chave secreta criptografada
            
        }
    }
}
