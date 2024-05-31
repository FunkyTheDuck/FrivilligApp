using FrontendModels;

namespace BlazorRepository
{
    public interface IRatingRepository
    {
        Task<List<Ratings>> GetAllUsersRatinigsAsync(int userId);
        Task<List<Ratings>> GetNewestRatingsAsync(int userId);
    }
}