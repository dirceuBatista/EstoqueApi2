using EstoqueApi.Data;
using EstoqueApi.Extensions;
using EstoqueApi.Models;
using EstoqueApi.ViewModel;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;

namespace EstoqueApi.Services.UserServices;


public class UserService(DataContext context)
{
    private readonly DataContext _context = context;

    public async Task<ResultViewModel<List<User>>> GetAllUserAsync()
    {
        try
        {
            var users = await _context.users.ToListAsync();
            return new ResultViewModel<List<User>>(users);
        }
        catch
        {
            return new  ResultViewModel<List<User>>(
                "Erro ao buscar usuarios");
        }
    }
    public async Task<ResultViewModel<User>> GetByIdUserAsync(int id)
    {
        try
        {
            var user =
                await _context
                    .users
                    .FirstOrDefaultAsync(x => x.Id == id);
            if (user == null)
                return new ResultViewModel<User>(
                    "Usuario não encontrado");

            return new ResultViewModel<User>(user);
        }
        catch
        {
            return new  ResultViewModel<User>(
                "Erro ao buscar usuarios");
        }
    }
    public async Task<ResultViewModel<User>> CreateUserAsync(
        EditorUserViewModel model)
    {
        var existingUser = await _context.users
            .FirstOrDefaultAsync(x => x.Email.ToLower() == model.Email.ToLower());
        
        if (existingUser != null)
           return new ResultViewModel<User>("E-mail já cadastrado");
        
        var user = new User
        {
            Name = model.Name,
            Email = model.Email.ToLower(),
            Slug = model.Slug
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
    public async Task<ResultViewModel<User>> UpdateUserAsync(
        EditorUserViewModel model, int id)
    {
        try
        {
            var user =
                await context
                    .users
                    .FirstOrDefaultAsync(x => x.Id == id);
            if (user == null)
                return 
                    new ResultViewModel<User>("Usuario não encontrado");

            user.Name = model.Name;
            user.Email = model.Email;
            user.Slug = model.Slug;
            
            context.users.Update(user);
            await context.SaveChangesAsync();
            return new ResultViewModel<User>(user);
        }
        catch
        {
            return new  ResultViewModel<User>(
                "Erro ao atualizar usuario");
        }
    }



    public async Task<ResultViewModel<User>> DeleteAsync(int id) 
    {
        try
        {
            var user = await context
                .users
                .FirstOrDefaultAsync(x => x.Id == id);
            if (user == null)
                return new ResultViewModel<User>(
                    "Usuario não encontrado");

            context.users.Remove(user);
            await context.SaveChangesAsync();
            return new ResultViewModel<User>(user);
        }
        catch
        {
            return new  ResultViewModel<User>(
                "Erro ao deletar usuario");
        }

    }
    
}


  

