using KubeDog.Services.Interfaces;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KubeDog.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IApiService _apiService;

        public IndexModel(IApiService apiService)
        {
            _apiService = apiService;
        }

        public void OnGet()
        {
            var randomDog = _apiService.GetRandomDogImageAsync().Result;
            ViewData["DogImageUrl"] = randomDog.Message;
        }
    }
}