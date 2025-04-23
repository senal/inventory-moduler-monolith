namespace inventory.Domain;

public class Supplier
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public int PostCode { get; set; }
}