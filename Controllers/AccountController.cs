using EstoqueApi.Extensions;
using EstoqueApi.Services.ControllerService;
using EstoqueApi.Services.TokenService;
using EstoqueApi.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace EstoqueApi.Controllers;

public class AccountController(AccountService accountService): ControllerBase
{
    [HttpPost("v1/account")]
    public async Task<IActionResult> Account(
        [FromBody]RegisterViewModel model)
    {
        if (!ModelState.IsValid)
            return BadRequest(
                new ResultViewModel<string>(ModelState.GetErrors()));

        var create =
            await accountService.CreateAccount(model);
        
        if (!create.Success)
            return Conflict(new { erros = create.Errors });
        return Ok(create.Data);
    }
    [HttpPost("v1/accounts/login")]
    public async Task<IActionResult> Login(
        [FromServices]TokenService tokenService)
    {
        var token = tokenService.GenerateToken(null);
        return Ok(token);

    }
   
}