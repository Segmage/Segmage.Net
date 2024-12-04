using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Segmage.Models
{
	public abstract class Activity 
	{
		public string Id { get; set; }
		public string Status { get; set; }
		public DateTime? PlannedDate { get; set; }
		public DateTime? CompletionDate { get; set; }
        public string UserId { get; set; }
	}
}
