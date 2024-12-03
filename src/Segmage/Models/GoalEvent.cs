using Segmage.Models.Interfaces;

namespace Segmage.Models
{
	public class GoalEvent<TUserIdType> : BaseEvent<TUserIdType>, IGoalEvent
	{
		public decimal? Value { get; set; }
	}
}