using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Segmage
{
	public static class SegmageGlobal
	{
		public static Action<object> OnBeforeRequestSend { get; set; }
	}
}
