namespace Segmage.Models
{
    public class RemoveFromBasketEvent : BaseEvent
    {
        public string Description { get; set; }
        public decimal? Amount { get; set; }=0;
        public decimal? Quantity { get; set; } = 0;
        public decimal? Vat { get; set; }=0;
        public decimal? Discount { get; set; }=0;
        public string ProductId { get; set; }
        public string ProductCode { get; set; }
        public string ProductText { get; set; }
        public string Affiliation { get; set; }
        public string SKUId { get; set; }
        public string Brand { get; set; }
        public string Variant { get; set; }
        public string Category { get; set; }
        public string Category2 { get; set; }
        public string Category3 { get; set; }
        public string Category4 { get; set; }
        public string Category5 { get; set; }
        public string Unit { get; set; }
        public decimal? UnitPrice { get; set; } = 0;
        public decimal? VatPercentage { get; set; } = 0;
        public decimal? VatTotal { get; set; } =0;
        public decimal? DiscountCode { get; set; } = 0;
        public decimal? DiscountPercentage { get; set; } = 0;
        public decimal? DiscountTotal { get; set; } = 0;
        public decimal? ItemTotal { get; set; } = 0;
    }
}