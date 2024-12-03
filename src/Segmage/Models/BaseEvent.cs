
using System;

namespace Segmage.Models
{
	public abstract class BaseEvent<TUserIdType> : IBaseEvent
	{
		public Guid SessionId { get; set; }

		public TUserIdType UserId { get; set; }

		public DateTime? Created { get; set; }
	}
}