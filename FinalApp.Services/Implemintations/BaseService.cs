using FinalApp.ApiModels.DTOs.CommonDTOs.BaseDTOs;
using FinalApp.ApiModels.Response.Helpers;
using FinalApp.ApiModels.Response.Interfaces;
using FinalApp.DAL.Repository.Interfaces;
using FinalApp.Domain.Models.Common;
using FinalApp.Services.Interfaces;
using FinalApp.Services.Mapping;
using FinallApp.ValidationHelper;
using Microsoft.EntityFrameworkCore;

namespace FinalApp.Services.Implemintations
{
    public class BaseService<T, Tmodel> : IBaseService<T, Tmodel>
        where T : BaseEntity
        where Tmodel : BaseEntityDTO
    {
        private readonly IBaseAsyncRepository<T> _repository;

        public BaseService(IBaseAsyncRepository<T> repository)
        {
            _repository = repository;
        }

        public async Task<IBaseResponse<Tmodel>> Create(T entity)
        {
            try
            {
                ObjectValidator<T>.CheckIsNotNullObject(entity);
                Tmodel entityDTO = MapperHelper<T, Tmodel>.Map(entity);

                T convertedEntity = entityDTO as T;
                if (convertedEntity == null)
                    throw new InvalidOperationException("Failed to convert entity to the specified type.");

                await _repository.Create(convertedEntity);

                return ResponseFactory<Tmodel>.CreateSuccessResponseForOneModel(entityDTO);
            }
            catch (InvalidOperationException invException)
            {
                return ResponseFactory<Tmodel>.CreateInvalidOperationResponseForOneModel(invException);
            }
            catch (ArgumentNullException argNullException)
            {
                return ResponseFactory<Tmodel>.CreateNotFoundResponseForOneModel(argNullException);
            }
            catch (Exception exception)
            {
                return ResponseFactory<Tmodel>.CreateErrorResponseForOneModel(exception);
            }
        }

        public IBaseResponse<IEnumerable<Tmodel>> ReadAll()
        {
            try
            {
                var entities = _repository.ReadAll().ToList();

                ObjectValidator<IEnumerable<T>>.CheckIsNotNullObject(entities);
                IEnumerable<Tmodel> entitiesDTO = MapperHelper<T, Tmodel>.Map(entities);

                return ResponseFactory<IEnumerable<Tmodel>>.CreateSuccessResponseForOneModel(entitiesDTO);
            }
            catch (ArgumentNullException argNullException)
            {
                return ResponseFactory<IEnumerable<Tmodel>>.CreateNotFoundResponseForOneModel(argNullException);
            }
            catch (Exception exception)
            {
                return ResponseFactory<IEnumerable<Tmodel>>.CreateErrorResponseForOneModel(exception);
            }
        }

        public async Task<IBaseResponse<IEnumerable<Tmodel>>> ReadAllAsync()
        {
            try
            {
                var entities = await _repository.ReadAll().ToListAsync();

                ObjectValidator<IEnumerable<T>>.CheckIsNotNullObject(entities);
                IEnumerable<Tmodel> entitiesDTO = MapperHelper<T, Tmodel>.Map(entities);

                return ResponseFactory<IEnumerable<Tmodel>>.CreateSuccessResponseForOneModel(entitiesDTO);
            }
            catch (ArgumentNullException argNullException)
            {
                return ResponseFactory<IEnumerable<Tmodel>>.CreateNotFoundResponseForOneModel(argNullException);
            }
            catch (Exception exception)
            {
                return ResponseFactory<IEnumerable<Tmodel>>.CreateErrorResponseForOneModel(exception);
            }
        }

        public IBaseResponse<Tmodel> ReadById(int id)
        {
            try
            {
                ObjectValidator<int>.CheckIsNotNullObject(id);
                NumberValidator<int>.IsPositive(id);
                var entity = _repository.ReadById(id);

                ObjectValidator<T>.CheckIsNotNullObject(entity);
                Tmodel entityDTO = MapperHelper<T, Tmodel>.Map(entity);

                return ResponseFactory<Tmodel>.CreateSuccessResponseForOneModel(entityDTO);
            }
            catch (ArgumentNullException argNullException)
            {
                return ResponseFactory<Tmodel>.CreateNotFoundResponseForOneModel(argNullException);
            }
            catch (Exception exception)
            {
                return ResponseFactory<Tmodel>.CreateErrorResponseForOneModel(exception);
            }
        }

        public async Task<IBaseResponse<Tmodel>> ReadByIdAsync(int id)
        {
            try
            {
                ObjectValidator<int>.CheckIsNotNullObject(id);
                NumberValidator<int>.IsPositive(id);
                var entity = await _repository.ReadByIdAsync(id);

                ObjectValidator<T>.CheckIsNotNullObject(entity);
                Tmodel entityDTO = MapperHelper<T, Tmodel>.Map(entity);

                return ResponseFactory<Tmodel>.CreateSuccessResponseForOneModel(entityDTO);
            }
            catch (ArgumentNullException argNullException)
            {
                return ResponseFactory<Tmodel>.CreateNotFoundResponseForOneModel(argNullException);
            }
            catch (Exception exception)
            {
                return ResponseFactory<Tmodel>.CreateErrorResponseForOneModel(exception);
            }
        }

        public async Task<IBaseResponse<Tmodel>> UpdateAsync(T item)
        {
            try
            {
                ObjectValidator<T>.CheckIsNotNullObject(item);

                var entity = await _repository.ReadByIdAsync(item.Id);

                ObjectValidator<T>.CheckIsNotNullObject(entity);
                Tmodel entityDTO = MapperHelper<T, Tmodel>.Map(entity);

                T convertedEntity = entityDTO as T;
                if (convertedEntity == null)
                    throw new InvalidOperationException("Failed to convert entity to the specified type.");

                await _repository.UpdateAsync(convertedEntity);

                return ResponseFactory<Tmodel>.CreateSuccessResponseForOneModel(entityDTO);
            }
            catch (InvalidOperationException invException)
            {
                return ResponseFactory<Tmodel>.CreateInvalidOperationResponseForOneModel(invException);
            }
            catch (ArgumentNullException argNullException)
            {
                return ResponseFactory<Tmodel>.CreateNotFoundResponseForOneModel(argNullException);
            }
            catch (Exception exception)
            {
                return ResponseFactory<Tmodel>.CreateErrorResponseForOneModel(exception);
            }
        }
        public async Task<IBaseResponse<bool>> DeleteAsync(T item)
        {
            try
            {
                ObjectValidator<T>.CheckIsNotNullObject(item);
                Tmodel itemDTO = MapperHelper<T, Tmodel>.Map(item);

                if (!(itemDTO is T convertedItem))
                    throw new InvalidOperationException("Failed to convert itemDTO to the specified type.");

                await _repository.DeleteAsync(convertedItem);

                return ResponseFactory<bool>.CreateSuccessResponseForOneModel(true);
            }
            catch (InvalidOperationException invException)
            {
                return ResponseFactory<bool>.CreateInvalidOperationResponseForOneModel(invException);
            }
            catch (ArgumentNullException argNullException)
            {
                return ResponseFactory<bool>.CreateNotFoundResponseForOneModel(argNullException);
            }
            catch (Exception exception)
            {
                return ResponseFactory<bool>.CreateErrorResponseForOneModel(exception);
            }
        }

        public async Task<IBaseResponse<bool>> DeleteByIdAsync(int id)
        {
            try
            {
                ObjectValidator<int>.CheckIsNotNullObject(id);
                NumberValidator<int>.IsPositive(id);

                await _repository.DeleteByIdAsync(id);

                return ResponseFactory<bool>.CreateSuccessResponseForOneModel(true);
            }
            catch (ArgumentNullException argNullException)
            {
                return ResponseFactory<bool>.CreateNotFoundResponseForOneModel(argNullException);
            }
            catch (ArgumentException invException)
            {
                return ResponseFactory<bool>.CreateInvalidOperationResponseForOneModel(invException);
            }
            catch (Exception exception)
            {
                return ResponseFactory<bool>.CreateErrorResponseForOneModel(exception);
            }
        }
    }
}
