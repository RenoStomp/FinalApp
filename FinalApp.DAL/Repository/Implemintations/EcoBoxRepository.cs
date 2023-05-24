using FinalApp.DAL.Repository.Implemintations;
using FinalApp.DAL.Repository.Interfaces;
using FinalApp.DAL.SqlServer;
using FinalApp.Domain.Models.Abstractions.BaseRequests;
using FinalApp.Domain.Models.Entities.Requests.EcoBoxInfo;
using Microsoft.EntityFrameworkCore;

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
                .OfType<EcoBox>()
                .Where(e => e.LocationId == locationId)
                .ToListAsync();

            return ecoBoxes.Cast<T>().AsQueryable();
        }

        public async Task<IQueryable<T>> GetEcoBoxesByTemplateId(int templateId)
        {
            var ecoBoxes = await _dbSet
                .OfType<EcoBox>()
                .Where(e => e.TemplateId == templateId)
                .ToListAsync();

            return ecoBoxes.Cast<T>().AsQueryable();
        }

    }
}
