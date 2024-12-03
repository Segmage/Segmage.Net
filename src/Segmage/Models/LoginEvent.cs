using Segmage.Models.Interfaces;

namespace Segmage.Models
{
	public class LoginEvent<TUserIdType> : BaseEvent<TUserIdType>, ILoginEvent
	{
	}
}