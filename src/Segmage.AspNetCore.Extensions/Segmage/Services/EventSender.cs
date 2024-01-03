using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Segmage.AspNetCore.Extensions;
using Segmage.AspNetCore.Extensions.Exceptions;
using Segmage.Models;

namespace Segmage.Services
{
    public sealed class EventSender:SenderBase
    {
        private readonly SegmageApp _segmageApp;
        private readonly AppOptions _options;
        private string ToRequestUri(string item) => string.Format(item,"{0}", item);

        public EventSender(SegmageApp segmageApp):base(segmageApp.Options)
        {
            _segmageApp = segmageApp;
            _options = segmageApp.Options;
        }
        
        public async Task<ServiceResult> BasketSyncAsync(string eventUniqName,Basket @event,CancellationToken cancellationToken=default)=> await ExecuteAsync(string.Format(ApiUriConsts.BASEKET_EVENT,"{0}",eventUniqName), @event,cancellationToken);
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dataTableName"></param>
        /// <param name="jsonData"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<ServiceResult> SendDataAsync(string dataTableName, DataTable jsonData,CancellationToken cancellationToken=default)=> await PostRequestAsync(ApiUriConsts.CUSTOM_EVENT, jsonData,cancellationToken);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="event"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<ServiceResult> SendLoginEventAsync(string eventUniqName,LoginEvent @event,CancellationToken cancellationToken=default)=>await ExecuteAsync(string.Format(ApiUriConsts.LOGIN_EVENT,"{0}",eventUniqName), @event,cancellationToken);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="event"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<ServiceResult> SendLogoutEventAsync(string eventUniqName,LogoutEvent @event,CancellationToken cancellationToken=default)=>await ExecuteAsync(string.Format(ApiUriConsts.LOGOUT_EVENT,"{0}",eventUniqName), @event,cancellationToken);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<ServiceResult> SendAddToBasketEventAsync(string eventUniqName,AddToBasketEvent model,CancellationToken cancellationToken=default)=> await ExecuteAsync(string.Format(ApiUriConsts.ADD_TO_BASEKET_EVENT,"{0}",eventUniqName), model,cancellationToken);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="event"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<ServiceResult> SendRemoveFromBasketEventAsync(string eventUniqName,RemoveFromBasketEvent @event,CancellationToken cancellationToken=default)=> await ExecuteAsync(string.Format(ApiUriConsts.REMOVE_FROM_BASKET_EVENT,"{0}",eventUniqName), @event,cancellationToken);
        

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<ServiceResult> SendGoalEventAsync(string eventUniqName,GoalEvent model,CancellationToken cancellationToken=default)=>await ExecuteAsync(string.Format(ApiUriConsts.GOAL_EVENT,"{0}",eventUniqName), model,cancellationToken);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<ServiceResult> SendSearchEventAsync(string eventUniqName,SearchEvent model,CancellationToken cancellationToken=default)=> await ExecuteAsync(string.Format(ApiUriConsts.SEARCH_EVENT,"{0}",eventUniqName), model,cancellationToken);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="event"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<ServiceResult> SendCustomEventAsync(string eventUniqName,CustomEvent @event,CancellationToken cancellationToken=default)=> await ExecuteAsync(string.Format(ApiUriConsts.CUSTOM_EVENT,"{0}",eventUniqName), @event,cancellationToken);

        private async Task<ServiceResult> ExecuteAsync(string path, BaseEvent @event, CancellationToken cancellationToken)
        {
            var session =await _segmageApp.GetSession();
            if (session == null) throw new SessionNullException("Please set Session Id");
            @event.SessionId = session.Id;
            @event.UserId = session.UserId;
            return  await PostRequestAsync(path, @event,cancellationToken);

        }
    }
}