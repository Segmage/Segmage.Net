namespace Segmage.Models
{
	public abstract class ProductSaleItem<TIdType, TSaleIdType, TProductIdType> : ProductItem<TProductIdType>
	{
		public TIdType Id { get; set; }
		public TSaleIdType SaleId { get; set; }
	}
}