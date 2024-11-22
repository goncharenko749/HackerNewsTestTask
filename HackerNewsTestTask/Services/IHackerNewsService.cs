using HackerNewsTestTask.Models;

namespace HackerNewsTestTask.Services
{
    public interface IHackerNewsService
    {
        Task<List<Story>> GetBestStoriesAsync(int count);
    }
}