﻿using Business.DTOs;

namespace DataAccess.Repositories
{
    public interface IPeliculaRepository
    {
        Task<List<PeliculaDto>> GetPeliculasAsync();
    }
}
