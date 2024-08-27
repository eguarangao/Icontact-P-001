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
        public async Task<ServiceResponse> AddAsync(HorarioDto horarioDto)
        {
            try
            {
                var response = await httpClient.PostAsJsonAsync("api/horario", horarioDto);
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<ServiceResponse>();
                }
                else
                {
                    return new ServiceResponse(false, "Error al crear el horario");
                }
            }
            catch (Exception ex)
            {
                return new ServiceResponse(false, $"Excepción: {ex.Message}");
            }
        }

        public async Task<List<HorarioDto>> GetAsync()=>
            await httpClient.GetFromJsonAsync<List<HorarioDto>>("api/horario");

        Task<ServiceResponse> IHorario.DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
