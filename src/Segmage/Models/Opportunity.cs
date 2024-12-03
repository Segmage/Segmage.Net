using Segmage.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Segmage.Models
{
	public abstract class Opportunity<TIdType, TUserIdType> : IOpportunity
	{
		public TIdType Id { get; set; }
		public TUserIdType UserId { get; set; }
		public string Status { get; set; }
		public DateTime ValidityStartDate { get; set; }
		public DateTime ExpiryDate { get; set; }
		public string Title { get; set; }
		public double ProbabilityOfSuccess { get; set; }
	}
}
