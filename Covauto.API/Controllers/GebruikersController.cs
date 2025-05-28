
using Covauto.Applicatie.DTO.Gebruiker;
using Covauto.Applicatie.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Covauto.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GebruikersController : ControllerBase
    {
        private readonly IGebruikerService gebruikerService;

        public GebruikersController(IGebruikerService gebruikerService)
        {
            this.gebruikerService = gebruikerService;
        }

        [HttpGet]
        public async Task<IActionResult> GeefGebruikers()
        {
            return Ok(await gebruikerService.GeefAlleGebruikersAsync());
        }
        [HttpGet("search/{naam}")]
        public async Task<IActionResult> ZoekGebruikers(string naam)
        {
            return Ok(await gebruikerService.ZoekGebruikersAsync(naam));
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GeefGebruiker(int id)
        {
            var retVal = await gebruikerService.GeefGebruikerByIdAsync(id);
            return retVal != null ? Ok(retVal) : NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> MaakGebruiker(CreateGebruiker schrijver)
        {
            return Ok(await gebruikerService.MaakGebruikerAsync(schrijver));
        }
    }
}