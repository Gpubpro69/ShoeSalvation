
namespace ShoeSalvation.Domain.Entities
{
    public class Product
    {
        public int Id { get; set; }
       
        public required string Name { get; set; }
        public string? Description { get; set; }

        public required int BrandId { get; set; }
        public required Brand Brand { get; set; }
        public int CategoryId { get; set; }
        public required Category Category { get; set; }
        public int SubCategoryId { get; set; }
        public required SubCategory SubCategory { get; set; }
        public string? PrimaryImageUrl { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        
    }
}
