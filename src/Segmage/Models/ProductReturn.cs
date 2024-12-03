using Segmage.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Segmage.Models
{
	public abstract class ProductReturn<TIdType, TOfferIdType, TOpportunityIdType, TSaleIdType, TUserIdType> : BaseEvent<TUserIdType>, IProductReturn
	{
		public TOpportunityIdType OpportunityId { get; set; }

		public TOfferIdType OfferId { get; set; }

		public TSaleIdType SaleId { get; set; }
	}
}
