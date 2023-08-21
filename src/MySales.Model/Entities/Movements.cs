using MySales.Model.Enums;

namespace MySales.Model.Entities;

public class Movements
{
    public long Id { get; set; }
    public long ProductId { get; set; }
    public TypeMovement Type { get; set; }
    public int Amount { get; set; }

    public DateTime CreatedDate { get; set; } = DateTime.Now;

    public virtual Product Product { get; set; } = default!;
}
