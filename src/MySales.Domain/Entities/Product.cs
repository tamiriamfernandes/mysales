﻿namespace MySales.Core.Entities;

public class Product
{
    public int Id { get; set; }
    public string Description { get; set; } = string.Empty;
    public decimal value { get; set; }
    public DateTime CreatedDate { get; set; } = DateTime.Now;

    public virtual IEnumerable<Movements> Movements { get; set; } = default!;
    public virtual Stock Stock { get; set; } = default!;
}
