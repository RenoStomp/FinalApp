using FinalApp.ApiModels.DTOs.CommonDTOs.BaseDTOs;
using FinalApp.ApiModels.Response.Interfaces;
using FinalApp.DAL.Repository.Interfaces;
using FinalApp.Domain.Models.Common.BaseUsersInfo;
using FinalApp.Services.Interfaces;

namespace FinalApp.Services.Implemintations
{
    public class UserBaseService<T, Tmodel> : IUserBaseService<T, Tmodel>
        where T : BaseUser
        where Tmodel : UsersDTO
    {
        private readonly IBaseAsyncRepository<T> _repository;

        public UserBaseService(IBaseAsyncRepository<T> repository)
        {
            _repository = repository;
        }

        public Task<IBaseResponse<bool>> AcceptRequest(int requestId, int techTeamId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<T>> GetActiveRequests(int techTeamId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<T>> GetClosedRequests(int techTeamId)
        {
            throw new NotImplementedException();
        }

        public Task<IBaseResponse<bool>> MarkRequestAsCompleted(int requestId)
        {
            throw new NotImplementedException();
        }

        public Task<IBaseResponse<bool>> SetEcoBoxQuantityAndTemplate(int requestId, int quantity, int templateId)
        {
            throw new NotImplementedException();
        }
    }
}
