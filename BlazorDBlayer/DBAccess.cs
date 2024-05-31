using BackendModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Diagnostics;

namespace BlazorDBlayer
{
    public class DBAccess
    {
        protected HttpClient httpClient;
        public DBAccess()
        {
            httpClient = new HttpClient { BaseAddress =  new Uri("https://localhost:7023/api/")};
        }
        #region EventCRUD

        public async Task<List<DtoEvent>> GetAllEventsAsync(int page, int userId, double x, double y)
        {
            HttpResponseMessage response;
            try
            {
                response = await httpClient.GetAsync($"Event?page={page}&userId={userId}&locationX={x}&locationY={y}");
            }
            catch
            {
                return null;
            }
            if(response.IsSuccessStatusCode)
            {
                List<DtoEvent> events;
                try
                {
                    string json = await response.Content.ReadAsStringAsync();
                    events = JsonConvert.DeserializeObject<List<DtoEvent>>(json);
                }
                catch
                {
                    return null;
                }
                if(events != null && events.Count != 0)
                {
                    return events;
                }
            }
            return null;
        }
        public async Task<List<DtoEvent>> GetVoluntaryEventsAsync(int userId)
        {
            HttpResponseMessage response;
            try
            {
                response = await httpClient.GetAsync($"Event/Voluntary?userId={userId}");
            }
            catch
            {
                return null;
            }
            if(response.IsSuccessStatusCode)
            {
                List<DtoEvent> events;
                try
                {
                    string json = await response.Content.ReadAsStringAsync();
                    events = JsonConvert.DeserializeObject<List<DtoEvent>>(json);
                }
                catch
                {
                    return null;
                }
                if (events != null && events.Count != 0)
                {
                    return events;
                }
            }
            return null;
        }
        public async Task<List<DtoEvent>> GetOwnersEventsAsync(int userId)
        {
            HttpResponseMessage response;
            try
            {
                response = await httpClient.GetAsync($"Event/Owner?userId={userId}");
            }
            catch
            {
                return null;
            }
            if (response.IsSuccessStatusCode)
            {
                List<DtoEvent> events;
                try
                {
                    string json = await response.Content.ReadAsStringAsync();
                    events = JsonConvert.DeserializeObject<List<DtoEvent>>(json);
                }
                catch
                {
                    return null;
                }
                if (events != null && events.Count != 0)
                {
                    return events;
                }
            }
            return null;
        }
        public async Task<bool> CreateEventAsync(DtoEvent dtoEvent)
        {
            if(dtoEvent != null)
            {
                string json = JsonConvert.SerializeObject(dtoEvent);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage response;
                try
                {
                    response = await httpClient.PostAsync("Event", content);
                }
                catch
                {
                    return false;
                }
                return response.IsSuccessStatusCode;
            }
            return false;
        }

        public async Task<bool> AddVoluntaryToEventAsync(int userId, int eventId)
        {
            if(userId != 0 && eventId != 0)
            {
                HttpResponseMessage response;
                try
                {
                    response = await httpClient.GetAsync($"Event/AddVoluntary?userId={userId}&eventId={eventId}");
                }
                catch
                {
                    return false;
                }
                return response.IsSuccessStatusCode;
            }
            return false;
        }
        #endregion

        #region

        public async Task<DtoUser> LogUserInAsync(string username, string hashedPassword)
        {
            HttpResponseMessage response;
            try
            {
                response = await httpClient.GetAsync($"User?username={username}&hashedPassword={hashedPassword}");
            }
            catch
            {
                return null;
            }
            if(response.IsSuccessStatusCode)
            {
                DtoUser user;
                try
                {
                    string json = await response.Content.ReadAsStringAsync();
                    user = JsonConvert.DeserializeObject<DtoUser>(json);
                }
                catch
                {
                    return null;
                }
                if (user != null)
                {
                    return user;
                }
            }
            return null;
        }

        public async Task<bool> CreateUserAsync(DtoUser user)
        {
            if (user != null)
            {
                string json = JsonConvert.SerializeObject(user);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage response;
                try
                {
                    response = await httpClient.PostAsync("User", content);
                }
                catch
                {
                    return false;
                }
                return response.IsSuccessStatusCode;
            }
            return false;
        }

        public async Task<DtoUser> GetUserFromIdAsync(int userId)
        {
            HttpResponseMessage response;
            try
            {
                response = await httpClient.GetAsync($"User/{userId}");
            }
            catch
            {
                return null;
            }
            if (response.IsSuccessStatusCode)
            {
                DtoUser user;
                try
                {
                    string json = await response.Content.ReadAsStringAsync();
                    user = JsonConvert.DeserializeObject<DtoUser>(json);
                }
                catch
                {
                    return null;
                }
                if (user != null)
                {
                    return user;
                }
            }
            return null;
        }

        #endregion

        #region RatingsCRUD

        public async Task<List<DtoRatings>> GetNewestRatingsAsync(int userId)
        {
            HttpResponseMessage response;
            try
            {
                response = await httpClient.GetAsync($"Rating/Newest?userId={userId}");
            }
            catch
            {
                return null;
            }
            if(response.IsSuccessStatusCode)
            {
                List<DtoRatings> dtoRatings = new List<DtoRatings>();
                try
                {
                    string json = await response.Content.ReadAsStringAsync();
                    dtoRatings = JsonConvert.DeserializeObject<List<DtoRatings>>(json);
                }
                catch
                {
                    return null;
                }
                if(dtoRatings != null && dtoRatings.Count != 0)
                {
                    return dtoRatings;
                }
            }
            return null;
        }

        public async Task<List<DtoRatings>> GetAllUsersRatingsAsync(int userId)
        {
            HttpResponseMessage response;
            try
            {
                response = await httpClient.GetAsync($"Rating?userId={userId}");
            }
            catch
            {
                return null;
            }
            if (response.IsSuccessStatusCode)
            {
                List<DtoRatings> dtoRatings = new List<DtoRatings>();
                try
                {
                    string json = await response.Content.ReadAsStringAsync();
                    dtoRatings = JsonConvert.DeserializeObject<List<DtoRatings>>(json);
                }
                catch
                {
                    return null;
                }
                if (dtoRatings != null && dtoRatings.Count != 0)
                {
                    return dtoRatings;
                }
            }
            return null;
        }

        #endregion

        #region SkillsCRUD

        public async Task<List<DtoSkills>> GetAllSkillsAsync()
        {
            HttpResponseMessage response;
            try
            {
                response = await httpClient.GetAsync("Skills");
            }
            catch
            {
                return null;
            }
            if(response.IsSuccessStatusCode)
            {
                List<DtoSkills> skills;
                try
                {
                    string json = await response.Content.ReadAsStringAsync();
                    skills = JsonConvert.DeserializeObject<List<DtoSkills>>(json);
                }
                catch
                {
                    return null;
                }
                if(skills != null && skills.Count != 0)
                {
                    return skills;
                }
            }
            return null;
        }

        #endregion

        #region InterestsCRUD

        public async Task<List<DtoInterests>> GetAllInterestsAsync()
        {
            HttpResponseMessage response;
            try
            {
                response = await httpClient.GetAsync("Interests");
            }
            catch
            {
                return null;
            }
            if (response.IsSuccessStatusCode)
            {
                List<DtoInterests> interests;
                try
                {
                    string json = await response.Content.ReadAsStringAsync();
                    interests = JsonConvert.DeserializeObject<List<DtoInterests>>(json);
                }
                catch
                {
                    return null;
                }
                if (interests != null && interests.Count != 0)
                {
                    return interests;
                }
            }
            return null;
        }

        #endregion
    }
}