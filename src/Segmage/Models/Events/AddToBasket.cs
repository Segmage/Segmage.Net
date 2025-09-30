
using Segmage.Models;

public class AddToBasket : SegmageAction
{
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
	public decimal? UnitPrice { get; set; }
	public decimal? VatPercentage { get; set; }
	public decimal? VatTotal { get; set; } = 0;
	public decimal? DiscountCode { get; set; }
	public decimal? DiscountPercentage { get; set; } = 0;
	public decimal? DiscountTotal { get; set; } = 0;
	public decimal? ItemTotal { get; set; }
}