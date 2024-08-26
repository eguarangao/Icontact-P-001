using DataAccess.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalaController : ControllerBase
    {
        private readonly ISalaRepository _salaService;

        public SalaController(ISalaRepository salaService)
        {
            _salaService = salaService;
        }

        [HttpGet]
        public async Task<IActionResult> GetSalas()
        {
            var data = await _salaService.GetSalasAsync();
            return Ok(data);
        }
    }
}
