namespace EstoqueApi.Models;

public class Custumer
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int ZipCode { get; set; }
    public string Email { get; set; }
    public DateTime Lastpurchase {  get; set; }
    public List<Sale> sales { get; set; }
}