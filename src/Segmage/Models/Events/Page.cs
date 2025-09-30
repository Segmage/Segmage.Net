using System;

namespace Segmage.Models
{
	public class Page
	{
		public Guid Id { get; set; } = Guid.NewGuid();
		public Guid ProjectId { get; set; }
		public Guid IntegrationId { get; set; }
		public string Title { get; set; }
		public string Url { get; set; }
		public string CreatedSystemUser { get; set; }
		public DateTime CreatedSystemDate { get; set; }
	} 
}