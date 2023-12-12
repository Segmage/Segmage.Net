using System;
using System.Threading;
using System.Threading.Tasks;
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
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<ServiceResult> SendAsync(DataTable data, CancellationToken cancellationToken = default)
        {
            
            throw new NotImplementedException();
        }
    }
}