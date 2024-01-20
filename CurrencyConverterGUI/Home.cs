using CurrencyConverterGUI.Models.Api;
using CurrencyConverterGUI.Models.AvailableCurrencies;
using CurrencyConverterGUI.Services.CurrencyConverterService;
using System.Globalization;

namespace CurrencyConverterGUI
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
            InitializeCurrencyInfo();
        }

        private void Home_Load(object sender, EventArgs e)
        {

        }

        private void InitializeCurrencyInfo()
        {
            var currencyItems = CurrencyList.GetItems();

            fromCurrency.Items.AddRange(currencyItems.ToArray());
            toCurrency.Items.AddRange(currencyItems.ToArray());

            var lastRateRequest = ExchangeRateRequestLog.GetLastApiRequest();

            if (lastRateRequest != null)
            {
                int fromIndex = currencyItems.FindIndex(item => item.Key == lastRateRequest.FromCurrency);
                int toIndex = currencyItems.FindIndex(item => item.Key == lastRateRequest.ToCurrency);

                fromCurrency.SelectedIndex = fromIndex != -1 ? fromIndex : 0;
                toCurrency.SelectedIndex = toIndex != -1 ? toIndex : 1;

                UpdateAmount();
            }
            else
            {
                fromCurrency.SelectedIndex = currencyItems.Count >= 1 ? 0 : -1;
                toCurrency.SelectedIndex = currencyItems.Count >= 2 ? 1 : -1;
                labelRate.Text = "Rate: N/A";
            }
        }

        private void textBoxAmount_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }

            if (e.KeyChar == (char)Keys.Enter)
            {
                UpdateAmount();
                e.Handled = true;
            }
        }

        private void fromCurrency_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                UpdateAmount();
                e.Handled = true;
            }
        }

        private void toCurrency_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                UpdateAmount();
                e.Handled = true;
            }
        }

        private decimal GetAmountFromTextBox()
        {
            decimal amount;
            bool isConversionSuccessful = decimal.TryParse(textBoxAmount.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out amount);

            if (isConversionSuccessful)
            {
                return amount;
            }
            else
            {
                throw new InvalidOperationException("Invalid amount value.");
            }
        }

        private void convertionButton_ClickAsync(object sender, EventArgs e)
        {
            UpdateAmount();
        }

        private async void UpdateAmount()
        {
            labelStatusField.Text = "Loading...";
            convertionButton.Enabled = false;
            textBoxAmount.Enabled = false;

            decimal amount = GetAmountFromTextBox();

            string fromCurrencyKey = ((CurrencyItem)fromCurrency.SelectedItem).Key;
            string toCurrencyKey = ((CurrencyItem)toCurrency.SelectedItem).Key;

            decimal rate;
            var lastRequest = ExchangeRateRequestLog.GetLastApiRequest(fromCurrencyKey, toCurrencyKey);
            if (lastRequest != null && lastRequest.LastRequestTimestamp.Date == DateTime.Now.Date)
            {
                rate = lastRequest.Rate;
            }
            else
            {
                rate = await CurrencyConverterService.GetCurrencyRate(fromCurrencyKey, toCurrencyKey);
                ExchangeRateRequestLog.RegisterExchangeRateRequest(fromCurrencyKey, toCurrencyKey, rate);
            }

            decimal result = amount * rate;
            string formattedResult = result.ToString("F2", CultureInfo.InvariantCulture);

            textBoxConversionResult.Text = formattedResult;
            labelRate.Text = $"Rate: 1 {fromCurrencyKey} = {rate} {toCurrencyKey}";
            labelStatusField.Text = "Done!";
            textBoxAmount.Enabled = true;
            convertionButton.Enabled = true;
            textBoxAmount.Focus();

            lastRequest = ExchangeRateRequestLog.GetLastApiRequest(fromCurrencyKey, toCurrencyKey);

            labelStatusField.Text = lastRequest != null
                ? $"Last request: {lastRequest.LastRequestTimestamp.ToString("dd.MM HH:mm")}"
                : "No previous requests.";
        }

        private void invertButton_Click(object sender, EventArgs e)
        {
            string tempAmount = textBoxAmount.Text;
            textBoxAmount.Text = textBoxConversionResult.Text;
            textBoxConversionResult.Text = tempAmount;

            if (fromCurrency.SelectedIndex != -1 && toCurrency.SelectedIndex != -1)
            {
                int tempIndex = fromCurrency.SelectedIndex;
                fromCurrency.SelectedIndex = toCurrency.SelectedIndex;
                toCurrency.SelectedIndex = tempIndex;
            }
        }
    }
}
