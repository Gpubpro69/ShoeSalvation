
namespace ShoeSalvation.Domain.Entities
{
    public class ProductVariant
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public required Product Product { get; set; }
        public required string Color { get; set; }
        public required string Size { get; set; }

        public decimal Mrp { get; set; }
        public decimal SellingPrice { get; set; }

        public int StockQuantity { get; set; }
        public string? ImageUrl { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

    }
}
