
namespace Segmage.Models
{
	public class PageViewEvent : BaseEvent
	{
		public string Referer { get; set; }
		public string Title { get; set; }
		public string Url { get; set; }
	}
}