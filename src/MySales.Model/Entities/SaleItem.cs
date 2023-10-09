namespace MySales.Model.Entities;

public class SaleItem
{
    public long Id { get; set; }
    public long SaleId { get; set; }
    public long ProductId { get; set; }
    public int Amount { get; set; }
    public decimal Price { get; set; }

    public virtual Sale Sale { get; set; }
    public virtual Product Product { get; set; }
}
