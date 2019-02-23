using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Forms.VendaParcela
{
    public partial class VendaParcelaGrid : Form
    {
        public List<Library.VendaParcela> VendaParcelas { get; set; }

        public VendaParcelaGrid()
        {
            InitializeComponent();
        }

        private void VendaParcela_Load(object sender, EventArgs e)
        {
            foreach (Library.VendaParcela vp in this.VendaParcelas)
            {
                this.vendaParcelasDGV.Rows.Add(vp.Id, vp.Data, vp.Pago, vp.Valor);
            }
        }

        private void VendaParcelaGrid_KeyDown(object sender, KeyEventArgs e)
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
