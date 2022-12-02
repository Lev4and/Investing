using Newtonsoft.Json;

namespace Investing.HttpClients.BcsApi.ResponseModels
{
    public class Partner
    {
        [JsonProperty("qualification")]
        public bool? Qualification { get; set; }

        [JsonProperty("price_scale")]
        public int? PriceScale { get; set; }

        [JsonProperty("portfolio_id")]
        public int? PortfolioId { get; set; }

        [JsonProperty("min_price")]
        public double? MinPrice { get; set; }

        [JsonProperty("max_price")]
        public double? MaxPrice { get; set; }

        [JsonProperty("last_price")]
        public double? LastPrice { get; set; }

        [JsonProperty("open_price")]
        public double? OpenPrice { get; set; }

        [JsonProperty("close_price")]
        public double? ClosePrice { get; set; }

        [JsonProperty("price_change")]
        public double? PriceChange { get; set; }

        [JsonProperty("capitalization")]
        public double? Capitalization { get; set; }

        [JsonProperty("trading_volumes")]
        public double? TradingVolumes { get; set; }

        [JsonProperty("previous_close_price")]
        public double? PreviousClosePrice { get; set; }

        [JsonProperty("price_change_percent")]
        public double? PriceChangePercent { get; set; }

        [JsonProperty("issuer")]
        public string Issuer { get; set; }

        [JsonProperty("exchange")]
        public string Exchange { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("secur_code")]
        public string SecurCode { get; set; }

        [JsonProperty("class_code")]
        public string ClassCode { get; set; }

        [JsonProperty("base_asset")]
        public string BaseAsset { get; set; }

        [JsonProperty("bond_type")]
        public string? BondType { get; set; }

        [JsonProperty("company_logo")]
        public string CompanyLogo { get; set; }

        [JsonProperty("portfolio_name")]
        public string PortfolioName { get; set; }

        [JsonProperty("relative_reference")]
        public string RelativeReference { get; set; }

        [JsonProperty("last_price_time")]
        public DateTime? LastPriceTime { get; set; }

        [JsonProperty("date_time_redemption_format")]
        public DateTime? DateTimeRedemptionFormat { get; set; }

        [JsonProperty("sector")]
        public Sector Sector { get; set; }

        [JsonProperty("graph_data")]
        public List<GraphItem> GraphData { get; set; }
    }
}
