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

        public async Task<ServiceResponse> AddAsync(HorarioDto horarioDto)
        {
            var horario = new Horario
            {
                IdSala = horarioDto.IdSala,
                IdPelicula = horarioDto.IdPelicula,
                FechaYHora = horarioDto.FechaYHora,
            };

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

        public async Task<List<HorarioDto>> GetAsync()
        {
            return await _context.Horarios
                .Include(h => h.Sala)
                .Include(h => h.Pelicula)
                .Select(h => new HorarioDto
                {
                    IdHorario = h.IdHorario,
                    IdSala = h.IdSala,
                    IdPelicula = h.IdPelicula,
                    FechaYHora = h.FechaYHora,
                    NombreSala = h.Sala.NombreSala,
                    NombrePelicula = h.Pelicula.NombrePelicula
                })
                .ToListAsync();
        }

        public async Task<HorarioDto> GetByIdAsync(int id)
        {
            return await _context.Horarios
                 .Include(h => h.Sala)
                 .Include(h => h.Pelicula)
                 .Select(h => new HorarioDto
                 {
                     IdHorario = h.IdHorario,
                     IdSala = h.IdSala,
                     IdPelicula = h.IdPelicula,
                     FechaYHora = h.FechaYHora,
                     NombreSala = h.Sala.NombreSala,
                     NombrePelicula = h.Pelicula.NombrePelicula
                 })
                 .FirstOrDefaultAsync(h => h.IdHorario == id);
        }

        public async Task<ServiceResponse> UpdateAsync(updateDto horarioDto)
        {
            try
            {
                var horario = await _context.Horarios.FindAsync(horarioDto.IdHorario);
                if (horario == null)
                {
                    return new ServiceResponse(false, "Horario no encontrado.");
                }

                // Actualizar los campos necesarios
                horario.IdSala = horarioDto.IdSala;
                horario.IdPelicula = horarioDto.IdPelicula;
                horario.FechaYHora = horarioDto.FechaYHora;

                _context.Horarios.Update(horario);

                // Guardar los cambios con un mayor tiempo de espera
                await _context.SaveChangesAsync();

                return new ServiceResponse(true, "Horario actualizado exitosamente.");
            }
            catch (Exception ex)
            {
                // Manejo de errores
                return new ServiceResponse(false, $"Error al actualizar el horario: {ex.Message}");
            }
        }

        public async Task<List<HorarioDto>> GetFilteredAsync(int? peliculaId = null, int? salaId = null, DateTime? startDate = null, DateTime? endDate = null)
        {
            var query = _context.Horarios.AsQueryable();

            if (peliculaId.HasValue)
            {
                query = query.Where(h => h.IdPelicula == peliculaId.Value);
            }

            if (salaId.HasValue)
            {
                query = query.Where(h => h.IdSala == salaId.Value);
            }

            if (startDate.HasValue)
            {
                query = query.Where(h => h.FechaYHora >= startDate.Value);
            }

            if (endDate.HasValue)
            {
                query = query.Where(h => h.FechaYHora <= endDate.Value);
            }

            return await query
                .Include(h => h.Sala)
                .Include(h => h.Pelicula)
                .Select(h => new HorarioDto
                {
                    IdHorario = h.IdHorario,
                    IdSala = h.IdSala,
                    IdPelicula = h.IdPelicula,
                    FechaYHora = h.FechaYHora,
                    NombreSala = h.Sala.NombreSala,
                    NombrePelicula = h.Pelicula.NombrePelicula
                })
                .ToListAsync();
        }

      
    }
}
