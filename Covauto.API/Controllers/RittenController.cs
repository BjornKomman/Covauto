using Covauto.Domain.Entities;
using Covauto.Infrastructure.Data;
using Covauto.Shared.DTO.Rit;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[Route("api/[controller]")]
[ApiController]
public class RittenController : ControllerBase
{
    private readonly AutosContext _context;

    public RittenController(AutosContext context)
    {
        _context = context;
    }

    [HttpPost]
    public async Task<IActionResult> PostRit([FromBody] CreateRit dto)
    {
        var rit = new Rit
        {
            AutoId = dto.AutoId,
            GebruikerId = dto.GebruikerId,
            BeginAdres = dto.BeginAdres,
            EindAdres = dto.EindAdres,
            BeginKmStand = dto.BeginKmStand,
            EindKmStand = dto.EindKmStand,
            Datum = dto.Datum
        };

        _context.Ritten.Add(rit);
        await _context.SaveChangesAsync();
        return Ok(rit.Id);
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<RitDTO>>> GetRitten()
    {
        var ritten = await _context.Ritten
            .Select(r => new RitDTO
            {
                Id = r.Id,
                BeginAdres = r.BeginAdres,
                EindAdres = r.EindAdres,
                BeginKmStand = r.BeginKmStand,
                EindKmStand = r.EindKmStand,
                Datum = r.Datum
            })
            .ToListAsync();

        return Ok(ritten);
    }
}
