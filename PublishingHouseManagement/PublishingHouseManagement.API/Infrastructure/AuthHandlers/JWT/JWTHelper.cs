using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace PublishingHouseManagement.API.Infrastrcture.AuthHandlers.JWT
{
    public static class JWTHelper
    {
        public static string GenerateJWTToken(string userName, string role, IOptions<JWTConfiguration> options)
        {
            var jwtTokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(options?.Value?.Secret ?? string.Empty);

            var securityTokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, userName),
                    new Claim(ClaimTypes.Role, role),
                }),

                Expires = DateTime.UtcNow.AddMinutes(options?.Value?.ExpirationInMinutes ?? 0),
                Audience = "localhost",
                Issuer = "localhost",
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256)
            };

            var token = jwtTokenHandler.CreateToken(securityTokenDescriptor);

            return jwtTokenHandler.WriteToken(token);
        }
    }
}