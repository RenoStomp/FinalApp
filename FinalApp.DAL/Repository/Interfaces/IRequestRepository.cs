using FinalApp.Domain.Models.Entities.Requests.RequestsInfo;
/// <summary>
/// Represents a repository for managing requests.
/// </summary>
public interface IRequestRepository
{
    /// <summary>
    /// Retrieves unassigned requests.
    /// </summary>
    /// <returns>An asynchronous operation that returns the collection of unassigned requests.</returns>
    Task<IQueryable<Request>> GetUnassignedRequests();

    /// <summary>
    /// Retrieves closed requests by operator ID.
    /// </summary>
    /// <param name="operatorId">The ID of the operator.</param>
    /// <returns>An asynchronous operation that returns the collection of closed requests by the specified operator ID.</returns>
    Task<IQueryable<Request>> GetClosedRequestsByOperatorId(int operatorId);

    /// <summary>
    /// Retrieves active requests by operator ID.
    /// </summary>
    /// <param name="operatorId">The ID of the operator.</param>
    /// <returns>An asynchronous operation that returns the collection of active requests by the specified operator ID.</returns>
    Task<IQueryable<Request>> GetActiveRequestsByOperatorId(int operatorId);

    /// <summary>
    /// Assigns a request to a team.
    /// </summary>
    /// <param name="requestId">The ID of the request.</param>
    /// <param name="teamId">The ID of the team.</param>
    /// <returns>An asynchronous operation that represents the assignment of the request to the specified team.</returns>
    Task AssignRequestToTeam(int requestId, int teamId);

    /// <summary>
    /// Assigns a request to an operator.
    /// </summary>
    /// <param name="requestId">The ID of the request.</param>
    /// <param name="operatorId">The ID of the operator.</param>
    /// <returns>An asynchronous operation that represents the assignment of the request to the specified operator.</returns>
    Task AssignRequestToOperator(int requestId, int operatorId);

    /// <summary>
    /// Marks a request as completed.
    /// </summary>
    /// <param name="requestId">The ID of the request.</param>
    /// <returns>An asynchronous operation that represents the marking of the request as completed.</returns>
    Task MarkRequestAsCompleted(int requestId);
}