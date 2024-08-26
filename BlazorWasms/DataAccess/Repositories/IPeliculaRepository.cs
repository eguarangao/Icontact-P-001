using Business.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public interface IPeliculaRepository
    {
        Task<List<PeliculaDto>> GetPeliculasAsync();
    }
}
