using FinalApp.ApiModels.DTOs.EntitiesDTOs.RequestsDTO;
using FinalApp.ApiModels.Response.Interfaces;

namespace FinalApp.Services.Interfaces
{
    public interface IHistoryService
    {
        public Task<IBaseResponse<IEnumerable<RequestStatusHistoryDTO>>> GetRequestStatusHistory(int requestId);
    }
}
