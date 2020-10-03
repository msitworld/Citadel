using System;
using System.Collections.Generic;

namespace Citadel.RahkaranClient.Models.Voucher
{
    public class VocherData
    {
        public int BranchRef { get; set; }
        public DateTime Date { get; set; }
        //public string Description { get; set; }
        //[JsonProperty("Description_En")]
        //public string DescriptionEn { get; set; }
        //public int FiscalYearRef { get; set; }
        //public int LedgerRef { get; set; }
        public int VoucherTypeRef { get; set; }
        //public string VoucherTypeOwnerSystem { get; set; }
        //public int VoucherTypeCode { get; set; }
        //public int Number { get; set; }
        public string AuxiliaryNumber { get; set; }
        public IList<VoucherItemData> VoucherItems { get; set; }
        //public bool IsCurrencyBased { get; set; }
        //public IList<VoucherReferenceInfo> VoucherReferenceInfo { get; set; }
        //public VoucherState State { get; set; }
        //public bool IsExternal { get; set; }
        //public int Creator { get; set; }
        //public string CreatorName { get; set; }
        //public string StateTitle { get; set; }
    }
}
