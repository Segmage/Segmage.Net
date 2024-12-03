using Segmage.Models.Interfaces;

namespace Segmage.Models
{
	public class LogoutEvent<TUserIdType> : BaseEvent<TUserIdType>, ILoginEvent
	{
	}
}