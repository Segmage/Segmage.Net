using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Segmage.Models
{
    public class Activity : SegmageEntity
	{
		public string Status { get; set; }
		public DateTime? PlannedDate { get; set; }
		public DateTime? CompletionDate { get; set; } = DateTime.Now;
		public string UserId { get; set; }
    }
}
	