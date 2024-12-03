using Segmage.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Segmage.Models
{
	public abstract class Activity<TIdType, TUserIdType> : IActivity
	{
		public TIdType Id { get; set; }
		public string Status { get; set; }
		public DateTime? PlannedDate { get; set; }
		public DateTime? CompletionDate { get; set; }
        public TUserIdType UserId { get; set; }
	}
}
