using FinalApp.Domain.Models.Abstractions.BaseUsers;
using FinalApp.Services.Implemintations;
using FinalApp.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace FinalApp.Api.Authentication
{
    public class AuthService : IAuthService
    {
        private readonly IAuthManager<BaseUser> _authManager;
        private readonly JwtSettings _jwtSettings;
        public AuthService(IAuthManager<BaseUser> userManager, IOptions<JwtSettings> jwtsettings)
        {
            _authManager = userManager;
            _jwtSettings = jwtsettings.Value;
        }
        public async Task<string> AccessToken(string email, string password)
        {
            var user = await _authManager.FindByEmailAsync(email);
            if (user == null)
            {
                throw new Exception("User is not found");
            }
            var result = await _authManager.CheckPasswordAsync(user, password);
            if (result == false)
            {
                throw new Exception("Password is not correct");
            }

            var roles = await _authManager.GetRolesAsync(user);
            var claims = new List<Claim>()
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, email),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
            };
            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            var datenow = DateTime.UtcNow;
            var expire = DateTime.UtcNow.Add(TimeSpan.FromMinutes(120));
            var jwt = new JwtSecurityToken(
                _jwtSettings.Issuer,
                _jwtSettings.Audience,
                claims,
                datenow,
                expire,
                new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key)),
                SecurityAlgorithms.HmacSha256)
                );
            var tokenhandler = new JwtSecurityTokenHandler();
            return tokenhandler.WriteToken(jwt);
        }

    }
}
