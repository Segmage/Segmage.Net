using Segmage.Models.Interfaces;

namespace Segmage.Models
{
	public class PageViewEvent<TUserIdType> : BaseEvent<TUserIdType>, IPageViewEvent
	{
		public string Referer { get; set; }
		public string Title { get; set; }
		public string Url { get; set; }
	}
}