using FinalApp.Domain.Models.Common.BaseRequests;
using FinalApp.Domain.Models.Entities.Requests.RequestsInfo;

namespace FinalApp.DAL.Repository.Interfaces
{
    public interface ILocationRepository<T> 
        where T : BaseLocation
    {
        public Task<IQueryable<T>> GetLocationsByCity(string city);
        public Task<IQueryable<T>> GetLocationsByZipCode(string zipCode);
        public Task<T> GetLocationByRequestId(int requestId);

    }
}
