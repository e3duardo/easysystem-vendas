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

namespace Forms.Venda
{
    public partial class VendaList : Form
    {
        private delegate void InvokeDelegate(int index);
        private string fvDeletarMsgSmall = "Desseja mesmo remover esta Venda?";
        private string fvDeletarMsgLarger = "Excluindo esta Venda, todos seus produtos serão removidos também, mas, por precaução, não retornará seus valores ao Caixa.";
        private string fvDeletarMsgTitle = "Exclusão de Venda";

        Forms.Venda.VendaDetail sd = null;

        public VendaList()
        {
            InitializeComponent();
        }

        private void VendaList_Load(object sender, EventArgs e)
        {
            this.dataInicioDTP.Text = "";
            this.dataTerminoDTP.Text = "";
        }

        private void pesquisarButton_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            //
            resultadoDGV.Rows.Clear();

            QItem queryData1 = new QItem(null, null);
            QItem queryData2 = new QItem(null, null);

            QItem queryCodigo = new QItem(null, null);
            QItem queryClienteNome = new QItem(null, null);

            QItem queryFormaPagamento = new QItem(null, null);

            //dataEntrega
            if (this.dataInicioDTP.Text != "")
                queryData1 = new QItem("dataMenor", this.dataInicioDTP.Value.ToString("yyyy-MM-dd"));
            else
                queryData1 = new QItem(null, null);

            if (this.dataTerminoDTP.Text != "")
                queryData2 = new QItem("dataMaior", this.dataTerminoDTP.Value.ToString("yyyy-MM-dd"));
            else
                queryData2 = new QItem(null, null);

            //codigo
            if (this.codigoTB.Text != "")
                queryCodigo = new QItem("v.id", this.codigoTB.Text);
            else
                queryCodigo = new QItem(null, null);

            //cliente
            if (this.clienteNomeTB.Text != "")
                queryClienteNome = new QItem("c.nome LIKE %%", this.clienteNomeTB.Text);
            else
                queryClienteNome = new QItem(null, null);

            //formaPagamento
            if (this.avistaRB.Checked == true)
                queryFormaPagamento = new QItem("v.formaPagamento", "avista");
            if (this.chequeRB.Checked == true)
                queryFormaPagamento = new QItem("v.formaPagamento", "cheque");
            if (this.cartaoRB.Checked == true)
                queryFormaPagamento = new QItem("v.formaPagamento", "cartao");
            if (this.aprazoRB.Checked == true)
                queryFormaPagamento = new QItem("v.formaPagamento", "aprazo");
            if (this.noFormaPagamentoRB.Checked == true)
                queryFormaPagamento = new QItem(null, null);
                        
            List<Library.Venda> vendas = Library.VendaBD.FindAdvanced(queryData1, queryData2, queryCodigo, queryClienteNome, queryFormaPagamento);
            
            if (vendas != null)
            {
                foreach (Library.Venda v in vendas)
                {
                    string fp = "";

                    if (v.FormaPagamento == "avista")
                        fp = "À vista";
                    if (v.FormaPagamento == "aprazo")
                        fp = "À prazo";
                    if (v.FormaPagamento == "cartao")
                        fp = "Cartão";
                    if (v.FormaPagamento == "cheque")
                        fp = "Cheque";

                    resultadoDGV.Rows.Add(v.Id, v.Cliente.Nome, fp, v.Data);
                }
            }

            //
            this.Cursor = Cursors.Default;
        }

        private void resultadoDGV_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow rowSelected = resultadoDGV.SelectedRows[0];

            Library.Venda venda = Library.VendaBD.FindVendaById((long)rowSelected.Cells[0].Value);

            if (venda != null)
            {
                sd = new Forms.Venda.VendaDetail();
                sd.Venda = venda;

                sd.ShowDialog(this);
            }
        }

        private void VendaList_FormClosed(object sender, FormClosedEventArgs e)
        {
            Forms.OpenForm.RemoveForm(this);
        }

        
        private void resultadoDGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            try
            {
                if (e.RowIndex != -1)
                {
                    if (this.resultadoDGV.Columns[e.ColumnIndex].Name == "deleteColumn")
                        this.resultadoDGV.BeginInvoke(new InvokeDelegate(DeleteRow), new object[] { e.RowIndex });
                    if (this.resultadoDGV.Columns[e.ColumnIndex].Name == "printColumn")
                        this.resultadoDGV.BeginInvoke(new InvokeDelegate(PrintRow), new object[] { e.RowIndex });
                }


            }
            catch (Exception ex)
            {
                Library.Diagnostics.Logger.Error(ex);
            }

            this.Cursor = Cursors.Default;
        }

        private void DeleteRow(int index)
        {
            try
            {
                if (Library.Windows.Forms.MessageBox.Show(this.fvDeletarMsgTitle, this.fvDeletarMsgSmall, this.fvDeletarMsgLarger, "Sim", "Não", global::Resources.Properties.Resources.dialog_warning) == DialogResult.OK)
                {
                    Library.VendaBD.Delete(Library.VendaBD.FindVendaById((long)this.resultadoDGV.Rows[index].Cells[0].Value));
                    this.resultadoDGV.Rows.RemoveAt(index);
                    this.DialogResult = DialogResult.Ignore;
                }
            }
            catch (Exception ex)
            {
                Library.Diagnostics.Logger.Error(ex);
            }
        }

        private void PrintRow(int index)
        {
            try
            {
              /*  Reports.nota_venda notav = new Reports.nota_venda();
                notav.Venda = Library.VendaBD.FindVendaById((long)this.resultadoDGV.Rows[index].Cells[0].Value);
                notav.ShowDialog(this);
                notav.Disposed += delegate { notav.Dispose(); };*/
                Library.Classes.Print.PrintVenda(Library.VendaBD.FindVendaById((long)this.resultadoDGV.Rows[index].Cells[0].Value));
            }
            catch (Exception ex)
            {
                Library.Diagnostics.Logger.Error(ex);
            }
        }
       
    }
}
