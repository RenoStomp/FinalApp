using FinalApp.Domain.Models.Entities.Requests.RequestsInfo;

namespace FinalApp.DAL.Repository.Interfaces
{
    public interface IReviewRepository
    {
        public  Task<IQueryable<Review>> GetReviewsByEvaluation(int evaluation);
        public  Task<IQueryable<Review>> GetReviewsByRequestId(int requestId);
        public  Task<bool> CanCreateReview(int requestId);
        public  Task CreateReview(int requestId, string reviewText, int evaluation);
        public  Task<bool> CanUpdateReview(int reviewId);
        public  Task UpdateReview(int reviewId, string reviewText, int evaluation);
    }
}
