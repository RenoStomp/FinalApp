using FinalApp.ApiModels.DTOs.EntitiesDTOs.RequestsDTO;
using FinalApp.ApiModels.Response.Interfaces;
using FinalApp.Domain.Models.Entities.Requests.RequestsInfo;

namespace FinalApp.Services.Interfaces
{
    public interface IRequestService
    {
        public Task<IBaseResponse<IEnumerable<RequestDTO>>> GetUnassignedRequests();
        public Task<IBaseResponse<IEnumerable<RequestDTO>>> GetClosedRequestsByOperatorId(int operatorId);
        public Task<IBaseResponse<IEnumerable<RequestDTO>>> GetActiveRequestsByOperatorId(int operatorId);
        public Task<IBaseResponse<bool>> AssignRequestToTeam(int requestId, int teamId);
        public Task<IBaseResponse<bool>> AssignRequestToOperator(int requestId, int operatorId);
        public Task<IBaseResponse<bool>> MarkRequestAsCompleted(int requestId);
        public Task<IBaseResponse<bool>> AssignLocationToRequest(int requestId, int locationId);

    }
}
