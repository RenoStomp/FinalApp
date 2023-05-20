using FinalApp.Domain.Models.Entities.Persons.Users;

namespace FinalApp.DAL.Repository.Interfaces
{
    public interface IClientRepository
    {
        /// <summary>
        /// Retrieves a queryable collection of clients with their associated requests.
        /// </summary>
        /// <returns>A task representing the asynchronous operation. The task result contains the queryable collection of clients with requests.</returns>
        public Task<IQueryable<Client>> GetClientsWithRequests();
    }
}
