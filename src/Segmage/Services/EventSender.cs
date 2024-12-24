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
		public async Task<ServiceResult> SetSessionAsync(SessionEvent @event, CancellationToken cancellationToken = default) => await PostRequestAsync(ApiUriConsts.SET_SESSION, @event, cancellationToken);

		public async Task<ServiceResult> BasketSyncAsync(string eventUniqName, Basket @event, CancellationToken cancellationToken = default) => await ExecuteAsync(string.Format(ApiUriConsts.BASEKET_EVENT, "{0}", eventUniqName), @event, cancellationToken);

		/// <summary>
		/// 
		/// </summary>
		/// <param name="event"></param>
		/// <param name="cancellationToken"></param>
		/// <returns></returns>
		public async Task<ServiceResult> SendLoginEventAsync(string eventUniqName, LoginEvent @event, CancellationToken cancellationToken = default) => await ExecuteAsync(string.Format(ApiUriConsts.LOGIN_EVENT, "{0}", eventUniqName), @event, cancellationToken);

		/// <summary>
		/// 
		/// </summary>
		/// <param name="event"></param>
		/// <param name="cancellationToken"></param>
		/// <returns></returns>
		public async Task<ServiceResult> SendLogoutEventAsync(string eventUniqName, LogoutEvent @event, CancellationToken cancellationToken = default) => await ExecuteAsync(string.Format(ApiUriConsts.LOGOUT_EVENT, "{0}", eventUniqName), @event, cancellationToken);

		/// <summary>
		/// 
		/// </summary>
		/// <param name="model"></param>
		/// <param name="cancellationToken"></param>
		/// <returns></returns>
		public async Task<ServiceResult> SendAddToBasketEventAsync(string eventUniqName, AddToBasketEvent model, CancellationToken cancellationToken = default) => await ExecuteAsync(string.Format(ApiUriConsts.ADD_TO_BASEKET_EVENT, "{0}", eventUniqName), model, cancellationToken);

		/// <summary>
		/// 
		/// </summary>
		/// <param name="event"></param>
		/// <param name="cancellationToken"></param>
		/// <returns></returns>
		public async Task<ServiceResult> SendRemoveFromBasketEventAsync(string eventUniqName, RemoveFromBasketEvent @event, CancellationToken cancellationToken = default) => await ExecuteAsync(string.Format(ApiUriConsts.REMOVE_FROM_BASKET_EVENT, "{0}", eventUniqName), @event, cancellationToken);

		/// <summary>
		/// 
		/// </summary>
		/// <param name="event"></param>
		/// <param name="cancellationToken"></param>
		/// <returns></returns>
		public async Task<ServiceResult> SendPageViewEventAsync(string eventUniqName, PageViewEvent @event, CancellationToken cancellationToken = default) => await ExecuteAsync(string.Format(ApiUriConsts.PAGE_VIEW_EVENT, "{0}", eventUniqName), @event, cancellationToken);

		/// <summary>
		/// 
		/// </summary>
		/// <param name="model"></param>
		/// <param name="cancellationToken"></param>
		/// <returns></returns>
		public async Task<ServiceResult> SendGoalEventAsync(string eventUniqName, GoalEvent model, CancellationToken cancellationToken = default) => await ExecuteAsync(string.Format(ApiUriConsts.GOAL_EVENT, "{0}", eventUniqName), model, cancellationToken);

		/// <summary>
		/// 
		/// </summary>
		/// <param name="model"></param>
		/// <param name="cancellationToken"></param>
		/// <returns></returns>
		public async Task<ServiceResult> SendSearchEventAsync(string eventUniqName, SearchEvent model, CancellationToken cancellationToken = default) => await ExecuteAsync(string.Format(ApiUriConsts.SEARCH_EVENT, "{0}", eventUniqName), model, cancellationToken);

		/// <summary>
		/// 
		/// </summary>
		/// <param name="event"></param>
		/// <param name="cancellationToken"></param>
		/// <returns></returns>
		public async Task<ServiceResult> SendCustomEventAsync(string eventUniqName, CustomEvent @event, CancellationToken cancellationToken = default) => await ExecuteAsync(string.Format(ApiUriConsts.CUSTOM_EVENT, "{0}", eventUniqName), @event, cancellationToken);

		public async Task<List<Event>> GetEvents(CancellationToken cancellationToken = default(CancellationToken))
		{
			return await GetRequestAsync<List<Event>>(ApiUriConsts.EVENTS, cancellationToken);
		}

		private async Task<ServiceResult> ExecuteAsync(string path, IBaseEvent @event, CancellationToken cancellationToken)
		{
			@event = await BeginExecutionAsync(@event);
			return await PostRequestAsync(path, @event, cancellationToken);
		}

		public async Task<bool> ValidateToken(CancellationToken cancellationToken = default(CancellationToken))
		{
			return await base.ValidateToken(cancellationToken);
		}

		public virtual async Task<IBaseEvent> BeginExecutionAsync(IBaseEvent @event)
		{
			return @event;
		}
	}
}