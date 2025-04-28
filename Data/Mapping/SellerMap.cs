using EstoqueApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EstoqueApi.Data.Mapping;

public class SellerMap:IEntityTypeConfiguration<Seller>
{
    public void Configure(EntityTypeBuilder<Seller> builder)
    {
        builder
            .ToTable("Seller");
        builder
            .HasKey(x => x.Id);
        builder
            .Property(x => x.Id)
            .ValueGeneratedOnAdd()
            .UseIdentityColumn();

        builder
            .Property(x => x.Name)
            .IsRequired()
            .HasColumnName("Name")
            .HasColumnType("NVARCHAR")
            .HasMaxLength(80);
        
        builder
            .Property(x=>x.Email)
            .IsRequired()
            .HasColumnName("Email")
            .HasColumnType("NVARCHAR")
            .HasMaxLength(50);
        
        builder
            .Property(x => x.Slug)
            .IsRequired()
            .HasColumnName("Slug")
            .HasColumnType("VARCHAR")
            .HasMaxLength(50);
        
        builder
            .Property(x => x.LastSale)
            .HasColumnName("LastSale")
            .HasColumnType("SMALLDATETIME")
            .HasMaxLength(60)
            .HasDefaultValueSql("GETDATE()");
        
        builder
            .HasIndex(x => x.Email, "IX_Email_Seller")
            .IsUnique();
        builder
            .HasOne(x => x.user)
            .WithOne(x => x.seller)
            .HasForeignKey<Seller>(x=>x.UserId)
            .HasConstraintName("FK_User_Seller")
            .OnDelete(DeleteBehavior.Cascade);
    }
}