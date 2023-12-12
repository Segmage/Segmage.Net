namespace Segmage.Models
{
    public class RemoveFromBasketEvent : BaseEvent
    {
        public ProductItem Product { get; set; }
    }
}