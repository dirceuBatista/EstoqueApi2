using EstoqueApi.Data;
using EstoqueApi.Models;
using EstoqueApi.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace EstoqueApi.Services;

public class CustumerService(DataContext context)
{
    public async Task<ResultViewModel<List<Custumer>>> GetAllCustumerAsync()
    {
        try
        {
            var custumer = await context
                .custumers
                .ToListAsync();

            return new ResultViewModel<List<Custumer>>(custumer);
        }
        catch
        {
            return new ResultViewModel<List<Custumer>>("Erro ao buscar clientes.");
        }
    }

    public async Task<ResultViewModel<Custumer>> GetByIdCustumerAsync(int id)
    {
        try
        {
            var custumer = await context.custumers
                .Include(x => x.sales)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (custumer == null)
                return new ResultViewModel<Custumer>("cliente não encontrado");

            return new ResultViewModel<Custumer>(custumer);
        }
        catch
        {
            return new ResultViewModel<Custumer>("Erro ao buscar cliente.");
        }
    }

    public async Task<ResultViewModel<Custumer>> CreateCustumerAsync(
        EditorCustumerViewModel model)
    {
        var custumer = new Custumer
        {
            Name = model.Name,
            Email = model.Email,
            ZipCode = model.ZipCode
        };

        try
        {
            await context.custumers.AddAsync(custumer);
            await context.SaveChangesAsync();
            return new ResultViewModel<Custumer>(custumer);
        }
        catch
        {
            return new ResultViewModel<Custumer>("Erro ao registrar cliente.");
        }
    }

    public async Task<ResultViewModel<Custumer>>UpdateCustumerAsync(
        EditorCustumerViewModel model, int id)
    {
        try
        {
            var custumer = await context
                .custumers
                .FirstOrDefaultAsync(x => x.Id == id);

            if (custumer == null)
                return new ResultViewModel<Custumer>("cliente não encontrada");

            custumer.Name = model.Name;
            custumer.Email = model.Email;
            custumer.ZipCode = model.ZipCode;
            
            context.custumers.Update(custumer);
            await context.SaveChangesAsync();
            return new ResultViewModel<Custumer>(custumer);
            
        }
        catch
        {
            return new  ResultViewModel<Custumer>(
                "Erro ao atualizar ao cliente");
        }

    }
    public async Task<ResultViewModel<Custumer>>DeleteCustumerAsync(int id)
    {
        try
        {
            var custumer = await context
                .custumers
                .FirstOrDefaultAsync(x => x.Id == id);

            if (custumer == null)
                return new ResultViewModel<Custumer>("venda não encontrada");
            
            context.custumers.Remove(custumer);
            await context.SaveChangesAsync();
            return new ResultViewModel<Custumer>(custumer);
            
        }
        catch
        {
            return new  ResultViewModel<Custumer>(
                "Erro ao deletar a cliente");
        }

    }


   
}
