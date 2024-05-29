using BackendModels;
using BlazorDBlayer;
using FrontendModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BlazorRepository
{
    public class EventRepository
    {
        protected DBAccess db {  get; set; }
        public EventRepository()
        {
            db = new DBAccess();
        }
        public async Task<List<Event>> GetAllEventsAsync(int page, int userId, double x, double y)
        {
            List<DtoEvent> dtoEvents;
            try
            {
                dtoEvents = await db.GetAllEventsAsync(page, userId, x, y);
            }
            catch
            {
                return null;
            }
            if(dtoEvents != null && dtoEvents.Count != 0)
            {
                List<Event> events = new List<Event>();
                for (int i = 0; i < dtoEvents.Count; i++)
                {
                    Event newEvent = ConvertFromDto(dtoEvents[i]);
                    events.Add(newEvent);
                }
                return events;
            }
            return null;

        }
        public async Task<bool> CreateAsync(Event events)
        {
            if(events != null)
            {
                return await db.CreateEventAsync(ConvertToDto(events));
            }
            return false;
        }
        public async Task<bool> AddVoluntaryToEventAsync(int userId, int eventId)
        {
            try
            {
                return await db.AddVoluntaryToEventAsync(userId, eventId);
            }
            catch
            {
                return false;
            }
        }
        public async Task<List<Event>> GetVoluntaryEventsAsync(int userId)
        {
            List<DtoEvent> dtoEvents;
            try
            {
                dtoEvents = await db.GetVoluntaryEventsAsync(userId);
            }
            catch
            {
                return null;
            }
            if(dtoEvents != null && dtoEvents.Count != 0)
            {
                List<Event> events = new List<Event>();
                for(int i = 0; i < dtoEvents.Count; i++)
                {
                    Event newEvent = ConvertFromDto(dtoEvents[i]);
                    events.Add(newEvent);
                }
                return events;
            }
            return null;
        }
        public async Task<List<Event>> GetOwnersEventsAsync(int userId)
        {
            List<DtoEvent> dtoEvents;
            try
            {
                dtoEvents = await db.GetOwnersEventsAsync(userId);
            }
            catch
            {
                return null;
            }
            if (dtoEvents != null && dtoEvents.Count != 0)
            {
                List<Event> events = new List<Event>();
                for (int i = 0; i < dtoEvents.Count; i++)
                {
                    Event newEvent = ConvertFromDto(dtoEvents[i]);
                    events.Add(newEvent);
                }
                return events;
            }
            return null;
        }
        private Event ConvertFromDto(DtoEvent events)
        {
            Event newEvent = new Event
            {
                Id = events.Id,
                Title = events.Title,
                Description = events.Description,
                ImageUrl = events.ImageUrl,
                EventInfo = new EventInfo
                {
                    Id = events.EventInfoId,
                    Address = events.EventInfo.Address,
                    CoordinateX = events.EventInfo.CoordinateX,
                    CoordinateY = events.EventInfo.CoordinateY,
                    Distance = events.EventInfo.Distance,
                    Interests = new List<Interests>(),
                    Skills = new List<Skills>()
                },
            };
            if(events.EventInfo.Interests != null)
            {
                foreach (DtoInterests dtoInterests in events.EventInfo.Interests)
                {
                    Interests interests = new Interests
                    {
                        Id = dtoInterests.Id,
                        Interest = dtoInterests.Interest
                    };
                    newEvent.EventInfo.Interests.Add(interests);
                }
            }
            if(events.EventInfo.Skills != null)
            {
                foreach (DtoSkills dtoSkill in events.EventInfo.Skills)
                {
                    Skills skill = new Skills
                    {
                        Id = dtoSkill.Id,
                        Skill = dtoSkill.Skill
                    };
                    newEvent.EventInfo.Skills.Add(skill);
                }
            }
            return newEvent;
        }
        private DtoEvent ConvertToDto(Event events)
        {
            DtoEvent newEvent = new DtoEvent
            {
                Id = events.Id,
                Title = events.Title,
                Description = events.Description,
                ImageUrl = events.ImageUrl,
                EventInfo = new DtoEventInfo
                {
                    Id = events.EventInfoId,
                    Address = events.EventInfo.Address,
                    CoordinateX = events.EventInfo.CoordinateX,
                    CoordinateY = events.EventInfo.CoordinateY,
                    Distance = events.EventInfo.Distance,
                    Interests = new List<DtoInterests>(),
                    Skills = new List<DtoSkills>()
                },
            };
            if (events.EventInfo.Interests != null)
            {
                foreach (Interests interests in events.EventInfo.Interests)
                {
                    DtoInterests dtoInterests = new DtoInterests
                    {
                        Id = interests.Id,
                        Interest = interests.Interest
                    };
                    newEvent.EventInfo.Interests.Add(dtoInterests);
                }
            }
            if (events.EventInfo.Skills != null)
            {
                foreach (Skills skill in events.EventInfo.Skills)
                {
                    DtoSkills Dtoskill = new DtoSkills
                    {
                        Id = skill.Id,
                        Skill = skill.Skill
                    };
                    newEvent.EventInfo.Skills.Add(Dtoskill);
                }
            }
            return newEvent;
        }
    }
}