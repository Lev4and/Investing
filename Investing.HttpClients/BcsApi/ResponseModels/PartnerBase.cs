using Newtonsoft.Json;

namespace Investing.HttpClients.BcsApi.ResponseModels
{
    public class PartnerBase
    {
        [JsonProperty("capitalization")]
        public double? Capitalization { get; set; }

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
        public string? BaseAsset { get; set; }

        [JsonProperty("bond_type")]
        public string? BondType { get; set; }

        [JsonProperty("company_logo")]
        public string? CompanyLogo { get; set; }

        [JsonProperty("portfolio_name")]
        public string PortfolioName { get; set; }

        [JsonProperty("sector")]
        public Sector Sector { get; set; }
    }
}
