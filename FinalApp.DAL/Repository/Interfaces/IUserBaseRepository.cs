using FinalApp.Domain.Models.Entities.Requests.RequestsInfo;

namespace FinalApp.DAL.Repository.Interfaces
{
    public interface IUserBaseRepository
    {
        public Task<IQueryable<Request>> GetActiveRequests(int techTeamId);
        public Task<IQueryable<Request>> GetClosedRequests(int techTeamId);
        public Task AcceptRequest(int requestId, int techTeamId);
        public Task MarkRequestAsCompleted(int requestId);

    }
}
