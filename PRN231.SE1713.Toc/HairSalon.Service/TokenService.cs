using HairSalon.Core.Contracts.Services;
using Microsoft.Extensions.Configuration;
using System.Security.Claims;
using System.Security.Cryptography;

namespace HairSalon.Service
{
    public class TokenService(IConfiguration configuration) : ITokenService
    {
        private readonly IConfiguration _configuration = configuration;

        public string GenerateAccessToken(IEnumerable<Claim> claims)
        {
            //var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtConfigurations.Key));
            //var signInCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

            //var jwtOptions = new JwtSecurityToken(
            //    issuer: JwtConfigurations.Issuer,
            //    audience: JwtConfigurations.Audience,
            //    claims: claims,
            //    expires: DateTime.Now.AddMinutes(10),
            //    signingCredentials: signInCredentials
            //);
            //var token = new JwtSecurityTokenHandler().WriteToken(jwtOptions) ?? string.Empty;
            //return token;

            return string.Empty;
        }

        public string GenerateRefreshToken()
        {
            var randomNumber = new byte[32];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomNumber);
                return Convert.ToBase64String(randomNumber);
            }

        }

        public ClaimsPrincipal GetPrincipalFromAccessToken(string token)
        {
            throw new NotImplementedException();
        }
    }
}
