using Library.Converter;
using System;
using System.Windows.Forms;

namespace Library.Windows.Forms
{
    public partial class DateTextBox : System.Windows.Forms.TextBox
    {
        public DateTextBox()
        {
            InitializeComponent();
            base.MaxLength = 10;
        }

        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            if (Convert.ToInt32(e.KeyChar) == 8)
                e.Handled = false;
            else if (!char.IsNumber(e.KeyChar) | e.KeyChar.ToString() == "/")
            {
                e.Handled = true;
                //base.OnKeyPress(e);
            }
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            string texto = base.Text;
            if (texto.Length == 2)
            {
                if (e.KeyCode != Keys.Back)
                {
                    base.AppendText("/");
                }
            }
            if (texto.Length == 5)
            {
                if (e.KeyCode != Keys.Back)
                {
                    base.AppendText("/");
                }
            }

            base.OnKeyDown(e);
        }

        protected override void OnLeave(EventArgs e)
        {

            if (this.Value.Year < 1800 || this.Value.Year > 9000)
            {
                base.Text = "";
            }
            
            //base.OnLeave(e);
        }

        public DateTime Value
        {
            get 
            {
                DateTime data = DateTime.MinValue;
                DateTime.TryParse(base.Text, out data);

                return data; 
            }
            set 
            {
                    base.Text = value.ToString("dd/MM/yyyy");
            }
        }
    }
}
