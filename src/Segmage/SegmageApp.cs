using System.Collections.Generic;
using Segmage.Services;

namespace Segmage
{
    /// <summary>
    /// SegmageApp
    /// </summary>
    public sealed class SegmageApp
    { 
        const string DEFAULT_INSTANCE = "[DEFAULT]";
        /// <summary>
        /// AppOptions
        /// </summary>
        public AppOptions Options { get; internal set; }
        public string Name { get; internal set; }

        /// <summary>
        /// SegmageApp
        /// </summary>
        /// <param name="name"></param>
        /// <param name="options"></param>
        public SegmageApp(string name,AppOptions options)
        {
            Options = options;
            Name = name;
            EventSender = new EventSender(this);
            BatchDataSender = new DataSender(this);
        }

        /// <summary>
        /// 
        /// </summary>
        public static SegmageApp DefaultInstance => GetInstance();

        /// <summary>
        /// Create SegmageApp
        /// </summary>
        /// <param name="options"></param>
        /// <param name="name"></param>
        /// <returns>SegmageApp</returns>
        public static SegmageApp CreateInstance(AppOptions options, string name =DEFAULT_INSTANCE)
        {
            
            if (GetInstance(name) == null)
            {
                AppManager.Apps.Add(name, new SegmageApp(name,options));
            }
            return GetInstance(name);
        }

        /// <summary>
        /// Get SegmageApp
        /// </summary>
        /// <param name="name"></param>
        /// <returns>SegmageApp</returns>
        public static SegmageApp GetInstance(string name =DEFAULT_INSTANCE)
        {
            AppManager.Apps.TryGetValue(name, out var app);
            return app;
        }

        /// <summary>
        /// 
        /// </summary>
        public EventSender EventSender { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DataSender BatchDataSender { get; set; }

    }
}