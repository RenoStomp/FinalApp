using FinalApp.Domain.Models.Abstractions.BaseRequests;

namespace FinalApp.DAL.Repository.Interfaces
{
    public interface IEcoBoxRepository<T>
        where T : BaseEcoBox
    {
        public Task<IQueryable<T>> GetEcoBoxesByLocationId(int locationId);
        public Task<IQueryable<T>> GetEcoBoxesByTemplateId(int templateId);

    }
}
