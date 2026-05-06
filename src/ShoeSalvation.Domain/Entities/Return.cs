

using ShoeSalvation.Domain.Enums;

namespace ShoeSalvation.Domain.Entities
{
    public class Return
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public required Order Order { get; set; }
        public int UserId { get; set; }

        public required User User { get; set; }
        public int Quantity { get; set; }
        public required string Reason { get; set; }
       public ReturnStatus Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
