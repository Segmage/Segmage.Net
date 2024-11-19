using Microsoft.Extensions.DependencyInjection;
using Segmage.Credential;

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
        public static IServiceCollection AddSegmage(this IServiceCollection services, string AccessToken,string name)
        {
            return services.AddSegmage(name, new AppOptions()
            {
                AppInstanceName = name,
                Credential = new SegmageCredential() { AccessToken = AccessToken }
            });
        }
        public static IServiceCollection AddSegmage(this IServiceCollection services,string name, string AccessToken,string CollectUrl)
        {
            return services.AddSegmage(name, new AppOptions()
            {
                AppInstanceName = name,
                Credential = new SegmageCredential() { AccessToken = AccessToken ,CollectUrl = CollectUrl}
            });
        }
        public static IServiceCollection AddSegmage(this IServiceCollection services,AppOptions options)=>services.AddSegmage("[DEFAULT]",options);
        
        public static IServiceCollection AddSegmage(this IServiceCollection services,string name,AppOptions options) 
        {
            if (services == null||options==null) throw new ArgumentNullException(nameof(services));
            SegmageApp.CreateInstance(options,name);
            return services;
        }
        
    }
}