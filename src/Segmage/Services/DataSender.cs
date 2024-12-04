using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Segmage.Models;

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

		#region General Sender
		/// <summary>
		/// Sends a generic entity (unspecified type) to the server.
		/// </summary>
		public async Task<ServiceResult> SendEntity<TEntity>(TEntity entity, CancellationToken cancellationToken = default)
		{
			return await SendSingle(entity, ModuleTypeEnum.OTHER, cancellationToken);
		}

		/// <summary>
		/// Sends a batch of generic entities to the server.
		/// </summary>
		public async Task<ServiceResult> BatchSendEntity<TEntity>(List<TEntity> entities, CancellationToken cancellationToken = default)
		{
			return await SendBatch(entities, ModuleTypeEnum.OTHER, cancellationToken);
		}
		#endregion

		#region Customer360
		/// <summary>
		/// Sends a single Customer360 entity to the server.
		/// </summary>
		/// <typeparam name="TEntity">The type of the entity to send.</typeparam>
		/// <param name="entity">The entity to be sent.</param>
		/// <param name="cancellationToken">Token to cancel the operation.</param>
		/// <returns>Result of the operation.</returns>
		public async Task<ServiceResult> SendCustomer360<TEntity>(TEntity entity, CancellationToken cancellationToken = default) where TEntity : Customer360
		{
			return await SendSingle(entity, ModuleTypeEnum.ACTIVITY, cancellationToken, "Customer360");
		}

		/// <summary>
		/// Sends a batch of Customer360 entities to the server.
		/// </summary>
		/// <typeparam name="TEntity">The type of the entities to send.</typeparam>
		/// <param name="entities">The list of entities to send.</param>
		/// <param name="cancellationToken">Token to cancel the operation.</param>
		/// <returns>Result of the operation.</returns>
		public async Task<ServiceResult> BatchSendCustomer360<TEntity>(List<TEntity> entities, CancellationToken cancellationToken = default) where TEntity : Customer360
		{
			return await SendBatch(entities, ModuleTypeEnum.ACTIVITY, cancellationToken, "Customer360");
		}
		#endregion

		#region Product
		/// <summary>
		/// Sends a single Product360 entity to the server.
		/// </summary>
		public async Task<ServiceResult> SendProduct360<TEntity>(TEntity entity, CancellationToken cancellationToken = default) where TEntity : Product360
		{
			return await SendSingle(entity, ModuleTypeEnum.PRODUCT360, cancellationToken, "Product360");
		}

		/// <summary>
		/// Sends a batch of Product360 entities to the server.
		/// </summary>
		public async Task<ServiceResult> BatchSendProduct360<TEntity>(List<TEntity> entities, CancellationToken cancellationToken = default) where TEntity : Product360
		{
			return await SendBatch(entities, ModuleTypeEnum.PRODUCT360, cancellationToken, "Product360");
		}
		#endregion

		#region Activity

		/// <summary>
		/// Sends a single Activity entity to the server.
		/// </summary>
		public async Task<ServiceResult> SendActivity<TEntity>(TEntity entity, CancellationToken cancellationToken = default) where TEntity : Activity
		{
			return await SendSingle(entity, ModuleTypeEnum.ACTIVITY, cancellationToken);
		}

		/// <summary>
		/// Sends a batch of Activity entities to the server.
		/// </summary>
		public async Task<ServiceResult> BatchSendActivity<TEntity>(List<TEntity> entities, CancellationToken cancellationToken = default) where TEntity : Activity
		{
			return await SendBatch(entities, ModuleTypeEnum.ACTIVITY, cancellationToken);
		}
		#endregion

		#region Opportunity
		/// <summary>
		/// Sends a single Opportunity entity to the server.
		/// </summary>
		public async Task<ServiceResult> SendOpportunity<TEntity>(TEntity entity, CancellationToken cancellationToken = default) where TEntity : Opportunity
		{
			return await SendSingle(entity, ModuleTypeEnum.OPPORTUNITY, cancellationToken, "Opportunity");
		}

		/// <summary>
		/// Sends a batch of Opportunity entities to the server.
		/// </summary>
		public async Task<ServiceResult> BatchSendOpportunity<TEntity>(List<TEntity> entities, CancellationToken cancellationToken = default) where TEntity : Opportunity
		{
			return await SendBatch(entities, ModuleTypeEnum.OPPORTUNITY, cancellationToken, "Opportunity");
		}
		#endregion

		#region Sales
		/// <summary>
		/// Sends a single Sale entity to the server.
		/// </summary>
		public async Task<ServiceResult> SendSale<TEntity>(TEntity entity, CancellationToken cancellationToken = default) where TEntity : Sale
		{
			return await SendSingle(entity, ModuleTypeEnum.SALES, cancellationToken);
		}

		/// <summary>
		/// Sends a batch of Sale entities to the server.
		/// </summary>
		public async Task<ServiceResult> BatchSendSale<TEntity>(List<TEntity> entities, CancellationToken cancellationToken = default) where TEntity : Sale
		{
			return await SendBatch(entities, ModuleTypeEnum.SALES, cancellationToken);
		}

		/// <summary>
		/// Sends a single SaleItem entity to the server.
		/// </summary>
		public async Task<ServiceResult> SendSaleItem<TEntity>(TEntity entity, CancellationToken cancellationToken = default) where TEntity : ProductSaleItem
		{
			return await SendSingle(entity, ModuleTypeEnum.SALESITEMS, cancellationToken);
		}

		/// <summary>
		/// Sends a batch of SaleItem entities to the server.
		/// </summary>
		public async Task<ServiceResult> BatchSendSaleItem<TEntity>(List<TEntity> entities, CancellationToken cancellationToken = default) where TEntity : Sale	{
			return await SendBatch(entities, ModuleTypeEnum.SALESITEMS, cancellationToken);
		}
		#endregion

		#region PriceOffer
		/// <summary>
		/// Sends a single PriceOffer entity to the server.
		/// </summary>
		public async Task<ServiceResult> SendPriceOffer<TEntity>(TEntity entity, CancellationToken cancellationToken = default) where TEntity : Offer
		{
			return await SendSingle(entity, ModuleTypeEnum.PRICEOFFER, cancellationToken, "PriceOffer");
		}

		/// <summary>
		/// Sends a batch of PriceOffer entities to the server.
		/// </summary>
		public async Task<ServiceResult> BatchSendPriceOffer<TEntity>(List<TEntity> entities, CancellationToken cancellationToken = default) where TEntity : Offer
		{
			return await SendBatch(entities, ModuleTypeEnum.PRICEOFFER, cancellationToken, "PriceOffer");
		}
		#endregion

		#region ProductReturn
		/// <summary>
		/// Sends a single ProductReturn entity to the server.
		/// </summary>
		public async Task<ServiceResult> SendProductReturn<TEntity>(TEntity entity, CancellationToken cancellationToken = default) where TEntity : ProductReturn
		{
			return await SendSingle(entity, ModuleTypeEnum.RETURN, cancellationToken);
		}

		/// <summary>
		/// Sends a batch of ProductReturn entities to the server.
		/// </summary>
		public async Task<ServiceResult> BatchSendProductReturn<TEntity>(List<TEntity> entities, CancellationToken cancellationToken = default) where TEntity : ProductReturn
		{
			return await SendBatch(entities, ModuleTypeEnum.RETURN, cancellationToken);
		}

		/// <summary>
		/// Sends a single ProductReturnItem entity to the server.
		/// </summary>
		public async Task<ServiceResult> SendProductReturnItem<TEntity>(TEntity entity, CancellationToken cancellationToken = default) where TEntity : ProductReturnItem
		{
			return await SendSingle(entity, ModuleTypeEnum.RETURNITEMS, cancellationToken);
		}

		/// <summary>
		/// Sends a batch of ProductReturnItem entities to the server.
		/// </summary>
		public async Task<ServiceResult> BatchSendProductReturnItem<TEntity>(List<TEntity> entities, CancellationToken cancellationToken = default) where TEntity : ProductReturnItem
		{
			return await SendBatch(entities, ModuleTypeEnum.RETURNITEMS, cancellationToken);
		}
		#endregion

		/// <summary>
		/// Helper method for sending a single entity.
		/// </summary>
		private async Task<ServiceResult> SendSingle<TEntity>(TEntity entity, ModuleTypeEnum moduleType, CancellationToken cancellationToken, string typeName = null)
		{
			UploadContext uploader = new UploadContext()
			{
				TypeName = typeName ?? typeof(TEntity).Name,
				ModuleType = (int)moduleType,
				SerializedData = JsonConvert.SerializeObject(entity)
			};
			return await PostRequestAsync(ApiUriConsts.UPLOAD_SINGLE_DATA, uploader, cancellationToken);
		}

		/// <summary>
		/// Helper method for sending a batch of entities.
		/// </summary>
		private async Task<ServiceResult> SendBatch<TEntity>(List<TEntity> entities, ModuleTypeEnum moduleType, CancellationToken cancellationToken, string typeName = null)
		{
			UploadContext uploader = new UploadContext()
			{
				TypeName = typeName ?? typeof(TEntity).Name,
				ModuleType = (int)moduleType,
				SerializedData = JsonConvert.SerializeObject(entities)
			};
			return await PostRequestAsync(ApiUriConsts.UPLOAD_BATCH_DATA, uploader, cancellationToken);
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
