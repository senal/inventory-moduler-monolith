using System.ComponentModel.DataAnnotations;

namespace inventory.Domain;

public class Item
{
    public Guid Id { get; init; }
    [MaxLength(100)]
    public required string Name { get; init; }
    public int Quantity { get; init; }
    public decimal Price { get; init; }
    public required Supplier Supplier { get; init; }
    public DateTimeOffset PurchasedAt { get; init; }
    public DateTimeOffset ExpiryAt { get; init; }
}