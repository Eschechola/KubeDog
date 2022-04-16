using KubeDog.Services.Responses;

namespace KubeDog.Services.Interfaces
{
    public interface IApiService
    {
        Task<GetRandomDogResponse> GetRandomDogImageAsync();
    }
}
