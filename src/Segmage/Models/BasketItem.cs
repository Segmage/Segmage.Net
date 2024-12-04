using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Segmage.Models
{
    public abstract class BasketItem : ProductItem
	{
		public string Id { get; set; }
		public string BasketId { get; set; }
	}
}
