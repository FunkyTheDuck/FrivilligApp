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
                EventInfo = new DtoEventInfo { Id = events.EventInfoId, Address = events.EventInfo.Address, CoordinateX = events.EventInfo.CoordinateX, CoordinateY = events.EventInfo.CoordinateY, Skills = new List<DtoSkills>(), Interests = new List<DtoInterests>() }
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
                EventInfo = new DtoEventInfo { Id = events.EventInfoId, Address = events.EventInfo.Address, CoordinateX = events.EventInfo.CoordinateX, CoordinateY = events.EventInfo.CoordinateY }
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
            dtoEvent = await db.Events.FirstOrDefaultAsync(x => x.Title == dtoEvent.Title);
            if (events.EventInfo.Skills != null)
            {
                foreach (Skills skill in events.EventInfo.Skills)
                {
                    DtoEventInfoSkills infoSkills = new DtoEventInfoSkills
                    {
                        EventInfoId = dtoEvent.EventInfoId,
                        SkillsId = skill.Id
                    };
                    await db.EventInfoSkills.AddAsync(infoSkills);
                }
            }
            if (events.EventInfo.Interests != null)
            {
                foreach (Interests interests in events.EventInfo.Interests)
                {
                    DtoEventInfoInterests infoInterests = new DtoEventInfoInterests
                    {
                        EventInfoId = dtoEvent.EventInfoId,
                        InterestsId = interests.Id
                    };
                    await db.EventInfoInterests.AddAsync(infoInterests);
                }
            }
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

        public async Task<List<Event>> GetFromUserInteretsAsync(int page, int userId, double locationX, double locationY)
        {
            List<DtoEvent> dtoEvents = new List<DtoEvent>();
            List<Event> eventList = new List<Event>();
            try
            {
                dtoEvents = await db.Events.Include(x => x.EventInfo.Interests).ToListAsync();
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
                    EventInfoId = dtoEvent.EventInfoId,
                    EventInfo = new FrontendModels.EventInfo
                    {
                        Id = dtoEvent.EventInfoId,
                        Address = dtoEvent.EventInfo.Address,
                        CoordinateX = dtoEvent.EventInfo.CoordinateX,
                        CoordinateY = dtoEvent.EventInfo.CoordinateY,
                    },
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
            List<string> interests = await db.Users.Where(u => u.Id == userId)
                .SelectMany(ui => ui.UserInfo.Interests)
                .Select(i => i.Interest).ToListAsync();
            if (interests != null && interests.Count != 0)
            {
                eventList = eventList
                    .OrderByDescending(x => x.EventInfo.Interests != null ? x.EventInfo.Interests.Count(i => interests.Contains(i.Interest)) : 0)
                    .ThenBy(x => x.EventInfo.Distance).ToList();
            }
            else
            {
                eventList = eventList
                    .OrderBy(x => x.EventInfo.Distance).ToList();
            }
            if (eventList.Count > 10)
            {
                return eventList.GetRange(page - 1 * 10, 10);
            }
            return eventList;
        }
        public async Task<bool> AddVoluntaryToEvent(int userId, int eventId)
        {
            DtoEventUser dtoEventUser = new DtoEventUser
            {
                UserId = userId,
                EventId = eventId
            };
            await db.EventUsers.AddAsync(dtoEventUser);
            try
            {
                await db.SaveChangesAsync();
            }
            catch
            {
                return false;
            }
            return true;
        }
        public async Task<List<Event>> GetOwnersEventsAsync(int userId)
        {
            List<DtoEvent> dtoEvents = new List<DtoEvent>();
            try
            {
                dtoEvents = await db.Events.Where(x => x.OwnerId == userId).Include(ei => ei.EventInfo).ToListAsync();
            }
            catch (Exception)
            {
                return new List<Event>();
            }
            if(dtoEvents != null )
            {
                List<Event> eventList = new List<Event>();
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
                        EventInfoId = dtoEvent.EventInfoId,
                        EventInfo = new FrontendModels.EventInfo
                        {
                            Id = dtoEvent.EventInfoId,
                            Address = dtoEvent.EventInfo.Address,
                            CoordinateX = dtoEvent.EventInfo.CoordinateX,
                            CoordinateY = dtoEvent.EventInfo.CoordinateY,
                        },
                    };
                    eventList.Add(events);
                }
                return eventList;
            }
            return null;
        }
        public async Task<List<Event>> GetVoluntarysEventsAsync(int userId)
        {
            List<DtoEvent> dtoEvents = new List<DtoEvent>();
            try
            {
                dtoEvents = await db.Events.Where(x => x.OwnerId == userId).Include(ei => ei.EventInfo).ToListAsync();
            }
            catch (Exception)
            {
                return new List<Event>();
            }
            if (dtoEvents != null)
            {
                List<Event> eventList = new List<Event>();
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
                        EventInfoId = dtoEvent.EventInfoId,
                        EventInfo = new FrontendModels.EventInfo
                        {
                            Id = dtoEvent.EventInfoId,
                            Address = dtoEvent.EventInfo.Address,
                            CoordinateX = dtoEvent.EventInfo.CoordinateX,
                            CoordinateY = dtoEvent.EventInfo.CoordinateY,
                        },
                    };
                    eventList.Add(events);
                }
                return eventList;
            }
            return null;
        }
        public async Task<bool> RemoveVoluntaryFromEvent(int userId, int eventId)
        {
            DtoEventUser dtoEventUser = new DtoEventUser
            {
                UserId = userId,
                EventId = eventId
            };
            db.EventUsers.Remove(dtoEventUser);
            try
            {
                await db.SaveChangesAsync();
            }
            catch
            {
                return false;
            }
            return true;
        }
        public async Task<List<Event>> GetEventToUserAsync(int userId)
        {
            List<DtoEventUser> dtoEventUsers = await db.EventUsers.Include(x => x.Event).ThenInclude(x => x.EventInfo).Where(x => x.UserId == userId).ToListAsync();
            List<Event> EventList = new List<Event>();
            for (int i = 0; i < dtoEventUsers.Count; i++)
            {
                Event events = new Event
                {
                    Id = dtoEventUsers[i].Event.Id,
                    OwnerId = dtoEventUsers[i].Event.OwnerId,
                    VoluntaryId = dtoEventUsers[i].Event.VoluntaryId,
                    Title = dtoEventUsers[i].Event.Title,
                    Description = dtoEventUsers[i].Event.Description,
                    ImageUrl = dtoEventUsers[i].Event.ImageUrl,
                    WantedVolunteers = dtoEventUsers[i].Event.WantedVolunteers,
                    EventInfoId = dtoEventUsers[i].Event.EventInfoId,
                    EventInfo = new FrontendModels.EventInfo
                    {
                        Id = dtoEventUsers[i].Event.EventInfoId,
                        Address = dtoEventUsers[i].Event.EventInfo.Address,
                        CoordinateX = dtoEventUsers[i].Event.EventInfo.CoordinateX,
                        CoordinateY = dtoEventUsers[i].Event.EventInfo.CoordinateY,
                    },
                };
                EventList.Add(events);
            }
            return EventList;
        }
        public async Task<List<Event>> GetEventToOwnerAsync(int userId)
        {
            List<DtoEvent> dtoEvent = await db.Events.Include(x => x.EventInfo).Where(x => x.OwnerId == userId).ToListAsync();
            List<Event> eventList = new List<Event>();
            for (int i = 0; i < dtoEvent.Count; i++)
            {
                Event events = new Event
                {
                    Id = dtoEvent[i].Id,
                    OwnerId = dtoEvent[i].OwnerId,
                    VoluntaryId = dtoEvent[i].VoluntaryId,
                    Title = dtoEvent[i].Title,
                    Description = dtoEvent[i].Description,
                    ImageUrl = dtoEvent[i].ImageUrl,
                    WantedVolunteers = dtoEvent[i].WantedVolunteers,
                    EventInfoId = dtoEvent[i].EventInfoId,
                    EventInfo = new FrontendModels.EventInfo
                    {
                        Id = dtoEvent[i].EventInfoId,
                        Address = dtoEvent[i].EventInfo.Address,
                        CoordinateX = dtoEvent[i].EventInfo.CoordinateX,
                        CoordinateY = dtoEvent[i].EventInfo.CoordinateY,
                        Skills = new(),
                        Interests = new()
                    }
                };
                if (dtoEvent[i].EventInfo.Skills != null)
                {
                    foreach (DtoSkills dtoSkill in dtoEvent[i].EventInfo.Skills)
                    {
                        Skills skill = new Skills
                        {
                            Id = dtoSkill.Id,
                            Skill = dtoSkill.Skill,
                        };
                        events.EventInfo.Skills.Add(skill);
                    }
                }
                if (dtoEvent[i].EventInfo.Interests != null)
                {
                    foreach (DtoInterests dtoInterests in dtoEvent[i].EventInfo.Interests)
                    {
                        Interests interest = new Interests
                        {
                            Id = dtoInterests.Id,
                            Interest = dtoInterests.Interest,
                        };
                        events.EventInfo.Interests.Add(interest);
                    }
                }
                eventList.Add(events);
            }
            return eventList;
        }
    }
}
