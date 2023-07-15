using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoFinal_MAUI__FV__ME
{
    public class JokeService
    {
        private readonly HttpClient httpClient;

        public JokeService()
        {
            httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
        }

        public async Task<string> GetJoke()
        {
            HttpResponseMessage response = await httpClient.GetAsync("https://icanhazdadjoke.com/");
            if (response.IsSuccessStatusCode)
            {
                string json = await response.Content.ReadAsStringAsync();
                dynamic jokeData = Newtonsoft.Json.JsonConvert.DeserializeObject(json);
                string joke = jokeData.joke;
                return joke;
            }
            else
            {
                // Maneja el error de la solicitud HTTP
                return string.Empty;
            }
        }
    }
}