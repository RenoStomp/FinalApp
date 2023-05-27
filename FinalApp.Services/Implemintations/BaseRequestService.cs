﻿using FinalApp.ApiModels.DTOs.CommonDTOs.BaseDTOs;
using FinalApp.ApiModels.Response.Helpers;
using FinalApp.ApiModels.Response.Interfaces;
using FinalApp.DAL.Repository.Interfaces;
using FinalApp.Domain.Models.Abstractions.BaseEntities;
using FinalApp.Domain.Models.Abstractions.BaseUsers;
using FinalApp.Services.Interfaces;
using FinalApp.Services.Mapping.Helpers;
using FinallApp.ValidationHelper;
using Microsoft.AspNetCore.Identity;
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

        public async Task<IBaseResponse<T>> CreateAsync(Tmodel entityDTO)
        {
            
            try
            {
                ObjectValidator<Tmodel>.CheckIsNotNullObject(entityDTO);
                T entity = MapperHelperForEntity<Tmodel, T>.Map(entityDTO);

                await _repository.Create(entity);

                return ResponseFactory<T>.CreateSuccessResponse(entity);
            }
            catch (ArgumentNullException argNullException)
            {
                return ResponseFactory<T>.CreateNotFoundResponse(argNullException);
            }
            catch (Exception exception)
            {
                return ResponseFactory<T>.CreateErrorResponse(exception);
            }
        }

        public IBaseResponse<IEnumerable<T>> ReadAll()
        {
            try
            {
                var entities = _repository.ReadAll().ToList();
                ObjectValidator<IEnumerable<T>>.CheckIsNotNullObject(entities);

                return ResponseFactory<IEnumerable<T>>.CreateSuccessResponse(entities);
            }
            catch (ArgumentNullException argNullException)
            {
                return ResponseFactory<IEnumerable<T>>.CreateNotFoundResponse(argNullException);
            }
            catch (Exception exception)
            {
                return ResponseFactory<IEnumerable<T>>.CreateErrorResponse(exception);
            }
        }

        public async Task<IBaseResponse<IEnumerable<T>>> ReadAllAsync()
        {
            try
            {
                var entities = await _repository.ReadAll().ToListAsync();
                ObjectValidator<IEnumerable<T>>.CheckIsNotNullObject(entities);

                return ResponseFactory<IEnumerable<T>>.CreateSuccessResponse(entities);
            }
            catch (ArgumentNullException argNullException)
            {
                return ResponseFactory<IEnumerable<T>>.CreateNotFoundResponse(argNullException);
            }
            catch (Exception exception)
            {
                return ResponseFactory<IEnumerable<T>>.CreateErrorResponse(exception);
            }
        }

        public IBaseResponse<T> ReadById(int id)
        {
            try
            {
                NumberValidator<int>.IsPositive(id);
                var entity = _repository.ReadById(id);
                ObjectValidator<T>.CheckIsNotNullObject(entity);

                return ResponseFactory<T>.CreateSuccessResponse(entity);
            }
            catch (ArgumentNullException argNullException)
            {
                return ResponseFactory<T>.CreateNotFoundResponse(argNullException);
            }
            catch (Exception exception)
            {
                return ResponseFactory<T>.CreateErrorResponse(exception);
            }
        }

        public async Task<IBaseResponse<T>> ReadByIdAsync(int id)
        {
            try
            {
                NumberValidator<int>.IsPositive(id);
                var entity = await _repository.ReadByIdAsync(id);

                ObjectValidator<T>.CheckIsNotNullObject(entity);

                return ResponseFactory<T>.CreateSuccessResponse(entity);
            }
            catch (ArgumentNullException argNullException)
            {
                return ResponseFactory<T>.CreateNotFoundResponse(argNullException);
            }
            catch (Exception exception)
            {
                return ResponseFactory<T>.CreateErrorResponse(exception);
            }
        }

        public async Task<IBaseResponse<T>> UpdateAsync(Tmodel entityDTO)
        {
            try
            {
                ObjectValidator<Tmodel>.CheckIsNotNullObject(entityDTO);
                T entity = MapperHelperForEntity<Tmodel, T>.Map(entityDTO);

               // var updatedEntity = await _repository.ReadByIdAsync(entity.Id);
              //  ObjectValidator<T>.CheckIsNotNullObject(updatedEntity);

                await _repository.UpdateAsync(entity);

                return ResponseFactory<T>.CreateSuccessResponse(entity);
            }
            catch (ArgumentNullException argNullException)
            {
                return ResponseFactory<T>.CreateNotFoundResponse(argNullException);
            }
            catch (Exception exception)
            {
                return ResponseFactory<T>.CreateErrorResponse(exception);
            }
        }
        public async Task<IBaseResponse<bool>> DeleteAsync(Tmodel entityDTO)
        {
            try
            {
                ObjectValidator<Tmodel>.CheckIsNotNullObject(entityDTO);

                T entity = MapperHelperForEntity<Tmodel, T>.Map(entityDTO);
                await _repository.DeleteAsync(entity);

                return ResponseFactory<bool>.CreateSuccessResponse(true);
            }
            catch (ArgumentNullException argNullException)
            {
                return ResponseFactory<bool>.CreateNotFoundResponse(argNullException);
            }
            catch (Exception exception)
            {
                return ResponseFactory<bool>.CreateErrorResponse(exception);
            }
        }

        public async Task<IBaseResponse<bool>> DeleteByIdAsync(int id)
        {
            try
            {
                NumberValidator<int>.IsPositive(id);
                await _repository.DeleteByIdAsync(id);

                return ResponseFactory<bool>.CreateSuccessResponse(true);
            }

            catch (ArgumentException invException)
            {
                return ResponseFactory<bool>.CreateNotFoundResponse(invException);
            }
            catch (Exception exception)
            {
                return ResponseFactory<bool>.CreateErrorResponse(exception);
            }
        }
    }
}