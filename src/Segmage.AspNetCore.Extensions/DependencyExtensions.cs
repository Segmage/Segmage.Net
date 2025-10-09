using Microsoft.Extensions.DependencyInjection;
using Segmage.Credential;
using Microsoft.AspNetCore.Http; // Required for IHttpContextAccessor
using System.Linq;
using Microsoft.AspNetCore.Session; // Required for .Any()

namespace Segmage.Core.Extensions
{
	public static class DependencyExtensions
	{
		public static IServiceCollection AddSegmage(this IServiceCollection services, string AccessToken)
		{
			return services.AddSegmage("[DEFAULT]", new AppOptions()
			{
				Credential = new SegmageCredential() { AccessToken = AccessToken }
			});
		}

		public static IServiceCollection AddSegmage(this IServiceCollection services, string AccessToken, string name)
		{
			return services.AddSegmage(name, new AppOptions()
			{
				AppInstanceName = name,
				Credential = new SegmageCredential() { AccessToken = AccessToken }
			});
		}

		public static IServiceCollection AddSegmage(this IServiceCollection services, string name, string AccessToken, string CollectUrl)
		{
			return services.AddSegmage(name, new AppOptions()
			{
				AppInstanceName = name,
				Credential = new SegmageCredential() { AccessToken = AccessToken, CollectUrl = CollectUrl }
			});
		}

		public static IServiceCollection AddSegmage(this IServiceCollection services, AppOptions options) => services.AddSegmage("[DEFAULT]", options);

		public static IServiceCollection AddSegmage(this IServiceCollection services, string name, AppOptions options)
		{
			if (services == null || options == null)
			{
				throw new ArgumentNullException(nameof(services));
			}

			// --- START: Added Checks ---

			// Check if IHttpContextAccessor is already registered. If not, add it.
			// This is equivalent to builder.Services.AddHttpContextAccessor();
			if (!services.Any(d => d.ServiceType == typeof(IHttpContextAccessor)))
			{
				services.AddHttpContextAccessor();
			}

			// Check if a core session service (ISessionStore) is registered. If not, add session services.
			// This is equivalent to builder.Services.AddSession();
			if (!services.Any(d => d.ServiceType == typeof(ISessionStore)))
			{
				services.AddSession();
			}

			// --- END: Added Checks ---

			SegmageApp.CreateInstance(options, name);
			return services;
		}
	}
}