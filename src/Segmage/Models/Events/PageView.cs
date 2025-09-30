
using System;

namespace Segmage.Models
{
	public class PageView : SegmageAction
	{
		public Guid PageId { get; set; }

		public string Url { get; set; }
	}
}