using System;
using System.Collections.Generic;
using System.Data;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Segmage.Models;
using DataTable = Segmage.Models.DataTable;

namespace Segmage.Services
{
	/// <summary>
	/// Service class for sending various types of data (e.g., Customer360, Product360) to an API.
	/// </summary>
	public class DataSender : SenderBase
	{
		/// <summary>
		/// Initializes a new instance of the DataSender class with the given application options.
		/// </summary>
		/// <param name="options">Application options used for configuration.</param>
		public DataSender(AppOptions options) : base(options) { }


		public async Task<ServiceResult> SendCustomer360<TEntity>(TEntity entity, CancellationToken cancellationToken = default(CancellationToken))
		{
			return await PostRequestAsync(ApiUriConsts.CUSTOMER60, new List<TEntity>() { entity }, cancellationToken);
		}
		public async Task<ServiceResult> SendBatchCustomer360<TEntity>(List<TEntity> entities, CancellationToken cancellationToken = default(CancellationToken))
		{
			return await PostRequestAsync(ApiUriConsts.CUSTOMER60, entities, cancellationToken);
		}

		public async Task<ServiceResult> SendProduct<TEntity>(TEntity entity, CancellationToken cancellationToken = default(CancellationToken))
		{
			return await PostRequestAsync(ApiUriConsts.PRODUCT360, new List<TEntity>() { entity }, cancellationToken);
		}
		public async Task<ServiceResult> SendBatchProduct<TEntity>(List<TEntity> entities, CancellationToken cancellationToken = default(CancellationToken))
		{
			return await PostRequestAsync(ApiUriConsts.PRODUCT360, entities, cancellationToken);
		}

		public async Task<ServiceResult> SendBasket<TEntity>(TEntity entity, CancellationToken cancellationToken = default(CancellationToken))
		{
			return await PostRequestAsync(ApiUriConsts.BASKET, new List<TEntity>() { entity }, cancellationToken);
		}

		public async Task<ServiceResult> FlushBasket(string userId, CancellationToken cancellationToken = default(CancellationToken))
		{
			return await PostRequestAsync(ApiUriConsts.BASKET_FLUSH, new List<FlushRequest>() { new FlushRequest() { UserId = userId } }, cancellationToken);
		}

		public async Task<ServiceResult> SendBatchBasket<TEntity>(List<TEntity> entities, CancellationToken cancellationToken = default(CancellationToken))
		{
			return await PostRequestAsync(ApiUriConsts.BASKET, entities, cancellationToken);
		}

		public async Task<ServiceResult> SendOpportunity<TEntity>(TEntity entity, CancellationToken cancellationToken = default(CancellationToken))
		{
			return await PostRequestAsync(ApiUriConsts.OPPORTUNITY, new List<TEntity>() { entity }, cancellationToken);
		}
		public async Task<ServiceResult> SendBatchOpportunity<TEntity>(List<TEntity> entities, CancellationToken cancellationToken = default(CancellationToken))
		{
			return await PostRequestAsync(ApiUriConsts.OPPORTUNITY, entities, cancellationToken);
		}

		public async Task<ServiceResult> SendSale<TEntity>(TEntity entity, CancellationToken cancellationToken = default(CancellationToken))
		{
			return await PostRequestAsync(ApiUriConsts.SALE, new List<TEntity>() { entity }, cancellationToken);
		}
		public async Task<ServiceResult> SendBatchSale<TEntity>(List<TEntity> entities, CancellationToken cancellationToken = default(CancellationToken))
		{
			return await PostRequestAsync(ApiUriConsts.SALE, entities, cancellationToken);
		}

		public async Task<ServiceResult> SendLead<TEntity>(TEntity entity, CancellationToken cancellationToken = default(CancellationToken))
		{
			return await PostRequestAsync(ApiUriConsts.LEAD, new List<TEntity>() { entity }, cancellationToken);
		}
		public async Task<ServiceResult> SendBatchLead<TEntity>(List<TEntity> entities, CancellationToken cancellationToken = default(CancellationToken))
		{
			return await PostRequestAsync(ApiUriConsts.LEAD, entities, cancellationToken);
		}

		public async Task<ServiceResult> SendReturn<TEntity>(TEntity entity, CancellationToken cancellationToken = default(CancellationToken))
		{
			return await PostRequestAsync(ApiUriConsts.RETURN, new List<TEntity>() { entity }, cancellationToken);
		}
		public async Task<ServiceResult> SendBatchReturn<TEntity>(List<TEntity> entities, CancellationToken cancellationToken = default(CancellationToken))
		{
			return await PostRequestAsync(ApiUriConsts.RETURN, entities, cancellationToken);
		}

