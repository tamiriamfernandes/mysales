namespace MySales.Model.DTOs.Sale;

public record SaleItemDto
{
    public long ProductId { get; init; }
    public int Amount { get; init; }
    public decimal Price { get; init; }
}
