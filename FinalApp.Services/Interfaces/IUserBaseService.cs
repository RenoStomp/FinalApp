using FinalApp.ApiModels.DTOs.CommonDTOs.BaseDTOs;
using FinalApp.ApiModels.Response.Interfaces;
using FinalApp.Domain.Models.Common.BaseUsersInfo;
using FinalApp.Domain.Models.Entities.Requests.RequestsInfo;

namespace FinalApp.Services.Interfaces
{
    public interface IUserBaseService
    {
        public Task<IEnumerable<Request>> GetActiveRequests(int Id);
        public Task<IEnumerable<Request>> GetClosedRequests(int Id);
        public Task<IBaseResponse<bool>> AcceptRequest(int requestId, int Id);
        public Task<IBaseResponse<bool>> MarkRequestAsCompleted(int requestId);
        public Task<IBaseResponse<bool>> SetEcoBoxQuantityAndTemplate(int requestId, int quantity, int templateId);

    }
}
