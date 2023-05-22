using FinalApp.ApiModels.DTOs.EntitiesDTOs.UsersDTOs;
using FinalApp.ApiModels.Response.Helpers;
using FinalApp.ApiModels.Response.Interfaces;
using FinalApp.DAL.Repository.Interfaces;
using FinalApp.Domain.Models.Entities.Persons.Users;
using FinalApp.Services.Interfaces;
using FinalApp.Services.Mapping;
using FinallApp.ValidationHelper;
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
                var clientsWithRequests = await _repository.ReadAllAsync().Result.Include(c => c.Rrequests).ToListAsync();

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

        public async Task<IBaseResponse<Client>> RegisterClient(ClientDTO client)
        {
            try
            {
                ObjectValidator<ClientDTO>.CheckIsNotNullObject(client);

                var newClient = MapperHelperForDto<Client, ClientDTO>.Map(client);

                // Сохранение клиента в репозитории
                var createdClient = await _repository.Create(newClient);

                // Возвращение успешного ответа с созданным клиентом
                return ResponseFactory<Client>.CreateSuccessResponse(createdClient);
            }
            catch (Exception exception)
            {
                // Возвращение ошибки в случае возникновения исключения
                return ResponseFactory<Client>.CreateErrorResponse(exception);
            }
        }
    }
}
