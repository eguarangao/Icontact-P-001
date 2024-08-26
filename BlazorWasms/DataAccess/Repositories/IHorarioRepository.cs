

using Business.Entities;

namespace DataAccess.Repositories
{
    public interface IHorarioRepository:IRepository<Horario>
    {
        // Métodos adicionales específicos para la entidad Horario
        Task<IEnumerable<Horario>> GetByPeliculaIdAsync(int peliculaId);
        Task<IEnumerable<Horario>> GetBySalaIdAsync(int salaId);
    }
}
