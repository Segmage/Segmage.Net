using Segmage.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Segmage.Models
{
	public abstract class Offer<TIdType, TOpportunityIdType, TUserIdType> : Basket<TIdType, TUserIdType>, IOffer
	{
		public TOpportunityIdType OpportunityId { get; set; }

	}
}
