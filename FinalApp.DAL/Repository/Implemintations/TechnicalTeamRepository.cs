using FinalApp.DAL.Repository.Interfaces;
using FinalApp.DAL.SqlServer;
using FinalApp.Domain.Models.Entities.Persons.Users;
using FinalApp.Domain.Models.Entities.Requests.RequestsInfo;
using FinalApp.Domain.Models.Enums;
using Microsoft.EntityFrameworkCore;

namespace FinalApp.DAL.Repository.Implemintations
{
    public class TechTeam : BaseAsyncRepository<TechnicalTeam>, ITechnicalTeamRepository
    {
        public TechTeam(AppDbContext context) : base(context)
        {
        }

        public async Task<IQueryable<Request>> GetActiveRequestsForBrigade(int techTeamId)
        {
            var activeTechTeamRequests = await _context.Requests
                                .Where(r => r.TechTeamId == techTeamId && r.RequestStatus == Status.Active)
                                .ToListAsync();
            return activeTechTeamRequests.AsQueryable();
        }
        public async Task<IQueryable<Request>> GetClosedRequestsForBrigade(int techTeamId)
        {
            var clodedTechTeamRequests = await _context.Requests
                            .Where(r => r.TechTeamId == techTeamId && r.RequestStatus == Status.Closed)
                            .ToListAsync();
            return clodedTechTeamRequests.AsQueryable();
        }

        public async Task AcceptRequest(int requestId, int techTeamId)
        {
            var request = await _context.Requests.FindAsync(requestId);
            if (request != null)
            {
                request.RequestStatus = Status.InProgress;
                request.TechTeamId = techTeamId;
                await _context.SaveChangesAsync();
            }
        }

        public async Task MarkRequestAsCompleted(int requestId)
        {
            var request = await _context.Requests.FindAsync(requestId);
            if (request != null)
            {
                request.RequestStatus = Status.Completed;
                await _context.SaveChangesAsync();
            }
        }
    }
}
