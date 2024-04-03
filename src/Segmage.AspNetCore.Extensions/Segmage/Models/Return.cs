using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Segmage.Models
{
	public abstract class Return : Basket
	{
		public string OpportunityId { get; set; }

		public string OfferId { get; set; }
	}
}
