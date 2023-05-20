using FinalApp.DAL.Repository.Interfaces;
using FinalApp.DAL.SqlServer;
using FinalApp.Domain.Models.Entities.Persons.Users;
using Microsoft.EntityFrameworkCore;

namespace FinalApp.DAL.Repository.Implemintations
{
    public class ClientRepository : BaseAsyncRepository<Client>, IClientRepository
    {
        public ClientRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IQueryable<Client>> GetClientsWithRequests()
        {
            var clientsWithRequests = await _context.Clients.Include(c => c.Rrequests).ToListAsync();
            return clientsWithRequests.AsQueryable();
        }
    }
}
