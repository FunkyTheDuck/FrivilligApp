using FrontendModels;

namespace BlazorRepository
{
    public interface ISkillsRepository
    {
        Task<List<Skills>> GetAllAsync();
    }
}