

using ShoeSalvation.Domain.Enums;

namespace ShoeSalvation.Domain.Entities
{
    public class StockAdjustment
    {
        public int Id { get; set; }
        public int VariantId { get; set; }

        public required ProductVariant Variant { get; set; }

        public AdjustmentType AdjustmentType { get; set; }
        public int Quantity { get; set; }
        public required string Note { get; set; }
        public int AdjustedBy { get; set; }
        public required User User { get; set; }
        public DateTime AdjustedAt { get; set; }
    }
}
