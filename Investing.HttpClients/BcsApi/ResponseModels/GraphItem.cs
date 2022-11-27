using Newtonsoft.Json;

namespace Investing.HttpClients.BcsApi.ResponseModels
{
    public class GraphItem
    {
        [JsonProperty("close")]
        public double? Close { get; set; }

        [JsonProperty("trade_date")]
        public DateTime? TradeDate { get; set; }
    }
}
