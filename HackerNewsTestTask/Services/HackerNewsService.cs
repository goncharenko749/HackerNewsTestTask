using HackerNewsTestTask.Models;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;

namespace HackerNewsTestTask.Services
{
    public class HackerNewsService : IHackerNewsService
    {
        private readonly HttpClient _httpClient;
        private readonly IMemoryCache _cache;
        private const string BaseUrl = "https://hacker-news.firebaseio.com/v0";

        public HackerNewsService(HttpClient httpClient, IMemoryCache cache)
        {
            _httpClient = httpClient;
            _cache = cache;
        }

        public async Task<List<Story>> GetBestStoriesAsync(int count)
        {
            var bestStoryIds = await _cache.GetOrCreateAsync("BestStoryIds", async entry =>
            {
                entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5);
                string response = await _httpClient.GetStringAsync($"{BaseUrl}/beststories.json");
                return JsonConvert.DeserializeObject<List<int>>(response);
            });

            var tasks = bestStoryIds.Take(count).Select(id => GetStoryAsync(id));
            var stories = await Task.WhenAll(tasks);

            return stories.Where(story => story != null)
                .OrderByDescending(story => story.Score)
                .ToList();
        }

        private async Task<Story> GetStoryAsync(int id)
        {
            string response = await _httpClient.GetStringAsync($"{BaseUrl}/item/{id}.json");
            Story? storyDetails = JsonConvert.DeserializeObject<Story>(response);

            return storyDetails;
        }
    }
}