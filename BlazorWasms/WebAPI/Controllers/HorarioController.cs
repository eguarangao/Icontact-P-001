using Business.DTOs;
using Business.Entities;
using DataAccess.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HorarioController : ControllerBase
    {
        private readonly IHorarioRepository horario;
        public HorarioController(IHorarioRepository horario)
        {
            this.horario = horario;
        }
       
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var data = await horario.GetAsync();
            return Ok(data);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var data = await horario.GetByIdAsync(id);
            if (data == null)
            {
                return NotFound("Horario no encontrado");
            }
            return Ok(data);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] HorarioDto horarioDto)
        {
            if (horarioDto == null)
            {
                return BadRequest("El horario no puede ser nulo.");
            }

            // Validar la fecha y otros datos
            if (horarioDto.FechaYHora < DateTime.UtcNow)
            {
                return BadRequest("La fecha y hora no pueden ser en el pasado.");
            }

            var result = await horario.AddAsync(horarioDto);
           
            if (!result.Flag)
            {
                return StatusCode(500, result.Message);
            }

            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] updateDto horarioDto)
        {
            if (id != horarioDto.IdHorario)
            {
                return BadRequest("El ID del horario no coincide con el ID del cuerpo de la solicitud.");
            }

            if (horarioDto == null)
            {
                return BadRequest("El horario no puede ser nulo.");
            }

            // Valida la fecha y hora
            if (horarioDto.FechaYHora < DateTime.UtcNow)
            {
                return BadRequest("La fecha y hora no pueden ser en el pasado.");
            }

            var result = await horario.UpdateAsync(horarioDto);

            if (!result.Flag)
            {
                return StatusCode(500, result.Message);
            }

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await horario.DeleteAsync(id);
            if (!result.Flag)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
        }
    }
}
