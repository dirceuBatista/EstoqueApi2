using EstoqueApi.Extensions;
using EstoqueApi.Services;
using EstoqueApi.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace EstoqueApi.Controllers;

[ApiController]
public class SaleController(SaleService saleService): ControllerBase
{
    
    private readonly SaleService _saleService = saleService;

    [HttpGet("v1/sales")]
    public async Task<IActionResult> GetAsync()
    {
        var result =await _saleService.GetAllSaleAsync();
        if (!result.Success)
            return Conflict(new { erros = result.Errors });
        return Ok(result);
    }

    [HttpGet("v1/sales/{id:int}")]
    public async Task<IActionResult> GetByIdAsync([FromRoute] int id)
    {
        var result =await _saleService.GetSaleByIdAsync(id);
        if (!result.Success)
            return Conflict(new { erros = result.Errors });
        return Ok(result);
    }
    
    [HttpPost("v1/sales")]
    public async Task<IActionResult> PostAsync(
        [FromBody] EditorSaleViewModel model)
    {
        if (!ModelState.IsValid)
            return BadRequest(
                new ResultViewModel<string>(ModelState.GetErrors()));
        var result =await _saleService.CreateSaleAsync(model);
        if (!result.Success)
            return Conflict(new { erros = result.Errors });
        return Ok(result.Data);
    }
    
    [HttpPut("v1/sales/{id:int}")]
    public async Task<IActionResult> PutAsync(
        [FromBody] EditorSaleViewModel model, [FromRoute] int id)
    {
        var result = await _saleService.UpdateSaleAsync(model, id);
        if (!result.Success)
            return Conflict(new { erros = result.Errors });
        return Ok(result.Data);
    }

    [HttpDelete("v1/sales/{id:int}")]
    public async Task<IActionResult> DeleteAsync([FromRoute] int id)
    {
        var result = await _saleService.DeleteSaleAsync(id);
        if (!result.Success)
            return Conflict(new { erros = result.Errors });
        return Ok($"{result.Data.Id} - venda deletado");
    }
}