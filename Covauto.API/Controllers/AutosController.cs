using Covauto.Application.Interfaces;
using Covauto.Shared.DTO.Boeken;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Covauto.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AutosController : ControllerBase
{
    private readonly IBoekenService boekenService;

    public AutosController(IBoekenService boekenService)
    {
        this.boekenService = boekenService;
    }

    [HttpGet]
    public async Task<IActionResult> GeefBoeken()
    {
        return Ok(await boekenService.GeefAlleBoekenAsync());
    }

    [HttpGet("search/{titel}")]
    public async Task<IActionResult> ZoekBoeken(string titel)
    {
        return Ok(await boekenService.ZoekBoekenAsync(titel));
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GeefBoek(int id)
    {
        FullBoek? retVal = await boekenService.GeefBoekAsync(id);
        return retVal != null ? Ok(retVal) : NotFound();
    }

    [HttpPost]
    public async Task<IActionResult> MaakBoek(CreateBoek boek)
    {
        try
        {
            var id = await boekenService.CreateBoekAsync(boek);

            return Ok(id);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }

    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateBoek(int id, UpdateBoek boek)
    {
        try
        {
            await boekenService.UpdateBoekAsync(id, boek);
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

    [HttpDelete("id")]
    public async Task<IActionResult> DeleteBoek(int id)
    {
        try
        {
            await boekenService.DeleteBoekAsync(id);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}