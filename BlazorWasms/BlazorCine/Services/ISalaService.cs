using Business.DTOs;

namespace BlazorCine.Services
{
    public interface ISalaService
    {
        Task<List<SalaDto>> GetSalasAsync();
    }
}
