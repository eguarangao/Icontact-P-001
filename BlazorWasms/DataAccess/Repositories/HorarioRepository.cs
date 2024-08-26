using Business.DTOs;
using Business.Entities;
using DataAccess.Data;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories
{
    public class HorarioRepository : IHorarioRepository
    {
        private readonly AppDbContext _context;
        public HorarioRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse> AddAsync(Horario horario)
        {
            await _context.Horarios.AddAsync(horario);
            await _context.SaveChangesAsync();
            return new ServiceResponse(true, "Horario creado exitosamente.");
        }

        public async Task<ServiceResponse> DeleteAsync(int id)
        {
            var horario = await _context.Horarios.FindAsync(id);
            if (horario == null)
            {
                return new ServiceResponse(false, "Horario no encontrado.");
            }

            _context.Horarios.Remove(horario);
            await _context.SaveChangesAsync();
            return new ServiceResponse(true, "Horario eliminado exitosamente.");
        }

        public async Task<List<Horario>> GetAsync()
        {
            return await _context.Horarios
                 .Include(h => h.Sala)
                 .Include(h => h.Pelicula)
                 .ToListAsync();
        }

        public async Task<Horario> GetByIdAsync(int id)
        {
            return await _context.Horarios
                 .Include(h => h.Sala)
                 .Include(h => h.Pelicula)
                 .FirstOrDefaultAsync(h => h.IdHorario == id);
        }

        public async Task<ServiceResponse> UpdateAsync(Horario horario)
        {
            _context.Horarios.Update(horario);
            await _context.SaveChangesAsync();
            return new ServiceResponse(true, "Horario actualizado exitosamente.");
        }
    }
}
