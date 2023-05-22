using FinalApp.ApiModels.DTOs.CommonDTOs.BaseDTOs;
using FinalApp.ApiModels.Response.Interfaces;
using FinalApp.DAL.Repository.Interfaces;
using FinalApp.Domain.Models.Common.BaseUsersInfo;
using FinalApp.Domain.Models.Entities.Requests.RequestsInfo;
using FinalApp.Services.Interfaces;

namespace FinalApp.Services.Implemintations
{
    public class UserBaseService<T, Tmodel> : IUserBaseService
        where T : BaseUser
        where Tmodel : BaseUserDTO
    {
        private readonly IBaseAsyncRepository<T> _repository;

        public UserBaseService(IBaseAsyncRepository<T> repository)
        {
            _repository = repository;
        }

        public Task<IBaseResponse<bool>> AcceptRequest(int requestId, int Id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Request>> GetActiveRequests(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Request>> GetClosedRequests(int Id)
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
