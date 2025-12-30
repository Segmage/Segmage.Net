using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Segmage.Models;
using Segmage.Models.Entities;

namespace Segmage.Services
{
	public class DataSender : SenderBase
	{
		private readonly string _baseUrl;
		/// <summary>
		/// Initializes a new instance of the DataSender class with the given application options.
		/// </summary>
		/// <param name="options">Application options used for configuration.</param>
		public DataSender(AppOptions options) : base(options) {
			_baseUrl = options.Credential.CollectUrl;
		}

		#region Customer360 Methods

		public async Task<ServiceResult> SaveCustomer360(Customer360 entity, CancellationToken cancellationToken = default) =>
			await PostRequestAsync(string.Format(ApiUriConsts.CUSTOMER360, _baseUrl), entity, cancellationToken);

		public async Task<ServiceResult> SaveBatchCustomer360(List<Customer360> entities, CancellationToken cancellationToken = default) =>
			await PostRequestAsync(string.Format(ApiUriConsts.CUSTOMER360_BATCH, _baseUrl), entities, cancellationToken);

		public async Task<ServiceResult> UpdateCustomer360(Customer360 entity, CancellationToken cancellationToken = default) =>
			await PutRequestAsync(string.Format(ApiUriConsts.CUSTOMER360, _baseUrl), entity, cancellationToken);

		public async Task<ServiceResult> UpdateBatchCustomer360(List<Customer360> entities, CancellationToken cancellationToken = default) =>
			await PutRequestAsync(string.Format(ApiUriConsts.CUSTOMER360_BATCH, _baseUrl), entities, cancellationToken);

		public async Task<ServiceResult> DeleteCustomer360(string id, CancellationToken cancellationToken = default)
		{
			var path = string.Format(ApiUriConsts.CUSTOMER360_BY_ID, _baseUrl, id);
			return await DeleteRequestAsync(path, cancellationToken);
		}

		#endregion

		#region Product Methods

		public async Task<ServiceResult> SaveProduct(Product360 entity, CancellationToken cancellationToken = default) =>
			await PostRequestAsync(string.Format(ApiUriConsts.PRODUCT360, _baseUrl), entity, cancellationToken);

		public async Task<ServiceResult> SaveBatchProduct(List<Product360> entities, CancellationToken cancellationToken = default) =>
			await PostRequestAsync(string.Format(ApiUriConsts.PRODUCT360_BATCH, _baseUrl), entities, cancellationToken);

		public async Task<ServiceResult> UpdateProduct(Product360 entity, CancellationToken cancellationToken = default) =>
			await PutRequestAsync(string.Format(ApiUriConsts.PRODUCT360, _baseUrl), entity, cancellationToken);

		public async Task<ServiceResult> UpdateBatchProduct(List<Product360> entities, CancellationToken cancellationToken = default) =>
			await PutRequestAsync(string.Format(ApiUriConsts.PRODUCT360_BATCH, _baseUrl), entities, cancellationToken);

		public async Task<ServiceResult> DeleteProduct(string id, CancellationToken cancellationToken = default)
		{
			var path = string.Format(ApiUriConsts.PRODUCT360_BY_ID, _baseUrl, id);
			return await DeleteRequestAsync(path, cancellationToken);
		}

		#endregion

		#region Basket Methods

		public async Task<ServiceResult> SaveBasket(Basket entity, CancellationToken cancellationToken = default) =>
			await PostRequestAsync(string.Format(ApiUriConsts.BASKET, _baseUrl), entity, cancellationToken);

		public async Task<ServiceResult> SaveBatchBasket(List<Basket> entities, CancellationToken cancellationToken = default) =>
			await PostRequestAsync(string.Format(ApiUriConsts.BASKET_BATCH, _baseUrl), entities, cancellationToken);

		public async Task<ServiceResult> UpdateBasket(Basket entity, CancellationToken cancellationToken = default) =>
			await PutRequestAsync(string.Format(ApiUriConsts.BASKET, _baseUrl), entity, cancellationToken);

		public async Task<ServiceResult> UpdateBatchBasket(List<Basket> entities, CancellationToken cancellationToken = default) =>
			await PutRequestAsync(string.Format(ApiUriConsts.BASKET_BATCH, _baseUrl), entities, cancellationToken);

