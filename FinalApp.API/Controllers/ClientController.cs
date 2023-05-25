using FinalApp.ApiModels.DTOs.EntitiesDTOs.UsersDTOs;
using FinalApp.Domain.Models.Entities.Persons.Users;
using FinalApp.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FinalApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IBaseService<Client, ClientDTO> _service;
        private readonly IClientService _clientService;

        public ClientController(IBaseService<Client, ClientDTO> service, IClientService clientService)
        {
            _service = service;
            _clientService = clientService;
        }

        [HttpGet("ClientsWithRequest")]
        public async Task<IResult> GetClients()
        {
            var response = await _clientService.GetClientsWithRequests();
            return Results.Ok(response.Data);
        }
        [HttpGet("ActiveRequest")]
        public async Task<IResult> GetActive( int clientId)
        {
            var response = await _clientService.GetActiveRequests(clientId);
            return Results.Ok(response.Data);
        }
        [HttpGet("ClosedRequest")]
        public async Task<IResult> GetClosed(int clientId)
        {
            var response = await _clientService.GetClosedRequests(clientId);
            return Results.Ok(response.Data);
        }

        [HttpGet]
        public IResult Get()
        {
            var response = _service.ReadAll();
            return Results.Ok(response.Data);
        }
  
        [HttpGet("{id}")]
        public IResult Get(int id)
        {
            var response = _service.ReadById(id);
            return Results.Ok(response.Data);
        }

        [HttpPost("{Register}")]
        public async Task PostClient(ClientDTO model)
        {
           await _clientService.RegisterClient(model);
        }


        [HttpPost]
        public async Task Post(ClientDTO model)
        {
            await _service.CreateAsync(model);
        }

        [HttpPut]
        public async Task Put(ClientDTO model)
        {
            await _service.UpdateAsync(model);
        }

        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _service.DeleteByIdAsync(id);
        }

    }
}
