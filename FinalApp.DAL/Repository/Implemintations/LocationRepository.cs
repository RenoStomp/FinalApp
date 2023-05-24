using FinalApp.DAL.Repository.Implemintations;
using FinalApp.DAL.Repository.Interfaces;
using FinalApp.DAL.SqlServer;
using FinalApp.Domain.Models.Abstractions.BaseRequests;
using Microsoft.EntityFrameworkCore;

namespace FinalApp.DAL.Repository.Implementations
{
    public class LocationRepository<T> : BaseAsyncRepository<T>, ILocationRepository<T>
        where T : BaseLocation
    {
        public LocationRepository(AppDbContext context) : base(context)
        {
        }



        public async Task<IQueryable<T>> GetLocationsByCity(string city)
        {
            var locations = await _dbSet
                .Where(l => l.City == city)
                .ToListAsync();

            return locations.AsQueryable();
        }

        public async Task<IQueryable<T>> GetLocationsByZipCode(string zipCode)
        {
            var locations = await _dbSet
                .Where(l => l.ZipCode == zipCode)
                .ToListAsync();

            return locations.AsQueryable();
        }
        public async Task<T> GetLocationByRequestId(int requestId)
        {
            var location = await _dbSet
                .SingleOrDefaultAsync(location => _context.Requests
                .Any(request => request.LocationId == location.Id && request.Id == requestId));

            return location;
        }

    }
}