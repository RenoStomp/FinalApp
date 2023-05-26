using FinalApp.Domain.Models.Abstractions.BaseUsers;
using FinalApp.Domain.Models.Enums;

namespace FinalApp.Services.Interfaces
{
    public interface IAuthManager<T>
        where T : BaseUser
    {
        public Task<T> FindByLoginAsync(string login);
        public Task<bool> CheckPasswordAsync(T user, string password);
    }
}
