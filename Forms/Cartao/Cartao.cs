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

namespace Forms.Cartao
{

    public partial class Cartao : Form
    {
        Forms.Cartao.CartaoDetail cq = null;

        public Cartao()
        {
            InitializeComponent();
        }

        private void Cartao_Load(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            this.dataCB.DisplayMember = "data";
            this.dataCB.ValueMember = "id";
            this.dataCB.DataSource = Library.CartaoBD.FindAdvancedDistinctDate();

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
                    DateTime data = (DateTime)this.dataCB.SelectedValue;
                    List<Library.Cartao> cartaos = Library.CartaoBD.FindAdvanced(new QItem("ct.data varchar", data.ToString("dd/MM/yyyy")));

                    this.transacoesDGV.Rows.Clear();
                    foreach (Library.Cartao cq in cartaos)
                    {
                        if (cq.Venda != null)
                        {
                            this.transacoesDGV.Rows.Add(cq.Id, cq.Venda.Cliente.Nome, "Venda", cq.Tipo, cq.Parcelas, cq.Valor / cq.Parcelas, cq.Valor);
                        }
                        else
                            this.transacoesDGV.Rows.Add(cq.Id, "Indisponível", "Indisponível", cq.Tipo, cq.Parcelas, cq.Valor / cq.Parcelas, cq.Valor);
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

            try
            {
                DataGridViewRow rowSelected = transacoesDGV.SelectedRows[0];

                Library.Cartao cartao = Library.CartaoBD.FindCartaoById((long)rowSelected.Cells[0].Value);

                if (cartao != null)
                {
                    cq = new Forms.Cartao.CartaoDetail();
                    cq.Cartao = cartao;

                    cq.ShowDialog(this);
                }
            }
            catch (Exception ex)
            {
                Library.Diagnostics.Logger.Error(ex);
            }

        }

        private void Cartao_FormClosed(object sender, FormClosedEventArgs e)
        {
            Forms.OpenForm.RemoveForm(this);
        }

        private void Cartao_KeyDown(object sender, KeyEventArgs e)
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
