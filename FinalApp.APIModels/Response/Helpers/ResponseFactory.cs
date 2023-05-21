﻿using FinalApp.ApiModels.DTOs.CommonDTOs.BaseDTOs;
using FinalApp.ApiModels.Response.Implemintations;

namespace FinalApp.ApiModels.Response.Helpers
{
    public static class ResponseFactory<TModel>
        where TModel : BaseEntityDTO
    {
        public static BaseResponse<IEnumerable<TModel>> CreateSuccessResponseForModelCollection(IEnumerable<TModel> models)
        {
            return new BaseResponse<IEnumerable<TModel>>()
            {
                IsSuccess = true,
                Data = models,
                StatusCode = 200,
            };
        }
        public static BaseResponse<TModel> CreateSuccessResponseForOneModel(TModel model)
        {
            return new BaseResponse<TModel>
            {
                IsSuccess = true,
                Data = model,
                StatusCode = 200,
            };
        }
        public static BaseResponse<IEnumerable<TModel>> CreateNotFoundResponseForModelCollection()
        {
            return new BaseResponse<IEnumerable<TModel>>()
            {
                Message = "no records found in the database",
                StatusCode = 0,
                IsSuccess = false,
            };
        }

        public static BaseResponse<TModel> CreateNotFoundResponseForOneModel()
        {
            return new BaseResponse<TModel>()
            {
                Message = "no records found in the database",
                StatusCode = 0,
                IsSuccess = false,
            };
        }

        public static BaseResponse<IEnumerable<TModel>> CreateErrorResponseForModelCollection()
        {
            return new BaseResponse<IEnumerable<TModel>>()
            {
                Message = "internal server error",
                StatusCode = 500,
                IsSuccess = false,
            };
        }

        public static BaseResponse<TModel> CreateErrorResponseForOneModel()
        {
            return new BaseResponse<TModel>()
            {
                Message = "internal server error",
                StatusCode = 500,
                IsSuccess = false,
            };
        }
    }

}
