using FinalApp.DAL.Repository.Interfaces;
using FinalApp.DAL.SqlServer;
using FinalApp.Domain.Models.Common.BaseUsersInfo;
using FinalApp.Domain.Models.Entities.Persons.Users;
using FinalApp.Domain.Models.Entities.Requests.RequestsInfo;
using FinalApp.Domain.Models.Enums;
using Microsoft.EntityFrameworkCore;

namespace FinalApp.DAL.Repository.Implemintations
{
    public class UserBaseRepository<T> : BaseAsyncRepository<T>, IUserBaseRepository
        where T : BaseUser
    {
        public UserBaseRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IQueryable<Request>> GetActiveRequests(int Id)
        {
            var activeRequests = typeof(T) switch
            {
                Type techTeamType when techTeamType == typeof(TechnicalTeam) => await _context.Requests
                    .Where(r => r.TechTeamId == Id && r.RequestStatus == Status.Active)
                    .ToListAsync(),

                Type supportOperatorType when supportOperatorType == typeof(SupportOperator) => await _context.Requests
                    .Where(r => r.OperatorId == Id && r.RequestStatus == Status.Active)
                    .ToListAsync(),

                _ => throw new ArgumentNullException(nameof(DbSet<T>))
            };

            return activeRequests.AsQueryable();
        }

        public async Task<IQueryable<Request>> GetClosedRequests(int Id)
        {
            var closedRequests = typeof(T) switch
            {
                Type techTeamType when techTeamType == typeof(TechnicalTeam) => await _context.Requests
                    .Where(r => r.TechTeamId == Id && r.RequestStatus == Status.Closed)
                    .ToListAsync(),

                Type supportOperatorType when supportOperatorType == typeof(SupportOperator) => await _context.Requests
                    .Where(r => r.OperatorId == Id && r.RequestStatus == Status.Closed)
                    .ToListAsync(),

                _ => throw new ArgumentNullException(nameof(DbSet<T>))
            };

            return closedRequests.AsQueryable();
        }

        public async Task AcceptRequest(int requestId, int Id)
        {
            var request = await _context.Requests.FindAsync(requestId);

            if (request != null)
            {
                switch (typeof(T))
                {
                    case Type techTeamType when techTeamType == typeof(TechnicalTeam):
                        request.RequestStatus = Status.InProgress;
                        request.TechTeamId = Id;
                        break;

                    case Type supportOperatorType when supportOperatorType == typeof(SupportOperator):
                        request.RequestStatus = Status.InProgress;
                        request.OperatorId = Id;
                        break;

                    default:
                        throw new ArgumentNullException(nameof(DbSet<T>));
                }

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
