
namespace Segmage.Models
{
    public class AddToBasketEvent : BaseEvent
    {
        public ProductItem Product { get; set; }
    }
}