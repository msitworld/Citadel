using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Citadel.RahkaranClient.Models.Voucher
{
    public class VoucherInfo
    {
        [JsonProperty("ID")]
        public long Id { get; set; }
        public int Sequence { get; set; }
        public int Number { get; set; }
        public int DailyNumber { get; set; }
        public DateTime VoucherDate { get; set; }
        public long? MasterEntityRef { get; set; }
        public IList<KeyValuePair<string,string>> ValidationErrors { get; set; }
        //public IList<AbstractVoucherItemInfo> VoucherItemInformation { get; set; }
    }
}
