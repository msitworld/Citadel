using Citadel.RahkaranClient.Models.Authentication;

namespace Citadel.RahkaranClient.Services
{
    public class RahkaranService
    {
        internal readonly IHttpRequestService HttpRequestService;

        public RahkaranService(IHttpRequestService httpRequestService, Configuration sessionConfiguration)
        {
            SessionContext.Create(sessionConfiguration);
            HttpRequestService = httpRequestService;
        }

        public RahkaranService(Configuration sessionConfiguration)
        {
            SessionContext.Create(sessionConfiguration);

            HttpRequestService = new HttpRequestService();
        }
    } }
