
namespace Segmage.Models
{
    public abstract class BaseEvent
    {
        public string SessionId { get; set; }
        public string UserId { get; set; }
    }
}