using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace IDO_Backend.Data
{
    public class JwtTokenGenerator
    {
        public static async Task<GeneratedTokenResponse> GenerateToken(CustomTokenRequestModel model)
        {
            var claims = new List<Claim>
        {
            new Claim(JwtRegisteredClaimNames.Sub, model.UserId.ToString())
            // Add other claims as needed
        };

            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddHours(5),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(Encoding.UTF8.GetBytes("HelloMyFriendThisIsMySecurityKey")),
                    SecurityAlgorithms.HmacSha256Signature
                )
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return new GeneratedTokenResponse(tokenHandler.WriteToken(token), tokenDescriptor.Expires);
        }
    }
    public class GeneratedTokenResponse
    {
        public string Token { get; set; }
        public DateTime? Expiration { get; set; }

        public GeneratedTokenResponse(string token, DateTime? expiration)
        {
            Token = token;
            Expiration = expiration;
        }
    }

}
