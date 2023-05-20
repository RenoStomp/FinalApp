using FinalApp.Domain.Models.Entities.Requests.RequestsInfo;

namespace FinalApp.DAL.Repository.Interfaces
{
    /// <summary>
    /// Represents a repository for managing user base entities.
    /// </summary>
    public interface IUserBaseRepository
    {
        /// <summary>
        /// Retrieves the active requests for a technical team.
        /// </summary>
        /// <param name="techTeamId">The ID of the technical team.</param>
        /// <returns>An asynchronous operation that returns the IQueryable of active requests.</returns>
        Task<IQueryable<Request>> GetActiveRequests(int techTeamId);

        /// <summary>
        /// Retrieves the closed requests for a technical team.
        /// </summary>
        /// <param name="techTeamId">The ID of the technical team.</param>
        /// <returns>An asynchronous operation that returns the IQueryable of closed requests.</returns>
        Task<IQueryable<Request>> GetClosedRequests(int techTeamId);

        /// <summary>
        /// Accepts a request and assigns it to a technical team.
        /// </summary>
        /// <param name="requestId">The ID of the request.</param>
        /// <param name="techTeamId">The ID of the technical team.</param>
        /// <returns>An asynchronous operation.</returns>
        Task AcceptRequest(int requestId, int techTeamId);

        /// <summary>
        /// Marks a request as completed.
        /// </summary>
        /// <param name="requestId">The ID of the request.</param>
        /// <returns>An asynchronous operation.</returns>
        Task MarkRequestAsCompleted(int requestId);

        /// <summary>
        /// Sets the quantity and template of eco boxes for the specified request.
        /// This method is intended to be used by the TechnicalTeam controller.
        /// </summary>
        /// <param name="requestId">The identifier of the request.</param>
        /// <param name="quantity">The quantity of eco boxes to set.</param>
        /// <param name="templateId">The identifier of the eco box template.</param>
        /// <returns>An asynchronous task.</returns>
        public Task SetEcoBoxQuantityAndTemplate(int requestId, int quantity, int templateId);
    }
}
