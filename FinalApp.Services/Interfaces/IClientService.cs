using FinalApp.ApiModels.DTOs.EntitiesDTOs.UsersDTOs;
using FinalApp.ApiModels.Response.Interfaces;
using FinalApp.Domain.Models.Entities.Persons.Users;

namespace FinalApp.Services.Interfaces
{
    public interface IClientService
    {
        public Task<IBaseResponse<IEnumerable<Client>>> GetClientsWithRequests();
        public Task<IBaseResponse<bool>> RegisterClient(ClientDTO client);
    }
}
