namespace EstoqueApi.Models;

public class Profile
{
    public List<User> users;
    public int Id { get; set; }
    public string Name { get; set; }
    public string Slug { get; set; }
}