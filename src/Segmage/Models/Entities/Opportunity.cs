
using System;

namespace Segmage.Models
{
    public class Opportunity : SegmageAction
	{
		public string Status { get; set; }
		public DateTime ValidityStartDate { get; set; }
		public DateTime ExpiryDate { get; set; }
		public string Title { get; set; }
		public double ProbabilityOfSuccess { get; set; }
        public string UserId { get; set; }
    }
}
