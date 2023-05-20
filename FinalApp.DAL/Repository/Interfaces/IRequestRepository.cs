using FinalApp.Domain.Models.Entities.Requests.RequestsInfo;

namespace FinalApp.DAL.Repository.Interfaces
{
    public interface IRequestRepository
    {
        public Task<IQueryable<Request>> GetUnassignedRequests();
        public Task<IQueryable<Request>> GetClosedRequestsByOperatorId(int operatorId);
        public Task<IQueryable<Request>> GetActiveRequestsByOperatorId(int operatorId);
        public Task AssignRequestToTeam(int requestId, int teamId);
        public Task AssignRequestToOperator(int requestId, int operatorId);
        public Task MarkRequestAsCompleted(int requestId);
    }
}
