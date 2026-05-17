

namespace ShoeSalvation.Domain.Entities
{
    public class SubCategoryDto
    {
        public int Id { get; set; }
       
        public required string Name { get; set; }

        public string? CategoryName{ get; set; }
    }
}
