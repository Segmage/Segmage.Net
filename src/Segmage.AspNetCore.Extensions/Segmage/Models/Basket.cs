using System.Collections.Generic;

namespace Segmage.Models
{
    public class Basket:BaseEvent
    {
        public string BasketId { get; set; }
        public List<ProductItem> Products { get; set; }
        public decimal? Total { get; set; } = 0;
        public decimal? TotalDiscount { get; set; } = 0; 
        public decimal? TotalVat { get; set; } = 0;
        public decimal? GrandTotal { get; set; }
    }
}