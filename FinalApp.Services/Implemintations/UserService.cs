using FinalApp.ApiModels.DTOs.EntitiesDTOs.RequestsDTO;
using FinalApp.ApiModels.Response.Helpers;
using FinalApp.ApiModels.Response.Interfaces;
using FinalApp.DAL.Repository.Interfaces;
using FinalApp.Domain.Models.Common.BaseUsersInfo;
using FinalApp.Domain.Models.Entities.Requests.RequestsInfo;
using FinalApp.Domain.Models.Enums;
using FinalApp.Services.Helpers;
using FinalApp.Services.Interfaces;
using FinalApp.Services.Mapping;
using FinallApp.ValidationHelper;
using Microsoft.EntityFrameworkCore;

namespace FinalApp.Services.Implemintations
{
    public class UserService<T> : IUserService<T>
        where T : BaseUser
    {
        private readonly IBaseAsyncRepository<Request> _repository;

        public UserService(IBaseAsyncRepository<Request> repository)
        {
            _repository = repository;
        }

        public async Task<IBaseResponse<IEnumerable<RequestDTO>>> GetActiveRequests(int Id)
        {
            try
            {
                NumberValidator<int>.IsPositive(Id);

                var requests = TypeHelper<T>.CheckUserTypeForActiveRequest(Id, _repository).Result;

                ObjectValidator<IEnumerable<Request>>.CheckIsNotNullObject(requests);
                IEnumerable<RequestDTO> requestsDTO = MapperHelperForDto<Request, RequestDTO>.Map(requests);

                return ResponseFactory<RequestDTO>.CreateSuccessResponseForModelCollection(requestsDTO);
            }
            catch (ArgumentException argException)
            {
                return ResponseFactory<RequestDTO>.CreateNotFoundResponseForModelCollection(argException);
            }
            catch (Exception exception)
            {
                return ResponseFactory<RequestDTO>.CreateErrorResponseForModelCollection(exception);
            }
        }

        public async Task<IBaseResponse<IEnumerable<RequestDTO>>> GetClosedRequests(int Id)
        {
            try
            {
                NumberValidator<int>.IsPositive(Id);

                var requests = TypeHelper<T>.CheckUserTypeForClosedRequest(Id, _repository).Result;

                ObjectValidator<IEnumerable<Request>>.CheckIsNotNullObject(requests);
                IEnumerable<RequestDTO> requestsDTO = MapperHelperForDto<Request, RequestDTO>.Map(requests);

                return ResponseFactory<RequestDTO>.CreateSuccessResponseForModelCollection(requestsDTO);
            }
            catch (ArgumentException argException)
            {
                return ResponseFactory<RequestDTO>.CreateNotFoundResponseForModelCollection(argException);
            }
            catch (Exception exception)
            {
                return ResponseFactory<RequestDTO>.CreateErrorResponseForModelCollection(exception);
            }
        }
        public async Task<IBaseResponse<bool>> AcceptRequest(int requestId, int Id)
        {
            try
            {
                NumberValidator<int>.IsPositive(requestId);
                NumberValidator<int>.IsPositive(Id);

                var request = await TypeHelper<T>.CheckUserTypeForAcceptRequest(requestId, Id, _repository);
                ObjectValidator<Request>.CheckIsNotNullObject(request);

                await _repository.UpdateAsync(request);

                return ResponseFactory<bool>.CreateSuccessResponse(true);
            }
            catch (ArgumentException argException)
            {
                return ResponseFactory<bool>.CreateNotFoundResponse(argException);
            }
            catch (Exception exception)
            {
                return ResponseFactory<bool>.CreateErrorResponse(exception);
            }
        }
        public async Task<IBaseResponse<bool>> MarkRequestAsCompleted(int requestId)
        {
            try
            {
                NumberValidator<int>.IsPositive(requestId);
                var request = await _repository.ReadByIdAsync(requestId);
                ObjectValidator<Request>.CheckIsNotNullObject(request);

                request.RequestStatus = Status.Completed;
                await _repository.UpdateAsync(request);

                return ResponseFactory<bool>.CreateSuccessResponse(true);
            }
            catch (ArgumentException argException)
            {
                return ResponseFactory<bool>.CreateNotFoundResponse(argException);
            }
            catch (Exception exception)
            {
                return ResponseFactory<bool>.CreateErrorResponse(exception);
            }
        }

        public async Task<IBaseResponse<bool>> CloseRequestByUser(int requestId, int Id)
        {
            try
            {
                NumberValidator<int>.IsPositive(requestId);
                NumberValidator<int>.IsPositive(Id);

                var request = await _repository.ReadByIdAsync(requestId);
                ObjectValidator<Request>.CheckIsNotNullObject(request);

                request.RequestStatus = Status.Closed;
                await _repository.UpdateAsync(request);

                return ResponseFactory<bool>.CreateSuccessResponse(true);
            }
            catch (ArgumentException argException)
            {
                return ResponseFactory<bool>.CreateNotFoundResponse(argException);
            }
            catch (Exception exception)
            {
                return ResponseFactory<bool>.CreateErrorResponse(exception);
            }
        }

    }
}
