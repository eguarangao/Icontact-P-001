using Business.DTOs;

namespace BlazorCine.Services
{
    public interface IHorario
    {
        Task<ServiceResponse> AddAsync(HorarioDto horarioDto);
        Task<List<HorarioDto>> GetAsync();
        Task<ServiceResponse> UpdateAsync(updateDto horarioDto);
        Task<ServiceResponse> DeleteAsync(int id);
        Task<List<HorarioDto>> GetFilteredAsync(int? peliculaId = null, int? salaId = null, DateTime? startDate = null, DateTime? endDate = null);
    }
}
