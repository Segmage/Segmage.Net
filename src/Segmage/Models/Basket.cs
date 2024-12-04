
using System.Collections.Generic;

namespace Segmage.Models
{
	public abstract class Basket : BaseEvent
	{
		public string Id { get; set; }
		public decimal? Total { get; set; } = 0;
		public decimal? TotalDiscount { get; set; } = 0;
		public decimal? TotalVat { get; set; } = 0;
		public decimal? GrandTotal { get; set; }
	}
}