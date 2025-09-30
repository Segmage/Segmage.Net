using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Segmage.Models
{
	public class Basket : ProductExchangeBase
	{
		public virtual List<BasketItem> Items { get; set; } 
        public string UserId { get; set; }
    }
}

