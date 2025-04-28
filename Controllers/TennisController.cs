using System.Runtime.InteropServices.JavaScript;
using EstoqueApi.Data;
using EstoqueApi.Extensions;
using EstoqueApi.Models;
using EstoqueApi.Services;
using EstoqueApi.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EstoqueApi.Controllers;
[ApiController]
public class TennisController(TennisService tennisService):ControllerBase
{private readonly TennisService _tennisService = tennisService;

    [HttpGet("v1/tennis")]
    public async Task<IActionResult> GetAsync()
    {
        var result = await _tennisService.GetAllTennisAsync();
        if (!result.Success)
            return Conflict(new { erros = result.Errors });
        return Ok(result);
        
    }

    [HttpGet("v1/tennis/{id:int}")]
    public async Task<IActionResult> GetByIdAsync([FromRoute] int id)
    {
        var result = await _tennisService.GetByIdTennisAsync(id);
        if (!result.Success)
            return Conflict(new { erros = result.Errors });
        return Ok(result);
    }


    [HttpPost("v1/tennis")]
    public async Task<IActionResult> PostAsync(
        [FromBody] EditorTennisViewModel model)
    {
        if (!ModelState.IsValid)
            return BadRequest(
                new ResultViewModel<string>(ModelState.GetErrors()));
        var result = await _tennisService.CreateTennisAsync(model);
        if (!result.Success)
            return Conflict(new { erros = result.Errors });
        return Ok(result.Data);
    }

    [HttpPut("v1/tennis/{id:int}")]
    public async Task<IActionResult> PutAsync(
        [FromBody] EditorTennisViewModel model, [FromRoute] int id)
    {
        var result = await _tennisService.UpdateTennisAsync(model, id);
        if (!result.Success)
            return Conflict(new { erros = result.Errors });
        return Ok(result.Data);
    }

    [HttpDelete("v1/tennis/{id:int}")]
    public async Task<IActionResult> DeleteAsync([FromRoute] int id)
    {
        var result = await _tennisService.DeleteTennisAsync(id);
        if (!result.Success)
            return Conflict(new { erros = result.Errors });
        return Ok(result);
    }
}