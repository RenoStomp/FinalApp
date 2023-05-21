using FinalApp.ApiModels.DTOs.CommonDTOs.BaseDTOs;
using FinalApp.ApiModels.DTOs.EntitiesDTOs.RequestsDTO;
using FinalApp.ApiModels.Response.Interfaces;
using FinalApp.Domain.Models.Common;

namespace FinalApp.Services.Interfaces
{
    public interface IBaseService<T, Tmodel>
        where T : BaseEntity
        where Tmodel : BaseEntityDTO
    {
        public Task<IBaseResponse<Tmodel>> Create(T entity);
        public IBaseResponse<IEnumerable<Tmodel>> ReadAll();
        public Task<IBaseResponse<IEnumerable<Tmodel>>> ReadAllAsync();
        public IBaseResponse<Tmodel> ReadById(int id);
        public Task<IBaseResponse<Tmodel>> ReadByIdAsync(int id);
        public Task<IBaseResponse<Tmodel>> UpdateAsync(T item);
        public Task<IBaseResponse<Tmodel>> DeleteAsync(T item);
        public Task<IBaseResponse<Tmodel>> DeleteByIdAsync(int id); 
    }
}