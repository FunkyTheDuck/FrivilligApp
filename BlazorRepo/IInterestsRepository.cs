using FrontendModels;

namespace BlazorRepository
{
    public interface IInterestsRepository
    {
        Task<List<Interests>> GetAllAsync();
    }
}