		public async Task<ServiceResult> DeleteBasket(string id, CancellationToken cancellationToken = default)
		{
			var path = string.Format(ApiUriConsts.BASKET_BY_ID, _baseUrl, id);
			return await DeleteRequestAsync(path, cancellationToken);
		}
		public async Task<ServiceResult> FlushBasket(string userId, CancellationToken cancellationToken = default) =>
			await PostRequestAsync(string.Format(ApiUriConsts.BASKET_FLUSH, _baseUrl), new FlushRequest { UserId = userId }, cancellationToken);

		#endregion

		#region Opportunity Methods

		public async Task<ServiceResult> SaveOpportunity(Opportunity entity, CancellationToken cancellationToken = default) =>
			await PostRequestAsync(string.Format(ApiUriConsts.OPPORTUNITY, _baseUrl), entity, cancellationToken);

		public async Task<ServiceResult> SaveBatchOpportunity(List<Opportunity> entities, CancellationToken cancellationToken = default) =>
			await PostRequestAsync(string.Format(ApiUriConsts.OPPORTUNITY_BATCH, _baseUrl), entities, cancellationToken);

		public async Task<ServiceResult> UpdateOpportunity(Opportunity entity, CancellationToken cancellationToken = default) =>
			await PutRequestAsync(string.Format(ApiUriConsts.OPPORTUNITY, _baseUrl), entity, cancellationToken);

		public async Task<ServiceResult> UpdateBatchOpportunity(List<Opportunity> entities, CancellationToken cancellationToken = default) =>
			await PutRequestAsync(string.Format(ApiUriConsts.OPPORTUNITY_BATCH, _baseUrl), entities, cancellationToken);

		public async Task<ServiceResult> DeleteOpportunity(string id, CancellationToken cancellationToken = default)
		{
			var path = string.Format(ApiUriConsts.OPPORTUNITY_BY_ID, _baseUrl, id);
			return await DeleteRequestAsync(path, cancellationToken);
		}

		#endregion

		#region PriceOffer Methods

		public async Task<ServiceResult> SavePriceOffer(Offer entity, CancellationToken cancellationToken = default) =>
			await PostRequestAsync(string.Format(ApiUriConsts.PRICEOFFER, _baseUrl), entity, cancellationToken);

		public async Task<ServiceResult> SaveBatchPriceOffer(List<Offer> entities, CancellationToken cancellationToken = default) =>
			await PostRequestAsync(string.Format(ApiUriConsts.PRICEOFFER_BATCH, _baseUrl), entities, cancellationToken);

		public async Task<ServiceResult> UpdatePriceOffer(Offer entity, CancellationToken cancellationToken = default) =>
			await PutRequestAsync(string.Format(ApiUriConsts.PRICEOFFER, _baseUrl), entity, cancellationToken);

		public async Task<ServiceResult> UpdateBatchPriceOffer(List<Offer> entities, CancellationToken cancellationToken = default) =>
			await PutRequestAsync(string.Format(ApiUriConsts.PRICEOFFER_BATCH, _baseUrl), entities, cancellationToken);

		public async Task<ServiceResult> DeletePriceOffer(string id, CancellationToken cancellationToken = default)
		{
			var path = string.Format(ApiUriConsts.PRICEOFFER_BY_ID, _baseUrl, id);
			return await DeleteRequestAsync(path, cancellationToken);
		}

		#endregion

		#region Sale Methods

		public async Task<ServiceResult> SaveSale(Sale entity, CancellationToken cancellationToken = default) =>
			await PostRequestAsync(string.Format(ApiUriConsts.SALE, _baseUrl), entity, cancellationToken);

		public async Task<ServiceResult> SaveBatchSale(List<Sale> entities, CancellationToken cancellationToken = default) =>
			await PostRequestAsync(string.Format(ApiUriConsts.SALE_BATCH, _baseUrl), entities, cancellationToken);

		public async Task<ServiceResult> UpdateSale(Sale entity, CancellationToken cancellationToken = default) =>
			await PutRequestAsync(string.Format(ApiUriConsts.SALE, _baseUrl), entity, cancellationToken);

