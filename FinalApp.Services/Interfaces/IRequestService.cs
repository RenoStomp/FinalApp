using FinalApp.ApiModels.DTOs.EntitiesDTOs.RequestsDTO;
using FinalApp.ApiModels.Response.Interfaces;

namespace FinalApp.Services.Interfaces
{
    /// <summary>
    /// Interface for the request service that handles operations related to requests.
    /// </summary>
    public interface IRequestService
    {
        /// <summary>
        /// Retrieves a list of unassigned requests.
        /// </summary>
        /// <returns>An asynchronous operation that returns the list of unassigned requests.</returns>
        Task<IBaseResponse<IEnumerable<RequestDTO>>> GetUnassignedRequests();

        /// <summary>
        /// Retrieves a list of closed requests assigned to the specified operator.
        /// </summary>
        /// <param name="operatorId">The ID of the operator.</param>
        /// <returns>An asynchronous operation that returns the list of closed requests.</returns>
        Task<IBaseResponse<IEnumerable<RequestDTO>>> GetClosedRequestsByOperatorId(int operatorId);

        /// <summary>
        /// Retrieves a list of active requests assigned to the specified operator.
        /// </summary>
        /// <param name="operatorId">The ID of the operator.</param>
        /// <returns>An asynchronous operation that returns the list of active requests.</returns>
        Task<IBaseResponse<IEnumerable<RequestDTO>>> GetActiveRequestsByOperatorId(int operatorId);

        /// <summary>
        /// Assigns a request to a team.
        /// </summary>
        /// <param name="requestId">The ID of the request to assign.</param>
        /// <param name="teamId">The ID of the team to assign the request to.</param>
        /// <returns>An asynchronous operation that returns a response indicating the success or failure of the assignment.</returns>
        Task<IBaseResponse<bool>> AssignRequestToTeam(int requestId, int teamId);

        /// <summary>
        /// Assigns a request to an operator.
        /// </summary>
        /// <param name="requestId">The ID of the request to assign.</param>
        /// <param name="operatorId">The ID of the operator to assign the request to.</param>
        /// <returns>An asynchronous operation that returns a response indicating the success or failure of the assignment.</returns>
        Task<IBaseResponse<bool>> AssignRequestToOperator(int requestId, int operatorId);

        /// <summary>
        /// Marks a request as completed.
        /// </summary>
        /// <param name="requestId">The ID of the request to mark as completed.</param>
        /// <returns>An asynchronous operation that returns a response indicating the success or failure of marking the request as completed.</returns>
        Task<IBaseResponse<bool>> MarkRequestAsCompleted(int requestId);

        /// <summary>
        /// Assigns a location to a request.
        /// </summary>
        /// <param name="requestId">The ID of the request to assign the location to.</param>
        /// <param name="locationId">The ID of the location to assign to the request.</param>
        /// <returns>An asynchronous operation that returns a response indicating the success or failure of assigning the location to the request.</returns>
        Task<IBaseResponse<bool>> AssignLocationToRequest(int requestId, int locationId);
    }
}
