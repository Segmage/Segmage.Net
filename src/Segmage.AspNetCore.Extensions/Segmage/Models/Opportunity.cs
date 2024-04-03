using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Segmage.Models
{
	public abstract class Opportunity
	{
		public string Status { get; set; }
		public DateTime ValidityStartDate { get; set; }
		public DateTime ExpiryDate { get; set; }
		public string Title { get; set; }
		public double ProbabilityOfSuccess { get; set; }
	}
}
