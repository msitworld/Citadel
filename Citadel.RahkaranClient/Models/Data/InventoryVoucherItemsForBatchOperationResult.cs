using System;
using Newtonsoft.Json;

namespace Citadel.RahkaranClient.Models.Data
{
    public class InventoryVoucherItemsForBatchOperationResult
    {
        [JsonProperty("ID")]
		public int Id { get; set; }
		public string Number { get; set; }
		public string VoucherSpecificationName { get; set; }
		public string StoreName { get; set; }
		public DateTime Date { get; set; }
		[JsonProperty("Date_Display")]
		public string DateDisplay { get; set; }
		public string ReferenceVoucherNumber { get; set; }
		public string PartCode { get; set; }
        [JsonProperty("PartCode_Display")]
		public string PartCodeDisplay { get; set; }
		public string PartName { get; set; }
        [JsonProperty("PartName_Display")]
		public string PartNameDisplay { get; set; }
		public string UnitName { get; set; }
        [JsonProperty("UnitName_Display")]
        public string UnitNameDisplay { get; set; }
		public string MajorUnitQuantity { get; set; }
        [JsonProperty("MajorUnitQuantity_Display")]
		public string MajorUnitQuantity_Display { get; set; }
		public string SecondUnitQuantity { get; set; }
        [JsonProperty("SecondUnitQuantity_Display")]
		public string SecondUnitQuantityDisplay { get; set; }
		public string CounterpartEntityText { get; set; }
		public bool State { get; set; }
        [JsonProperty("State_Display")]
		public string StateDisplay { get; set; }
		public string DelivererOrReceiverPartyName { get; set; }
		public string Branch { get; set; }
		public string Description { get; set; }
		public string Additional1 { get; set; }
		public string Additional2 { get; set; }
		public string Additional3 { get; set; }
		public string Additional4 { get; set; }
		public string Additional5 { get; set; }
		public string Creator { get; set; }
	}
}
