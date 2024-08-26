

using Business.DTOs;
using Business.Entities;

namespace DataAccess.Repositories
{
    public interface IHorarioRepository
    {
        Task<ServiceResponse> AddAsync(Horario horario);
        Task<ServiceResponse> UpdateAsync(Horario horario);
        Task<ServiceResponse> DeleteAsync(int id);
        Task<List<Horario>> GetAsync();
        Task<Horario> GetByIdAsync(int id);
    }
}
