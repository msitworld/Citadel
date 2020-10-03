using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Citadel.RahkaranClient.Models.VoucherProcessing
{
    public class InventoryVoucher
    {
        //[JsonProperty("ID")]
        //public long Id { get; set; }
        [JsonProperty("InventoryVoucherSpecificationID")]
        public long InventoryVoucherSpecificationId { get; set; }
        [JsonProperty("StoreID")]
        public long StoreId { get; set; }
        //[JsonProperty("CounterpartStoreID ")]
        //public long CounterpartStoreId { get; set; }
        [JsonProperty("DelivererOrReceiverPartyID")]
        public long? DelivererOrReceiverPartyId { get; set; }
        //public string SLCode { get; set; }
        public DateTime Date { get; set; }
        //public int CounterpartEntityCode { get; set; }
        //public int CounterpartEntityRef { get; set; }
        //public string CounterpartDLCode { get; set; }
        //public string Level5DLCode { get; set; }
        //public string Level6DLCode { get; set; }
        public string Description { get; set; }
        //[JsonProperty("BranchID")]
        //public long BranchId { get; set; }
        //[JsonProperty("FiscalYearID")]
        //public long FiscalYearId { get; set; }
        //public string Additional1 { get; set; }
        //public string Additional2 { get; set; }
        //public string Additional3 { get; set; }
        //public string Additional4 { get; set; }
        //public string Additional5 { get; set; }
        //public int VoucherTypeRef { get; set; }
        public IList<InventoryVoucherItem> Items { get; set; }
        //public InventoryVoucherInfo Info { get; set; }
    }
}
