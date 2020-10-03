using System.Net.Http;
using System.Threading.Tasks;

namespace Citadel.RahkaranClient.Services
{
    public interface IHttpRequestService
    {
        Task<T> SendAsync<T>(string url, HttpMethod httpMethod, string body = null);
        Task<T> SendAsync<T>(string url, HttpMethod httpMethod, object body);
    }
}
