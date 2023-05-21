using FinalApp.ApiModels.DTOs.EntitiesDTOs.RequestsDTO;
using FinalApp.ApiModels.Response.Interfaces;

namespace FinalApp.Services.Interfaces
{
    public interface IReviewService
    {
        public Task<IBaseResponse<IEnumerable<ReviewDTO>>> GetReviewsByEvaluation(int evaluation);
        public Task<IBaseResponse<IEnumerable<ReviewDTO>>> GetReviewsByRequestId(int requestId);
        public Task<IBaseResponse<bool>> CanCreateReview(int requestId);
        public Task<IBaseResponse<ReviewDTO>> CreateReview(int requestId, string reviewText, int evaluation);
    }
}
