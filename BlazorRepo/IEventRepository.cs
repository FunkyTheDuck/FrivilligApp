using FrontendModels;

namespace BlazorRepository
{
    public interface IEventRepository
    {
        Task<bool> AddVoluntaryToEventAsync(int userId, int eventId);
        Task<bool> CreateAsync(Event events);
        Task<List<Event>> GetAllEventsAsync(int page, int userId, double x, double y);
        Task<List<Event>> GetOwnersEventsAsync(int userId);
        Task<List<Event>> GetVoluntaryEventsAsync(int userId);
    }
}