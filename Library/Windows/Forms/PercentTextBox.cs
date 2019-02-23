using Library.Converter;

namespace Library.Windows.Forms
{
    public partial class PercentTextBox : System.Windows.Forms.TextBox
    {
        public PercentTextBox()
        {
            InitializeComponent();
        }

        protected override void OnLeave(System.EventArgs e)
        {
            base.Text = base.Text.ConvertToPercentString();

            base.OnLeave(e);
        }

        public decimal Value
        {
            get { return base.Text.ConvertToDecimal(); }
            set { base.Text = value.ConvertToMoneyString(); }
        }
    }
}
