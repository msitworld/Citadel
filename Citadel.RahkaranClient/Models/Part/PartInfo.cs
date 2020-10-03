using Citadel.RahkaranClient.Models.Shared;
using Newtonsoft.Json;

namespace Citadel.RahkaranClient.Models.Part
{
    public class PartInfo
    {
        [JsonProperty("ID")]
        public long Id { get; set; }
        public Binary Version { get; set; }
    }
}
