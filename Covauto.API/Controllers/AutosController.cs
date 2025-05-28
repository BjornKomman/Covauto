using Covauto.Applicatie.DTO.Auto;
using Covauto.Applicatie.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Covauto.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AutosController : ControllerBase
{
    private readonly IAutoService autoService;

    public AutosController(IAutoService autoService)
    {
        this.autoService = autoService;
    }

    [HttpGet]
    public async Task<IActionResult> GeefAutos()
    {
        return Ok(await autoService.GeefAlleAutosAsync());
    }

    [HttpGet("search/{naam}")]
    public async Task<IActionResult> ZoekAutos(string naam)
    {
        return Ok(await autoService.ZoekAutosAsync(naam));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GeefAuto(int id)
    {
        FullAuto? retVal = await autoService.GeefAutoAsync(id);
        return retVal != null ? Ok(retVal) : NotFound();
    }

    [HttpPost]
    public async Task<IActionResult> MaakAuto(CreateAuto auto)
    {
        try
        {
            var id = await autoService.CreateAutoAsync(auto);

            return Ok(id);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAuto(int id, UpdateAuto auto)
    {
        try
        {
            await autoService.UpdateAutoAsync(id, auto);
            return Ok();
        }
        catch (ValidationException ex)
        {
            return BadRequest(ex.Message);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAuto(int id)
    {
        try
        {
            await autoService.DeleteAutoAsync(id);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
