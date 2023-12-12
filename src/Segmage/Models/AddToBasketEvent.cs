
namespace Segmage.Models
{
    public class AddToBasketEvent : BaseEvent
    {
        public string ProductId { get; set; }
        public string ProductCode { get; set; }
        public string ProductGroup { get; set; }
        public string ProductGroupCode { get; set; }
        public string Description { get; set; }
        public string Unit { get; set; }
        public decimal? UnitPrice { get; set; } = 0;
        public decimal? Amount { get; set; } = 0;
        public decimal? Quantity { get; set; } = 1;
        public decimal? Vat { get; set; } = 0;
        public decimal? Discount { get; set; } = 0;

    }
}