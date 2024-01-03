using Microsoft.Extensions.DependencyInjection;

namespace Segmage.Core.Extensions
{
    public static class DependencyExtensions
    {
        public static IServiceCollection AddSegmage(this IServiceCollection services,Action<AppOptions>options)=>services.AddSegmage("[DEFAULT]",options);
      
        public static IServiceCollection AddSegmage(this IServiceCollection services,string name,Action<AppOptions>options)
        {
            var o = new AppOptions();
            options(o);
            if (services == null||options==null) throw new ArgumentNullException(nameof(services));
            services.AddSegmage(name,o);
            return services;
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