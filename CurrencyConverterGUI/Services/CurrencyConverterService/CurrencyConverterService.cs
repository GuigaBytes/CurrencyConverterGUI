using CurrencyConverter.Services;
using CurrencyConverterGUI.Models.Api;

namespace CurrencyConverterGUI.Services.CurrencyConverterService
{
    public class CurrencyConverterService
    {
        public static async Task<decimal> GetCurrencyRate(string fromCurrency, string toCurrency)
        {
            decimal rate = await ExchangeRateService.GetCurrencyRate(fromCurrency, toCurrency);
            ExchangeRateRequestLog.RegisterExchangeRateRequest(fromCurrency, toCurrency, rate);
            return rate;
        }
    }
}
