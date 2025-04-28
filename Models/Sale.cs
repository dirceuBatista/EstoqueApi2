namespace EstoqueApi.Models;

public class Sale
{
    
    public int Id { get; set; }
    public string Description { get; set; }
    public DateTime DateSale { get; set; }
    public int  SellerId { get; set; }
    public int TennisId {  get; set; }

    public Seller sellers { get; set; }
    public Tennis Tennis { get; set; }
    public List<Seller> Seller { get; set; }

}

