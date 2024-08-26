using Business.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public class HorarioService : IHorarioService
    {
        private readonly IHorarioRepository _horarioRepository;
        public HorarioService(IHorarioRepository horarioRepository)
        {
            _horarioRepository = horarioRepository;
        }

        public Task<ServiceResponse> CrearHorario(HorarioCreateDto horarioDto)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse> EditarHorario(int id, HorarioUpdateDto horarioDto)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse> EliminarHorario(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<HorarioDto> IHorarioService.ObtenerHorarioPorId(int id)
        {
            var horario = await _horarioRepository.GetByIdAsync(id);
            if (horario == null) return null;

            return new HorarioDto
            {
                IdHorario = horario.IdHorario,
                NombreSala = horario.Sala.NombreSala,
                NombrePelicula = horario.Pelicula.NombrePelicula,
                FechaYHora = horario.FechaYHora
            };
        }

        public async Task<List<HorarioDto>> IHorarioService.ObtenerHorarios()
        {
            var horarios = await _horarioRepository.GetAllAsync();

            return horarios.Select(h => new HorarioDto
            {
                IdHorario = h.IdHorario,
                NombreSala = h.Sala.NombreSala,
                NombrePelicula = h.Pelicula.NombrePelicula,
                FechaYHora = h.FechaYHora
            }).ToList();
        }
    }
}
