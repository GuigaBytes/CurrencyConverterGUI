using CurrencyConverterGUI.Data;

namespace CurrencyConverterGUI
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new Home());
        }

        // Initialize the SQLite database
        static Program()
        {
            Directory.CreateDirectory(Path.Combine(Directory.GetCurrentDirectory(), "db/config"));
            using var db = new CurrencyConverterDbContext();
            db.Database.EnsureCreated();
        }
    }
}
