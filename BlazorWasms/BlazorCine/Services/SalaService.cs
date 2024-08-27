using Business.DTOs;
using System.Net.Http.Json;

namespace BlazorCine.Services
{
    public class SalaService : ISalaService
    {
        private readonly HttpClient httpClient;

        public SalaService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }
        public async Task<List<SalaDto>> GetSalasAsync()
        {
            return await httpClient.GetFromJsonAsync<List<SalaDto>>("api/sala");
        }
    }
}
