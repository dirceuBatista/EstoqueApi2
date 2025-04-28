using System.Data.Common;
using EstoqueApi.Data;
using EstoqueApi.Models;
using EstoqueApi.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EstoqueApi.Services;

public class SellerService(DataContext context) 
{
    private readonly DataContext _context = context;
    public async Task<ResultViewModel<List<Seller>>> GetAllSellerAsync()
    {
        try
        {
            var sellers = await _context.Sellers.ToListAsync();
            return 
                new ResultViewModel<List<Seller>>(sellers);
        }
        catch
        {
            return new ResultViewModel<List<Seller>>(
                "0AX01 - Erro ao buscar vendedores");
        }
    }
    public async Task<ResultViewModel<Seller>> GetByIdSellerAsync(int id)
    {
        try
        {
            var seller =
                await _context
                    .Sellers
                    .FirstOrDefaultAsync(x => x.Id == id);
            if (seller == null)
                return 
                    new ResultViewModel<Seller>("Vendedor não encontrado");

            return 
                new ResultViewModel<Seller>(seller);
        }
        catch
        {
            return new ResultViewModel<Seller>(
                "0AX01 - Erro ao buscar vendedore");
        }
    }
    public async Task<ResultViewModel<Seller>> CreateSellerAsync(
        EditorSellerViewModel model)
    {
        try
        {
            var seller = new Seller()
            {
               
                Name = model.Name,
                Email = model.Email.ToLower(),
                Slug = model.Slug
            };
            await _context.Sellers.AddAsync(seller);
            await _context.SaveChangesAsync();
            return new ResultViewModel<Seller>(seller);
        }
        catch 
        {
            return new ResultViewModel<Seller>(
                "0AX01 - Erro ao criar vendedor");
        }

    }

    public async Task<ResultViewModel<Seller>> UpdateSellerAsync(
        EditorSellerViewModel model, int id)
    {
        try
        {
            var seller =
                await context
                    .Sellers
                    .FirstOrDefaultAsync(x => x.Id == id);
            if (seller == null)
                return new ResultViewModel<Seller>("vendedor não encontrado");

            seller.Name = model.Name;
            seller.Email = model.Email;
            seller.Slug = model.Slug;

            context.Sellers.Update(seller);
            await context.SaveChangesAsync();

            return new ResultViewModel<Seller>(seller);
        }
        catch
        {
            return new ResultViewModel<Seller>(
                "0AX01 - Erro ao atualizar vendedor");
        }
    }

    public async Task<ResultViewModel<Seller>> DeleteSellerAsync(int id)
    {
        try
        {
            var seller = await context
                .Sellers
                .FirstOrDefaultAsync(x => x.Id == id);
            if (seller == null)
                return new ResultViewModel<Seller>(
                    "vendedor não encontrado");

            context.Sellers.Remove(seller);
            await context.SaveChangesAsync();

            return new ResultViewModel<Seller>(seller);
        }
        catch
        {
            return new ResultViewModel<Seller>(
                "0AX01 - Erro ao deletar vendedor");
        }
    }
}