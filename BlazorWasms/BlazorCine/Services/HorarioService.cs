using Business.DTOs;
using System.Net.Http.Json;

namespace BlazorCine.Services
{
    public class HorarioService : IHorario
    {
        private readonly HttpClient httpClient;
        public HorarioService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }
        public Task<ServiceResponse> AddAsync(HorarioDto horarioDto)
        {
            throw new NotImplementedException();
        }

        public async Task<List<HorarioDto>> GetAsync()=>
            await httpClient.GetFromJsonAsync<List<HorarioDto>>("api/horario");
    }
}
