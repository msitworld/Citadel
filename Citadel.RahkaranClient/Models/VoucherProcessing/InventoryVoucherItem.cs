using System.Collections.Generic;
using Newtonsoft.Json;

namespace Citadel.RahkaranClient.Models.VoucherProcessing
{
    public class InventoryVoucherItem
    {
        //[JsonProperty("ID")]
        //public long Id { get; set; }
        [JsonProperty("PartID")]
        public long PartId { get; set; }
        public decimal Quantity { get; set; }
        [JsonProperty("UnitID")]
        public long UnitId { get; set; }
        //public decimal? MajorUnitQuantity { get; set; }
        //public decimal? SecondUnitQuantity { get; set; }
        //public string SLCode { get; set; }
        //public string SLName { get; set; }
        //public int CounterpartEntityCode { get; set; }
        //public string CounterpartEntityRef { get; set; }
        //public string Level5DLCode { get; set; }
        //public string Level6DLCode { get; set; }
        //public string Description { get; set; }
        //public int RowNumber { get; set; }
        //public string Additional1 { get; set; }
        //public string Additional2 { get; set; }
        //public string Additional3 { get; set; }
        //public string Additional4 { get; set; }
        //public string Additional5 { get; set; }
        //public long AtfRef { get; set; }
        //public bool HasQualityControl { get; set; }
        //public IList<InventoryVoucherItemTrackingFactor> ItemTrackingFactors { get; set; }
        //public InventoryVoucherItemInfo Info { get; set; }
    }
}
