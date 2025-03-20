using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace FamilyToDoApp.Data
{
    class WeatherApi
    {
        private static readonly HttpClient Client = new HttpClient
        {
            BaseAddress = new Uri("https://api.api-ninjas.com")
        };

        static WeatherApi()
        {
            Client.DefaultRequestHeaders.Add("X-Api-Key", "");
        }

        public static async Task<Model.WeatherData> GetWeatherAsync(string uri)
        {
            HttpResponseMessage response = await Client.GetAsync(uri);

            if (response.IsSuccessStatusCode)
            {
                string responseString = await response.Content.ReadAsStringAsync();

                return JsonSerializer.Deserialize<Model.WeatherData>(responseString);
            }
            else
            {
                return null;
            }
        }
    }
}
