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
                    .Where(request => request.TechTeamId == Id && request.RequestStatus == Status.Active)
                    .ToListAsync(),

                Type supportOperatorType when supportOperatorType == typeof(SupportOperator) => await _context.Requests
                    .Where(request => request.OperatorId == Id && request.RequestStatus == Status.Active)
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
                    .Where(request => request.TechTeamId == Id && request.RequestStatus == Status.Closed)
                    .ToListAsync(),

                Type supportOperatorType when supportOperatorType == typeof(SupportOperator) => await _context.Requests
                    .Where(request => request.OperatorId == Id && request.RequestStatus == Status.Closed)
                    .ToListAsync(),

                _ => throw new ArgumentNullException(nameof(DbSet<T>))
            };

            return closedRequests.AsQueryable();
        }

        public async Task AcceptRequest(int requestId, int userId)
        {
            var request = await _context.Requests.FindAsync(requestId);

            if (request != null)
            {
                switch (typeof(T))
                {
                    case Type techTeamType when techTeamType == typeof(TechnicalTeam):
                        request.RequestStatus = Status.InProgress;
                        request.TechTeamId = userId;
                        break;

                    case Type supportOperatorType when supportOperatorType == typeof(SupportOperator):
                        request.RequestStatus = Status.InProgress;
                        request.OperatorId = userId;
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
        //TODO: Add to Services
        public async Task SetEcoBoxQuantityAndTemplate(int requestId, int quantity, int templateId)
        {
            var request = await _context.Requests.Include(r => r.Location)
                .ThenInclude(location => location.EcoBoxes)
                .FirstOrDefaultAsync(request => request.Id == requestId);

            if (request != null)
            {
                if (request.Location != null && request.Location.EcoBoxes != null && request.Location.EcoBoxes.Any())
                {
                    var ecoBoxTemplate = await _context.EcoBoxTemplates.FindAsync(templateId);
                    if (ecoBoxTemplate != null)
                    {
                        var ecoBoxesToUpdate = request.Location.EcoBoxes.Take(quantity);

                        foreach (var ecoBox in ecoBoxesToUpdate)
                        {
                            ecoBox.Template = ecoBoxTemplate;
                        }
                    }
                    else
                    {
                        throw new ArgumentException("Invalid EcoBoxTemplateId.");
                    }
                }
                else
                {
                    throw new InvalidOperationException("The Location or EcoBoxes associated with the Request are not available.");
                }

                await _context.SaveChangesAsync();
            }
        }
    }
}
