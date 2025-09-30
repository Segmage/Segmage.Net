using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Segmage.Models;

namespace Segmage.Services
{
	public class EventSender : SenderBase
	{
		public EventSender(AppOptions options) : base(options) { }

		/// <summary>
		/// 
		/// </summary>
		/// <param name="event"></param>
		/// <param name="cancellationToken"></param>
		/// <returns></returns>
		public async Task<ServiceResult> SetSessionAsync(Session @event, CancellationToken cancellationToken = default) => await PostRequestAsync(ApiUriConsts.SET_SESSION, @event, cancellationToken);

		/// <summary>
		/// 
		/// </summary>
		/// <param name="event"></param>
		/// <param name="cancellationToken"></param>
		/// <returns></returns>
		public async Task<ServiceResult> SendLoginEventAsync(string eventUniqName, Login @event, CancellationToken cancellationToken = default) => await ExecuteAsync(string.Format(ApiUriConsts.LOGIN_EVENT, "{0}", eventUniqName), @event, cancellationToken);

		/// <summary>
		/// 
		/// </summary>
		/// <param name="event"></param>
		/// <param name="cancellationToken"></param>
		/// <returns></returns>
		public async Task<ServiceResult> SendLogoutEventAsync(string eventUniqName, Logout @event, CancellationToken cancellationToken = default) => await ExecuteAsync(string.Format(ApiUriConsts.LOGOUT_EVENT, "{0}", eventUniqName), @event, cancellationToken);

		/// <summary>
		/// 
		/// </summary>
		/// <param name="model"></param>
		/// <param name="cancellationToken"></param>
		/// <returns></returns>
		public async Task<ServiceResult> SendAddToBasketEventAsync(string eventUniqName, AddToBasket model, CancellationToken cancellationToken = default) => await ExecuteAsync(string.Format(ApiUriConsts.ADD_TO_BASEKET_EVENT, "{0}", eventUniqName), model, cancellationToken);

		/// <summary>
		/// 
		/// </summary>
		/// <param name="event"></param>
		/// <param name="cancellationToken"></param>
		/// <returns></returns>
		public async Task<ServiceResult> SendRemoveFromBasketEventAsync(string eventUniqName, RemoveFromBasket @event, CancellationToken cancellationToken = default) => await ExecuteAsync(string.Format(ApiUriConsts.REMOVE_FROM_BASKET_EVENT, "{0}", eventUniqName), @event, cancellationToken);

		/// <summary>
		/// 
		/// </summary>
		/// <param name="event"></param>
		/// <param name="cancellationToken"></param>
		/// <returns></returns>
		public async Task<ServiceResult> SendPageViewEventAsync(string eventUniqName, PageView @event, CancellationToken cancellationToken = default) => await ExecuteAsync(string.Format(ApiUriConsts.PAGE_VIEW_EVENT, "{0}", eventUniqName), @event, cancellationToken);

		/// <summary>
		/// 
		/// </summary>
		/// <param name="model"></param>
		/// <param name="cancellationToken"></param>
		/// <returns></returns>
		public async Task<ServiceResult> SendGoalEventAsync(string eventUniqName, Goal model, CancellationToken cancellationToken = default) => await ExecuteAsync(string.Format(ApiUriConsts.GOAL_EVENT, "{0}", eventUniqName), model, cancellationToken);

		/// <summary>
		/// 
		/// </summary>
		/// <param name="model"></param>
		/// <param name="cancellationToken"></param>
		/// <returns></returns>
		public async Task<ServiceResult> SendSearchEventAsync(string eventUniqName, Search model, CancellationToken cancellationToken = default) => await ExecuteAsync(string.Format(ApiUriConsts.SEARCH_EVENT, "{0}", eventUniqName), model, cancellationToken);

		/// <summary>
		/// 
		/// </summary>
		/// <param name="event"></param>
		/// <param name="cancellationToken"></param>
		/// <returns></returns>
		public async Task<ServiceResult> SendCustomEventAsync(string eventUniqName, Custom @event, CancellationToken cancellationToken = default) => await ExecuteAsync(string.Format(ApiUriConsts.CUSTOM_EVENT, "{0}", eventUniqName), @event, cancellationToken);


		public async Task<List<Event>> GetEvents(CancellationToken cancellationToken = default(CancellationToken))
		{
			return await GetRequestAsync<List<Event>>(ApiUriConsts.EVENTS, cancellationToken);
		}

		private async Task<ServiceResult> ExecuteAsync(string path, SegmageAction @event, CancellationToken cancellationToken)
		{
			@event = await BeginExecutionAsync(@event);
			return await PostRequestAsync(path, @event, cancellationToken);
		}

		public async Task<bool> ValidateToken(CancellationToken cancellationToken = default(CancellationToken))
		{
			return await base.ValidateToken(cancellationToken);
		}

		public virtual async Task<SegmageAction> BeginExecutionAsync(SegmageAction @event)
		{
			return @event;
		}
	}
}