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
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await horario.AddAsync(horarioDto);
            if (!result.Flag)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] HorarioDto horarioDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != horarioDto.IdHorario)
            {
                return BadRequest("ID del horario no coincide.");
            }

            var result = await horario.UpdateAsync(horarioDto);
            if (!result.Flag)
            {
                return BadRequest(result.Message);
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
