using FrontendModels;

namespace BlazorRepository
{
    public interface IUserRepository
    {
        Task<bool> CreateUserAsync(string username, string password, bool IsVoluntary);
        Task<User> LogUserInAsync(string username, string password);
        Task<User> GetUserFromIdAsync(int userId);
    }
}