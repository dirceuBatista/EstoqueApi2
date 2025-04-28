using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace EstoqueApi.Models;

public class User
{

    public int Id { get; set; }
    public string Name { get; set; }

    public string Slug { get; set; }
    public string Email { get; set; }
    public string? PasswordHash { get; set; }
    
    public Seller seller { get; set; }

    public List<Profile> profiles { get; set; }
    
}