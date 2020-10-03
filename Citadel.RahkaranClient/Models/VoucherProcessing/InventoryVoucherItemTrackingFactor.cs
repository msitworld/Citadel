using System.Runtime.Serialization;
using Citadel.RahkaranClient.Models.Shared;
using Newtonsoft.Json;

namespace Citadel.RahkaranClient.Models.VoucherProcessing
{
    public class InventoryVoucherItemTrackingFactor
    {
        public ExtensionDataObject ExtensionData { get; set; }
        [JsonProperty("Id")]
        public long ID { get; set; }
        public long InventoryVoucherItemRef { get; set; }
        public Binary Version { get; set; }
    }

}