		public async Task<ServiceResult> UpdateBatchSale(List<Sale> entities, CancellationToken cancellationToken = default) =>
			await PutRequestAsync(string.Format(ApiUriConsts.SALE_BATCH, _baseUrl), entities, cancellationToken);

		public async Task<ServiceResult> DeleteSale(string id, CancellationToken cancellationToken = default)
		{
			var path = string.Format(ApiUriConsts.SALE_BY_ID, _baseUrl, id);
			return await DeleteRequestAsync(path, cancellationToken);
		}

		#endregion

		#region Lead Methods

		public async Task<ServiceResult> SaveLead(Lead entity, CancellationToken cancellationToken = default) =>
			await PostRequestAsync(string.Format(ApiUriConsts.LEAD, _baseUrl), entity, cancellationToken);

		public async Task<ServiceResult> SaveBatchLead(List<Lead> entities, CancellationToken cancellationToken = default) =>
			await PostRequestAsync(string.Format(ApiUriConsts.LEAD_BATCH, _baseUrl), entities, cancellationToken);

		public async Task<ServiceResult> UpdateLead(Lead entity, CancellationToken cancellationToken = default) =>
			await PutRequestAsync(string.Format(ApiUriConsts.LEAD, _baseUrl), entity, cancellationToken);

		public async Task<ServiceResult> UpdateBatchLead(List<Lead> entities, CancellationToken cancellationToken = default) =>
			await PutRequestAsync(string.Format(ApiUriConsts.LEAD_BATCH, _baseUrl), entities, cancellationToken);

		public async Task<ServiceResult> DeleteLead(string id, CancellationToken cancellationToken = default)
		{
			var path = string.Format(ApiUriConsts.LEAD_BY_ID, _baseUrl, id);
			return await DeleteRequestAsync(path, cancellationToken);
		}

		#endregion

		#region Return Methods

		public async Task<ServiceResult> SaveReturn(ProductReturn entity, CancellationToken cancellationToken = default) =>
			await PostRequestAsync(string.Format(ApiUriConsts.RETURN, _baseUrl), entity, cancellationToken);

		public async Task<ServiceResult> SaveBatchReturn(List<ProductReturn> entities, CancellationToken cancellationToken = default) =>
			await PostRequestAsync(string.Format(ApiUriConsts.RETURN_BATCH, _baseUrl), entities, cancellationToken);

		public async Task<ServiceResult> UpdateReturn(ProductReturn entity, CancellationToken cancellationToken = default) =>
			await PutRequestAsync(string.Format(ApiUriConsts.RETURN, _baseUrl), entity, cancellationToken);

		public async Task<ServiceResult> UpdateBatchReturn(List<ProductReturn> entities, CancellationToken cancellationToken = default) =>
			await PutRequestAsync(string.Format(ApiUriConsts.RETURN_BATCH, _baseUrl), entities, cancellationToken);

		public async Task<ServiceResult> DeleteReturn(string id, CancellationToken cancellationToken = default)
		{
			var path = string.Format(ApiUriConsts.RETURN_BY_ID, _baseUrl, id);
			return await DeleteRequestAsync(path, cancellationToken);
		}

		#endregion

		#region ActivityAppointment Methods

		public async Task<ServiceResult> SaveActivityAppointment(ActivityAppointment entity, CancellationToken cancellationToken = default) =>
			await PostRequestAsync(string.Format(ApiUriConsts.ACTIVITYAPPOINTMENT, _baseUrl), entity, cancellationToken);

		public async Task<ServiceResult> SaveBatchActivityAppointment(List<ActivityAppointment> entities, CancellationToken cancellationToken = default) =>
			await PostRequestAsync(string.Format(ApiUriConsts.ACTIVITYAPPOINTMENT_BATCH, _baseUrl), entities, cancellationToken);

		public async Task<ServiceResult> UpdateActivityAppointment(ActivityAppointment entity, CancellationToken cancellationToken = default) =>
			await PutRequestAsync(string.Format(ApiUriConsts.ACTIVITYAPPOINTMENT, _baseUrl), entity, cancellationToken);

		public async Task<ServiceResult> UpdateBatchActivityAppointment(List<ActivityAppointment> entities, CancellationToken cancellationToken = default) =>
			await PutRequestAsync(string.Format(ApiUriConsts.ACTIVITYAPPOINTMENT_BATCH, _baseUrl), entities, cancellationToken);

