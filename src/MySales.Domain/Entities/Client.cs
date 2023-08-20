namespace MySales.Core.Entities;

public class Client
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Phone { get; set; }
    public DateTime CreatedDate { get; set; } = DateTime.Now;
}
