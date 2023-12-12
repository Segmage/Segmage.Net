using System.Collections.Generic;

namespace Segmage
{
    public static class AppManager
    {
        public static Dictionary<string, SegmageApp> Apps { get; set; } = new Dictionary<string, SegmageApp>();

    }
}