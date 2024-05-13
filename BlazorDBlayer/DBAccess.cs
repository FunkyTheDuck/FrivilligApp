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
    }
}