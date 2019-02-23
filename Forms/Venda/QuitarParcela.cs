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
    public partial class QuitarParcela : Form
    {
        /*************************************************/
        string fvQuitarParcelaValorInvalid = "Você não pode pagar este valor!";
        string fvQuitarParcelaImprimirMsg = "Deseja imprimir esta parcela?";
        string fvQuitarParcelaImprimirMsgTitle = "Imprimir";
        /*************************************************/

        List<Library.Venda> vendas;

        Library.Windows.Forms.Print print = null;

        public QuitarParcela()
        {
            InitializeComponent();
        }


        private void QuitarParcela_Load(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            this.DescontarParcelaEnable();
            this.Cursor = Cursors.Default;
        }

        private void pesquisarButton_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            long tempId = 0;
            long.TryParse(this.codigoTB.Text, out tempId);

            if (tempId == 0)
            {
                if (this.nomeTB.Text == "")
                {
                    this.vendas = Library.VendaBD.FindAdvanced();
                }
                else
                {
                    this.vendas = Library.VendaBD.FindAdvanced(new QItem("c.nome LIKE %%", this.nomeTB.Text));
                }
            }
            else
            {
                if (this.nomeTB.Text == "")
                {
                    this.vendas = Library.VendaBD.FindAdvanced(new QItem("v.id", tempId));
                }
                else
                {
                    this.vendas = Library.VendaBD.FindAdvanced(new QItem("v.id", tempId), new QItem("c.nome LIKE %%", this.nomeTB.Text));
                }
            }

            this.vendasDGV.Rows.Clear();
            foreach (Library.Venda vs in this.vendas)
            {
                if (vs.Pago == 0)
                {
                    this.vendasDGV.Rows.Add(vs.Id, vs.Cliente.Nome, vs.Funcionario.Nome, vs.Data, vs.Valor);
                }
            }

            this.Cursor = Cursors.Default;
        }

        private void selecionarButton_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            if (this.vendasDGV.SelectedRows.Count == 1)
            {
                foreach (DataGridViewRow row in this.vendasDGV.Rows)
                {
                    if (row.Selected == true)
                    {
                        row.DefaultCellStyle.BackColor = Color.FromArgb(255, 204, 51);
                        row.DefaultCellStyle.SelectionBackColor = Color.FromArgb(120, 131, 128);
                    }
                    else
                    {
                        row.DefaultCellStyle.BackColor = SystemColors.Window;
                        row.DefaultCellStyle.SelectionBackColor = SystemColors.Highlight;
                    }
                }

                this.parcelasDGV.Rows.Clear();
                int i = 0;
                int np = 1;
                foreach (Library.VendaParcela vp in Library.VendaParcelaBD.FindAdvanced(new QItem("vp.idVenda", this.vendasDGV.SelectedRows[0].Cells[0].Value)))
                {
                    if (vp.Pago != 1)
                    {
                        this.parcelasDGV.Rows.Add(vp.Id, np, vp.Venda.Id, vp.Data, vp.Valor, vp.Pago);

                        if (vp.Pago == 1)
                        {
                            this.parcelasDGV.Rows[i].DefaultCellStyle.BackColor = Color.FromArgb(178, 178, 178);
                            this.parcelasDGV.Rows[i].DefaultCellStyle.SelectionBackColor = Color.FromArgb(178, 178, 178);
                        }
                        else
                        {
                            if (vp.Data < DateTime.Today)
                            {
                                this.parcelasDGV.Rows[i].DefaultCellStyle.BackColor = Color.FromArgb(234, 203, 181);
                                this.parcelasDGV.Rows[i].DefaultCellStyle.SelectionBackColor = Color.FromArgb(223, 175, 141);
                            }
                            else
                            {
                                this.parcelasDGV.Rows[i].DefaultCellStyle.BackColor = Color.FromArgb(211, 227, 174);
                                this.parcelasDGV.Rows[i].DefaultCellStyle.SelectionBackColor = Color.FromArgb(191, 214, 136);
                            }
                        }
                        i++;
                    }
                    np++;
                }
            }
            this.Cursor = Cursors.Default;
        }

        private void quitarButton_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                Library.Venda venda = Library.VendaBD.FindVendaById((long)this.vendasDGV.SelectedRows[0].Cells[0].Value);


                //instanciando e definindo valores de uma transação
                Library.CaixaTransacao caixaTransacao = new Library.CaixaTransacao();
                caixaTransacao.Venda = venda;
                caixaTransacao.Caixa = Library.CaixaBD.GetCaixaToday();
                //caixaTransacao.Hora = TimeSpan.Parse(venda.Data.GetValueOrDefault().ToShortTimeString());
                caixaTransacao.Hora = TimeSpan.Parse(DateTime.Now.ToShortTimeString());
                caixaTransacao.Tipo = "Parcela de venda";
                caixaTransacao.Valor = (decimal)venda.Valor;
                //


                if (this.descontarParcelaCB.Checked == true)
                {
                    Library.VendaParcela parcela = Library.VendaParcelaBD.FindVendaParcelaById((long)this.parcelasDGV.SelectedRows[0].Cells[0].Value);

                    decimal valor = 0;
                    decimal.TryParse(this.descontarParcelaTB.Text, out valor);

                    decimal valor2 = (decimal)parcela.Valor - valor;

                    if (valor2 == 0)//pagando parcela inteira pois descontou um valor do tamanho da parcela
                    {
                        parcela.Pago = 1;

                        Library.VendaParcelaBD.Update(parcela);

                        Library.VendaBD.Update(venda);

                        //salvando transacao
                        caixaTransacao.Valor = valor;
                        caixaTransacao.VendaParcela = parcela;
                        Library.CaixaTransacaoBD.Save(caixaTransacao);

                        if (MessageBox.Show(this.fvQuitarParcelaImprimirMsg, this.fvQuitarParcelaImprimirMsgTitle, MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            print = new Library.Windows.Forms.Print(Library.Classes.Print.GeneratorStringVendaQuitarParcela(venda), "Quitar parcela de venda");
                            print.ShowDialog(this);
                        }
                    }
                    else if (valor2 > 0)//pagando um valor em uma parcela
                    {
                        parcela.Pago = 0;
                        parcela.Valor = valor2;

                        Library.VendaParcelaBD.Update(parcela);

                        //salvando transacao
                        caixaTransacao.Valor = valor;
                        caixaTransacao.VendaParcela = parcela;
                        Library.CaixaTransacaoBD.Save(caixaTransacao);

                        //if (MessageBox.Show(this.fvQuitarParcelaImprimirMsg, this.fvQuitarParcelaImprimirMsgTitle, MessageBoxButtons.YesNo) == DialogResult.Yes)
                        //{
                        //    print = new Library.Windows.Forms.Print(Library.Classes.Print.GeneratorStringVendaQuitarParcelaValor(venda), "Quitar parcela de venda");
                        //    print.ShowDialog(this);
                        //}
                    }
                    else
                    {
                        MessageBox.Show(this.fvQuitarParcelaValorInvalid);
                    }

                }
                else//pagando parcela inteira pois não foi selecionado o checkbox
                {
                    Library.VendaParcela parcela = Library.VendaParcelaBD.FindVendaParcelaById((long)this.parcelasDGV.SelectedRows[0].Cells[0].Value);

                    parcela.Pago = 1;

                    Library.VendaParcelaBD.Update(parcela);

                    Library.VendaBD.Update(venda);

                    //salvando transacao
                    caixaTransacao.Valor = (decimal)parcela.Valor;
                    caixaTransacao.VendaParcela = parcela;
                    Library.CaixaTransacaoBD.Save(caixaTransacao);

                    //if (MessageBox.Show(this.fvQuitarParcelaImprimirMsg, this.fvQuitarParcelaImprimirMsgTitle, MessageBoxButtons.YesNo) == DialogResult.Yes)
                    //{
                    //    print = new Library.Windows.Forms.Print(Library.Classes.Print.GeneratorStringVendaQuitarParcela(venda), "Quitar parcela de venda");
                    //    print.ShowDialog(this);
                    //}
                }

                //conferindo se todas parcelas estão pagas
                List<Library.VendaParcela> vendasparcelas = Library.VendaParcelaBD.FindAdvanced(new QItem("v.id", venda.Id));
                int count = 0;
                foreach (Library.VendaParcela vp in vendasparcelas)
                {
                    if (vp.Pago == 1)
                        count++;
                }
                if (count == vendasparcelas.Count)
                {
                    venda.Pago = 1;
                    Library.VendaBD.Update(venda);
                }
                //end conferindo se todas parcelas estão pagas

                this.parcelasDGV.Rows.Clear();

                selecionarButton.PerformClick();
                descontarParcelaCB.Checked = false;
                descontarParcelaTB.Text = "";
            }
            catch (Exception ex)
            {
                Library.Diagnostics.Logger.Error(ex); ;
            }
            this.Cursor = Cursors.Default;
        }

        private void descontarParcelaCB_CheckedChanged(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            this.DescontarParcelaEnable();
            this.Cursor = Cursors.Default;
        }

        private void vendasDGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            this.parcelasDGV.Rows.Clear();
            this.Cursor = Cursors.Default;
        }


        private void DescontarParcelaEnable()
        {
            this.descontarParcelaTB.Enabled = this.descontarParcelaCB.Checked;
        }

        private void QuitarParcela_FormClosed(object sender, FormClosedEventArgs e)
        {
            Forms.OpenForm.RemoveForm(this);
        }

        private void QuitarParcela_KeyDown(object sender, KeyEventArgs e)
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
