using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Citadel.RahkaranClient.Models.Voucher;

namespace Citadel.RahkaranClient.Services
{
    public static class VoucherProcessingService
    {
        public static async Task<VoucherInfo> RegisterVoucher(this RahkaranService service, VocherData vocherData)
        {
            var url = "/Financial/VoucherManagement/Services/VoucherService.svc/RegisterVoucher";

            return await service.HttpRequestService.SendAsync<VoucherInfo>(url, HttpMethod.Post, vocherData);
        }

        public static async Task<IList<KeyValuePair<string, string>>> ValidateVoucher(this RahkaranService service, VocherData vocherData)
        {
            var url = "/Financial/VoucherManagement/Services/VoucherService.svc/ValidateVoucher";

            return await service.HttpRequestService.SendAsync<IList<KeyValuePair<string, string>>>(url, HttpMethod.Post, vocherData);
        }
    }
}
