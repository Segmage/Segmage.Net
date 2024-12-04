using System;

namespace Segmage.Models
{
	public interface IBaseEvent
	{
		DateTime? Created { get; set; }
		Guid SessionId { get; set; }
		string UserId { get; set; }
	}
}