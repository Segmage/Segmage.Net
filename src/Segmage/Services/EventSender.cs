using System.Threading;
using System.Threading.Tasks;
using Segmage.Models;

namespace Segmage.Services
{
    public sealed class EventSender:SenderBase
    {
        private readonly AppOptions _options;
        private string ToRequestUri(string item) => string.Format(item,"{0}", item);
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
        public async Task<ServiceResult> SetSessionAsync(SessionEvent @event,CancellationToken cancellationToken=default)=> await PostRequestAsync(ApiUriConsts.SET_SESSION, @event,cancellationToken);
        
        public async Task<ServiceResult> BasketSyncAsync(string eventUniqName,Basket @event,CancellationToken cancellationToken=default)=> await PostRequestAsync(string.Format(ApiUriConsts.BASEKET_EVENT,"{0}",eventUniqName), @event,cancellationToken);
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dataTableName"></param>
        /// <param name="jsonData"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<ServiceResult> SendDataAsync(string dataTableName, object jsonData,CancellationToken cancellationToken=default)=> await PostRequestAsync(ApiUriConsts.CUSTOM_EVENT, jsonData,cancellationToken);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="event"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<ServiceResult> SendLoginEventAsync(string eventUniqName,LoginEvent @event,CancellationToken cancellationToken=default)=>await PostRequestAsync(string.Format(ApiUriConsts.LOGIN_EVENT,"{0}",eventUniqName), @event,cancellationToken);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="event"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<ServiceResult> SendLogoutEventAsync(string eventUniqName,LogoutEvent @event,CancellationToken cancellationToken=default)=>await PostRequestAsync(string.Format(ApiUriConsts.LOGOUT_EVENT,"{0}",eventUniqName), @event,cancellationToken);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<ServiceResult> SendAddToBasketEventAsync(string eventUniqName,AddToBasketEvent model,CancellationToken cancellationToken=default)=> await PostRequestAsync(string.Format(ApiUriConsts.ADD_TO_BASEKET_EVENT,"{0}",eventUniqName), model,cancellationToken);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="event"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<ServiceResult> SendRemoveFromBasketEventAsync(string eventUniqName,RemoveFromBasketEvent @event,CancellationToken cancellationToken=default)=> await PostRequestAsync(string.Format(ApiUriConsts.REMOVE_FROM_BASKET_EVENT,"{0}",eventUniqName), @event,cancellationToken);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="event"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<ServiceResult> SendPageViewEventAsync(string eventUniqName,PageViewEvent @event,CancellationToken cancellationToken=default)=> await PostRequestAsync(string.Format(ApiUriConsts.PAGE_VIEW_EVENT,"{0}",eventUniqName), @event,cancellationToken);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<ServiceResult> SendGoalEventAsync(string eventUniqName,object model,CancellationToken cancellationToken=default)=>await PostRequestAsync(string.Format(ApiUriConsts.GOAL_EVENT,"{0}",eventUniqName), model,cancellationToken);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<ServiceResult> SendSearchEventAsync(string eventUniqName,object model,CancellationToken cancellationToken=default)=> await PostRequestAsync(string.Format(ApiUriConsts.SEARCH_EVENT,"{0}",eventUniqName), model,cancellationToken);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="event"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<ServiceResult> SendCustomEventAsync(string eventUniqName,CustomEvent @event,CancellationToken cancellationToken=default)=> await PostRequestAsync(string.Format(ApiUriConsts.CUSTOM_EVENT,"{0}",eventUniqName), @event,cancellationToken);
    }
}