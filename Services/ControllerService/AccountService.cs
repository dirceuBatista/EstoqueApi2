using System.Collections.Frozen;
using EstoqueApi.Data;
using EstoqueApi.Models;
using EstoqueApi.ViewModel;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SecureIdentity.Password;

namespace EstoqueApi.Services.ControllerService;

public class AccountService(DataContext context, TokenService.TokenService service)
{
    private readonly DataContext _context = context;


    public async Task<ResultViewModel<dynamic>> CreateAccount(
        RegisterViewModel model)
    {
        var user = new User
        {
            Name = model.Name,
            Email = model.Email.ToLower(),
            Slug = model.Email.Replace("@", "-")

        };
        var password = PasswordGenerator.Generate(25);
        user.PasswordHash = PasswordHasher.Hash(password);
        try
        {
            await _context.users.AddAsync(user);
            await _context.SaveChangesAsync();
            return new ResultViewModel<dynamic>(
                new { user = user.Email, password });
        }
        catch (Exception e)
        {
            return new ResultViewModel<dynamic>(e.InnerException?.Message);
        }
    }

    public async Task<ResultViewModel<User>> Login(
        LoginViewModel login)
    {
        var email = login.Email?.Trim().ToLower();
        var user = await _context
            .users
            .AsNoTracking()
            .Include(x => x.profiles)
            .FirstOrDefaultAsync(x => x.Email == email);

        if (user == null || !PasswordHasher.Verify(user.PasswordHash, login.Password))
            return new ResultViewModel<User>("Usuario invalido");
        try
        {
            var token = service.GenerateToken(user);
            return new ResultViewModel<User>(token);
        }
        catch (Exception )
        {
            return new ResultViewModel<User>(
                "Não foi possivel fazer o login");
            
        }
    }
}


  
    
