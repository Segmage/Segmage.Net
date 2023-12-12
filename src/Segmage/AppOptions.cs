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
       
        /// <summary>
        /// 
        /// </summary>
        /// <param name="accessToken"></param>
        public AppOptions(string accessToken)
        {
            FromAccessToken(accessToken);
        }
        /// <summary>
        /// 
        /// </summary>
        public  SegmageCredential Credential { get; set; }

        public string EventUrl { get; set; } = "https://collect.segmage.dev";
        public string BatchUrl { get; set; } = "https://batch.segmage.dev";

        /// <summary>
        /// 
        /// </summary>
        /// <param name="accessToken"></param>
        /// <returns></returns>
        public SegmageCredential FromAccessToken(string accessToken)
        {
            var json =JsonConvert.SerializeObject(new SegmageCredential()
            {
                AccessToken=accessToken,
            });
            return FromJson(json);
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="json"></param>
        /// <returns></returns>
        public SegmageCredential FromJson(string json)
        {
           return JsonConvert.DeserializeObject<SegmageCredential>(json);
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public SegmageCredential FromFile(string path)
        {
            using (var stream = File.OpenRead(path))
            {
                return  FromStream(stream);
            }
        }
       
        /// <summary>
        /// 
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public async Task<SegmageCredential> FromFileAsync(string path)
        {
            using (var stream = File.OpenRead(path))
            {
                return await FromStreamAsync(stream);
            }
        }

        #region Private Members

        private async Task<SegmageCredential> FromStreamAsync(Stream stream)
        {
            try
            {
                using (var streamReader = new StreamReader(stream))
                {
                    var json = await streamReader.ReadToEndAsync();
                    using (var reader = new JsonTextReader(new StringReader(json)))
                    {
                        return  JsonSerializer.CreateDefault().Deserialize<SegmageCredential>(reader);
                    }
                }
            }
            catch (System.Exception e)
            {
                throw new InvalidOperationException("Error deserializing JSON credential data.", e);
            }
        }
       
        private SegmageCredential FromStream(Stream stream)
        {
            try
            {
                using (var streamReader = new StreamReader(stream))
                {
                    var json =  streamReader.ReadToEnd();
                    using (var reader = new JsonTextReader(new StringReader(json)))
                    {
                        return  JsonSerializer.CreateDefault().Deserialize<SegmageCredential>(reader);
                    }
                }
            }
            catch (System.Exception e)
            {
                throw new InvalidOperationException("Error deserializing JSON credential data.", e);
            }
        }

        #endregion
    }
}