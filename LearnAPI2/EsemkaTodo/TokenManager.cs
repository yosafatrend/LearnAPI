using LearnAPI2.Models;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace LearnAPI2.EsemkaTodo
{
    public class TokenManager : ITokenManager
    {
        EsemkaTodoContext _esemkaTodoContext;
        private JwtSecurityTokenHandler tokenHandler;
        private byte[] secretKey;

        public TokenManager(EsemkaTodoContext esemkaTodoContext)
        {
            _esemkaTodoContext = esemkaTodoContext;
            tokenHandler = new JwtSecurityTokenHandler();
            secretKey = Encoding.ASCII.GetBytes("qwertyuiopasdfghjklzxcvbnmqwerty");
        }

        public bool Authenticate(Auth user)
        {
            var count = _esemkaTodoContext.Users.Count(p => p.Email == user.email);
            if (count == 1)
            {
                var userValid = _esemkaTodoContext.Users.Where(p => p.Email == user.email && p.Password == user.password).FirstOrDefault();
                if (userValid != null)
                {
                    return true;
                }
            }
            return false;
        }

        public string NewToken(string email)
        {
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[] 
                { 
                    new Claim(ClaimTypes.Name, email), 
                }),
                Expires = DateTime.UtcNow.AddMinutes(10),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(secretKey),
                    SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var jwtString = tokenHandler.WriteToken(token);
            return jwtString;
        }

        public ClaimsPrincipal VerifyToken(string token)
        {
            var claims = tokenHandler.ValidateToken(token,
                new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(secretKey),
                    ValidateLifetime = true,
                    ValidateAudience = false,
                    ValidateIssuer = false,
                    ClockSkew = TimeSpan.Zero
                }, out SecurityToken validatedToken);

            return claims;
        }
    }
}
