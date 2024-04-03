using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Segmage.Models;
using Segmage.Services;

namespace Segmage.AspNetCore.Extensions.Segmage.Services
{
    public class DataSender : SenderBase
    {
        private readonly AppOptions _options;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="options"></param>
        public DataSender(SegmageApp app) : base(app.Options)
        {
            _options = app.Options;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="entity"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<ServiceResult> SendCustomer360<TEntity>(TEntity entity, CancellationToken cancellationToken = default) where TEntity : Customer360
        {
            return await SendSingle(entity, ModuleTypeEnum.ACTIVITY, cancellationToken, "Customer360");
        }



        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="batch"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<ServiceResult> BatchSendCustomer360<TEntity>(List<TEntity> entities, CancellationToken cancellationToken = default) where TEntity : Customer360
        {
            return await SendBatch(entities, ModuleTypeEnum.ACTIVITY, cancellationToken, "Customer360");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="entity"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<ServiceResult> SendProduct360<TEntity>(TEntity entity, CancellationToken cancellationToken = default) where TEntity : Product360
        {
            return await SendSingle(entity, ModuleTypeEnum.PRODUCT360, cancellationToken, "Product360");
        }


        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="batch"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<ServiceResult> BatchSendProduct360<TEntity>(List<TEntity> entities, CancellationToken cancellationToken = default) where TEntity : Product360
        {
            return await SendBatch(entities, ModuleTypeEnum.PRODUCT360, cancellationToken, "Product360");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="entity"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<ServiceResult> SendEntity<TEntity>(TEntity entity, CancellationToken cancellationToken = default)
        {
            return await SendSingle(entity, ModuleTypeEnum.OTHER, cancellationToken);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="batch"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<ServiceResult> BatchSendEntity<TEntity>(List<TEntity> entities, CancellationToken cancellationToken = default) where TEntity : Product360
        {
            return await SendBatch(entities, ModuleTypeEnum.OTHER, cancellationToken);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="entity"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<ServiceResult> SendActivity<TEntity>(TEntity entity, CancellationToken cancellationToken = default) where TEntity : Activity
        {
            return await SendSingle(entity, ModuleTypeEnum.ACTIVITY, cancellationToken);
        }



        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="batch"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<ServiceResult> BatchSendActivity<TEntity>(List<TEntity> entities, CancellationToken cancellationToken = default) where TEntity : Activity
        {
            return await SendBatch(entities, ModuleTypeEnum.ACTIVITY, cancellationToken);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="entity"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<ServiceResult> SendOpportunity<TEntity>(TEntity entity, CancellationToken cancellationToken = default) where TEntity : Opportunity
        {
            return await SendSingle(entity, ModuleTypeEnum.OPPORTUNITY, cancellationToken);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="batch"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<ServiceResult> BatchSendOpportunity<TEntity>(List<TEntity> entities, CancellationToken cancellationToken = default) where TEntity : Opportunity
        {
            return await SendBatch(entities, ModuleTypeEnum.OPPORTUNITY, cancellationToken);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="entity"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<ServiceResult> SendSale<TEntity>(TEntity entity, CancellationToken cancellationToken = default) where TEntity : Sale
        {
            return await SendSingle(entity, ModuleTypeEnum.SALES, cancellationToken);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="batch"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<ServiceResult> BatchSendSale<TEntity>(List<TEntity> entities, CancellationToken cancellationToken = default) where TEntity : Sale
        {
            return await SendBatch(entities, ModuleTypeEnum.SALES, cancellationToken);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="entity"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<ServiceResult> SendOffer<TEntity>(TEntity entity, CancellationToken cancellationToken = default) where TEntity : Offer
        {
            return await SendSingle(entity, ModuleTypeEnum.PRICEOFFER, cancellationToken);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="batch"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<ServiceResult> BatchSendOffer<TEntity>(List<TEntity> entities, CancellationToken cancellationToken = default) where TEntity : Offer
        {
            return await SendBatch(entities, ModuleTypeEnum.PRICEOFFER, cancellationToken);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="entity"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<ServiceResult> SendOffer<TEntity>(TEntity entity, CancellationToken cancellationToken = default) where TEntity : Offer
        {
            return await SendSingle(entity, ModuleTypeEnum.SALES, cancellationToken);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="batch"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<ServiceResult> BatchSendOffer<TEntity>(List<TEntity> entities, CancellationToken cancellationToken = default) where TEntity : Offer
        {
            return await SendBatch(entities, ModuleTypeEnum.SALES, cancellationToken);
        }


        private async Task<ServiceResult> SendSingle<TEntity>(TEntity entity, ModuleTypeEnum moduleType, CancellationToken cancellationToken, string typeName = null)
        {
            UploadContext uploader = new UploadContext()
            {
                TypeName = typeName == null ? typeof(TEntity).Name : typeName,
                ModuleType = (int)moduleType,
                SerializedData = JsonConvert.SerializeObject(entity)
            };
            return await PostRequestAsync(ApiUriConsts.UPLOAD_SINGLE_DATA, uploader, cancellationToken);
        }

        private async Task<ServiceResult> SendBatch<TEntity>(List<TEntity> entities, ModuleTypeEnum moduleType, CancellationToken cancellationToken, string typeName = null)
        {
            UploadContext uploader = new UploadContext()
            {
                TypeName = typeName == null ? typeof(TEntity).Name : typeName,
                ModuleType = (int)moduleType,
                SerializedData = JsonConvert.SerializeObject(entities)
            };
            return await PostRequestAsync(ApiUriConsts.UPLOAD_BATCH_DATA, uploader, cancellationToken);
        }
    }

    internal class UploadContext
    {
        public string TypeName { get; set; }

        public int ModuleType { get; set; }

        public string SerializedData { get; set; }
    }
}