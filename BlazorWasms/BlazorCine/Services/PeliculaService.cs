using Business.DTOs;
using System.Net.Http.Json;

namespace BlazorCine.Services
{
    public class PeliculaService : IPeliculaService
    {
        private readonly HttpClient httpClient;

        public PeliculaService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }
        public async Task<List<PeliculaDto>> GetPeliculasAsync()
        {
            return await httpClient.GetFromJsonAsync<List<PeliculaDto>>("api/pelicula");
        }
    }
}
