using MySales.Model.Enums;

namespace MySales.Model.Entities;

public class Sale
{
    public long Id { get; set; }
    public long CustomerId { get; set; }
    public TypePayment Payment { get; set; }
    public int Installments { get; set; }
    public int DatePay { get; set; }
    public DateTime CreatedDate { get; set; } = DateTime.Now;
    public decimal Total { get; set; }
    public string Observation { get; set; }

    public virtual Customer Customer { get; set; }
    public virtual IEnumerable<SaleItem> SaleItems { get; set; }
    public virtual IEnumerable<AccountReceive> AccountReceives { get; set; }
}