		public async Task<ServiceResult> DeleteActivityAppointment(string id, CancellationToken cancellationToken = default)
		{
			var path = string.Format(ApiUriConsts.ACTIVITYAPPOINTMENT_BY_ID, _baseUrl, id);
			return await DeleteRequestAsync(path, cancellationToken);
		}

		#endregion

		#region ActivityMeeting Methods

		public async Task<ServiceResult> SaveActivityMeeting(ActivityMeeting entity, CancellationToken cancellationToken = default) =>
			await PostRequestAsync(string.Format(ApiUriConsts.ACTIVITYMEETING, _baseUrl), entity, cancellationToken);

		public async Task<ServiceResult> SaveBatchActivityMeeting(List<ActivityMeeting> entities, CancellationToken cancellationToken = default) =>
			await PostRequestAsync(string.Format(ApiUriConsts.ACTIVITYMEETING_BATCH, _baseUrl), entities, cancellationToken);

		public async Task<ServiceResult> UpdateActivityMeeting(ActivityMeeting entity, CancellationToken cancellationToken = default) =>
			await PutRequestAsync(string.Format(ApiUriConsts.ACTIVITYMEETING, _baseUrl), entity, cancellationToken);

		public async Task<ServiceResult> UpdateBatchActivityMeeting(List<ActivityMeeting> entities, CancellationToken cancellationToken = default) =>
			await PutRequestAsync(string.Format(ApiUriConsts.ACTIVITYMEETING_BATCH, _baseUrl), entities, cancellationToken);

		public async Task<ServiceResult> DeleteActivityMeeting(string id, CancellationToken cancellationToken = default)
		{
			var path = string.Format(ApiUriConsts.ACTIVITYMEETING_BY_ID, _baseUrl, id);
			return await DeleteRequestAsync(path, cancellationToken);
		}

		#endregion

		#region ActivityPhone Methods

		public async Task<ServiceResult> SaveActivityPhone(ActivityPhone entity, CancellationToken cancellationToken = default) =>
			await PostRequestAsync(string.Format(ApiUriConsts.ACTIVITYPHONE, _baseUrl), entity, cancellationToken);

		public async Task<ServiceResult> SaveBatchActivityPhone(List<ActivityPhone> entities, CancellationToken cancellationToken = default) =>
			await PostRequestAsync(string.Format(ApiUriConsts.ACTIVITYPHONE_BATCH, _baseUrl), entities, cancellationToken);

		public async Task<ServiceResult> UpdateActivityPhone(ActivityPhone entity, CancellationToken cancellationToken = default) =>
			await PutRequestAsync(string.Format(ApiUriConsts.ACTIVITYPHONE, _baseUrl), entity, cancellationToken);

		public async Task<ServiceResult> UpdateBatchActivityPhone(List<ActivityPhone> entities, CancellationToken cancellationToken = default) =>
			await PutRequestAsync(string.Format(ApiUriConsts.ACTIVITYPHONE_BATCH, _baseUrl), entities, cancellationToken);

		public async Task<ServiceResult> DeleteActivityPhone(string id, CancellationToken cancellationToken = default)
		{
			var path = string.Format(ApiUriConsts.ACTIVITYPHONE_BY_ID, _baseUrl, id);
			return await DeleteRequestAsync(path, cancellationToken);
		}

		#endregion

		#region ActivitySupport Methods

		public async Task<ServiceResult> SaveActivitySupport(ActivitySupport entity, CancellationToken cancellationToken = default) =>
			await PostRequestAsync(string.Format(ApiUriConsts.ACTIVITYSUPPORT, _baseUrl), entity, cancellationToken);

		public async Task<ServiceResult> SaveBatchActivitySupport(List<ActivitySupport> entities, CancellationToken cancellationToken = default) =>
			await PostRequestAsync(string.Format(ApiUriConsts.ACTIVITYSUPPORT_BATCH, _baseUrl), entities, cancellationToken);

		public async Task<ServiceResult> UpdateActivitySupport(ActivitySupport entity, CancellationToken cancellationToken = default) =>
			await PutRequestAsync(string.Format(ApiUriConsts.ACTIVITYSUPPORT, _baseUrl), entity, cancellationToken);

