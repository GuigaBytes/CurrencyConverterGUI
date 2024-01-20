using CurrencyConverterGUI.Data;

namespace CurrencyConverterGUI.Models.Api
{
    public class ApiRequestLog
    {
        public int Id { get; set; }
        public string ApiName { get; set; }
        public DateTime LastRequestTimestamp { get; set; }

        public static void RegisterApiRequest(string apiName)
        {
            using var db = new CurrencyConverterDbContext();
            var apiRequestLog = new ApiRequestLog
            {
                ApiName = apiName,
                LastRequestTimestamp = DateTime.UtcNow
            };

            db.ApiRequestLogs.Add(apiRequestLog);
            db.SaveChanges();
        }

        public static ApiRequestLog? GetLastApiRequest(string apiName)
        {
            using var db = new CurrencyConverterDbContext();
            var apiRequestLog = db.ApiRequestLogs
                .Where(a => a.ApiName == apiName)
                .OrderByDescending(a => a.LastRequestTimestamp)
                .FirstOrDefault();

            return apiRequestLog;
        }
    }
}
