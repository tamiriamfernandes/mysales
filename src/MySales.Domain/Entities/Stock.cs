namespace MySales.Core.Entities;

public class Stock
{
    public int Id { get; set; }
    public int ProductId { get; set; }
    public int Amount { get; set; }

    public virtual Product Product { get; set; } = default!;
}
