
namespace ShoeSalvation.Domain.Entities
{
    public class PriceHistory
    {
        public int Id { get; set; }
        public int VariantId { get; set; }
        public required ProductVariant ProductVariant { get; set; }
       

        public decimal OldMrp { get; set; }
        public decimal NewMrp { get; set; }
        public decimal OldSellingPrice { get; set; }
        public decimal NewSellingPrice { get; set; }
        
        public DateTime ChangedAt { get; set; }
        public int ChangedBy { get; set; }
        public required User ChangedByUser { get; set; }

    }
}
