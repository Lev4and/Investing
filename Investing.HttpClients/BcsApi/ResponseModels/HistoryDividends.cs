using Newtonsoft.Json;

namespace Investing.HttpClients.BcsApi.ResponseModels
{
    public class HistoryDividends : Dividend
    {
        [JsonProperty("actual")]
        public bool Actual { get; set; }

        [JsonProperty("checked")]
        public bool Checked { get; set; }

        [JsonProperty("foreign_stock")]
        public bool ForeignStock { get; set; }

        [JsonProperty("year")]
        public int Year { get; set; }

        [JsonProperty("sector")]
        public int Sector { get; set; }

        [JsonProperty("ticker_id")]
        public int TickerId { get; set; }

        [JsonProperty("isin_code")]
        public string IsinCode { get; set; }

        [JsonProperty("class_code")]
        public string ClassCode { get; set; }

        [JsonProperty("secure_code")]
        public string SecureCode { get; set; }

        [JsonProperty("quote_currency_code")]
        public string? QuoteCurrencyCode { get; set; }

        [JsonProperty("dividend_currency_code")]
        public string DividendCurrencyCode { get; set; }

        [JsonProperty("history_values")]
        public List<decimal> HistoryValues { get; set; }

        [JsonProperty("history_yields")]
        public List<decimal?> HistoryYields { get; set; }

        [JsonProperty("history_dates")]
        public List<DateTime> HistoryDates { get; set; }

        [JsonProperty("previous_dividends")]
        public List<Dividend> Dividends { get; set; }
    }
}
