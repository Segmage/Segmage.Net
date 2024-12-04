namespace Segmage.Models
{
	public abstract class ProductSaleItem: ProductItem
	{
		public string Id { get; set; }
		public string SaleId { get; set; }
	}
}