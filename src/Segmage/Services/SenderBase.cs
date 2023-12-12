using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;

namespace Segmage.Services
{
    public abstract class SenderBase
    {
        private readonly AppOptions _options;

        protected SenderBase(AppOptions options)
        {
            _options = options;
        }

        protected async Task<ServiceResult> PostRequestAsync(string url, object body,CancellationToken cancellationToken=default)
        {
            var result = new ServiceResult();
            using (var httpClient = new HttpClient())
            {
                using (var request = new HttpRequestMessage(new HttpMethod("POST"), url))
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
      
        protected async Task<ServiceResult> GetRequestAsync(string url,CancellationToken cancellationToken=default)
        {
            var result = new ServiceResult();
            using (var httpClient = new HttpClient())
            {
                using (var request = new HttpRequestMessage(new HttpMethod("GET"), url))
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