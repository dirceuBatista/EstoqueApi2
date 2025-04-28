using EstoqueApi.Data;
using EstoqueApi.Models;
using EstoqueApi.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace EstoqueApi.Services;

public class SaleService(DataContext context)
{
    public async Task<ResultViewModel<List<Sale>>> GetAllSaleAsync()
    {
        try
        {
            var sales = await context.Sales
                .Include(x => x.Seller)
                .Include(x => x.Tennis)
                .ToListAsync();

            return new ResultViewModel<List<Sale>>(sales);
        }
        catch
        {
            return new ResultViewModel<List<Sale>>("Erro ao buscar vendas.");
        }
    }

    public async Task<ResultViewModel<Sale>> GetSaleByIdAsync(int id)
    {
        try
        {
            var sale = await context.Sales
                .Include(x => x.SellerId)
                .Include(x => x.TennisId)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (sale == null)
                return new ResultViewModel<Sale>("Venda não encontrada");

            return new ResultViewModel<Sale>(sale);
        }
        catch
        {
            return new ResultViewModel<Sale>("Erro ao buscar venda.");
        }
    }

    public async Task<ResultViewModel<Sale>> CreateSaleAsync(
        EditorSaleViewModel model)
    {
        var sale = new Sale
        {
            Description = model.Description,
            DateSale = model.DateSale,
            SellerId = model.SellerId,
            TennisId = model.TennisId
        };

        try
        {
            await context.Sales.AddAsync(sale);
            await context.SaveChangesAsync();
            return new ResultViewModel<Sale>(sale);
        }
        catch
        {
            return new ResultViewModel<Sale>("Erro ao registrar venda.");
        }
    }

    public async Task<ResultViewModel<Sale>>UpdateSaleAsync(
        EditorSaleViewModel model, int id)
    {
        try
        {
            var sale = await context
                .Sales
                .Include(x => x.SellerId)
                .Include(x => x.TennisId)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (sale == null)
                return new ResultViewModel<Sale>("venda não encontrada");

            sale.Description = model.Description;
            context.Sales.Update(sale);
            await context.SaveChangesAsync();
            return new ResultViewModel<Sale>(sale);
            
        }
        catch
        {
            return new  ResultViewModel<Sale>(
                "Erro ao atualizar a venda");
        }

    }
    public async Task<ResultViewModel<Sale>>DeleteSaleAsync(int id)
    {
        try
        {
            var sale = await context
                .Sales
                .Include(x => x.SellerId)
                .Include(x => x.TennisId)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (sale == null)
                return new ResultViewModel<Sale>("venda não encontrada");
            
            context.Sales.Remove(sale);
            await context.SaveChangesAsync();
            return new ResultViewModel<Sale>(sale);
            
        }
        catch
        {
            return new  ResultViewModel<Sale>(
                "Erro ao deletar a venda");
        }

    }


   
}

