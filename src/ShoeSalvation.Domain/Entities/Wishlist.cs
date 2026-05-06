

namespace ShoeSalvation.Domain.Entities
{
    public class Wishlist
    {
        public int Id { get; set; }
        public int UserId { get; set; }
       
        public required User User { get; set; }
        public ICollection<WishlistItem> WishlistItems { get; set; }= new List<WishlistItem>();
        public DateTime CreatedAt { get; set; }
    }
}
