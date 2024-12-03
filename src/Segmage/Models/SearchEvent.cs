namespace Segmage.Models
{
	public class SearchEvent<TUserIdType> : BaseEvent<TUserIdType>
	{
		public string Data { get; set; }
	}
}