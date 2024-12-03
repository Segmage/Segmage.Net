using Segmage.Models.Interfaces;

namespace Segmage.Models
{
	public abstract class ProductReturnItem<TIdType, TProductReturnIdType, TProductIdType> : ProductItem<TProductIdType>, IProductReturnItem
	{
		public TIdType Id { get; set; }
		public TProductReturnIdType ProductReturnId { get; set; }
	}
}