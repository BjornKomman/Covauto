
using Covauto.Applicatie.DTO.Gebruiker;
using Covauto.Applicatie.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Covauto.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GebruikersController : ControllerBase
    {
        private readonly IGebruikerService _svc;
        public GebruikersController(IGebruikerService svc) => _svc = svc;

        [HttpPost]
        public async Task<IActionResult> Post(CreateGebruiker dto)
        {
            var id = await _svc.MaakGebruikerAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id }, dto);
        }

        [HttpGet]
        public Task<IEnumerable<GebruikerListItem>> GetAll()
            => _svc.GeefAlleGebruikersAsync();

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var g = await _svc.GeefGebruikerByIdAsync(id);
            return g is null ? NotFound() : Ok(g);
        }
    }

}