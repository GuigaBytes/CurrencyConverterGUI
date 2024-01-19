using CurrencyConverter.Services;
using CurrencyConverterGUI.Models.AvailableCurrencies;
using System.Globalization;

namespace CurrencyConverterGUI
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
            var currencyItems = CurrencyList.GetItems();

            fromCurrency.Items.AddRange(currencyItems.ToArray());
            toCurrency.Items.AddRange(currencyItems.ToArray());

            if (currencyItems.Count >= 2)
            {
                fromCurrency.SelectedIndex = 0;

                toCurrency.SelectedIndex = 1;
            }
        }

        private void Home_Load(object sender, EventArgs e)
        {

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

            decimal rate = await ExchangeRateService.GetCurrencyRate(fromCurrencyKey, toCurrencyKey);
            decimal result = amount * rate;
            string formattedResult = result.ToString("F2", CultureInfo.InvariantCulture);

            textBoxConversionResult.Text = formattedResult;
            labelRate.Text = $"Rate: 1 {fromCurrencyKey} = {rate} {toCurrencyKey}";
            labelStatusField.Text = "Done!";
            textBoxAmount.Enabled = true;
            convertionButton.Enabled = true;
            textBoxAmount.Focus();
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
