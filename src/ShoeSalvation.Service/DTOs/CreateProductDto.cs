
namespace ShoeSalvation.Service.DTOs
{
    public class  CreateProductDto
    {       
        public required string Name { get; set; }
        public string? Description { get; set; }
        public int BrandId { get; set; }
        public int CategoryId { get; set; }
        public int SubCategoryId { get; set; }
        
    }
}
