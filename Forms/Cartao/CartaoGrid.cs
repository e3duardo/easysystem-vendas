using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Forms.Cartao
{
    public partial class CartaoGrid : Form
    {
        private Library.Cartao[] cartaos;
        public Library.Cartao[] Cartaos
        {
            get { return this.cartaos; }
            set { this.cartaos = value; }
        }

        public CartaoGrid()
        {
            InitializeComponent();
        }

        private void Cartao_Load(object sender, EventArgs e)
        {
            if (cartaos != null)
            {
                foreach (Library.Cartao cq in cartaos)
                {
                    this.cartaosDGV.Rows.Add(cq.Id, cq.Data, cq.Tipo, cq.Parcelas, cq.Valor);
                }
            }
        }

        private void CartaoGrid_KeyDown(object sender, KeyEventArgs e)
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
