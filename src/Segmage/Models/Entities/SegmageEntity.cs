using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Segmage.Models
{
	public class SegmageEntity
	{
		public string Id { get; set; }

		public Guid SessionId { get; set; }

		public Guid DeviceId { get; set; }

	}
}
