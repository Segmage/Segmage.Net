using System.Collections.Generic;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Segmage.Models;

namespace Segmage.Services
{
	public abstract class SenderBase
	{
		private readonly AppOptions _options;
		private string ToRequestUri(string path) => string.Format(path, _options.Credential.CollectUrl, "{1}");

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
		/// <returns>Task<ServiceResult> </returns>
		protected async Task<ServiceResult> PostRequestAsync(string path, object body, CancellationToken cancellationToken = default)
		{
			var result = new ServiceResult();
			using (var httpClient = new HttpClient())
			{
				using (var request = new HttpRequestMessage(new HttpMethod("POST"), ToRequestUri(path)))
				{
					request.Headers.TryAddWithoutValidation("Authorization",
						"Bearer " + _options.Credential.AccessToken);
					request.Headers.TryAddWithoutValidation("accept", "*/*");
					var jsonModel = Newtonsoft.Json.JsonConvert.SerializeObject(body);
					request.Content = new StringContent(jsonModel);
					request.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");

					var response = await httpClient.SendAsync(request, cancellationToken);
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

		protected async Task<ServiceResult> PostJsonRequestAsync(string moduleName, string body, CancellationToken cancellationToken = default)
		{
			var result = new ServiceResult();
			using (var httpClient = new HttpClient())
			{
				using (var request = new HttpRequestMessage(new HttpMethod("POST"), ToRequestUri("{0}/dt/JsonRequest")))
				{
					request.Headers.TryAddWithoutValidation("Authorization",
						"Bearer " + _options.Credential.AccessToken);
					request.Headers.TryAddWithoutValidation("accept", "*/*");
					UploadContext uploadContext = new UploadContext()
					{
						TypeName = moduleName,
						SerializedData = body
					};
					request.Content = new StringContent(JsonConvert.SerializeObject(uploadContext));
					request.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");

					var response = await httpClient.SendAsync(request, cancellationToken);
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


		protected async Task<T> GetRequestAsync<T>(string path, CancellationToken cancellationToken = default)
		{
			T result = default(T);
			using (var httpClient = new HttpClient())
			{
				using (var request = new HttpRequestMessage(HttpMethod.Get, ToRequestUri(path)))
				{
					request.Headers.TryAddWithoutValidation("Authorization",
						"Bearer " + _options.Credential.AccessToken);
					request.Headers.TryAddWithoutValidation("accept", "*/*");

					var response = await httpClient.SendAsync(request, cancellationToken);

					if (response.IsSuccessStatusCode)
					{
						var jsonData = await response.Content.ReadAsStringAsync();
						var jsonObject = Newtonsoft.Json.Linq.JObject.Parse(jsonData);
						var data = jsonObject["data"];
						result = data.ToObject<T>();
					}
				}
			}
			return result;
		}

		protected async Task<bool> ValidateToken(CancellationToken cancellationToken = default)
		{
			using (var httpClient = new HttpClient())
			{
				using (var request = new HttpRequestMessage(HttpMethod.Get, ToRequestUri(ApiUriConsts.TOKENVALIDATE)))
				{
					request.Headers.TryAddWithoutValidation("Authorization",
						"Bearer " + _options.Credential.AccessToken);
					request.Headers.TryAddWithoutValidation("accept", "*/*");

					var response = await httpClient.SendAsync(request, cancellationToken);

					if (response.IsSuccessStatusCode)
					{
						return true;
					}
					else
					{
						return false;
					}

				}
			}
			return false; ;
		}
	}
}