using BackendModels;
using BlazorDBlayer;
using FrontendModels;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public async Task<bool> CreateAsync(Event events)
        {
            if(events != null)
            {
                DtoEvent dtoEvent = new DtoEvent
                {
                    Title = events.Title,
                    Description = events.Description,
                    ImageUrl = events.ImageUrl,
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
                if(events.EventInfo.Skills != null)
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
    }
}