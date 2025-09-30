using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Segmage.Models
{
	public class Feedback : SegmageAction
	{
		public Guid FeedbackId { get; set; }
		public Guid IntegrationId { get; set; }
		public int Rating { get; set; }
		public int MaxRating { get; set; }
		public string Comments { get; set; }
	}
}
