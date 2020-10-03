using Newtonsoft.Json;

namespace Citadel.RahkaranClient.Models.Voucher
{
    public class AbstractVoucherItemInfo
    {
        [JsonProperty("VoucherItemID")]
        public long VoucherItemId { get; set; }
        public int RowNumber { get; set; }
    }
}
