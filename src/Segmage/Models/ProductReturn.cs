
using System.Collections.Generic;

namespace Segmage.Models
{
	public class ProductReturn : ProductExchangeBase
	{
		public string OpportunityId { get; set; }

		public string OfferId { get; set; }

		public string SaleId { get; set; }

		public string UserId { get; set; }

		public List<ProductReturnItem> Items { get; set; }
	}
}
