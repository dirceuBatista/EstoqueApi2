namespace EstoqueApi.Models;

public class Tennis
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Version { get; set; }
    public int Price { get; set; }
    
    public List<Sale> sales { get; set; }
    public List<Seller> sellers { get; set; }
}