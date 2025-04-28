using EstoqueApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EstoqueApi.Data.Mapping;

public class UserMap : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder
            .ToTable("User");
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
            .Property(x => x.Email)
            .IsRequired()
            .HasColumnName("Email")
            .HasColumnType("NVARCHAR")
            .HasMaxLength(50);
        builder.Property(x => x.Slug)
            .IsRequired()
            .HasColumnName("Slug")
            .HasColumnType("VARCHAR")
            .HasMaxLength(50);
        builder
            .Property(x=>x.PasswordHash)
            .HasColumnName("Password")
            .HasColumnType("VARCHAR")
            .HasMaxLength(100);

        builder
            .HasIndex(x => x.Email, "IX_User_Email")
            .IsUnique();

        builder
            .HasMany(x => x.profiles)
            .WithMany(x => x.users)
            .UsingEntity<Dictionary<string, object>>(
                "Userprofile",
                profile => profile
                    .HasOne<Profile>()
                    .WithMany()
                    .HasForeignKey("SellerId")
                    .HasConstraintName("Fk_UserProfile_ProfileId")
                    .OnDelete(DeleteBehavior.Cascade),
                user => user
                    .HasOne<User>()
                    .WithMany()
                    .HasForeignKey("profileId")
                    .HasConstraintName("Fk_UserProfile_UserId")
                    .OnDelete(DeleteBehavior.Cascade)
            );
        
            
       
    }
}