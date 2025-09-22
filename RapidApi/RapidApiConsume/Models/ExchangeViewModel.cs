using Newtonsoft.Json;

namespace RapidApiConsume.Models
{
    public class ExchangeViewModel
    {
        [JsonProperty("data")]
        public ExchangeData Data { get; set; }

        public class ExchangeData
        {
            [JsonProperty("exchange_rates")]
            public Exchange_Rates[] ExchangeRates { get; set; }

            [JsonProperty("base_currency_date")]
            public string BaseCurrencyDate { get; set; }

            [JsonProperty("base_currency")]
            public string BaseCurrency { get; set; }
        }

        public class Exchange_Rates
        {
            [JsonProperty("currency")]
            public string Currency { get; set; }

            [JsonProperty("exchange_rate_buy")]
            public string ExchangeRateBuy { get; set; }
        }
    }
}