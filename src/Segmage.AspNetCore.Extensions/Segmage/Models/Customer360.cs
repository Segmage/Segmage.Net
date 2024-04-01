using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Segmage.Models
{
	public abstract class Customer360
	{
		public string FullName { get; set; }
		public string ProfileUrl { get; set; }
		public string ProfileImageUrl { get; set; }
		public string Email { get; set; }
		public string Phone { get; set; }
		public string MobilePhone { get; set; }
		public DateTime DateOfBirth { get; set; }
		public string Gender { get; set; }
		public string Province { get; set; }
		public string District { get; set; }
		public string Country { get; set; }
		public string Neighbourhood { get; set; }
		public string TaxNumber { get; set; }
		public string TaxOffice { get; set; }
		public bool IsEmailGranted { get; set; }
		public bool IsCallGranted { get; set; }
		public bool IsSmsGranted { get; set; }
		public bool IsWebPushGranted { get; set; }
		public bool IsMobilePushGranted { get; set; }
	}
}
