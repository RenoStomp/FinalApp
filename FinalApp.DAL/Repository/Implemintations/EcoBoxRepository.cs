using FinalApp.DAL.Repository.Implemintations;
using FinalApp.DAL.Repository.Interfaces;
using FinalApp.DAL.SqlServer;
using FinalApp.Domain.Models.Common.BaseRequests;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace FinalApp.DAL.Repository.Implementations
{
    public class EcoBoxRepository<T> : BaseAsyncRepository<T>, IEcoBoxRepository<T>
        where T : BaseEcoBox
    {
        public EcoBoxRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IQueryable<T>> GetEcoBoxesByLocationId(int locationId)
        {
            var ecoBoxes = await _dbSet
                .Where(e => e.LocationId == locationId)
                .ToListAsync();

            return ecoBoxes.AsQueryable();
        }

        public async Task<IQueryable<T>> GetEcoBoxesByTemplateId(int templateId)
        {
            var ecoBoxes = await _dbSet
                .Where(e => e.TemplateId == templateId)
                .ToListAsync();

            return ecoBoxes.AsQueryable();
        }

    }
}
