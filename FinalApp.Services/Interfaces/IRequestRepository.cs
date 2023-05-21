using FinalApp.ApiModels.Response.Interfaces;
using FinalApp.Domain.Models.Entities.Requests.RequestsInfo;

namespace FinalApp.Services.Interfaces
{
    public interface IRequestRepository
    {
        public Task<IBaseResponse<IEnumerable<Request>>> GetUnassignedRequests();
        public Task<IBaseResponse<IEnumerable<Request>>> GetClosedRequestsByOperatorId(int operatorId);
        public Task<IBaseResponse<IEnumerable<Request>>> GetActiveRequestsByOperatorId(int operatorId);
        public Task<IBaseResponse<Request>> AssignRequestToTeam(int requestId, int teamId);
        public Task<IBaseResponse<Request>> AssignRequestToOperator(int requestId, int operatorId);
        public Task<IBaseResponse<Request>> MarkRequestAsCompleted(int requestId);
        public Task<IBaseResponse<Request>> AssignLocationToRequest(int requestId, int locationId);

    }
}
