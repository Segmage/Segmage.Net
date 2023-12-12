namespace Segmage.Models
{
    public class SessionEvent
    {
        public string UserId { get; set; }
        public string DeviceNo { get; set; }
        public string Browser { get; set; }
        public string BrowserVersion { get; set; }
        public string Platform { get; set; }
        public string PlatformVersion { get; set; }
        public string PlatformProcessor { get; set; }
        public string CharacterSet { get; set; }
        public string Color { get; set; }
        public string DeviceType { get; set; }
        public string GoogleAnalyticsId { get; set; }
        public string Ip { get; set; }
        public string Language { get; set; }
        public string Screen { get; set; }
        public string Time { get; set; }
        public string TimeZone { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
        public string Referer { get; set; }
    }
}