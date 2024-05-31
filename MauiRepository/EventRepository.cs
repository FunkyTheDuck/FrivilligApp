using FrontendModels;
using BackendModels;
using MauiDBlayer;
namespace MauiRepository
{
    public class EventRepository
    {
        DBAccess db;
        public EventRepository()
        {
            db = new DBAccess();
        }
        public async Task<bool> CreateAsync(Event events)
        {
            if (events != null)
            {
                DtoEvent dtoEvent = new DtoEvent
                {
                    Title = events.Title,
                    Description = events.Description,
                    ImageUrl = events.ImageUrl,
                    WantedVolunteers = events.WantedVolunteers,
                    EventInfo = new DtoEventInfo
                    {
                        Address = events.EventInfo.Address,
                        CoordinateX = events.EventInfo.CoordinateX,
                        CoordinateY = events.EventInfo.CoordinateY,
                        Skills = new(),
                        Interests = new()
                    },
                    OwnerId = events.OwnerId
                };
                if (events.EventInfo.Skills != null)
                {
                    for (int i = 0; i < events.EventInfo.Skills.Count; i++)
                    {
                        DtoSkills skill = new DtoSkills
                        {
                            Id = events.EventInfo.Skills[i].Id,
                            Skill = events.EventInfo.Skills[i].Skill
                        };
                        dtoEvent.EventInfo.Skills.Add(skill);
                    }
                }
                if (events.EventInfo.Interests != null)
                {
                    for (int i = 0; i < events.EventInfo.Interests.Count; i++)
                    {
                        DtoInterests interest = new DtoInterests
                        {
                            Id = events.EventInfo.Interests[i].Id,
                            Interest = events.EventInfo.Interests[i].Interest
                        };
                        dtoEvent.EventInfo.Interests.Add(interest);
                    }
                }
                return await db.CreateEventAsync(dtoEvent);
            }
            return false;
        }
        public async Task<List<Event>> GetFromUserInteretsAsync(int page, int userId, double locationX, double locationY)
        {
            List<DtoEvent> dtoEvent = await db.GetFromUserInteretsAsync(page,userId,locationX,locationY);
            List<Event> events = GetEvent(dtoEvent);
            return events;
        }
        public async Task<List<Event>> GetEventToUserAsync(int userId)
        {
            List<DtoEvent> dtoEvent = await db.GetEventToUserAsync(userId);
            List<Event> events = GetEvent(dtoEvent);
            return events;
        }
        public async Task<List<Event>> GetEventToOwnerAsync(int userId)
        {
            List<DtoEvent> dtoEvent = await db.GetEventToOwnerAsync(userId);
            List<Event> events = GetEvent(dtoEvent);
            return events;
        }
        private List<Event> GetEvent(List<DtoEvent> dtoEvent)
        {
            List<Event> events = new List<Event>();
            foreach (DtoEvent dto in dtoEvent)
            {
                Event newEvent = new Event
                {
                    Id = dto.Id,
                    Title = dto.Title,
                    Description = dto.Description,
                    ImageUrl = dto.ImageUrl,
                    WantedVolunteers = dto.WantedVolunteers,
                    EventInfo = new EventInfo
                    {
                        Address = dto.EventInfo.Address,
                        CoordinateX = dto.EventInfo.CoordinateX,
                        CoordinateY = dto.EventInfo.CoordinateY,
                        Skills = new(),
                        Interests = new(),
                    },
                    OwnerId = dto.OwnerId,
                };
                if (dto.EventInfo.Skills != null)
                {
                    for (int i = 0; i < dto.EventInfo.Skills.Count; i++)
                    {
                        Skills skill = new Skills
                        {
                            Id = dto.EventInfo.Skills[i].Id,
                            Skill = dto.EventInfo.Skills[i].Skill
                        };
                        newEvent.EventInfo.Skills.Add(skill);
                    }
                }
                if (dto.EventInfo.Interests != null)
                {
                    for (int i = 0; i < dto.EventInfo.Interests.Count; i++)
                    {
                        Interests Interest = new Interests
                        {
                            Id = dto.EventInfo.Interests[i].Id,
                            Interest = dto.EventInfo.Interests[i].Interest
                        };
                        newEvent.EventInfo.Interests.Add(Interest);
                    }
                }
                events.Add(newEvent);
            }
            return events;
        }
        public async Task<bool> AddVoluntaryToEvent(int UserId, int EventId)
        {
            try
            {
                bool result = await db.AddVoluntaryToEvent(UserId, EventId);
                return result;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public async Task<bool> RemoveVoluntaryFromEvent(int UserId, int EventId)
        {
            try
            {
                bool result = await db.RemoveVoluntaryFromEvent(UserId, EventId);
                return result;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
