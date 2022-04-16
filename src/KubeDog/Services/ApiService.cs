using KubeDog.Services.Interfaces;
using KubeDog.Services.Responses;
using Newtonsoft.Json;

namespace KubeDog.Services
{
    public class ApiService : IApiService
    {
        private readonly IConfiguration _configuration;

        public ApiService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<GetRandomDogResponse> GetRandomDogImageAsync()
        {
            var httpClient = new HttpClient();

            var httpRequestMessage = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(_configuration["Dogs:ApiUrl"]),
            };

            var response = await httpClient.SendAsync(httpRequestMessage);
            var responseBody = await response.Content.ReadAsStringAsync();
            
            return JsonConvert.DeserializeObject<GetRandomDogResponse>(responseBody);
        }
    }
}
