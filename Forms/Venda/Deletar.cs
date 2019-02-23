using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Library.Classes;


namespace Forms.Venda
{
    public partial class Deletar : Form
    {
        string fvDeletarMsgSmall = "Desseja mesmo remover esta venda?";
        string fvDeletarMsgLarger = "Excluindo esta venda, todos seus produtos e parcelas serão removidos também, mas, por precaução, não retornará seus valores ao Caixa.";
        string fvDeletarMsgTitle = "Exclusão de venda";

        List<Library.Venda> vendas;

        public Deletar()
        {
            InitializeComponent();
        }

        private void pesquisarButton_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            
            if (this.nomeTB.Text != "")
                this.vendas = Library.VendaBD.FindAdvanced(new QItem("c.nome LIKE %%", this.nomeTB.Text));

            if (this.dataTB.Text != "")
                this.vendas = Library.VendaBD.FindAdvanced(new QItem("v.data varchar", DateTime.Parse(this.dataTB.Text).ToString("dd/MM/yyyy")));

            if (this.codigoTB.Text != "")
                this.vendas = Library.VendaBD.FindAdvanced(new QItem("v.id", this.codigoTB.Text));


            //this.vendas = Library.VendaBD.FindAdvanced(idstring, nomestring, datastring);

            this.vendasDGV.Rows.Clear();
            foreach (Library.Venda vs in this.vendas)
            {
                    this.vendasDGV.Rows.Add(vs.Id, vs.Cliente.Nome, vs.Funcionario.Nome, vs.Data, vs.Valor);
            }

            this.Cursor = Cursors.Default;
        }

        private void deletarButton_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            if (this.vendasDGV.SelectedRows.Count == 1)
            {
                long idVenda = 0;
                long.TryParse(this.vendasDGV.SelectedRows[0].Cells[0].Value.ToString(), out idVenda);

                if (idVenda != 0)
                {
                    if (Library.Windows.Forms.MessageBox.Show(this.fvDeletarMsgTitle, this.fvDeletarMsgSmall, this.fvDeletarMsgLarger, "Sim", "Não", global::Resources.Properties.Resources.dialog_warning) == DialogResult.OK)
                    {
                        Library.VendaBD.Delete(Library.VendaBD.FindVendaById(idVenda));
                        this.pesquisarButton.PerformClick();
                    }
                }
            }

            this.Cursor = Cursors.Default;
        }

        private void Deletar_Load(object sender, EventArgs e)
        {

        }

        private void Deletar_FormClosed(object sender, FormClosedEventArgs e)
        {
            Forms.OpenForm.RemoveForm(this);
        }

        private void Deletar_KeyDown(object sender, KeyEventArgs e)
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
