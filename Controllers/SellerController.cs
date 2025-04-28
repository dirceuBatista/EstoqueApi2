
using EstoqueApi.Extensions;
using EstoqueApi.Services;
using EstoqueApi.ViewModel;
using Microsoft.AspNetCore.Mvc;


namespace EstoqueApi.Controllers;
[ApiController]
public class SellerController(SellerService sellerService): ControllerBase
{
    
    private readonly SellerService _sellerService = sellerService;

    [HttpGet("v1/sellers")]
    public async Task<IActionResult> GetAsync()
    {
        var result =await _sellerService.GetAllSellerAsync();
        if (!result.Success)
            return Conflict(new { erros = result.Errors });
        return Ok(result);
    }

    [HttpGet("v1/sellers/{id:int}")]
    public async Task<IActionResult> GetByIdAsync([FromRoute] int id)
    {
        var result =await _sellerService.GetByIdSellerAsync(id);
        if (!result.Success)
            return Conflict(new { erros = result.Errors });
        return Ok(result);
    }
    
    [HttpPost("v1/sellers")]
    public async Task<IActionResult> PostAsync(
        [FromBody] EditorSellerViewModel model)
    {
        if (!ModelState.IsValid)
            return BadRequest(
                new ResultViewModel<string>(ModelState.GetErrors()));
        var result =await sellerService.CreateSellerAsync(model);
        if (!result.Success)
            return Conflict(new { erros = result.Errors });
        return Ok(result.Data);
    }
    
    [HttpPut("v1/sellers/{id:int}")]
    public async Task<IActionResult> PutAsync(
        [FromBody] EditorSellerViewModel model, [FromRoute] int id)
    {
        var result = await _sellerService.UpdateSellerAsync(model, id);
        if (!result.Success)
            return Conflict(new { erros = result.Errors });
        return Ok(result.Data);
    }

    [HttpDelete("v1/sellers/{id:int}")]
    public async Task<IActionResult> DeleteAsync([FromRoute] int id)
    {
        var result = await _sellerService.DeleteSellerAsync(id);
        if (!result.Success)
            return Conflict(new { erros = result.Errors });
        return Ok($"{result.Data.Name} - vendedor deletado");
    }
}