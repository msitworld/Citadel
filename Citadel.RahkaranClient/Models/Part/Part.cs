using Newtonsoft.Json;

namespace Citadel.RahkaranClient.Models.Part
{
    public class Part
    {
        public string Code { get; set; }
        public string Name { get; set; }
        [JsonProperty("Name_En")]
        public string NameEn { get; set; }
        public long MajorUnitID { get; set; }
        public string State { get; set; }
        public string Nature { get; set; }
        public bool IsInputDocumentSuspended { get; set; }
        public bool IsOutputDocumentSuspended { get; set; }
        public decimal? Length { get; set; }
        public decimal? Height { get; set; }
        public decimal? Weight { get; set; }
        public decimal? Width { get; set; }
        public PartInfo Info { get; set; }
    }
}
