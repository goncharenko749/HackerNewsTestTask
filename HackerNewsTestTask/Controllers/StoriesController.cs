using HackerNewsTestTask.Models;
using HackerNewsTestTask.Services;
using Microsoft.AspNetCore.Mvc;

namespace HackerNewsTestTask.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StoriesController : ControllerBase
    {
        private readonly IHackerNewsService _hackerNewsService;

        public StoriesController(IHackerNewsService hackerNewsService)
        {
            _hackerNewsService = hackerNewsService;
        }

        [HttpGet("best/{count}")]
        [ProducesResponseType(typeof(List<Story>), StatusCodes.Status200OK)]
        public virtual async Task<IActionResult> GetBestStories(int count)
        {
            if (count <= 0)
            {
                return BadRequest("Count must be greater than 0.");
            }

            List<Story> stories = await _hackerNewsService.GetBestStoriesAsync(count);

            if (!stories.Any())
            {
                return NotFound("No stories found.");
            }

            return Ok(stories);
        }
    }
}
