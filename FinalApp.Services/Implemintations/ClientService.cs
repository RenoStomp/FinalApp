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

                return ResponseFactory<Client>
                    .CreateSuccessResponseForModelCollection(clientsWithRequests);
            }
            catch (ArgumentNullException argNullException)
            {
                return ResponseFactory<Client>
                    .CreateNotFoundResponseForModelCollection(argNullException);
            }
            catch (Exception exception)
            {
                return ResponseFactory<Client>
                    .CreateErrorResponseForModelCollection(exception);
            }

        }

        public async Task<IBaseResponse<bool>> RegisterClient(ClientDTO client)
        {
            try
            {
                ObjectValidator<ClientDTO>.CheckIsNotNullObject(client);

                var newClient = MapperHelperForEntity<ClientDTO, Client>.Map(client);

                await _repository.Create(newClient);

                return ResponseFactory<bool>.CreateSuccessResponseForOneModel(true);
            }
            catch (ArgumentNullException argNullException)
            {
                return ResponseFactory<bool>
                    .CreateNotFoundResponseForOneModel(argNullException);
            }
            catch (Exception exception)
            {
                return ResponseFactory<bool>.CreateErrorResponseForOneModel(exception);
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

                return ResponseFactory<RequestDTO>.CreateSuccessResponseForModelCollection(activeRequestsDTO);
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
        В этом методе мы сначала проверяем, что идентификатор клиента clientId положительный.Затем мы получаем клиента из репозитория по его идентификатору и проверяем, что он существует.Далее, мы выбираем только активные заявки клиента и выполняем маппинг в DTO формат. В конце возвращаем успешный ответ с кол




    }
}
