using System.Runtime.InteropServices.JavaScript;
using EstoqueApi.Data;
using EstoqueApi.Extensions;
using EstoqueApi.Models;
using EstoqueApi.Services.UserServices;
using EstoqueApi.ViewModel;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EstoqueApi.Controllers;


[ApiController]
public class UserController(UserService userService) : ControllerBase
{
    [HttpGet("v1/users")]
    public async Task<IActionResult> GetAsync()
    { 
        var result= await userService.GetAllUserAsync();
        if (!result.Success)
            return Conflict(new { erros = result.Errors });
        return Ok(result);
    }

    [HttpGet("v1/users/{id:int}")]
    public async Task<IActionResult> GetByIdAsync([FromRoute] int id)
    {
       var result = await userService.GetByIdUserAsync(id);
       if (!result.Success)
           return Conflict(new { erros = result.Errors });
       return Ok(result.Data);
    }
    
    [HttpPost("v1/users")]
    public async Task<IActionResult> PostAsync(
        [FromBody] EditorUserViewModel model)
    {
        if (!ModelState.IsValid)
            return BadRequest(
                new ResultViewModel<string>(ModelState.GetErrors()));
        
        var create =
            await userService.CreateUserAsync(model);
        
        if (!create.Success)
            return Conflict(new { erros = create.Errors });
        return Ok(create.Data);
    }
    
    [HttpPut("v1/users/{id:int}")]
    public async Task<IActionResult> PutAsync(
        [FromBody] EditorUserViewModel model, [FromRoute] int id)
    {
        var result = 
            await userService.UpdateUserAsync(model,id);
        if (!result.Success)
            return Conflict(new { erros = result.Errors });
        return Ok(result);
    }

    [HttpDelete("v1/users/{id:int}")]
    public async Task<IActionResult> DeleteAsync([FromRoute] int id)
    {
       var result = await userService.DeleteAsync(id);
       if (!result.Success)
           return Conflict(new { erros = result.Errors });
       return Ok($"{result.Data.Name} - usuario deletado");
    }




}