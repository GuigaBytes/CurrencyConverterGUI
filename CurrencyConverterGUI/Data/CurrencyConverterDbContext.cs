using CurrencyConverterGUI.Models.Api;
using Microsoft.EntityFrameworkCore;

namespace CurrencyConverterGUI.Data
{
    public class CurrencyConverterDbContext : DbContext
    {
        public DbSet<ApiRequestLog> ApiRequestLogs { get; set; }
        public DbSet<ExchangeRateRequestLog> ExchangeRateRequestLogs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite("Data Source=db/config/currencyConverter.db");
    }
}
