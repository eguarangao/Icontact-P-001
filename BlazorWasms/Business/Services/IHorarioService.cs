using Business.DTOs;
using Business.Entities;

namespace Business.Services
{
    public interface IHorarioService
    {
   
        Task<ServiceResponse> CrearHorario(HorarioCreateDto horarioDto);
        Task<ServiceResponse> EditarHorario(int id, HorarioUpdateDto horarioDto);
        Task<ServiceResponse> EliminarHorario(int id);
    }
}
