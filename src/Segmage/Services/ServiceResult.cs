using System.Net;

namespace Segmage.Services
{
    public class ServiceResult
    {
        public HttpStatusCode StatusCode { get; set; }
        public bool IsSuccessStatusCode { get; set; } = false;
        public int SuccessCount { get; set; } = 0;
        public int FailCount { get; set; } = 0;
        public object Data { get; set; }
    }
}