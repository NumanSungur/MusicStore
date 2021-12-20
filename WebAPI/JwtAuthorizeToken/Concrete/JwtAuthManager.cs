using B.L.Abstract;
using Cores.Results.ComplexTypes;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using WebAPI.JwtAuthorizeToken.Abstract;

namespace WebAPI.JwtAuthorizeToken.Concrete
{
    public class JwtAuthManager : IJwtAuthService
    {
        private readonly string SecretKey;
        private readonly IUsersAdminService users;
        private readonly Microsoft.Extensions.Configuration.IConfiguration config;
        public JwtAuthManager(IUsersAdminService _users, Microsoft.Extensions.Configuration.IConfiguration _config)
        {
            config = _config;
            users = _users;
            SecretKey = config["Token:SecurityKey"];
        }
        public string Authenticate(string username, string password)
        {
            var Data = users.Login(username, password);
            if (Data.ResultStatus == ResultStatus.Success)
            {
                var TokenHandler = new JwtSecurityTokenHandler(); 
                var TokenKey = Encoding.ASCII.GetBytes(SecretKey);                
                var TokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                        new Claim("Id", Data.Data.Id.ToString()), 
                        new Claim(ClaimTypes.Name, Data.Data.NameSurname), 
                        new Claim(ClaimTypes.Role, Data.Data.Roles) 
                    }),
                    Expires = DateTime.UtcNow.AddHours(2),                     
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(TokenKey), SecurityAlgorithms.HmacSha256Signature)
                };               
                var Token = TokenHandler.CreateToken(TokenDescriptor);                
                return TokenHandler.WriteToken(Token);
            }
            else
            {
                return "Böyle Bir Kullanıcı Bulunamadı";
            }
        }
    }
}
