

namespace ShoeSalvation.Domain.Entities
{
    public class Brand
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public string? LogoUrl { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
