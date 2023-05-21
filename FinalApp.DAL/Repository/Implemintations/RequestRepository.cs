using FinalApp.DAL.SqlServer;
using FinalApp.Domain.Models.Entities.Requests.RequestsInfo;
using FinalApp.Domain.Models.Enums;
using Microsoft.EntityFrameworkCore;

namespace FinalApp.DAL.Repository.Implemintations
{
    public class RequestRepository : BaseAsyncRepository<Request>, IRequestRepository
    {
        public RequestRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IQueryable<Request>> GetUnassignedRequests()
        {
            var unassignedRequests = await _context.Requests
                .Where(r => r.RequestStatus == Status.Active && r.OperatorId == null && r.TechTeamId == null)
                .ToListAsync();

            return unassignedRequests.AsQueryable();
        }

        public async Task<IQueryable<Request>> GetClosedRequestsByOperatorId(int operatorId)
        {
            var closedRequests = await _context.Requests
                .Where(r => r.OperatorId == operatorId && r.RequestStatus == Status.Closed)
                .ToListAsync();

            return closedRequests.AsQueryable();
        }

        public async Task<IQueryable<Request>> GetActiveRequestsByOperatorId(int operatorId)
        {
            var activeRequests = await _context.Requests
                .Where(r => r.OperatorId == operatorId && r.RequestStatus == Status.Active)
                .ToListAsync();

            return activeRequests.AsQueryable();
        }

        public async Task AssignRequestToTeam(int requestId, int teamId)
        {
            var request = await _context.Requests.FindAsync(requestId);

            if (request != null)
            {
                request.TechTeamId = teamId;
                await _context.SaveChangesAsync();
            }
        }

        public async Task AssignRequestToOperator(int requestId, int operatorId)
        {
            var request = await _context.Requests.FindAsync(requestId);

            if (request != null)
            {
                request.OperatorId = operatorId;
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
        public async Task AssignLocationToRequest(int requestId, int locationId)
        {
            var request = await _context.Requests.FindAsync(requestId);
            var location = await _context.Locations.FindAsync(locationId);

            if (request != null && location != null)
            {
                request.Location = location;
                await _context.SaveChangesAsync();
            }
        }

    }
}
