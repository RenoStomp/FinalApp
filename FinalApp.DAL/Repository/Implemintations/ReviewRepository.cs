using FinalApp.DAL.Repository.Interfaces;
using FinalApp.DAL.SqlServer;
using FinalApp.Domain.Models.Entities.Requests.RequestsInfo;
using FinalApp.Domain.Models.Enums;
using Microsoft.EntityFrameworkCore;

namespace FinalApp.DAL.Repository.Implemintations
{
    public class ReviewRepository : BaseAsyncRepository<Review>, IReviewRepository
    {
        public ReviewRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IQueryable<Review>> GetReviewsByEvaluation(int evaluation)
        {
            var reviews = await _dbSet
                .Where(r => r.Evaluation == evaluation)
                .ToListAsync();

            return reviews.AsQueryable();
        }

        public async Task<IQueryable<Review>> GetReviewsByRequestId(int requestId)
        {
            var reviews = await _dbSet
                .Where(request => request.Request.Id == requestId)
                .ToListAsync();

            return reviews.AsQueryable();
        }

        public async Task<bool> CanCreateReview(int requestId)
        {
            var request = await _context.Requests.FindAsync(requestId);

            return request != null && request.RequestStatus == Status.Completed && request.Review == null;
        }

        public async Task CreateReview(int requestId, string reviewText, int evaluation)
        {
            var request = await _context.Requests.FindAsync(requestId);

            if (request == null || request.RequestStatus != Status.Completed || request.Review != null)
                throw new InvalidOperationException("Unable to create review for the specified request.");

            var review = new Review
            {
                ReviewText = reviewText,
                Evaluation = evaluation
            };

            await Create(review);
            request.Review = review;

            await _context.SaveChangesAsync();
        }

        public async Task<bool> CanUpdateReview(int reviewId)
        {
            var review = await ReadByIdAsync(reviewId);

            return review != null && review.Request.RequestStatus == Status.Completed;
        }

        public async Task UpdateReview(int reviewId, string reviewText, int evaluation)
        {
            var review = await ReadByIdAsync(reviewId);

            if (review == null || review.Request.RequestStatus != Status.Completed)
                throw new InvalidOperationException("Unable to update the specified review.");

            review.ReviewText = reviewText;
            review.Evaluation = evaluation;

            await UpdateAsync(review);
        }
    }
}
