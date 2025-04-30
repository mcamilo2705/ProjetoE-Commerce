//Classe para cria o token de autenticacao

using System.IdentityModel.Tokens.Jwt;
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

            //Criar uma chave de seguranca 
            var chave = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("minha-chave-ultra-mega-secreta-senai")); //Classe SymmetricSecurityKey padrao do C#, serve para guardar chave secreta criptografada

            //Criptografando a chave de seguranca
            var creds = new SigningCredentials(chave, SecurityAlgorithms.HmacSha256);//Classe SigningCredentials padrao do C#, serve para criptografada

            //Montar o token

            var token = new JwtSecurityToken(
                issuer: "ecommerce", //qual o nome do sistem que gerou o token
                audience: "ecommerce",//quem ler o token, ou seja, validacao de quem gerou o token X leitura 
                claims: claims, //quais informacoes do usuario que precisa guardar, neste cenario, o email do usuario
                expires: DateTime.Now.AddMinutes(30),  //Determinar quando o token expira, ou seja, neste cenario vai expirar em 30 minutos
                signingCredentials: creds //informar qual a senha desse token.

                );

            return new JwtSecurityTokenHandler().WriteToken(token); //Definir um new JwtSecurityTokenHandler e passar o token no metodo WriteToken

        }
    }
}
