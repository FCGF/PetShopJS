using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace PetShopJS.Models {
    public class WeatherMapProxy {
        private static readonly string appId = "efbc7f044ee579a5f8504dc86623d6b6";

        public static async Task<RootObject> GetWeather(double lat, double lon) {
            var http = new HttpClient();
            string uri =
                $"http://api.openweathermap.org/data/2.5/weather?lat={lat}&lon={lon}&units=metric&appid={appId}";
            var response = await http.GetAsync(uri);
            var result = await response.Content.ReadAsStringAsync();
            var serializer = new DataContractJsonSerializer(typeof(RootObject));

            var memoryStream = new MemoryStream(Encoding.UTF8.GetBytes(result));
            var data = (RootObject)serializer.ReadObject(memoryStream);

            return data;
        }
    }
}