		public async Task<ServiceResult> UpdateBatchActivitySupport(List<ActivitySupport> entities, CancellationToken cancellationToken = default) =>
			await PutRequestAsync(string.Format(ApiUriConsts.ACTIVITYSUPPORT_BATCH, _baseUrl), entities, cancellationToken);

		public async Task<ServiceResult> DeleteActivitySupport(string id, CancellationToken cancellationToken = default)
		{
			var path = string.Format(ApiUriConsts.ACTIVITYSUPPORT_BY_ID, _baseUrl, id);
			return await DeleteRequestAsync(path, cancellationToken);
		}

		#endregion


		#region MobileToken Methods

		public async Task<ServiceResult> SaveMobilePushToken(MobilePushToken entity, CancellationToken cancellationToken = default) =>
			await PostRequestAsync(string.Format(ApiUriConsts.MOBILEPUSHTOKEN, _baseUrl), entity, cancellationToken);

		public async Task<ServiceResult> SaveBatchMobilePushToken(List<MobilePushToken> entities, CancellationToken cancellationToken = default) =>
			await PostRequestAsync(string.Format(ApiUriConsts.MOBILEPUSHTOKEN_BATCH, _baseUrl), entities, cancellationToken);

		public async Task<ServiceResult> UpdateMobilePushToken(MobilePushToken entity, CancellationToken cancellationToken = default) =>
			await PutRequestAsync(string.Format(ApiUriConsts.MOBILEPUSHTOKEN, _baseUrl), entity, cancellationToken);

		public async Task<ServiceResult> UpdateBatchMobilePushToken(List<MobilePushToken> entities, CancellationToken cancellationToken = default) =>
			await PutRequestAsync(string.Format(ApiUriConsts.MOBILEPUSHTOKEN_BATCH, _baseUrl), entities, cancellationToken);

		public async Task<ServiceResult> DeleteMobilePushToken(string id, CancellationToken cancellationToken = default)
		{
			var path = string.Format(ApiUriConsts.MOBILEPUSHTOKEN_BY_ID, _baseUrl, id);
			return await DeleteRequestAsync(path, cancellationToken);
		}

		#endregion

		#region Other Methods (Generic)

		public async Task<ServiceResult> SaveOther(object entity, CancellationToken cancellationToken = default) =>
			await PostRequestAsync(string.Format(ApiUriConsts.OTHER, _baseUrl), entity, cancellationToken);

		public async Task<ServiceResult> SaveBatchOther(List<object> entities, CancellationToken cancellationToken = default) =>
			await PostRequestAsync(string.Format(ApiUriConsts.OTHER_BATCH, _baseUrl), entities, cancellationToken);

		public async Task<ServiceResult> UpdateOther(object entity, CancellationToken cancellationToken = default) =>
			await PutRequestAsync(string.Format(ApiUriConsts.OTHER, _baseUrl), entity, cancellationToken);

		public async Task<ServiceResult> UpdateBatchOther(List<object> entities, CancellationToken cancellationToken = default) =>
			await PutRequestAsync(string.Format(ApiUriConsts.OTHER_BATCH, _baseUrl), entities, cancellationToken);

		public async Task<ServiceResult> DeleteOther(string id, CancellationToken cancellationToken = default)
		{
			var path = string.Format(ApiUriConsts.OTHER_BY_ID, _baseUrl, id);
			return await DeleteRequestAsync(path, cancellationToken);
		}

		#endregion

		#region Utility Methods

		public async Task<ServiceResult> SendJson(string moduleName, string json, CancellationToken cancellationToken = default) =>
			await PostJsonRequestAsync(moduleName, json, cancellationToken);

		public async Task<List<DataTable>> GetDataTables(CancellationToken cancellationToken = default) =>
			await GetRequestAsync<List<DataTable>>(ApiUriConsts.DATATABLE, cancellationToken);

		public async Task<bool> ValidateToken(CancellationToken cancellationToken = default) =>
			await base.ValidateToken(cancellationToken);

		#endregion

	}

	#region Helper Classes

	/// <summary>
	/// Represents a request to flush a basket.
	/// </summary>
	public class FlushRequest
	{
		public string UserId { get; set; }
	}


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
	#endregion
}