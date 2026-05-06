

using ShoeSalvation.Domain.Enums;

namespace ShoeSalvation.Domain.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public int UserId { get; set; }       
        public required User User { get; set; }
        public int AddressId { get; set; }
        public required Address Address { get; set; }
        public OrderStatus Status { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; }= new List<OrderItem>();

        public decimal TotalAmount { get; set; }

        public PaymentStatus PaymentStatus { get; set; }

        public required string PaymentReference { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
