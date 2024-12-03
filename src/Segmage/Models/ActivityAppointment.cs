using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Segmage.Models
{
	public abstract class ActivityAppointment<TIdType, TUserIdType> : Activity<TIdType, TUserIdType>
	{
        public string Location { get; set; }
    }
}
