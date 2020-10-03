using System.Net.Http;
using System.Threading.Tasks;
using Citadel.RahkaranClient.Models.Part;

namespace Citadel.RahkaranClient.Services
{
    public static class ProductService
    {
        public static async Task<Part> GetPartByCode(this RahkaranService service, int code)
        {
            var url = $"/Logistics/MaterialManagement/WebServices/MaterialManagementService.svc/GetPartByCode?code={code}";

            return await service.HttpRequestService.SendAsync<Part>(url, HttpMethod.Get);
        }
    }
}
