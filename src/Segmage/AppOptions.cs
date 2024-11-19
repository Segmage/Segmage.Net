using System;
using System.IO;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Segmage.Credential;

namespace Segmage
{
    public sealed class AppOptions
    {
        /// <summary>
        /// 
        /// </summary>
        public AppOptions()
        {
            
        }
        public string AppInstanceName { get; set; }="[DEFAULT]";
        /// <summary>
        /// 
        /// </summary>
        public  SegmageCredential Credential { get; set; }
        
    }
}