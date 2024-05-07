using ApiDBlayer;
using DbModels;
using FrontendModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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
            dtoEvent = await db.Events.FirstOrDefaultAsync(x => x.Id == eventId);
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
            return events;
        }

        public async Task<bool> UpdateEventAsync(Event events)
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
                EventInfoId = events.EventInfoId
            };
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
                EventInfoId = events.EventInfoId
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
