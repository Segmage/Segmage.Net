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
		// Her request başında cookie'den oku ve AsyncLocal'e kaydet
		var sgSession = SegmageHttpContext.GetSgCookie();
		if (sgSession != null)
		{
			SegmageRequestContext.Current = sgSession;
		}

		await _next(context);

		// Request bitince temizle
		SegmageRequestContext.Clear();
	}
}

public static class SessionMiddlewareExtensions
{
	public static IApplicationBuilder UseSegmage(this IApplicationBuilder app)
	{
		SegmageHttpContext.Services = app.ApplicationServices;

		SegmageGlobal.OnBeforeRequestSend = (entity) =>
		{
			// AsyncLocal'den session bilgisini al
			var session = SegmageRequestContext.Current;

			if (session == null)
				return;

			if (entity is SegmageAction action)
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
			else if (entity is Session sessionAction)
			{
				if (Guid.TryParse(session.DeviceId, out var deviceId))
				{
					sessionAction.DeviceId = deviceId;
				}
			}
			else
			{
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