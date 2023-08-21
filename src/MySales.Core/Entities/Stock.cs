namespace MySales.Core.Entities;

public class Stock
{
    public long Id { get; set; }
    public long ProductId { get; set; }
    public int Amount { get; set; }

    public virtual Product Product { get; set; } = default!;
}
