using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Segmage.Models
{
	public class SegmageAction : SegmageEntity
	{
		public Guid? SessionId { get; set; }
		public Guid? DeviceId { get; set; }
		public string UserId { get; set; }
		public DateTime? CreatedDate { get; set; }
	}
}
