using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Segmage.Models
{
    public class Activity : SegmageEntity
	{
		public string Status { get; set; }
		public DateTime? PlannedDate { get; set; }
		// TZ-03 (2026-08-28): initializer YEREL saat yaziyordu. Bu SDK MUSTERININ sunucusunda
        // kosar; alan wire'dan DOLU gittigi icin Segmage tarafindaki
        // `if (!CompletionDate.HasValue) = UtcNow` guard'ini EZIYORDU -> kalici kolona
        // rastgele tenant yereli. Deger verilmezse sunucu UTC ile doldurur.
        public DateTime? CompletionDate { get; set; }
		public string UserId { get; set; }
    }
}
	