using FinalApp.ApiModels.DTOs.CommonDTOs.BaseDTOs;
using FinalApp.ApiModels.Response.Interfaces;
using FinalApp.DAL.Repository.Interfaces;
using FinalApp.Domain.Models.Common;
using FinalApp.Domain.Models.Entities.Requests.RequestsInfo;
using FinalApp.Services.Interfaces;

namespace FinalApp.Services.Implemintations
{
    public class BaseService<T, Tmodel> : IBaseService<T, Tmodel>
        where T : BaseEntity
        where Tmodel : BaseEntityDTO
    {
        private readonly IBaseAsyncRepository<T> _repository;

        public BaseService(IBaseAsyncRepository<T> repository)
        {
            _repository = repository;
        }

        public Task<IBaseResponse<Tmodel>> Create(T entity)
        {
            throw new NotImplementedException();
        }

        public Task<IBaseResponse<Tmodel>> DeleteAsync(T item)
        {
            throw new NotImplementedException();
        }

        public Task<IBaseResponse<Tmodel>> DeleteByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public IBaseResponse<IEnumerable<Tmodel>> ReadAll()
        {
            throw new NotImplementedException();
        }

        public Task<IBaseResponse<IEnumerable<Tmodel>>> ReadAllAsync()
        {
            throw new NotImplementedException();
        }

        public IBaseResponse<Tmodel> ReadById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IBaseResponse<Tmodel>> ReadByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IBaseResponse<Tmodel>> UpdateAsync(T item)
        {
            throw new NotImplementedException();
        }
    }
}
