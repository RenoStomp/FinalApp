﻿using FinalApp.ApiModels.DTOs.EntitiesDTOs.UsersDTOs;
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
    }
}
