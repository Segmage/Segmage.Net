using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Segmage.Models
{
	public class Event
	{
		public Guid Id { get; set; }
		public string EventType { get; set; }
		public string Name { get; set; }
		public string TypeName { get; set; }
	}
}
