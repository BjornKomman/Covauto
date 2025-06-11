using Covauto.Application.Repositories;
using Covauto.Shared.DTO.Rit;
using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class RittenController : ControllerBase
{
    private readonly IRittenRepository _rittenRepo;

    public RittenController(IRittenRepository rittenRepo)
    {
        _rittenRepo = rittenRepo;
    }

    [HttpPost]
    public async Task<IActionResult> PostRit([FromBody] CreateRit dto)
    {
        var id = await _rittenRepo.MaakRitAsync(dto);
        return Ok(id);
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<RitDTO>>> GetRitten()
    {
        var ritten = await _rittenRepo.GeefAlleRittenAsync();
        return Ok(ritten);
    }
}
