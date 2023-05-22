﻿using FinalApp.ApiModels.DTOs.EntitiesDTOs.RequestsDTO;
using FinalApp.ApiModels.Response.Interfaces;
using FinalApp.Domain.Models.Common;
using FinalApp.Domain.Models.Common.BaseUsersInfo;

namespace FinalApp.Services.Interfaces
{
    public interface IUserService<T>
        where T : BaseUser
    {
        public Task<IBaseResponse<IEnumerable<RequestDTO>>> GetActiveRequests(int Id);
        public Task<IBaseResponse<IEnumerable<RequestDTO>>> GetClosedRequests(int Id);
        public Task<IBaseResponse<bool>> AcceptRequest(int requestId, int Id);
        public Task<IBaseResponse<bool>> MarkRequestAsCompleted(int requestId);
    }
}