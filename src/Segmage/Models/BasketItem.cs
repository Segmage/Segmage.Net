using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Segmage.Models.Interfaces;

namespace Segmage.Models
{
    public abstract class BasketItem<TIdType, TBasketIdType, TProductIdType> : ProductItem<TProductIdType>, IBasketItem
	{
		public TIdType Id { get; set; }
		public TBasketIdType BasketId { get; set; }
	}
}
