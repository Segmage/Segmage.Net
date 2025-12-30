using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Segmage.Models.Entities
{
	public class MobilePushToken
	{
		public string Id { get; set; }

		public string AppId { get; set; }

		public string DeviceToken { get; set; }

		public string UserId { get; set; }
	}
}
