using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Segmage.Models;

namespace Segmage.Services
{
	public class BatchDataSender : SenderBase
	{
		private readonly AppOptions _options;

		/// <summary>
		/// 
		/// </summary>
		/// <param name="options"></param>
		public BatchDataSender(SegmageApp app) : base(app.Options)
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
		public async Task<ServiceResult> UploadCustomer360<TEntity>(TEntity entity, CancellationToken cancellationToken = default) where TEntity : Customer360
		{
			return await UploadSingle(entity, ModuleTypeEnum.ACTIVITY, cancellationToken);
		}



		/// <summary>
		/// 
		/// </summary>
		/// <typeparam name="TEntity"></typeparam>
		/// <param name="batch"></param>
		/// <param name="cancellationToken"></param>
		/// <returns></returns>
		public async Task<ServiceResult> BatchUploadCustomer360<TEntity>(List<TEntity> entities, CancellationToken cancellationToken = default) where TEntity : Customer360
		{
			return await UploadBatch(entities, ModuleTypeEnum.ACTIVITY, cancellationToken);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <typeparam name="TEntity"></typeparam>
		/// <param name="entity"></param>
		/// <param name="cancellationToken"></param>
		/// <returns></returns>
		public async Task<ServiceResult> UploadProduct360<TEntity>(TEntity entity, CancellationToken cancellationToken = default) where TEntity : Product360
		{
			return await UploadSingle(entity, ModuleTypeEnum.PRODUCT360, cancellationToken);
		}


		/// <summary>
		/// 
		/// </summary>
		/// <typeparam name="TEntity"></typeparam>
		/// <param name="batch"></param>
		/// <param name="cancellationToken"></param>
		/// <returns></returns>
		public async Task<ServiceResult> BatchUploadProduct360<TEntity>(List<TEntity> entities, CancellationToken cancellationToken = default) where TEntity : Product360
		{
			return await UploadBatch(entities, ModuleTypeEnum.PRODUCT360, cancellationToken);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <typeparam name="TEntity"></typeparam>
		/// <param name="entity"></param>
		/// <param name="cancellationToken"></param>
		/// <returns></returns>
		public async Task<ServiceResult> UploadEntity<TEntity>(TEntity entity, CancellationToken cancellationToken = default)
		{
			return await UploadSingle(entity, ModuleTypeEnum.OTHER, cancellationToken);
		}


		/// <summary>
		/// 
		/// </summary>
		/// <typeparam name="TEntity"></typeparam>
		/// <param name="entity"></param>
		/// <param name="cancellationToken"></param>
		/// <returns></returns>
		public async Task<ServiceResult> UploadActivity<TEntity>(TEntity entity, CancellationToken cancellationToken = default) where TEntity : Activity
		{
			return await UploadSingle(entity, ModuleTypeEnum.ACTIVITY, cancellationToken);
		}



		/// <summary>
		/// 
		/// </summary>
		/// <typeparam name="TEntity"></typeparam>
		/// <param name="batch"></param>
		/// <param name="cancellationToken"></param>
		/// <returns></returns>
		public async Task<ServiceResult> BatchUploadActivity<TEntity>(List<TEntity> entities, CancellationToken cancellationToken = default) where TEntity : Activity
		{
			return await UploadBatch(entities, ModuleTypeEnum.ACTIVITY, cancellationToken);
		}


		/// <summary>
		/// 
		/// </summary>
		/// <typeparam name="TEntity"></typeparam>
		/// <param name="batch"></param>
		/// <param name="cancellationToken"></param>
		/// <returns></returns>
		public async Task<ServiceResult> BatchUploadEntity<TEntity>(List<TEntity> entities, CancellationToken cancellationToken = default)
		{
			return await UploadBatch(entities, ModuleTypeEnum.OTHER, cancellationToken);
		}


		private async Task<ServiceResult> UploadSingle<TEntity>(TEntity entity, ModuleTypeEnum moduleType, CancellationToken cancellationToken)
		{
			string typeName = typeof(TEntity).Name;
			UploadContext uploader = new UploadContext()
			{
				TypeName = typeName,
				ModuleType = (int)moduleType,
				SerializedData = JsonConvert.SerializeObject(entity)
			};
			return await PostRequestAsync(ApiUriConsts.UPLOAD_SINGLE_DATA, uploader, cancellationToken);
		}

		private async Task<ServiceResult> UploadBatch<TEntity>(List<TEntity> entities, ModuleTypeEnum moduleType, CancellationToken cancellationToken)
		{
			string typeName = typeof(TEntity).Name;
			UploadContext uploader = new UploadContext()
			{
				TypeName = typeName,
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