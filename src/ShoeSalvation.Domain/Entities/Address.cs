
namespace ShoeSalvation.Domain.Entities
{
    public class Address
    {
        public int Id { get; set; }
        public int UserId { get; set; }

        public required User User { get; set; }
        public required string FullName { get; set; }
        public required string Street { get; set; }
        public required string Phone { get; set; }
        public required string City { get; set; }
        public required string State { get; set; }
        public required string ZipCode { get; set; }
        public required string Country { get; set; }
        public required bool IsDefault { get; set; }
    }
}
