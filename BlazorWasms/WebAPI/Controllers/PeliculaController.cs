using DataAccess.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeliculaController : ControllerBase
    {
        private readonly IPeliculaRepository _peliculaService;

        public PeliculaController(IPeliculaRepository peliculaService)
        {
            _peliculaService = peliculaService;
        }

        [HttpGet]
        public async Task<IActionResult> GetPeliculas()
        {
            var data = await _peliculaService.GetPeliculasAsync();
            return Ok(data);
        }
    }
}
