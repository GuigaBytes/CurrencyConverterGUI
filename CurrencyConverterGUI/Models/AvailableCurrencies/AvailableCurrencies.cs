namespace CurrencyConverterGUI.Models.AvailableCurrencies
{
    public class CurrencyItem
    {
        public string Key { get; set; }
        public string Value { get; set; }

        public CurrencyItem(string key, string value)
        {
            Key = key;
            Value = value;
        }

        public override string ToString()
        {
            return Value;
        }
    }
    public class CurrencyList
    {
        public static List<CurrencyItem> GetItems()
        {
            return new List<CurrencyItem>
            {
                new CurrencyItem("USD", "USD - United States Dollar"),
                new CurrencyItem("EUR", "EUR - Euro"),
                new CurrencyItem("BRL", "BRL - Brazilian Real")
            };
        }
    }
}
