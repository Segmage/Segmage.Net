
namespace Segmage.Models
{
	public abstract class ProductReturnItem : ProductItem
	{
		public string Id { get; set; }
		public string ProductReturnId { get; set; }
	}
}