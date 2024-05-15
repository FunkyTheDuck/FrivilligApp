using ApiDBlayer;
using DbModels;
using FrontendModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;


namespace ApiRepository
{
    public class EventRepository
    {
        Database db;
        public EventRepository() 
        {  
            db = new Database(); 
        }
        public async Task<Event> GetOneEventAsync(int eventId)
        {
            DtoEvent dtoEvent = new DtoEvent();
            dtoEvent = await db.Events.Include(x => x.EventInfo).ThenInclude(x => x.Skills).FirstOrDefaultAsync(x => x.Id == eventId);
            Event events = new Event
            {
                Id = dtoEvent.Id,
                OwnerId = dtoEvent.OwnerId,
                VoluntaryId = dtoEvent.VoluntaryId,
                Title = dtoEvent.Title,
                Description = dtoEvent.Description,
                ImageUrl = dtoEvent.ImageUrl,
                WantedVolunteers = dtoEvent.WantedVolunteers,
                EventInfoId = dtoEvent.EventInfoId,
            };
            return events;
        }

        public async Task<bool> UpdateEventAsync(Event events)
        {
            DtoEvent dtoEvent = await db.Events.Include(x => x.EventInfo).ThenInclude(x => x.Skills).FirstOrDefaultAsync(x => x.Id == events.Id);
            dtoEvent = new DtoEvent
            {
                Id = events.Id,
                OwnerId = events.OwnerId,
                VoluntaryId = events.VoluntaryId,
                Title = events.Title,
                Description = events.Description,
                ImageUrl = events.ImageUrl,
                WantedVolunteers = events.WantedVolunteers,
                EventInfoId = events.EventInfoId,
                EventInfo = new DtoEventInfo {Id = events.EventInfoId, Address = events.EventInfo.Address, CoordinateX = events.EventInfo.CoordinateX, CoordinateY = events.EventInfo.CoordinateY, Skills = new List<DtoSkills>(), Interests = new List<DtoInterests>() }
            };
            for (int i = 0; i < dtoEvent.EventInfo.Skills.Count; i++)
            {
                await RemoveSkillFromEventAsync(dtoEvent.EventInfoId, events.EventInfo.Skills[i].Id);
            }
            for (int i = 0; i < events.EventInfo.Skills.Count; i++)
            {
                await AddSkillToEventAsync(dtoEvent.EventInfoId, events.EventInfo.Skills[i].Id);
            }

            for (int i = 0; i < events.EventInfo.Interests.Count; i++)
            {
                dtoEvent.EventInfo.Interests.Add(new DtoInterests { Id = events.EventInfo.Interests[i].Id, Interest = events.EventInfo.Interests[i].Interest });
            }
            db.Events.Update(dtoEvent);
            try
            {
                await db.SaveChangesAsync();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
        public async Task AddSkillToEventAsync(int eventId, int skillId)
        {
            var eventInfo = await db.EventsInfo.FindAsync(eventId);
            var skill = await db.Skills.FindAsync(skillId);

            if (eventInfo != null && skill != null)
            {
                eventInfo.Skills ??= new List<DtoSkills>();
                eventInfo.Skills.Add(skill);
                db.Attach(eventInfo);
                await db.SaveChangesAsync();
            }
        }
        public async Task RemoveSkillFromEventAsync(int eventId, int skillId)
        {
            var eventInfo = await db.EventsInfo.Include(e => e.Skills).FirstOrDefaultAsync(e => e.Id == eventId);

            if (eventInfo != null)
            {
                var skillToRemove = eventInfo.Skills?.FirstOrDefault(s => s.Id == skillId);
                if (skillToRemove != null)
                {
                    eventInfo.Skills.Remove(skillToRemove);
                    db.Attach(eventInfo);
                    await db.SaveChangesAsync();
                }
            }
        }

        public async Task<bool> DeleteEventAsync(int eventId)
        {
            DtoEvent dtoEvent = await db.Events.FirstOrDefaultAsync(e => e.Id == eventId);
            db.Events.Remove(dtoEvent);
            try
            {
                await db.SaveChangesAsync();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public async Task<bool> CreateEventAsync(Event events)
        {
            DtoEvent dtoEvent = new DtoEvent
            {
                Id = events.Id,
                OwnerId = events.OwnerId,
                VoluntaryId = events.VoluntaryId,
                Title = events.Title,
                Description = events.Description,
                ImageUrl = events.ImageUrl,
                WantedVolunteers = events.WantedVolunteers,
                EventInfoId = events.EventInfoId,
                EventInfo = new DtoEventInfo {Id = events.EventInfoId, Address = events.EventInfo.Address, CoordinateX = events.EventInfo.CoordinateX, CoordinateY = events.EventInfo.CoordinateY }
            };
            await db.Events.AddAsync(dtoEvent);
            try
            {
                await db.SaveChangesAsync();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public async Task<List<Event>> GetFromUserInteretsAsync(int page, List<string> interests, double locationX, double locationY)
        {
            List<DtoEvent> dtoEvents = new List<DtoEvent>();
            List<Event> eventList = new List<Event>();
            try
            {
                dtoEvents = await db.Events.ToListAsync();
            }
            catch (Exception)
            {
                return new List<Event>();
            }
            foreach (DtoEvent dtoEvent in dtoEvents)
            {
                Event events = new Event
                {
                    Id = dtoEvent.Id,
                    OwnerId = dtoEvent.OwnerId,
                    VoluntaryId = dtoEvent.VoluntaryId,
                    Title = dtoEvent.Title,
                    Description = dtoEvent.Description,
                    ImageUrl = dtoEvent.ImageUrl,
                    WantedVolunteers = dtoEvent.WantedVolunteers,
                    EventInfoId = dtoEvent.EventInfoId
                };
                double DistanceY = Math.Abs(dtoEvent.EventInfo.CoordinateY - locationY);
                double DistanceX = Math.Abs(dtoEvent.EventInfo.CoordinateX - locationX);
                if (DistanceY < 0)
                {
                    DistanceY *= -1;
                }
                if (DistanceX < 0)
                {
                    DistanceX *= -1;
                }
                events.EventInfo.Distance = DistanceY + DistanceX;
                eventList.Add(events);
            }
            eventList.OrderBy(x => -x.EventInfo.Interests.Count(i => interests.Contains(i.Interest))).ThenBy(x => x.EventInfo.Distance).ToList();

            return eventList.GetRange(page-1*10, 10);
        }
    }
}
