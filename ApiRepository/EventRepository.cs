using ApiDBlayer;
using BackendModels;
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
        public async Task<DtoEvent> GetOneEvent(int eventId)
        {
            DtoEvent dtoEvent = new DtoEvent();
            dtoEvent = await db.Events.FirstOrDefaultAsync(x => x.Id == eventId);
            Event events = new Event
            {

            }
            return dtoEvent;
        }

        public async Task<bool> UpdateEvent(DtoEvent events)
        {
            return true;
        }

        public async Task<bool> DeleteEvent(int eventId)
        {
            return true;
        }

        public async Task<bool> CreateEvent(DtoEvent events)
        {
            return true;
        }

        public async Task<List<DtoEvent>> GetFromUserInterets(int page, List<string> interests, string location)
        {
            List<DtoEvent> dtoEvents = new List<DtoEvent>();
            return dtoEvents;
        }
    }
}
