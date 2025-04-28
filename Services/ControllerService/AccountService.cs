using EstoqueApi.Data;
using EstoqueApi.Models;
using EstoqueApi.ViewModel;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace EstoqueApi.Services.ControllerService;

public class AccountService(DataContext context)
{
    private readonly DataContext _context = context;
    
    public  async Task<ResultViewModel<User>> CreateAccount(
        RegisterViewModel model)
    {
        var user = new User
        {
            Name = model.Name,
            Email = model.Email.ToLower()
            //Slug = model.Email.Replace("@","-")
           
        };
        try
        {
            await _context.users.AddAsync(user);
            await _context.SaveChangesAsync();
            return new ResultViewModel<User>(user);
        }
        catch
        {
            return new ResultViewModel<User>("0AX01 - Erro ao criar usuario");
        }
    }
}