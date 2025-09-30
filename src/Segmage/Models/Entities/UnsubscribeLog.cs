using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Segmage.Models
{
	public class UnsubscribeLog : SegmageEntity
	{
		public string Target { get; set; }
		public string UserId { get; set; }
		public List<string> Reasons { get; set; }
		public string Comments { get; set; }
		public int Type { get; set; }
	}

	public enum UnsubcribeType
	{
		Email = 1,
		SMS = 2,
		WhatsApp = 3,
		WebPush = 4,
		MobilePush = 5,
		Call = 6
	}
}
