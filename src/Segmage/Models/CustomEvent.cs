using Segmage.Models.Interfaces;

namespace Segmage.Models
{
	public class CustomEvent<TUserIdType> : BaseEvent<TUserIdType>, ICustomEvent
	{
		public string Data { get; set; }
	}
}