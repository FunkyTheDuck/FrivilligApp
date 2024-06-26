﻿using BackendModels;
using System.Text;
using Newtonsoft.Json;

namespace MauiDBlayer
{
    public class DBAccess
    {
        protected HttpClient HttpClient;
        //string ip;
        public DBAccess()
        {
            HttpClient = new HttpClient();
            //HttpClient.BaseAddress = new Uri("http://10.0.2.2:5191/api/");
        }
        public async Task<bool> CreateEventAsync(DtoEvent dtoEvent)
        {
            if (dtoEvent != null)
            {
                string json = JsonConvert.SerializeObject(dtoEvent);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage response;
                try
                {
                    response = await HttpClient.PostAsync("http://10.0.2.2:5191/api/Event", content);
                }
                catch
                {
                    return false;
                }
                return response.IsSuccessStatusCode;
            }
            return false;
        }
        public async Task<List<DtoEvent>> GetFromUserInteretsAsync(int page, int userId, double locationX, double locationY)
        {
            HttpResponseMessage response;
            response = await HttpClient.GetAsync($"http://10.0.2.2:5191/api/Event?page={page}&userId={userId}&locationX={locationX}&locationY={locationY}");
            string json = await response.Content.ReadAsStringAsync();
            List<DtoEvent> events = JsonConvert.DeserializeObject<List<DtoEvent>>(json);
            return events;
        }
        public async Task<List<DtoEvent>> GetEventToUserAsync(int userId)
        {
            HttpResponseMessage response;
            response = await HttpClient.GetAsync($"http://10.0.2.2:5191/api/Event/EventToUser?userId={userId}");
            string json = await response.Content.ReadAsStringAsync();
            List<DtoEvent> events = JsonConvert.DeserializeObject<List<DtoEvent>>(json);
            return events;
        }
        public async Task<List<DtoEvent>> GetEventToOwnerAsync(int userId)
        {
            HttpResponseMessage response;
            response = await HttpClient.GetAsync($"http://10.0.2.2:5191/api/Event/EventToOwner?userId={userId}");
            string json = await response.Content.ReadAsStringAsync();
            List<DtoEvent> events = JsonConvert.DeserializeObject<List<DtoEvent>>(json);
            return events;
        }
        public async Task<bool> AddVoluntaryToEvent(int userId, int eventId)
        {
            if (userId != null && eventId != null)
            {
                HttpResponseMessage response;
                response = await HttpClient.GetAsync($"http://10.0.2.2:5191/api/Event/AddVoluntary?userId={userId}&eventId={eventId}");
                return response.IsSuccessStatusCode;
            }
            return false;
        }
        public async Task<bool> RemoveVoluntaryFromEvent(int userId, int eventId)
        {
            if (userId != null && eventId != null)
            {
                HttpResponseMessage response;
                response = await HttpClient.DeleteAsync($"http://10.0.2.2:5191/api/Event/RemoveVoluntary?userId={userId}&eventId={eventId}");
                return response.IsSuccessStatusCode;
            }
            return false;
        }

        public async Task<List<DtoSkills>> GetSkillsAsync()
        {
            HttpResponseMessage response;
            response = await HttpClient.GetAsync("http://10.0.2.2:5191/api/Skills");
            string json = await response.Content.ReadAsStringAsync();
            List<DtoSkills> skills = JsonConvert.DeserializeObject<List<DtoSkills>>(json);
            return skills;
        }
        public async Task<List<DtoInterests>> GetInterestsAsync()
        {
            HttpResponseMessage response;
            response = await HttpClient.GetAsync("http://10.0.2.2:5191/api/Interests");
            string json = await response.Content.ReadAsStringAsync();
            List<DtoInterests> Interests = JsonConvert.DeserializeObject<List<DtoInterests>>(json);
            return Interests;
        }
        public async Task<bool> CreateUserAsync(DtoUser dtoUser)
        {
            if (dtoUser != null)
            {
                string json = JsonConvert.SerializeObject(dtoUser);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage response;
                try
                {
                    response = await HttpClient.PostAsync("http://10.0.2.2:5191/api/User", content);
                }
                catch
                {
                    return false;
                }
                return response.IsSuccessStatusCode;
            }
            return false;
        }
        public async Task<DtoUser> GetUserAsync(string username, string password)
        {
            HttpResponseMessage response;
            response = await HttpClient.GetAsync($"http://10.0.2.2:5191/api/User?username={username}&hashedPassword={password}");
            string json = await response.Content.ReadAsStringAsync();
            DtoUser dtoUser = JsonConvert.DeserializeObject<DtoUser>(json);
            return dtoUser;
        }
        public async Task<DtoUser> GetUserAsync(int userId)
        {
            HttpResponseMessage response;
            response = await HttpClient.GetAsync($"http://10.0.2.2:5191/api/User/{userId}");
            string json = await response.Content.ReadAsStringAsync();
            DtoUser dtoUser = JsonConvert.DeserializeObject<DtoUser>(json);
            return dtoUser;
        }
        public async Task<bool> UpdateUserAsync(DtoUser dtoUser)
        {
            HttpResponseMessage response;
            var content = new StringContent(JsonConvert.SerializeObject(dtoUser), Encoding.UTF8, "application/json");
            response = await HttpClient.PutAsync("http://10.0.2.2:5191/api/User", content);
            return response.IsSuccessStatusCode;
        }
    }
}
