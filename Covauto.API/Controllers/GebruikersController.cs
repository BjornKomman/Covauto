using Covauto.Application.Interfaces;
using Covauto.Shared.DTO.Schrijvers;
using Microsoft.AspNetCore.Mvc;

namespace Covauto.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GebruikersController : ControllerBase
    {
        private readonly ISchrijverService schrijverService;

        public GebruikersController(ISchrijverService schrijverService)
        {
            this.schrijverService = schrijverService;
        }

        [HttpGet]
        public async Task<IActionResult> GeefSchrijvers()
        {
            return Ok(await schrijverService.GeefAlleSchrijversAsync());
        }
        [HttpGet("search/{naam}")]
        public async Task<IActionResult> ZoekSchrijvers(string naam)
        {
            return Ok(await schrijverService.ZoekSchrijversAsync(naam));
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GeefSchrijver(int id)
        {
            var retVal = await schrijverService.GeefSchrijverByIdAsync(id);
            return retVal != null ? Ok(retVal) : NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> MaakSchrijver(CreateSchrijver schrijver)
        {
            return Ok(await schrijverService.MaakSchrijverAsync(schrijver));
        }
    }
}