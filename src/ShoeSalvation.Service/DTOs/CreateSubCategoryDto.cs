

namespace ShoeSalvation.Domain.Entities
{
    public class CreateSubCategoryDto
    {
        public required string Name { get; set; }

        public string? CategoryName{ get; set; }
    }
}
