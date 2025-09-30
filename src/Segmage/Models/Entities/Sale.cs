using System.Collections.Generic;

namespace Segmage.Models
{
	public class Sale : ProductExchangeBase
	{
		public string OpportunityId { get; set; }

		public string OfferId { get; set; }

		public virtual List<SaleItem> Items { get; set; }

		public string UserId { get; set; }
	}
}

