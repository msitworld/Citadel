using Newtonsoft.Json;

namespace Citadel.RahkaranClient.Models.Authentication
{
    public class AuthenticationSession
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("rsa")]
        public RSAPublicParameters RSA { get; set; }
    }
}
