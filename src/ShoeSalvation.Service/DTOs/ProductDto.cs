
namespace ShoeSalvation.Service.DTOs
{
    public class ProductDto
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }
        public  string? BrandName { get; set; }
        public  string? CategoryName { get; set; }
        public  string? SubCategoryName { get; set; }
        public bool IsActive { get; set; }
        
    }
}
