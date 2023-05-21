using FinalApp.ApiModels.DTOs.CommonDTOs.BaseDTOs;
using FinalApp.ApiModels.Response.Helpers;
using FinalApp.ApiModels.Response.Interfaces;
using FinalApp.DAL.Repository.Interfaces;
using FinalApp.Domain.Models.Common.BaseUsersInfo;
using FinalApp.Domain.Models.Entities.Persons.Users;
using FinalApp.Domain.Models.Entities.Requests.RequestsInfo;
using FinalApp.Domain.Models.Enums;
using FinalApp.Services.Interfaces;
using FinalApp.Services.Mapping;
using FinallApp.ValidationHelper;
using Microsoft.EntityFrameworkCore;

namespace FinalApp.Services.Implemintations
{
    public class UserBaseService<T, Tmodel> : IUserBaseService<T, Tmodel>
        where T : BaseUser
        where Tmodel : BaseUserDTO
    {
        private readonly IBaseAsyncRepository<T> _repository;

        public UserBaseService(IBaseAsyncRepository<T> repository)
        {
            _repository = repository;
        }
        public async Task<IEnumerable<Request>> GetActiveRequests(int techTeamId)
        {
            try
            {
                NumberValidator<int>.IsPositive(techTeamId);

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

                return ResponseFactory<Request>
                    .CreateSuccessResponseForModelCollection(entityDTO);
            }
            catch (ArgumentNullException argNullException)
            {
                return ResponseFactory<Request>
                    .CreateNotFoundResponseForModelCollection(argNullException);
            }
            catch (Exception exception)
            {
                return ResponseFactory<Request>
                    .CreateErrorResponseForModelCollection(exception);
            }
        }

        public Task<IEnumerable<Tmodel>> GetClosedRequests(int techTeamId)
        {
            throw new NotImplementedException();
        }

        public Task<IBaseResponse<bool>> AcceptRequest(int requestId, int techTeamId)
        {
            throw new NotImplementedException();
        } 
        public Task<IBaseResponse<bool>> MarkRequestAsCompleted(int requestId)
        {
            throw new NotImplementedException();
        }

        public Task<IBaseResponse<bool>> SetEcoBoxQuantityAndTemplate(int requestId, int quantity, int templateId)
        {
            throw new NotImplementedException();
        }
    }
}
