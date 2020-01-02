using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using WeatherApp.Model;

namespace WeatherApp.ViewModel.Helpers
{
   public class AccuWeatherHelper
   {
       public const string BaseUrl = "http://dataservice.accuweather.com/";
       public const string LocationAutoCompleteEndPoint = "locations/v1/cities/autocomplete?apikey={0}&q={1}";
       public const string CurrentConditionEndpoint = "currentconditions/v1/{0}?apikey={1}";
       public const string ApiKey = "05YA0nM6KH3Tz4Pp3jrsLIMQAVPjgOVE";

       public static async Task<List<City>> GetCities(string query)
       {
            string url = string.Format(BaseUrl + LocationAutoCompleteEndPoint, ApiKey, query);
            using (HttpClient client= new HttpClient())
            {
                var response = await client.GetAsync(url);
                string json = await response.Content.ReadAsStringAsync();

                var cities = JsonConvert.DeserializeObject<List<City>>(json);
           return   cities ?? new List<City>();
            }
       }

       public static async Task<CurrentConditions> GetCurrentCondition(string cityKey)
       {
           string url = string.Format(BaseUrl + CurrentConditionEndpoint, cityKey, ApiKey);
           using (HttpClient client = new HttpClient())
           {
               
               var response = await client.GetAsync(url);
               var json = await response.Content.ReadAsStringAsync();

               var currentConditions = JsonConvert.DeserializeObject<List<CurrentConditions>>(json).FirstOrDefault();
               return currentConditions ?? new CurrentConditions();
           }
       }
   }
}
