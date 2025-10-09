using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Session;
using Segmage.Models;
using System.Reflection.Metadata;

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
		var session = await SegmageHttpContext.GetSgSession();
		if (session != null) return;
		var cookie = SegmageHttpContext.GetSgCookie();
		if (cookie != null)
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
		if (app.ApplicationServices.GetService(typeof(ISessionStore)) == null)
		{
			throw new InvalidOperationException("Session services are not registered. Please call '.AddSession()' in your Program.cs or ConfigureServices method  before calling UseSegmage method");
		}
		SegmageGlobal.OnBeforeRequestSend = (entity) =>
		{
			if (entity is SegmageAction action)
			{
				var session = SegmageHttpContext.GetSgSession().GetAwaiter().GetResult();
				if (session != null)
				{
					if (Guid.TryParse(session.Id, out var sessionId))
					{
						action.SessionId = sessionId;
					}

					if (Guid.TryParse(session.DeviceId, out var deviceId))
					{
						action.DeviceId = deviceId;
					}

					action.UserId = session.UserId;
				}
			}
			else if (entity is Session sessionAction)
			{
				var session = SegmageHttpContext.GetSgSession().GetAwaiter().GetResult();
				if (session != null)
				{
					if (Guid.TryParse(session.DeviceId, out var deviceId))
					{
						sessionAction.DeviceId = deviceId;
					}
				}
			}
			else
			{
				var session = SegmageHttpContext.GetSgSession().GetAwaiter().GetResult();
				var properties = entity.GetType().GetProperties().ToList();
				var sessionProperty = properties.SingleOrDefault(p => p.Name == "SessionId");
				var deviceProperty = properties.SingleOrDefault(p => p.Name == "DeviceId");
				if (sessionProperty != null)
				{
					sessionProperty.SetValue(entity, Guid.Parse(session?.Id ?? Guid.Empty.ToString()));
				}
				if (deviceProperty != null)
				{
					deviceProperty.SetValue(entity, Guid.Parse(session?.DeviceId ?? Guid.Empty.ToString()));
				}
			}
		};
		return app.UseMiddleware<SegmageMiddleware>();
	}
}