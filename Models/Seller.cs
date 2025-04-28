namespace EstoqueApi.Models;

public class Seller
{
    
    
    public int Id { get; set; }

    public int UserId { get; set; }

    public string Name { get; set; }
    
    public string Slug { get; set; }

    public string Email { get; set; }
    
    public DateTime LastSale {  get; set; }


    public User user { get; set; }
    public List<Sale> sales { get; set; }
    

}