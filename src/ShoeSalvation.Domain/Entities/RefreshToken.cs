
namespace ShoeSalvation.Domain.Entities
{
    public class RefreshToken
    {
        public int Id { get; set; }
        public int UserId { get; set; }

        public required User User { get; set; }
        public required string Token { get; set; }
        public required DateTime ExpiresAt { get; set; }
        public required bool IsRevoked { get; set; }
        public required  DateTime CreatedAt { get; set; }
    }
}
