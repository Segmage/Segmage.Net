using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace Segmage.AspNetCore.Extensions;

public static class SegmageHttpContext {
    
    static IServiceProvider services = null;

    /// <summary>
    /// Provides static access to the framework's services provider
    /// </summary>
    public static IServiceProvider Services {
        get { return services; }
        set {
            if(services != null) {
                throw new Exception("Can't set once a value has already been set.");
            }
            services = value;
        }
    }

    /// <summary>
    /// Provides static access to the current HttpContext
    /// </summary>
    private static HttpContext Current {
        get {
            var httpContextAccessor = services.GetService(typeof(IHttpContextAccessor)) as IHttpContextAccessor;
            return httpContextAccessor?.HttpContext;
        }
    }

    public static async Task SetSgSession(SgSession value)
    {
        await Current.Session.LoadAsync();
        Current.Session.SetString("__sg", JsonConvert.SerializeObject(value));
    }
    public static async Task<SgSession?> GetSgSession()
    {
        await Current.Session.LoadAsync();
       var sessionItem= Current.Session.GetString("__sg");
       return !string.IsNullOrEmpty(sessionItem) ? JsonConvert.DeserializeObject<SgSession>(sessionItem) : null;
    }

    public static SgSession? GetSgCookie()
    {
        var cookie = Current.Request.Cookies["__sg"];
        if (string.IsNullOrEmpty(cookie)) return null;
        var base64EncodedBytes = Convert.FromBase64String(cookie);
        var item = System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
        return  JsonConvert.DeserializeObject<SgSession?>(item);
    }
}