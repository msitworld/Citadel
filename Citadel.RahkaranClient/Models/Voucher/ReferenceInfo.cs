using Newtonsoft.Json;

namespace Citadel.RahkaranClient.Models.Voucher
{
    public class VoucherReferenceInfo
    {
        public int OriginalEntityCode { get; set; }
        [JsonProperty("OriginalReferenceID")]
        public long OriginalReferenceId { get; set; }
        public int MasterEntityCode { get; set; }
        [JsonProperty("MasterReferenceID")]
        public long MasterReferenceId { get; set; }
        public string ReferenceNumber { get; set; }
        public string Description { get; set; }
        public int Descriminator { get; set; }
    }
}
