using System;
using System.Collections.Generic;
using Citadel.RahkaranClient.Models.Shared;
using Newtonsoft.Json;

namespace Citadel.RahkaranClient.Models.VoucherProcessing
{
    public class InventoryVoucherInfo
    {
        [JsonProperty("ID")]
        public long Id { get; set; }
        public string State { get; set; }
        public string CounterpartDLCode { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime LastModificationDate { get; set; }
        public long Creator { get; set; }
        public long LastModifier { get; set; }
        public string Number { get; set; }
        public bool Visible { get; set; }
        public bool Editable { get; set; }
        public Binary Version { get; set; }
        public IList<InventoryVoucherItemInfo> InventoryVoucherItemsInfo { get; set; }
    }
}
