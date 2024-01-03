using Segmage.Models;

namespace Segmage.Services
{
    public class BatchDataSender:SenderBase
    {
        private readonly AppOptions _options;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="options"></param>
        public BatchDataSender(SegmageApp app) : base(app.Options)
        {
            _options = app.Options;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <param name="cancellationToken"></param>
        /// <returns>Task<ServiceResult></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<ServiceResult> SendAsync(DataTable data, CancellationToken cancellationToken = default) => await PostRequestAsync(ApiUriConsts.BATCH_DATA_EVENT, data, cancellationToken);
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <param name="cancellationToken"></param>
        /// <returns>Task<ServiceResult> </returns>
        public async Task<ServiceResult> UploadJsonAsync(DataTable data, CancellationToken cancellationToken = default)
      => await PostRequestAsync(ApiUriConsts.UPLOAD_BATCH_DATA_EVENT, data, cancellationToken);
    }
}