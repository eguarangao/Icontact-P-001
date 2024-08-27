﻿using Business.DTOs;


namespace DataAccess.Repositories
{
    public interface ISalaRepository
    {
        Task<List<SalaDto>> GetSalasAsync();
    }
}
