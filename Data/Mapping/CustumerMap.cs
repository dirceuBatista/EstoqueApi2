using EstoqueApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EstoqueApi.Data.Mapping;

public class CustumerMap : IEntityTypeConfiguration<Custumer>
{
    public void Configure(EntityTypeBuilder<Custumer> builder)
    {
        builder.ToTable("Custumer");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id)
            .ValueGeneratedOnAdd()
            .UseIdentityColumn();

        builder
            .Property(x => x.Name)
            .IsRequired()
            .HasColumnName("Name")
            .HasColumnType("NVARCHAR")
            .HasMaxLength(80);

        builder
            .Property(x => x.ZipCode)
            .IsRequired()
            .HasColumnName("ZipCode")
            .HasColumnType("Int")
            .HasMaxLength(20);

        builder
            .Property(x => x.Email)
            .IsRequired()
            .HasColumnName("Email")
            .HasColumnType("NVARCHAR")
            .HasMaxLength(100);
            

        builder
            .HasIndex(x => x.Email, "IX_Custumer_Email")
            .IsUnique();
        



    }
}