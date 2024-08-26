using Business.DTOs;
using DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class SalaRepository : ISalaRepository
    {
        private readonly AppDbContext _context;

        public SalaRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<List<SalaDto>> GetSalasAsync()
        {
            return await _context.Salas
                 .Select(s => new SalaDto
                 {
                     IdSala = s.IdSala,
                     CodigoSala = s.CodigoSala,
                     NombreSala = s.NombreSala
                 })
                 .ToListAsync();
        }
    }
}
