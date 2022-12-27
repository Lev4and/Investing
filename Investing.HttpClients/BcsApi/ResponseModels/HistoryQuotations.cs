using Newtonsoft.Json;
using System.Collections;

namespace Investing.HttpClients.BcsApi.ResponseModels
{
    [JsonObject]
    public class HistoryQuotations : IEnumerable<Quotation>
    {
        [JsonProperty("scale")]
        public int Scale { get; set; }

        [JsonProperty("s")]
        public string Status { get; set; }

        [JsonProperty("t")]
        public List<long> TimeValues { get; set; }

        [JsonProperty("l")]
        public List<decimal> LowValues { get; set; }

        [JsonProperty("o")]
        public List<decimal> OpenValues { get; set; }

        [JsonProperty("h")]
        public List<decimal> HighValues { get; set; }

        [JsonProperty("c")]
        public List<decimal> CloseValues { get; set; }

        [JsonProperty("v")]
        public List<decimal> VolumeValues { get; set; }

        public IEnumerator<Quotation> GetEnumerator()
        {
            for (var i = 0; i < (TimeValues?.Count ?? 0); i++)
            {
                yield return new Quotation(LowValues.ElementAt(i), HighValues.ElementAt(i), OpenValues.ElementAt(i),
                    CloseValues.ElementAt(i), VolumeValues.ElementAt(i), TimeValues.ElementAt(i));
            }
        }

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

        IEnumerator IEnumerable.GetEnumerator()
        {
            yield return GetEnumerator();
        }
    }
}
