using Segmage.Models.Interfaces;

namespace Segmage.Models
{
	public abstract class Product360<TIdType> : IProduct360
	{
		public TIdType Id { get; set; }
		public string Text { get; set; }
		public string ProductCode { get; set; }
		public string Affiliation { get; set; }
		public string SKU { get; set; }
		public string Brand { get; set; }
		public string Variant { get; set; }
		public string Category { get; set; }
		public string Category2 { get; set; }
		public string Category3 { get; set; }
		public string Category4 { get; set; }
		public string Category5 { get; set; }
		public string Unit { get; set; }
		public decimal UnitPrice { get; set; }
		public string ProductUrl { get; set; }
		public decimal VatPercentage { get; set; }
	}
}
