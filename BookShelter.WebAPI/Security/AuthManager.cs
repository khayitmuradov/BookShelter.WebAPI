using BookShelter.WebAPI.Interfaces.Managers;
using BookShelter.WebAPI.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BookShelter.WebAPI.Security;

public class AuthManager : IAuthManager
{
    private readonly IConfigurationSection _config;

    public AuthManager(IConfiguration configuration)
    {
         _config = configuration.GetSection("Jwt");
    }

    public string GenerateToken(User user)
    {
        var claims = new[]
            {
                new Claim("Id", user.Id.ToString()),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, user.UserRole.ToString()),
            };

        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["SecretKey"]));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);
        var tokenDescriptor = new JwtSecurityToken(_config["Issuer"], _config["Audience"], claims,
            expires: DateTime.Now.AddMinutes(double.Parse(_config["Lifetime"])),
            signingCredentials: credentials);

        return new JwtSecurityTokenHandler().WriteToken(tokenDescriptor);
    }
}
