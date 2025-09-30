namespace Segmage.Models
{
    public class BasketItem : ProductItem
	{
		public string BasketId { get; set; }

		public string UserId { get; set; }
	}
}