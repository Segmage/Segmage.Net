using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Segmage.Models
{
	public abstract class Sale<TIdType, TOfferIdType, TOpportunityIdType, TUserIdType> : BaseEvent<TUserIdType>
	{
		public TIdType Id { get; set; }

		public TOpportunityIdType OpportunityId { get; set; }

		public TOfferIdType OfferId { get; set; }
	}
}
