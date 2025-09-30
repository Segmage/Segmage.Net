
using System;

namespace Segmage.Models
{
	public class Session
	{
		public Guid Id { get; set; } = Guid.NewGuid();
		public Guid ProjectId { get; set; }
		public Guid IntegrationId { get; set; }
		public Guid DeviceId { get; set; }
		public Guid PageId { get; set; }
		public DateTime Created { get; set; } = DateTime.UtcNow;
		public string GoogleAnalyticsId { get; set; }
		public string Time { get; set; }
		public string UserId { get; set; }
		public double? Latitude { get; set; }
		public double? Longitude { get; set; }
		public string Ip { get; set; }
		public long? AsnNumber { get; set; }
		public string AsnName { get; set; }
		public string Country { get; set; }
		public string City { get; set; }
		public string Town { get; set; }
		public string Referer { get; set; }
		public string RefererSource { get; set; }
		public string RefererMedium { get; set; }
		public string Term { get; set; }
		public string Sgclid { get; set; }
		public string FullName { get; set; }
		public bool? IsFullNameReliable { get; set; }
		public Guid? LeadId { get; set; }
		public DateTime? LastActiveDate { get; set; }
		public string UtmId { get; set; }
		public string UtmSource { get; set; }
		public string UtmMedium { get; set; }
		public string UtmCampaign { get; set; }
		public string UtmTerm { get; set; }
		public string UtmContent { get; set; }
		public Guid? CampaignId { get; set; }
		public Guid? StepId { get; set; }
		public Guid? CampaignItemId { get; set; }
		public string LinkIdentifier { get; set; }
		public string Gclid { get; set; }
		public string Fbclid { get; set; }
		public string CreatedSystemUser { get; set; }
		public DateTime CreatedSystemDate { get; set; }
		public string DeviceBrowser { get; set; }
		public string DeviceBrowserVersion { get; set; }
		public string DeviceDeviceType { get; set; }
		public string DeviceLanguage { get; set; }
		public string DevicePlatform { get; set; }
		public string DevicePlatformVersion { get; set; }
		public string DevicePlatformProcessor { get; set; }
		public string DeviceScreen { get; set; }
		public string DeviceTimeZone { get; set; }
	} 
}