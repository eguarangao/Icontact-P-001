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
                // Mapear otros campos si es necesario
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

        public async Task<ServiceResponse> UpdateAsync(HorarioDto horarioDto)
        {
            var horario = await _context.Horarios.FindAsync(horarioDto.IdHorario);
            if (horario == null)
            {
                return new ServiceResponse(false, "Horario no encontrado.");
            }

            horario.IdSala = horarioDto.IdSala;
            horario.IdPelicula = horarioDto.IdPelicula;
            horario.FechaYHora = horarioDto.FechaYHora;
            // Mapear otros campos si es necesario

            _context.Horarios.Update(horario);
            await _context.SaveChangesAsync();
            return new ServiceResponse(true, "Horario actualizado exitosamente.");
        }
    }
}
