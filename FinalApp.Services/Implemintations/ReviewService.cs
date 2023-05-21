using FinalApp.ApiModels.DTOs.EntitiesDTOs.RequestsDTO;
using FinalApp.ApiModels.Response.Helpers;
using FinalApp.ApiModels.Response.Implemintations;
using FinalApp.ApiModels.Response.Interfaces;
using FinalApp.DAL.Repository.Interfaces;
using FinalApp.Domain.Models.Entities.Requests.RequestsInfo;
using FinalApp.Services.Interfaces;
using FinalApp.Services.Mapping;
using FinallApp.ValidationHelper;
using Microsoft.EntityFrameworkCore;

namespace FinalApp.Services.Implemintations
{
    internal class ReviewService : IReviewService
    {
        public readonly IBaseAsyncRepository<Review> _repository;

        public ReviewService(IBaseAsyncRepository<Review> repository)
        {
            _repository = repository;
        }

        public async Task<IBaseResponse<IEnumerable<ReviewDTO>>> GetReviewsByEvaluation(int evaluation)
        {
            try
            {
                var reviews = await _repository.ReadAllAsync().Result
                    .Where(r => r.Evaluation == evaluation)
                    .ToListAsync();

                ObjectValidator<List<Review>>.CheckIsNotNullObject(reviews);
                IEnumerable<ReviewDTO> reviewsDTO = MapperHelper<Review, ReviewDTO>.Map(reviews);

                return ResponseFactory<ReviewDTO>.CreateSuccessResponseForModelCollection(reviewsDTO);
            }
            catch (ArgumentNullException exception)
            {
                return ResponseFactory<ReviewDTO>.CreateNotFoundResponseForModelCollection();
            }
            catch (Exception exp)
            {
                return ResponseFactory<ReviewDTO>.CreateErrorResponseForModelCollection();
            }
        }

        public async Task<IBaseResponse<IEnumerable<ReviewDTO>>> GetReviewsByRequestId(int requestId)
        {
            try
            {
                var reviews = await _repository.ReadAllAsync().Result
                    .Where(request => request.Request.Id == requestId)
                    .ToListAsync();

                ObjectValidator<List<Review>>.CheckIsNotNullObject(reviews);
                IEnumerable<ReviewDTO> reviewsDTO = MapperHelper<Review, ReviewDTO>.Map(reviews);

                return ResponseFactory<ReviewDTO>.CreateSuccessResponseForModelCollection(reviewsDTO);
            }
            catch (ArgumentNullException)
            {
                return ResponseFactory<ReviewDTO>.CreateNotFoundResponseForModelCollection();
            }
            catch (Exception)
            {
                return ResponseFactory<ReviewDTO>.CreateErrorResponseForModelCollection();
            }
        }

        public async Task<IBaseResponse<bool>> CanCreateReview(int requestId)
        {
            throw new NotImplementedException();
        }

        public async Task<IBaseResponse<ReviewDTO>> CreateReview(int requestId, string reviewText, int evaluation)
        {
            throw new NotImplementedException();
        }

        public Task<IBaseResponse<bool>> CanUpdateReview(int reviewId)
        {
            throw new NotImplementedException();
        }

        public Task<IBaseResponse<ReviewDTO>> UpdateReview(int reviewId, string reviewText, int evaluation)
        {
            throw new NotImplementedException();
        }
    }
}
