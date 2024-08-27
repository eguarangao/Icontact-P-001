using Business.DTOs;
using DataAccess.Data;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories
{
    public class PeliculaRepository : IPeliculaRepository
    {
        private readonly AppDbContext _context;

        public PeliculaRepository(AppDbContext context)
        {
            _context = context;
        }
      
        public async Task<List<PeliculaDto>> GetPeliculasAsync()
        {
            return await _context.Peliculas
                .Select(p => new PeliculaDto
                {
                    IdPelicula = p.IdPelicula,
                    NombrePelicula = p.NombrePelicula,
                    Clasificacion = p.Clasificacion,
                    DuracionMin = p.DuracionMin
                })
                .ToListAsync();
        }
    }
}
