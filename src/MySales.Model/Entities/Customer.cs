namespace MySales.Model.Entities;

public class Customer
{
    public long Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Phone { get; set; }
    public DateTime CreatedDate { get; set; } = DateTime.Now;

    public virtual IEnumerable<Sale> Sales { get; set; }
    public virtual IEnumerable<AccountReceive> AccountReceives { get; set; }
}
