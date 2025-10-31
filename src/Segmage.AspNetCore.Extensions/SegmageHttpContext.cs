using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace Segmage.AspNetCore.Extensions;

public static class SegmageHttpContext
{
	static IServiceProvider services = null;

	public static IServiceProvider Services
	{
		get { return services; }
		set
		{
			if (services != null)
			{
				throw new Exception("Can't set once a value has already been set.");
			}
			services = value;
		}
	}

	private static HttpContext Current
	{
		get
		{
			var httpContextAccessor = services.GetService(typeof(IHttpContextAccessor)) as IHttpContextAccessor;
			return httpContextAccessor?.HttpContext;
		}
	}

	public static SgSession? GetSgCookie()
	{
		try
		{
			var cookie = Current?.Request?.Cookies["__sg"];

			if (string.IsNullOrEmpty(cookie))
				return null;

			var base64EncodedBytes = Convert.FromBase64String(cookie);
			var item = System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
			return JsonConvert.DeserializeObject<SgSession>(item);
		}
		catch (Exception)
		{
			return null;
		}
	}
}