using Business.DTOs;

namespace BlazorCine.Services
{
    public interface IHorario
    {
        Task<ServiceResponse> AddAsync(HorarioDto horarioDto);
        Task<List<HorarioDto>> GetAsync();
        Task<ServiceResponse> DeleteAsync(int id);
    }
}
