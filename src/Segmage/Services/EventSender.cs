using System.Threading;
using System.Threading.Tasks;
using Segmage.Models;

namespace Segmage.Services
{
    public sealed class EventSender:SenderBase
    {
        private readonly AppOptions _options;

        public EventSender(SegmageApp segmageApp):base(segmageApp.Options)
        {
            _options = segmageApp.Options;
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="event"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<ServiceResult> SetSessionAsync(SessionEvent @event,CancellationToken cancellationToken=default)
        {
            return await PostRequestAsync(ApiUriConsts.SET_SESSION, @event,cancellationToken);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dataTableName"></param>
        /// <param name="jsonData"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<ServiceResult> SendDataAsync(string dataTableName, object jsonData,CancellationToken cancellationToken=default)
        {
            return new ServiceResult();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="event"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<ServiceResult> SendLoginEventAsync(LoginEvent @event,CancellationToken cancellationToken=default)
        {
            return await PostRequestAsync(ApiUriConsts.LOGIN_EVENT, @event,cancellationToken);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="event"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<ServiceResult> SendLogoutEventAsync(LogoutEvent @event,CancellationToken cancellationToken=default)
        {
            return await PostRequestAsync(ApiUriConsts.LOGOUT_EVENT, @event,cancellationToken);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<ServiceResult> SendAddToBasketEventAsync(AddToBasketEvent model,CancellationToken cancellationToken=default)
        {
            return await PostRequestAsync(ApiUriConsts.ADD_TO_BASEKET_EVENT, model,cancellationToken);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="event"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<ServiceResult> SendRemoveFromBasketEventAsync(
            RemoveFromBasketEvent @event,CancellationToken cancellationToken=default)
        {
            return await PostRequestAsync(ApiUriConsts.REMOVE_FROM_BASKET_EVENT, @event,cancellationToken);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="event"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<ServiceResult> SendPageViewEventAsync(PageViewEvent @event,CancellationToken cancellationToken=default)
        {
            return await PostRequestAsync(ApiUriConsts.PAGE_VIEW_EVENT, @event,cancellationToken);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<ServiceResult> SendGoalEventAsync(object model,CancellationToken cancellationToken=default)
        {
            return await PostRequestAsync(ApiUriConsts.GOAL_EVENT, model,cancellationToken);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<ServiceResult> SendSearchEventAsync(object model,CancellationToken cancellationToken=default)
        {
            return await PostRequestAsync(ApiUriConsts.SEARCH_EVENT, model,cancellationToken);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="event"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<ServiceResult> SendCustomEventAsync(CustomEvent @event,CancellationToken cancellationToken=default)
        {
            return await PostRequestAsync(ApiUriConsts.CUSTOM_EVENT, @event,cancellationToken);
        }
    }
}