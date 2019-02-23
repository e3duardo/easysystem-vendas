using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using Library.Classes;

namespace Forms.Cheque
{

    public partial class Cheque : Form
    {
        Forms.Cheque.ChequeDetail cq = null;

        public Cheque()
        {
            InitializeComponent();
        }

        private void Cheque_Load(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            
            this.dataCB.DisplayMember = "data";
            this.dataCB.ValueMember = "id";
            this.dataCB.DataSource = Library.ChequeBD.FindLimitAndOrderByDate();

            this.Cursor = Cursors.Default;
        }

        private void dataCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            this.AtualizarGrid();

            this.Cursor = Cursors.Default;
        }        

        private void AtualizarGrid()
        {
            try
            {
                if (this.dataCB.SelectedIndex != -1)
                {
                    Library.Cheque cheque = (Library.Cheque)this.dataCB.SelectedItem;
                    List<Library.Cheque> cheques = Library.ChequeBD.FindAdvanced(new QItem("cq.data varchar", cheque.Data.ToString("dd/MM/yyyy")));

                    this.transacoesDGV.Rows.Clear();
                    foreach (Library.Cheque cq in cheques)
                    {
                        if (cq.Venda != null)
                        {
                            this.transacoesDGV.Rows.Add(cq.Id, cq.Venda.Cliente.Nome, "Venda", cq.Valor, cq.Numero);
                        }
                        else
                            this.transacoesDGV.Rows.Add(cq.Id, "Indisponível", "Indisponível", cq.Valor, cq.Numero);
                    }
                }
            }
            catch (Exception ex)
            {
                Library.Diagnostics.Logger.Error(ex); ;
            }
        }

        private void transacoesDGV_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow rowSelected = transacoesDGV.SelectedRows[0];

            Library.Cheque cheque = Library.ChequeBD.FindChequeById((long)rowSelected.Cells[0].Value);

            if (cheque != null)
            {
                cq = new Forms.Cheque.ChequeDetail();
                cq.Cheque = cheque;

                cq.ShowDialog(this);
            }
        }

        private void Cheque_FormClosed(object sender, FormClosedEventArgs e)
        {
            Forms.OpenForm.RemoveForm(this);
        }

        private void buttonReceber_Click(object sender, EventArgs e)
        {

        }

        private void Cheque_KeyDown(object sender, KeyEventArgs e)
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
