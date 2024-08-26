

using Business.DTOs;
using Business.Entities;

namespace DataAccess.Repositories
{
    public interface IHorarioRepository
    {
        Task<ServiceResponse> AddAsync(HorarioDto horarioDto);
        Task<ServiceResponse> UpdateAsync(HorarioDto horarioDto);
        Task<ServiceResponse> DeleteAsync(int id);
        Task<List<HorarioDto>> GetAsync();
        Task<HorarioDto> GetByIdAsync(int id);
    }
}
