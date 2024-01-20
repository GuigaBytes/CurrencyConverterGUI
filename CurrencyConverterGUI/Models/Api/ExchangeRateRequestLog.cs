using CurrencyConverterGUI.Data;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace CurrencyConverterGUI.Models.Api
{
    public class ExchangeRateRequestLog : ApiRequestLog
    {
        private static string LogName = "ExchangeRateService";
        public required string FromCurrency { get; set; }
        public required string ToCurrency { get; set; }
        public decimal Rate { get; set; }

        public static void RegisterExchangeRateRequest(string fromCurrency, string toCurrency, decimal rate)
        {
            using var db = new CurrencyConverterDbContext();
            var exchangeRateLog = new ExchangeRateRequestLog
            {
                ApiName = LogName,
                FromCurrency = fromCurrency,
                ToCurrency = toCurrency,
                Rate = rate,
                LastRequestTimestamp = DateTime.UtcNow
            };

            db.Add(exchangeRateLog);
            db.SaveChanges();
        }

        public static ExchangeRateRequestLog? GetLastApiRequest(string? fromCurrency = null, string? toCurrency = null)
        {
            using var db = new CurrencyConverterDbContext();
            ExchangeRateRequestLog? exchangeRateLog;

            if (fromCurrency == null && toCurrency == null)
            {
               exchangeRateLog = db.ExchangeRateRequestLogs
                    .Where(a => a.ApiName == LogName)
                    .OrderByDescending(a => a.LastRequestTimestamp)
                    .FirstOrDefault();
            }
            else
            {
               exchangeRateLog = db.ExchangeRateRequestLogs
                    .Where(a => a.ApiName == LogName && a.FromCurrency == fromCurrency && a.ToCurrency == toCurrency)
                    .OrderByDescending(a => a.LastRequestTimestamp)
                    .FirstOrDefault();
            }

            return exchangeRateLog;
        }

        public static decimal? GetLastRate(string fromCurrency, string toCurrency)
        {
            return GetLastApiRequest(fromCurrency, toCurrency)?.Rate;
        }
    }
}
