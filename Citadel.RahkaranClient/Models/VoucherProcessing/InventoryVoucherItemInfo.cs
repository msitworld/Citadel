using System.Collections.Generic;
using Citadel.RahkaranClient.Models.Shared;
using Newtonsoft.Json;

namespace Citadel.RahkaranClient.Models.VoucherProcessing
{
    public class InventoryVoucherItemInfo
    {
        [JsonProperty("ID")]
        public long Id { get; set; }
        public long InventoryVoucherRef { get; set; }
        public Binary Version { get; set; }
        public List<InventoryVoucherItemTrackingFactor> InventoryVoucherItemTrackingFactorInfo { get; set; }

    }
}
