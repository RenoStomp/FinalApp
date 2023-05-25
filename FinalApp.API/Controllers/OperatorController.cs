using FinalApp.ApiModels.DTOs.EntitiesDTOs.UsersDTOs;
using FinalApp.Domain.Models.Entities.Persons.Users;
using FinalApp.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FinalApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OperatorController : ControllerBase
    {
        private readonly IBaseService<SupportOperator, SupportOperatorDTO> _service;
        private readonly IUserService<SupportOperator> _userService;

        public OperatorController(IBaseService<SupportOperator, SupportOperatorDTO> service, IUserService<SupportOperator> userService)
        {
            _service = service;
            _userService = userService;
        }

        [HttpGet("ActiveRequest")]
        public async Task<IActionResult> GetActive(int techTeamId)
        {
            var response = await _userService.GetActiveRequests(techTeamId);
            return Ok(response.Data);
        }

        [HttpGet("ClosedRequest")]
        public async Task<IActionResult> GetClosed(int techTeamId)
        {
            var response = await _userService.GetClosedRequests(techTeamId);
            return Ok(response.Data);
        }
        [HttpPost("AcceptRequest/{requestId}/{Id}")]
        public async Task<IActionResult> AcceptRequest(int requestId, int Id)
        {
            var response = await _userService.AcceptRequest(requestId, Id);
            return Ok(response.Data);
        }

        [HttpPost("MarkRequestAsCompleted/{requestId}")]
        public async Task<IActionResult> MarkRequestAsCompleted(int requestId)
        {
            var response = await _userService.MarkRequestAsCompleted(requestId);
            return Ok(response.Data);
        }

        [HttpPost("CloseRequestByUser/{requestId}/{Id}")]
        public async Task<IActionResult> CloseRequestByUser(int requestId, int Id)
        {
            var response = await _userService.CloseRequestByUser(requestId, Id);
            return Ok(response.Data);
        }

        [HttpGet]
        public IActionResult Get()
        {
            var response = _service.ReadAll();
            return Ok(response.Data);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var response = _service.ReadById(id);
            return Ok(response.Data);
        }

        [HttpPost]
        public async Task<IActionResult> Post(SupportOperatorDTO model)
        {
            await _service.CreateAsync(model);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Put(SupportOperatorDTO model)
        {
            await _service.UpdateAsync(model);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteByIdAsync(id);
            return Ok();
        }
    }
}
