using Newtonsoft.Json;

namespace Investing.HttpClients.BcsApi.ResponseModels
{
    public class HistoryQuotations
    {
        [JsonProperty("scale")]
        public int Scale { get; set; }

        [JsonProperty("s")]
        public string Status { get; set; }

        [JsonProperty("t")]
        public List<long> TimeValues { get; set; }

        [JsonProperty("l")]
        public List<double> LowValues { get; set; }

        [JsonProperty("o")]
        public List<double> OpenValues { get; set; }

        [JsonProperty("h")]
        public List<double> HighValues { get; set; }

        [JsonProperty("c")]
        public List<double> CloseValues { get; set; }

        [JsonProperty("v")]
        public List<double> VolumeValues { get; set; }

        public IEnumerable<Quotation> GetQuotations()
        {
            var result = new List<Quotation>();

            for (var i = 0; i < (TimeValues?.Count ?? 0); i++)
            {
                result.Add(new Quotation(LowValues.ElementAt(i), HighValues.ElementAt(i), OpenValues.ElementAt(i),
                    CloseValues.ElementAt(i), VolumeValues.ElementAt(i), TimeValues.ElementAt(i)));
            }

            return result;
        }
    }
}
