using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using API.entities;
using API.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace API.Services
{
    //Questa classe implemeta il nostro metodo CreateToken...si trova nell'interfaccia TokenService
    public class TokenService : ITokenService // questa riga significa che la classe TokenService Implementa (:) l'interfaccia ITokenService 
    {
        //Qui abbiamo bisogno du un costruttore perche andiamo ad iniettare la nostra comfigurazione in questa classe
        private readonly SymmetricSecurityKey _key; //tipo di crittografia
        public TokenService(IConfiguration config)
        {
           _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["TokenKey"]));
        }

        public string CreateToken(AppUser user)
        {
           var claims = new List<Claim> //add our claim--aggiungere la nostra richiesta
           {
                new Claim(JwtRegisteredClaimNames.NameId, user.Username)  
           };

           var creds = new SigningCredentials(_key, SecurityAlgorithms.HmacSha512Signature); //creare le credenziali 

           var tokenDescriptor = new SecurityTokenDescriptor //e descrivere come apparirà il nostro token 
           {
               Subject = new ClaimsIdentity(claims),
               Expires = DateTime.Now.AddDays(7),
               SigningCredentials = creds
           };

           var tokenHandler = new JwtSecurityTokenHandler();//supporto che ci serve per il token

           var token = tokenHandler.CreateToken(tokenDescriptor); //creiamo il token 

           return tokenHandler.WriteToken(token); // restituiure il token a chi ne ha bisogno
        }
    }
}