
using System;

namespace Segmage.Models
{
	public abstract class BaseEvent : IBaseEvent
	{
		public Guid SessionId { get; set; }

		public string UserId { get; set; }

		public DateTime? Created { get; set; }
	}
}