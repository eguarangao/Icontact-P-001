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

        public async Task<ServiceResponse> UpdateAsync(updateDto horarioDto)
        {
            try
            {
                var response = await httpClient.PutAsJsonAsync($"api/horario/{horarioDto.IdHorario}", horarioDto);
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<ServiceResponse>();
                }
                else
                {
                    return new ServiceResponse(false, "Error al actualizar el horario");
                }
            }
            catch (Exception ex)
            {
                return new ServiceResponse(false, $"Excepción: {ex.Message}");
            }
        }

        public async Task<ServiceResponse> DeleteAsync(int id)
        {
            try
            {
                var response = await httpClient.DeleteAsync($"api/horario/{id}");
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<ServiceResponse>();
                }
                else
                {
                    return new ServiceResponse(false, "Error al eliminar el horario.");
                }
            }
            catch (Exception ex)
            {
                return new ServiceResponse(false, $"Excepción: {ex.Message}");
            }
        }
    }
}
