using CatMemes.Models;
using Microsoft.AspNetCore.Mvc;

namespace CatMemes.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : ControllerBase
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public async Task<IEnumerable<string>> GetMemes()
        {
            var httpClient = new HttpClient();
            var apiKey = "PwrqhNXYACaACMleAIJvztz9lCRZwZg3";
            var searchQuery = "cat";
            var apiUrl = $"https://api.giphy.com/v1/gifs/search?api_key={apiKey}&q={searchQuery}";

            var response = await httpClient.GetAsync(apiUrl);
            var json = await response.Content.ReadAsStringAsync();
            var result = Newtonsoft.Json.JsonConvert.DeserializeObject<GiphyResponse>(json);

            if (result == null) { 
                return Enumerable.Empty<string>();
            }
            var result2 = result.Data.Select(gif => gif.Images.Original.Url).ToList();
            return result2;
        }
    }
}