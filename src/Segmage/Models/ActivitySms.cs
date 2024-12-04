using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Segmage.Models
{
	public abstract class ActivitySms : Activity
	{
        public string Phone { get; set; }

        public string Content { get; set; }

    }
}
