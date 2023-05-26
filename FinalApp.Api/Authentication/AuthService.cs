using FinalApp.Domain.Models.Abstractions.BaseUsers;
using FinalApp.Services.Interfaces;
using FinallApp.ValidationHelper;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace FinalApp.Api.Authentication
{
    public class AuthService : IAuthService
    {
        private readonly IAuthManager<User> _authManager;
        private readonly JwtSettings _jwtSettings;
        public AuthService(IAuthManager<User> userManager, IOptions<JwtSettings> jwtsettings)
        {
            _authManager = userManager;
            _jwtSettings = jwtsettings.Value;
        }
        public async Task<string> AccessToken(string email, string password)
        {
            try
            {
                var user = await _authManager.FindByLoginAsync(email);

                ObjectValidator<User>.CheckIsNotNullObject(user);

                var result = await _authManager.CheckPasswordAsync(user, password);
                if (result == false) throw new ArgumentNullException("Password is not correct");


                var role = user.UserType;
                var claims = new List<Claim>
                {
                    new Claim(ClaimsIdentity.DefaultNameClaimType, email),
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new Claim(ClaimTypes.Role, role.ToString())
                };

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
            catch (ArgumentNullException argNullException)
            {
                throw new ArgumentNullException("User not found\n\r" +
                    $"Error: {argNullException}");
            }
            catch (Exception exception)
            {
                throw new Exception(" internal server error.\n\r" +
                    $"Error: {exception}");
            }


        }

    }
}
