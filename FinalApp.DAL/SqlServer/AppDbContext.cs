using FinalApp.Domain.Models.Entities.Persons.Users;
using Microsoft.EntityFrameworkCore;

namespace FinalApp.DAL.SqlServer
{
    public class AppDbContext : DbContext
    {
        public DbSet<Client>
    }
}
