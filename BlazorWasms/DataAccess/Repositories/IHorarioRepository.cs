

using Business.DTOs;
using Business.Entities;

namespace DataAccess.Repositories
{
    public interface IHorarioRepository
    {
        Task<ServiceResponse> AddAsync(HorarioDto horarioDto);
        Task<ServiceResponse> UpdateAsync(updateDto horarioDto);
        Task<ServiceResponse> DeleteAsync(int id);
        Task<List<HorarioDto>> GetAsync();
        Task<HorarioDto> GetByIdAsync(int id);
        Task<List<HorarioDto>> GetFilteredAsync(int? peliculaId = null, int? salaId = null, DateTime? startDate = null, DateTime? endDate = null);
    }
}
