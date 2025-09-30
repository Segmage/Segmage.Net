using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Segmage.Models
{
	public class Lead : SegmageAction
	{
		public string FullName { get; set; }

		public string LeadExternalId { get; set; }

		public string RawData { get; set; }

		public string Email { get; set; }

		public string Phone { get; set; }

		public string MobilePhone { get; set; }

		public bool IsEmailGranted { get; set; }

		public bool IsSmsGranted { get; set; }

		public bool IsCallGranted { get; set; }

		public bool IsWebPushGranted { get; set; }

		public bool IsMobilePushGranted { get; set; }

		public string UserId { get; set; }
	}
}
