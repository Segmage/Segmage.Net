using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Segmage.Models
{
    public class Brand360 : SegmageEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        public string IconUrl { get; set; }
    }
}
