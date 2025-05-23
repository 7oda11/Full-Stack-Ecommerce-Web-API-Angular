using Ecom.Core.Entities;
using Ecom.Core.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Ecom.Infrastracture.Repositories.Service
{
    public class GenerateToken : IGenerateToken
    {
        private readonly IConfiguration configuration;

        public GenerateToken(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public string GetAndCteateToken(AppUser user)
        {
            var claims = new List<Claim>
    {
        new Claim(ClaimTypes.Name, user.UserName),
        new Claim(ClaimTypes.Email, user.Email),
        // Add issuer claim explicitly
        new Claim(JwtRegisteredClaimNames.Iss, configuration["Token:Issure"])
    };

            var securityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(configuration["Token:Secret"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                Issuer = configuration["Token:Issure"], // Make sure this matches your config
                SigningCredentials = credentials,
                NotBefore = DateTime.Now,
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

       
    }
}
