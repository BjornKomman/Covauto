using Covauto.Application.Interfaces;
using Covauto.Shared.DTO.Rit;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class RittenController : ControllerBase
{
    private readonly IRittenRepository _repo;

    public RittenController(IRittenRepository repo)
        => _repo = repo;

    [HttpGet]
    public async Task<IActionResult> GetRitten()
    {
        var ritten = await _repo.GeefAlleRittenAsync();
        return Ok(ritten);
    }

    [HttpPost]
    public async Task<IActionResult> PostRit([FromBody] CreateRit dto)
    {
        // Maakt de rit via de repository en retourneert 201 met locatie-header
        var id = await _repo.MaakRitAsync(dto);
        return CreatedAtAction(nameof(GetRitten), new { id }, id);
    }
}
