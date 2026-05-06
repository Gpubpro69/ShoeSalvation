

namespace ShoeSalvation.Domain.Entities
{
    public class CartItem
    {
        public int Id { get; set; }
        public int CartId { get; set; }

        public required Cart Cart { get; set; }

        public int VariantId { get; set; }

        public required ProductVariant Variant { get; set; }
        public int Quantity { get; set; }
        public DateTime AddedAt { get; set; }
    }
}
