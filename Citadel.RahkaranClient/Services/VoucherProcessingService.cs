using System.Net.Http;
using System.Threading.Tasks;
using Citadel.RahkaranClient.Models.VoucherProcessing;

namespace Citadel.RahkaranClient.Services
{
    public static class VoucherService
    {
        public static async Task<InventoryVoucherInfo> RegisterInventoryVoucher(this RahkaranService service, InventoryVoucher inventoryVoucher)
        {
            var url = "/Logistics/VoucherProcessing/WebServices/VoucherProcessingService.svc/RegisterVoucher";

            return await service.HttpRequestService.SendAsync<InventoryVoucherInfo>(url, HttpMethod.Post, inventoryVoucher);
        }
    }
}
