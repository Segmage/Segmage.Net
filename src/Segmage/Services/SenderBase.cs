using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;

namespace Segmage.Services
{
    public abstract class SenderBase
    {
        private readonly AppOptions _options;
        private string ToRequestUri(string path) => string.Format(path, _options.BatchUrl, "{1}");

    /// <summary>
        /// 
        /// </summary>
        /// <param name="options"></param>
        protected SenderBase(AppOptions options)
        {
            _options = options;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="path"></param>
        /// <param name="body"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        protected async Task<ServiceResult> PostRequestAsync(string path, object body,CancellationToken cancellationToken=default)
        {
            var result = new ServiceResult();
            using (var httpClient = new HttpClient())
            {
                using (var request = new HttpRequestMessage(new HttpMethod("POST"),ToRequestUri(path)))
                {
                    request.Headers.TryAddWithoutValidation("Authorization",
                        "Bearer " + _options.Credential.AccessToken);
                    request.Headers.TryAddWithoutValidation("accept", "*/*");
                    var jsonModel = Newtonsoft.Json.JsonConvert.SerializeObject(body);
                    request.Content = new StringContent(jsonModel);
                    request.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");

                    var response = await httpClient.SendAsync(request,cancellationToken);
                    result = new ServiceResult()
                    {
                        StatusCode = response.StatusCode,
                        IsSuccessStatusCode = response.IsSuccessStatusCode
                    };
                    if (response.IsSuccessStatusCode)
                    {
                        result.Data = await response.Content.ReadAsStringAsync();
                    }
                }
            }
            return result;
        }
      
        protected async Task<ServiceResult> GetRequestAsync(string path,CancellationToken cancellationToken=default)
        {
            var result = new ServiceResult();
            using (var httpClient = new HttpClient())
            {
                using (var request = new HttpRequestMessage(new HttpMethod("GET"), ToRequestUri(path)))
                {
                    request.Headers.TryAddWithoutValidation("Authorization",
                        "Bearer " + _options.Credential.AccessToken);
                    request.Headers.TryAddWithoutValidation("accept", "*/*");
                    request.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");
                    var response = await httpClient.SendAsync(request,cancellationToken);
                    result = new ServiceResult()
                    {
                        StatusCode = response.StatusCode,
                        IsSuccessStatusCode = response.IsSuccessStatusCode
                    };
                    if (response.IsSuccessStatusCode)
                    {
                        result.Data = await response.Content.ReadAsStringAsync();
                    }
                }
            }
            return result;
        }

    }
}