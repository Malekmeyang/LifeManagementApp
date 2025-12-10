using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using Notes.Interfaces;

namespace Notes.Services
{
    public class JokeService : IJokeService
    {
        private readonly HttpClient _httpClient;

        public JokeService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string> GetDailyJokeAsync()
        {
            string url = "https://v2.jokeapi.dev/joke/Programming" +
                         "?blacklistFlags=nsfw,religious,political,racist,sexist,explicit";

            string json = await _httpClient.GetStringAsync(url);
            using var doc = JsonDocument.Parse(json);

            var root = doc.RootElement;
            string type = root.GetProperty("type").GetString()!;

            if (type == "single")
                return root.GetProperty("joke").GetString()!;

            string setup = root.GetProperty("setup").GetString()!;
            string delivery = root.GetProperty("delivery").GetString()!;
            return $"{setup} — {delivery}";
        }
    }
}