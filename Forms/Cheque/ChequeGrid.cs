using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Forms.Cheque
{
    public partial class ChequeGrid : Form
    {

        public List<Library.Cheque> Cheques { get; set; }

        public ChequeGrid()
        {
            InitializeComponent();
        }

        private void Cheque_Load(object sender, EventArgs e)
        {
            if (this.Cheques != null)
            {
                foreach (Library.Cheque cq in this.Cheques)
                {
                    this.chequesDGV.Rows.Add(cq.Id, cq.Data, cq.Numero, cq.Pago, cq.Valor);
                }
            }
        }

        private void ChequeGrid_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    this.Close();
                    break;
            }
        }
    }
}
