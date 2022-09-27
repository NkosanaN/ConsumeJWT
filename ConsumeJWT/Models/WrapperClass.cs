using Newtonsoft.Json;

namespace ConsumeJWT.Models
{
    public class WrapperClass
    {
        [JsonProperty("Error")]
        public string Error;

        [JsonProperty("PhaseDetail")]
        public PhaseDetail PhaseDetail;
    }
}
