using EstoqueApi.Data;
using EstoqueApi.Models;
using EstoqueApi.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EstoqueApi.Services;

public class TennisService(DataContext context)
{
    private readonly DataContext _context = context;

    public async Task<ResultViewModel<List<Tennis>>> GetAllTennisAsync()
    {
        try
        {
            var tennis = await _context.tennis.ToListAsync();
            return
                new ResultViewModel<List<Tennis>>(tennis);
        }
        catch
        {
            return new  ResultViewModel<List<Tennis>>(
                "Erro ao buscar Tenis");
        }
    }

    public async Task<ResultViewModel<Tennis>> GetByIdTennisAsync(int id)
    {
        try
        {
            var tennis =
                await _context
                    .tennis
                    .FirstOrDefaultAsync(x => x.Id == id);
            if (tennis == null)
                return
                    new ResultViewModel<Tennis>("Tenis não encontrado");
            return
                new ResultViewModel<Tennis>(tennis);
        }
        catch
        {
            return new  ResultViewModel<Tennis>(
                "Erro ao buscar Tenis");
        }
    }
    public async Task<ResultViewModel<Tennis>> CreateTennisAsync(
        EditorTennisViewModel model)
    {
        try
        {
            var tennis = new Tennis
            {
                Name = model.Name,
                Version = model.Version,
                Price = model.Price
            };

            await _context.tennis.AddAsync(tennis);
            await _context.SaveChangesAsync();
            return  new ResultViewModel<Tennis>(tennis);
        }
        catch
        {
            return new  ResultViewModel<Tennis>(
                "Erro ao criar Tenis");
        }
    }

    public async Task<ResultViewModel<Tennis>> UpdateTennisAsync(
        EditorTennisViewModel model, int id)
    {
        try
        {
            var tennis =
                await context
                    .tennis
                    .FirstOrDefaultAsync(x => x.Id == id);
            if (tennis == null)
                return new ResultViewModel<Tennis>("Tenis não encontrado");

            tennis.Name = model.Name;
            tennis.Version = model.Version;
            tennis.Price = model.Price;

            context.tennis.Update(tennis);
            await context.SaveChangesAsync();
            return new ResultViewModel<Tennis>(tennis);
        }
        catch
        {
            return new  ResultViewModel<Tennis>(
                "Erro ao atualizar Tenis");
        }
    }
    public async Task<ResultViewModel<Tennis>> DeleteTennisAsync(int id) 
    {
        try
        {
            var tennis = await context
                .tennis
                .FirstOrDefaultAsync(x => x.Id == id);
            if (tennis == null)
                return new ResultViewModel<Tennis>(
                    "Usuario não encontrado");

            context.tennis.Remove(tennis);
            await context.SaveChangesAsync();
            return new ResultViewModel<Tennis>(tennis);
        }
        catch
        {
            return new  ResultViewModel<Tennis>(
                "Erro ao deletar Tenis");
        }

    }
}