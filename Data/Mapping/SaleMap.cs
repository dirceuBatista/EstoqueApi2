using EstoqueApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EstoqueApi.Data.Mapping;

public class SaleMap : IEntityTypeConfiguration<Sale>
{
    public void Configure(EntityTypeBuilder<Sale> builder)
    {
        builder.ToTable("Sale");

        builder.HasKey(x => x.Id);

        builder
            .Property(x => x.Id)
            .ValueGeneratedOnAdd()
            .UseIdentityColumn();

        builder
            .Property(x => x.DateSale)
            .IsRequired()
            .HasColumnName("DateSale")
            .HasColumnType("SMALLDATETIME")
            .HasMaxLength(60)
            .HasDefaultValueSql("GETDATE()");
        builder
            .Property(x => x.Description)
            .IsRequired()
            .HasColumnName("Description")
            .HasColumnType("NVARCHAR")
            .HasMaxLength(200);

        builder
            .HasIndex(x => x.Id, "IX_Sale_Id")
            .IsUnique();
        builder
            .HasOne(x => x.sellers)
            .WithMany(x => x.sales)
            .HasConstraintName("FK_Sale_Seller")
            .OnDelete(DeleteBehavior.Cascade);
        builder
            .HasOne(x => x.Tennis)
            .WithMany(x => x.sales)
            .HasConstraintName("FK_Sale_Tennis")
            .OnDelete(DeleteBehavior.Cascade);
    }
}