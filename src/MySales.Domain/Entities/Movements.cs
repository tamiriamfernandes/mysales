using MySales.Core.Enums;

namespace MySales.Core.Entities;

public class Movements
{
    public int Id { get; set; }
    public int ProductId { get; set; }
    public TypeMovement Type { get; set; }
    public int Amount { get; set; }
    public DateTime CreatedDate { get; set; } = DateTime.Now;

    public virtual Product Product { get; set; } = default!;
}
