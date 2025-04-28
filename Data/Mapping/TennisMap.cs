using EstoqueApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EstoqueApi.Data.Mapping;

public class TennisMap : IEntityTypeConfiguration<Tennis>
{
    public void Configure(EntityTypeBuilder<Tennis> builder)
    {
        builder.ToTable("Tennis");
        builder.HasKey(x => x.Id);
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
            .Property(x => x.Version)
            .IsRequired()
            .HasColumnName("Version")
            .HasColumnType("VARCHAR")
            .HasMaxLength(50);

        builder
            .Property(x => x.Price)
            .IsRequired()
            .HasColumnName("Price")
            .HasColumnType("int");
        builder
            .HasIndex(x => x.Id, "IX_Tennis_Id")
            .IsUnique();
        
    }
}