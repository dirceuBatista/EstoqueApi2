using EstoqueApi.Data.Mapping;
using EstoqueApi.Models;
using Microsoft.EntityFrameworkCore;

namespace EstoqueApi.Data;

public class DataContext : DbContext
{
    
    public DbSet<Sale> Sales{get; set ;}
    public DbSet<Tennis> tennis{get; set;}
    public DbSet<Seller> Sellers { get; set; }
    public DbSet<User> users {get; set;}
    public DbSet<Custumer> custumers{get;set;}
   

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UserMap());
        modelBuilder.ApplyConfiguration(new TennisMap());
        modelBuilder.ApplyConfiguration(new SaleMap());
        modelBuilder.ApplyConfiguration(new CustumerMap());
        modelBuilder.ApplyConfiguration(new SellerMap());
    }


    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        var conenction= options.UseSqlServer(
            "server=localhost,1433; DataBase=StockApi;User ID=sa;Password=1q2w3e4r@#$;TrustServerCertificate=True;");
    }
}