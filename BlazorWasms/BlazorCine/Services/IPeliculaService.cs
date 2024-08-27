using Business.DTOs;

namespace BlazorCine.Services
{
    public interface IPeliculaService
    {
        Task<List<PeliculaDto>> GetPeliculasAsync();
    }
}
