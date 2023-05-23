using FinalApp.ApiModels.DTOs.EntitiesDTOs.RequestsDTO;
using FinalApp.ApiModels.DTOs.EntitiesDTOs.UsersDTOs;
using FinalApp.ApiModels.Response.Helpers;
using FinalApp.ApiModels.Response.Interfaces;
using FinalApp.DAL.Repository.Interfaces;
using FinalApp.Domain.Models.Entities.Persons.Users;
using FinalApp.Domain.Models.Entities.Requests.RequestsInfo;
using FinalApp.Domain.Models.Enums;
using FinalApp.Services.Interfaces;
using FinalApp.Services.Mapping;
using FinallApp.ValidationHelper;
using Humanizer;
using Microsoft.EntityFrameworkCore;

namespace FinalApp.Services.Implemintations
{
    public class ClientService : IClientService
    {
        private readonly IBaseAsyncRepository<Client> _repository;

        public ClientService(IBaseAsyncRepository<Client> repository)
        {
            _repository = repository;
        }

        public async Task<IBaseResponse<IEnumerable<Client>>> GetClientsWithRequests()
        {
            try
            {
                var clientsWithRequests = await _repository.ReadAllAsync().Result.Include(c => c.Requests).ToListAsync();

                ObjectValidator<IEnumerable<Client>>.CheckIsNotNullObject(clientsWithRequests);

                return ResponseFactory<IEnumerable<Client>>.CreateSuccessResponse(clientsWithRequests);
            }
            catch (ArgumentNullException argNullException)
            {
                return ResponseFactory<IEnumerable<Client>>.CreateNotFoundResponse(argNullException);
            }
            catch (Exception exception)
            {
                return ResponseFactory<IEnumerable<Client>>.CreateErrorResponse(exception);
            }

        }

        public async Task<IBaseResponse<bool>> RegisterClient(ClientDTO client)
        {
            try
            {
                ObjectValidator<ClientDTO>.CheckIsNotNullObject(client);

                var newClient = MapperHelperForEntity<ClientDTO, Client>.Map(client);

                await _repository.Create(newClient);

                return ResponseFactory<bool>.CreateSuccessResponse(true);
            }
            catch (ArgumentNullException argNullException)
            {
                return ResponseFactory<bool>
                    .CreateNotFoundResponse(argNullException);
            }
            catch (Exception exception)
            {
                return ResponseFactory<bool>.CreateErrorResponse(exception);
            }
        }
        public async Task<IBaseResponse<IEnumerable<RequestDTO>>> GetActiveRequests(int clientId)
        {
            try
            {
                NumberValidator<int>.IsPositive(clientId);

                var client = await _repository.ReadByIdAsync(clientId);
                ObjectValidator<Client>.CheckIsNotNullObject(client);

                var activeRequests = client.Requests.Where(r => r.RequestStatus == Status.Active);

                IEnumerable<RequestDTO> activeRequestsDTO = MapperHelperForDto<Request, RequestDTO>.Map(activeRequests);

                return ResponseFactory<IEnumerable<RequestDTO>>.CreateSuccessResponse(activeRequestsDTO);
            }
            catch (ArgumentException argException)
            {
                return ResponseFactory<IEnumerable<RequestDTO>>.CreateNotFoundResponse(argException);
            }
            catch (Exception exception)
            {
                return ResponseFactory<IEnumerable<RequestDTO>>.CreateErrorResponse(exception);
            }
        }

        public async Task<IBaseResponse<IEnumerable<RequestDTO>>> GetClosedRequests(int clientId)
        {
            try
            {
                NumberValidator<int>.IsPositive(clientId);

                var client = await _repository.ReadByIdAsync(clientId);
                ObjectValidator<Client>.CheckIsNotNullObject(client);

                var closedRequests = client.Requests.Where(r => r.RequestStatus == Status.Closed);

                IEnumerable<RequestDTO> closedRequestsDTO = MapperHelperForDto<Request, RequestDTO>.Map(closedRequests);

                return ResponseFactory<IEnumerable<RequestDTO>>.CreateSuccessResponse(closedRequestsDTO);
            }
            catch (ArgumentException argException)
            {
                return ResponseFactory<IEnumerable<RequestDTO>>.CreateNotFoundResponse(argException);
            }
            catch (Exception exception)
            {
                return ResponseFactory<IEnumerable<RequestDTO>>.CreateErrorResponse(exception);
            }
        }

    }
}
