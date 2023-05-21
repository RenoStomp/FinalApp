using FinalApp.ApiModels.DTOs.CommonDTOs.BaseDTOs;
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
        public static BaseResponse<IEnumerable<TModel>> CreateNotFoundResponseForModelCollection(Exception exception)
        {
            return new BaseResponse<IEnumerable<TModel>>()
            {        
                StatusCode = 0,
                IsSuccess = false,
                Message = "no records found in the database\n\r" +
                    $"Error: {exception}",
            };
        }

        public static BaseResponse<TModel> CreateNotFoundResponseForOneModel(Exception exception)
        {
            return new BaseResponse<TModel>()
            {
                StatusCode = 0,
                IsSuccess = false,
                Message = "no records found in the database\n\r" +
                    $"Error: {exception}",
            };
        }

        public static BaseResponse<IEnumerable<TModel>> CreateErrorResponseForModelCollection(Exception exception)
        {
            return new BaseResponse<IEnumerable<TModel>>()
            {             
                StatusCode = 500,
                IsSuccess = false,
                Message = "internal server error\n\r" +
                $"Error: {exception}",
            };
        }

        public static BaseResponse<TModel> CreateErrorResponseForOneModel(Exception exception)
        {
            return new BaseResponse<TModel>()
            {
                StatusCode = 500,
                IsSuccess = false,
                Message = "internal server error\n\r" +
                $"Error: {exception}",
            };
        }
    }

}
