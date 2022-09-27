using Newtonsoft.Json;

namespace ConsumeJWT.Models
{
    public class TokenParams
    {
        [JsonProperty("token")]
        public string token { get; set; } = string.Empty;
        [JsonProperty("provCde")]
        public string ProvCde { get; set; } = string.Empty;

        [JsonProperty("phaseNo")]
        public string PhaseNo { get; set; } = string.Empty;

        //[JsonProperty("entityID")]
        //public string EntityID { get; set; } = string.Empty;
    }
}
