using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace Segmage.AspNetCore.Extensions;

public class SegmageMiddleware
{
    private readonly RequestDelegate _next;

    public SegmageMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    { 
        await Set();
        await _next(context);
    }

    private async Task Set()
    {
        var session=await SegmageHttpContext.GetSgSession();
        if (session != null) return;
        var cookie = SegmageHttpContext.GetSgCookie();
        if (cookie!=null)
        {
           await SegmageHttpContext.SetSgSession(cookie);
        }
    }
}

/// <summary>
/// 
/// </summary>
public static class SessionMiddlewareExtensions
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="app"></param>
    /// <returns>IApplicationBuilder</returns>
    public static IApplicationBuilder UseSegmage(this IApplicationBuilder app)
    {
        SegmageHttpContext.Services = app.ApplicationServices;
       // app.UseSession();
        return app.UseMiddleware<SegmageMiddleware>();
    }
}