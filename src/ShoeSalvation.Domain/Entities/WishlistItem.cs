

namespace ShoeSalvation.Domain.Entities
{
    public class WishlistItem
    {
        public int Id { get; set; }
        public int WishlistId { get; set; }

        public required Wishlist Wishlist { get; set; }

        public int VariantId { get; set; }

        public required ProductVariant Variant { get; set; }
        public DateTime AddedAt { get; set; }
    }
}