		public async Task<ServiceResult> SendActivityAppointment<TEntity>(TEntity entity, CancellationToken cancellationToken = default(CancellationToken))
		{
			return await PostRequestAsync(ApiUriConsts.ACTIVITYAPPOINTMENT, new List<TEntity>() { entity }, cancellationToken);
		}
		public async Task<ServiceResult> SendBatch<TEntity>(List<TEntity> entities, CancellationToken cancellationToken = default(CancellationToken))
		{
			return await PostRequestAsync(ApiUriConsts.ACTIVITYAPPOINTMENT, entities, cancellationToken);
		}

		public async Task<ServiceResult> SendActivityMeeting<TEntity>(TEntity entity, CancellationToken cancellationToken = default(CancellationToken))
		{
			return await PostRequestAsync(ApiUriConsts.ACTIVITYMEETING, new List<TEntity>() { entity }, cancellationToken);
		}
		public async Task<ServiceResult> SendBatchActivityMeeting<TEntity>(List<TEntity> entities, CancellationToken cancellationToken = default(CancellationToken))
		{
			return await PostRequestAsync(ApiUriConsts.ACTIVITYMEETING, entities, cancellationToken);
		}

		public async Task<ServiceResult> SendActivityPhone<TEntity>(TEntity entity, CancellationToken cancellationToken = default(CancellationToken))
		{
			return await PostRequestAsync(ApiUriConsts.ACTIVITYPHONE, new List<TEntity>() { entity }, cancellationToken);
		}
		public async Task<ServiceResult> SendBatchActivityPhone<TEntity>(List<TEntity> entities, CancellationToken cancellationToken = default(CancellationToken))
		{
			return await PostRequestAsync(ApiUriConsts.ACTIVITYPHONE, entities, cancellationToken);
		}

		public async Task<ServiceResult> SendActivitySupport<TEntity>(TEntity entity, CancellationToken cancellationToken = default(CancellationToken))
		{
			return await PostRequestAsync(ApiUriConsts.ACTIVITYSUPPORT, new List<TEntity>() { entity }, cancellationToken);
		}
		public async Task<ServiceResult> SendBatchActivitySupport<TEntity>(List<TEntity> entities, CancellationToken cancellationToken = default(CancellationToken))
		{
			return await PostRequestAsync(ApiUriConsts.ACTIVITYSUPPORT, entities, cancellationToken);
		}

		public async Task<ServiceResult> SendOther<TEntity>(string moduleName, TEntity entity, CancellationToken cancellationToken = default(CancellationToken))
		{
			UploadContext uploadContext = new UploadContext()
			{
				ModuleType = (int)ModuleTypeEnum.OTHER,
				TypeName = moduleName,
				SerializedData = JsonConvert.SerializeObject(new List<TEntity>() { entity })
			};
			return await PostRequestAsync(ApiUriConsts.OTHER, uploadContext, cancellationToken);
		}
		public async Task<ServiceResult> SendBatchOther<TEntity>(string moduleName, List<TEntity> entities, CancellationToken cancellationToken = default(CancellationToken))
		{
			UploadContext uploadContext = new UploadContext()
			{
				ModuleType = (int)ModuleTypeEnum.OTHER,
				TypeName = moduleName,
				SerializedData = JsonConvert.SerializeObject(entities)
			};
			return await PostRequestAsync(ApiUriConsts.OTHER, uploadContext, cancellationToken);
		}

		public async Task<ServiceResult> SendJson(string moduleName, string json, CancellationToken cancellationToken = default)
		{
			return await PostJsonRequestAsync(moduleName, json, cancellationToken);
		}

		public async Task<List<DataTable>> GetDataTables(CancellationToken cancellationToken = default(CancellationToken))
		{
			return await GetRequestAsync<List<DataTable>>(ApiUriConsts.DATATABLE, cancellationToken);
		}

		public async Task<bool> ValidateToken(CancellationToken cancellationToken = default(CancellationToken))
		{
			return await base.ValidateToken(cancellationToken);
		}

	}

	/// <summary>
	/// Represents the context for uploading data.
	/// </summary>
	public class UploadContext
	{
		/// <summary>
		/// The name of the entity type being uploaded.
		/// </summary>
		public string TypeName { get; set; }

		/// <summary>
		/// The module type (e.g., Activity, Product360) represented as an integer.
		/// </summary>
		public int ModuleType { get; set; }

		/// <summary>
		/// The serialized data to be uploaded.
		/// </summary>
		public string SerializedData { get; set; }
	}
}
