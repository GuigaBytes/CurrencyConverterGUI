namespace CurrencyConverterGUI
{
    partial class Home
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            textBoxAmount = new TextBox();
            convertionButton = new Button();
            labelStatusField = new Label();
            textBoxConversionResult = new TextBox();
            fromCurrency = new ComboBox();
            toCurrency = new ComboBox();
            invertButton = new Button();
            labelRate = new Label();
            SuspendLayout();
            // 
            // textBoxAmount
            // 
            textBoxAmount.Location = new Point(12, 12);
            textBoxAmount.Name = "textBoxAmount";
            textBoxAmount.Size = new Size(105, 27);
            textBoxAmount.TabIndex = 0;
            textBoxAmount.Text = "1.00";
            textBoxAmount.TextAlign = HorizontalAlignment.Right;
            textBoxAmount.TextChanged += textBoxAmount_TextChanged;
            textBoxAmount.KeyPress += textBoxAmount_KeyPress;
            // 
            // convertionButton
            // 
            convertionButton.Location = new Point(229, 157);
            convertionButton.Name = "convertionButton";
            convertionButton.Size = new Size(133, 36);
            convertionButton.TabIndex = 1;
            convertionButton.Text = "Convert";
            convertionButton.UseVisualStyleBackColor = true;
            convertionButton.Click += convertionButton_ClickAsync;
            // 
            // labelStatusField
            // 
            labelStatusField.AutoSize = true;
            labelStatusField.Location = new Point(12, 173);
            labelStatusField.Name = "labelStatusField";
            labelStatusField.Size = new Size(50, 20);
            labelStatusField.TabIndex = 2;
            labelStatusField.Text = "Ready";
            // 
            // textBoxConversionResult
            // 
            textBoxConversionResult.Location = new Point(12, 54);
            textBoxConversionResult.Name = "textBoxConversionResult";
            textBoxConversionResult.ReadOnly = true;
            textBoxConversionResult.Size = new Size(105, 27);
            textBoxConversionResult.TabIndex = 3;
            textBoxConversionResult.Text = "1.00";
            textBoxConversionResult.TextAlign = HorizontalAlignment.Right;
            // 
            // fromCurrency
            // 
            fromCurrency.FormattingEnabled = true;
            fromCurrency.Location = new Point(129, 12);
            fromCurrency.Name = "fromCurrency";
            fromCurrency.Size = new Size(149, 28);
            fromCurrency.TabIndex = 4;
            fromCurrency.KeyPress += fromCurrency_KeyPress;
            // 
            // toCurrency
            // 
            toCurrency.FormattingEnabled = true;
            toCurrency.Location = new Point(129, 54);
            toCurrency.Name = "toCurrency";
            toCurrency.Size = new Size(149, 28);
            toCurrency.TabIndex = 5;
            toCurrency.KeyPress += toCurrency_KeyPress;
            // 
            // invertButton
            // 
            invertButton.Location = new Point(284, 12);
            invertButton.Name = "invertButton";
            invertButton.Size = new Size(78, 69);
            invertButton.TabIndex = 6;
            invertButton.Text = "Invert";
            invertButton.UseVisualStyleBackColor = true;
            invertButton.Click += invertButton_Click;
            // 
            // labelRate
            // 
            labelRate.AutoSize = true;
            labelRate.Location = new Point(12, 143);
            labelRate.Name = "labelRate";
            labelRate.Size = new Size(68, 20);
            labelRate.TabIndex = 7;
            labelRate.Text = "Rate: n/a";
            // 
            // Home
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(374, 206);
            Controls.Add(labelRate);
            Controls.Add(invertButton);
            Controls.Add(toCurrency);
            Controls.Add(fromCurrency);
            Controls.Add(textBoxConversionResult);
            Controls.Add(labelStatusField);
            Controls.Add(convertionButton);
            Controls.Add(textBoxAmount);
            Name = "Home";
            Text = "Currency Converter";
            Load += Home_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBoxAmount;
        private Button convertionButton;
        private Label labelStatusField;
        private TextBox textBoxConversionResult;
        private ComboBox fromCurrency;
        private ComboBox toCurrency;
        private Button invertButton;
        private Label labelRate;
    }
}
