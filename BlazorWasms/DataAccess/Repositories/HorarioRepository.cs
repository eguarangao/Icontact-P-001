using Business.Entities;
using DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class HorarioRepository : Repository<Horario>, IHorarioRepository
    {
        public HorarioRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Horario>> GetByPeliculaIdAsync(int peliculaId)
        {
            return await _context.Horarios
                .Include(h => h.Pelicula)
                .Include(h => h.Sala)
                .Where(h => h.IdPelicula == peliculaId)
                .ToListAsync();
        }

        public async Task<IEnumerable<Horario>> GetBySalaIdAsync(int salaId)
        {
            return await _context.Horarios
               .Include(h => h.Pelicula)
               .Include(h => h.Sala)
               .Where(h => h.IdSala == salaId)
               .ToListAsync();
        }
    }
}
