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
        public string AppInstanceName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public  SegmageCredential Credential { get; set; }

        public string CollectUrl { get; set; } = "https://collect.segmage.com";

        /// <summary>
        /// 
        /// </summary>
        /// <param name="accessToken"></param>
        /// <returns>AppOptions</returns>
        public AppOptions FromAccessToken(string accessToken)
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
        /// <returns>AppOptions</returns>
        public static AppOptions FromJson(string json)
        {
           return JsonConvert.DeserializeObject<AppOptions>(json);
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="path"></param>
        /// <returns>AppOptions</returns>
        public static AppOptions FromFile(string path)
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
        /// <returns>AppOptions</returns>
        public static async Task<AppOptions> FromFileAsync(string path)
        {
            using (var stream = File.OpenRead(path))
            {
                return await FromStreamAsync(stream);
            }
        }

        #region Private Members

        private static async Task<AppOptions> FromStreamAsync(Stream stream)
        {
            try
            {
                using (var streamReader = new StreamReader(stream))
                {
                    var json = await streamReader.ReadToEndAsync();
                    using (var reader = new JsonTextReader(new StringReader(json)))
                    {
                        return  JsonSerializer.CreateDefault().Deserialize<AppOptions>(reader);
                    }
                }
            }
            catch (System.Exception e)
            {
                throw new InvalidOperationException("Error deserializing JSON credential data.", e);
            }
        }
       
        private static AppOptions FromStream(Stream stream)
        {
            try
            {
                using (var streamReader = new StreamReader(stream))
                {
                    var json =  streamReader.ReadToEnd();
                    using (var reader = new JsonTextReader(new StringReader(json)))
                    {
                        return  JsonSerializer.CreateDefault().Deserialize<AppOptions>(reader);
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