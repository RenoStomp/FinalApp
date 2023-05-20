using FinalApp.Domain.Models.Entities.Requests.RequestsInfo;

namespace FinalApp.DAL.Repository.Interfaces
{
    internal interface ITechnicalTeamRepository
    {
        public Task<IQueryable<Request>> GetActiveRequestsForBrigade(int techTeamId);
        public Task<IQueryable<Request>> GetClosedRequestsForBrigade(int techTeamId);
        public Task AcceptRequest(int requestId, int techTeamId);
        public Task MarkRequestAsCompleted(int requestId);

    }
}
