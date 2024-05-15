using BackendModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

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