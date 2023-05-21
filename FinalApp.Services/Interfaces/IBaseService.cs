using FinalApp.ApiModels.DTOs.CommonDTOs.BaseDTOs;
using FinalApp.ApiModels.Response.Interfaces;
using FinalApp.Domain.Models.Common;

namespace FinalApp.Services.Interfaces
{
    /// <summary>
    /// Represents a base service for managing entities of type T and their corresponding DTOs of type Tmodel.
    /// </summary>
    /// <typeparam name="T">The entity type.</typeparam>
    /// <typeparam name="Tmodel">The DTO type.</typeparam>
    public interface IBaseService<T, Tmodel>
        where T : BaseEntity
        where Tmodel : BaseEntityDTO
    {
        /// <summary>
        /// Creates a new entity.
        /// </summary>
        /// <param name="entity">The entity to create.</param>
        /// <returns>An asynchronous operation that returns the created entity.</returns>
        public Task<IBaseResponse<Tmodel>> Create(T entity);

        /// <summary>
        /// Retrieves all entities.
        /// </summary>
        /// <returns>A response containing a collection of entities.</returns>
        public IBaseResponse<IEnumerable<Tmodel>> ReadAll();

        /// <summary>
        /// Retrieves all entities asynchronously.
        /// </summary>
        /// <returns>An asynchronous operation that returns a response containing a collection of entities.</returns>
        public Task<IBaseResponse<IEnumerable<Tmodel>>> ReadAllAsync();

        /// <summary>
        /// Retrieves an entity by its ID.
        /// </summary>
        /// <param name="id">The ID of the entity to retrieve.</param>
        /// <returns>A response containing the retrieved entity.</returns>
        public IBaseResponse<Tmodel> ReadById(int id);

        /// <summary>
        /// Retrieves an entity by its ID asynchronously.
        /// </summary>
        /// <param name="id">The ID of the entity to retrieve.</param>
        /// <returns>An asynchronous operation that returns a response containing the retrieved entity.</returns>
        public Task<IBaseResponse<Tmodel>> ReadByIdAsync(int id);

        /// <summary>
        /// Updates an existing entity asynchronously.
        /// </summary>
        /// <param name="item">The updated entity.</param>
        /// <returns>An asynchronous operation that returns the updated entity.</returns>
        public Task<IBaseResponse<Tmodel>> UpdateAsync(T item);

        /// <summary>
        /// Deletes an entity asynchronously.
        /// </summary>
        /// <param name="item">The entity to delete.</param>
        /// <returns>An asynchronous operation that returns a response indicating the success of the deletion.</returns>
        public Task<IBaseResponse<bool>> DeleteAsync(T item);

        /// <summary>
        /// Deletes an entity by its ID asynchronously.
        /// </summary>
        /// <param name="id">The ID of the entity to delete.</param>
        /// <returns>An asynchronous operation that returns a response indicating the success of the deletion.</returns>
        public Task<IBaseResponse<bool>> DeleteByIdAsync(int id);
    }

}