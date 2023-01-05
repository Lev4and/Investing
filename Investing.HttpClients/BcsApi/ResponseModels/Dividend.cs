using Newtonsoft.Json;

namespace Investing.HttpClients.BcsApi.ResponseModels
{
    public class Dividend
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("yield")]
        public decimal? Yield { get; set; }

        [JsonProperty("close_price")]
        public decimal ClosePrice { get; set; }

        [JsonProperty("dividend_value")]
        public decimal DividendValue { get; set; }

        [JsonProperty("company_name")]
        public string CompanyName { get; set; }

        [JsonProperty("last_buy_day")]
        public DateTime LastBuyDay { get; set; }

        [JsonProperty("closing_date")]
        public DateTime ClosingDate { get; set; }
    }
}
