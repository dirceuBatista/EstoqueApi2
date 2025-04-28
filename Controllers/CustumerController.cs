using EstoqueApi.Extensions;
using EstoqueApi.Services;
using EstoqueApi.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace EstoqueApi.Controllers;

[ApiController]
public class CustumerController(CustumerService custumerService): ControllerBase
{
    [HttpGet("v1/custumers")]
    public async Task<IActionResult> GetAsync()
    {
        var result =await custumerService.GetAllCustumerAsync();
        if (!result.Success)
            return Conflict(new { erros = result.Errors });
        return Ok(result);
    }

    [HttpGet("v1/custumers/{id:int}")]
    public async Task<IActionResult> GetByIdAsync([FromRoute] int id)
    {
        var result =await custumerService.GetByIdCustumerAsync(id);
        if (!result.Success)
            return Conflict(new { erros = result.Errors });
        return Ok(result);
    }
    
    [HttpPost("v1/custumers")]
    public async Task<IActionResult> PostAsync(
        [FromBody] EditorCustumerViewModel model)
    {
        if (!ModelState.IsValid)
            return BadRequest(
                new ResultViewModel<string>(ModelState.GetErrors()));
        var result =await custumerService.CreateCustumerAsync(model);
        if (!result.Success)
            return Conflict(new { erros = result.Errors });
        return Ok(result.Data);
    }
    
    [HttpPut("v1/custumers/{id:int}")]
    public async Task<IActionResult> PutAsync(
        [FromBody] EditorCustumerViewModel model, [FromRoute] int id)
    {
        var result = await custumerService.UpdateCustumerAsync(model, id);
        if (!result.Success)
            return Conflict(new { erros = result.Errors });
        return Ok(result.Data);
    }

    [HttpDelete("v1/custumers/{id:int}")]
    public async Task<IActionResult> DeleteAsync([FromRoute] int id)
    {
        var result = await custumerService.DeleteCustumerAsync(id);
        if (!result.Success)
            return Conflict(new { erros = result.Errors });
        return Ok($"{result.Data.Name} - cliente deletado");
    }
}