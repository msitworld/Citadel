using System;
using Citadel.RahkaranClient.Models.Data;

namespace Citadel.RahkaranClient.Dtos
{
    public class FetchInventoryVoucherItemsDto
    {
        public Filter[] Filters { get; set; }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime FinishDate { get; set; }
        public string StoreRef { get; set; }
        public string VoucherState { get; set; }
        public string PricingState { get; set; }
        public string SlResolvingState { get; set; }
        public string AccountingState { get; set; }
        public string InventoryVoucherDirection { get; set; }
        public string DateTypeFilter { get; set; }
        public string SearchText { get; set; }
        public Sort[] Sorts { get; set; }
    }
}
