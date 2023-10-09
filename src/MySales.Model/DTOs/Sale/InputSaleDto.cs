using MySales.Model.Enums;

namespace MySales.Model.DTOs.Sale;

public record InputSaleDto
{
    public long CustomerId { get; init; }
    public TypePayment Payment { get; init; }
    public int Installments { get; init; }
    public int DatePay { get; init; }
    public DateTime CreatedDate { get; init; } = DateTime.Now;
    public decimal Total { get; init; }
    public string Observation { get; init; }
    //public IEnumerable<SaleItemDto> SaleItems { get; init; }
}
