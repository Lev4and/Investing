using Newtonsoft.Json;

namespace Investing.HttpClients.BcsApi.ResponseModels
{
    public class PartnerQuotations
    {
        [JsonProperty("has_more")]
        public bool? HasMore { get; set; }

        [JsonProperty("total")]
        public int? Total { get; set; }

        [JsonProperty("last_value")]
        public int? LastValue { get; set; }

        [JsonProperty("data")]
        public List<PartnerBase>? Partners { get; set; }
    }
}
