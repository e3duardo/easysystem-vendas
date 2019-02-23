using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Library.Converter;
using Library.Classes;

namespace Forms.Caixa
{

    public partial class Caixa : Form
    {
        private delegate void InvokeDelegate(int index);

        //private Library.Windows.Forms.Print print;

        private Forms.Venda.VendaDetail vd = null;



        public Caixa()
        {
            InitializeComponent();
        }

        private void Caixa_Load(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            Refreshs();

            this.Cursor = Cursors.Default;
        }


        private void dataCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            this.AtualizarGrid();

            this.Cursor = Cursors.Default;
        }


        private void imprimirButton_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            Library.Caixa caixa = (Library.Caixa)this.dataCB.SelectedItem;
            //atualizando caixa atual com valores do banco de dados;
            caixa = Library.CaixaBD.FindCaixaById(caixa.Id);

            Library.Classes.Print.PrintCaixa(caixa);

            this.Cursor = Cursors.Default;
        }

        private void encerrarButton_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            if (this.dataCB.SelectedIndex != -1)
            {
                Library.Caixa caixa = (Library.Caixa)this.dataCB.SelectedItem;
                caixa = Library.CaixaBD.FindCaixaById(caixa.Id);
                if (caixa.Data != DateTime.Today)
                {
                    caixa.Status = "Fechado";
                    Library.CaixaBD.Update(caixa);
                }
                else
                {
                    MessageBox.Show("Você não pode fechar o caixa de hoje ainda");
                }
            }
            else
            {
                MessageBox.Show("Selecione um caixa.");
            }
            Refreshs();
            this.Cursor = Cursors.Default;
        }

        private void entrarButton_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            decimal valor = this.entradaTB.Text.ConvertToDecimal();

            Library.CaixaTransacao transacao = new Library.CaixaTransacao();
            transacao.Caixa = Library.CaixaBD.GetCaixaToday();
            transacao.Hora = TimeSpan.Parse(DateTime.Now.ToShortTimeString());
            transacao.Tipo = "Entrada";
            transacao.Valor = valor;
            Library.CaixaTransacaoBD.Save(transacao);

            this.AtualizarGrid();

            this.Cursor = Cursors.Default;
        }

        private void retirarButton_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            decimal valor = this.retiradaTB.Text.ConvertToDecimal();

            Library.CaixaTransacao transacao = new Library.CaixaTransacao();
            transacao.Caixa = Library.CaixaBD.GetCaixaToday();
            transacao.Hora = TimeSpan.Parse(DateTime.Now.ToShortTimeString());
            transacao.Tipo = "Retirada";
            transacao.Valor = -valor;
            Library.CaixaTransacaoBD.Save(transacao);

            this.AtualizarGrid();

            this.Cursor = Cursors.Default;
        }


        private void entradaTB_Leave(object sender, EventArgs e)
        {
            this.entradaTB.Text = this.entradaTB.Text.ConvertToMoneyString();
        }

        private void retiradaTB_Leave(object sender, EventArgs e)
        {
            this.retiradaTB.Text = this.retiradaTB.Text.ConvertToMoneyString();
        }


        private void transacoesDGV_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow rowSelected = transacoesDGV.SelectedRows[0];

            Library.CaixaTransacao transacao = Library.CaixaTransacaoBD.FindCaixaTransacaoById((long)rowSelected.Cells[0].Value);

            if (transacao.Venda != null)
            {
                vd = new Forms.Venda.VendaDetail();
                vd.Venda = transacao.Venda;

                vd.ShowDialog(this);
            }
        }

        private void transacoesDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            try
            {
                if (e.RowIndex != -1)
                {
                    if (this.transacoesDGV.Columns[e.ColumnIndex].Name == "ColumnDelete")
                        this.transacoesDGV.BeginInvoke(new InvokeDelegate(DeleteRow), new object[] { e.RowIndex });
                }
            }
            catch (Exception ex)
            {
                Library.Diagnostics.Logger.Error(ex);
            }

            this.Cursor = Cursors.Default;
        }

        private void Caixa_FormClosed(object sender, FormClosedEventArgs e)
        {
            Forms.OpenForm.RemoveForm(this);
        }


        private void Refreshs()
        {
            //this.dataCB.Items.Clear();
            this.dataCB.DisplayMember = "data";
            this.dataCB.ValueMember = "id";
            this.dataCB.DataSource = Library.CaixaBD.FindAdvanced(new QItem("c.status", "Aberto"), new QItem("ORDER BY", "c.data"));
            //this.dataCB.Items.AddRange(Library.CaixaBD.FindAdvanced());
            //this.dataCB.SelectedIndex = this.dataCB.Items.Count - 1;
            this.dataCB.SelectedValue = Library.CaixaBD.GetCaixaToday().Id;

            this.AtualizarGrid();
        }

        private void AtualizarGrid()
        {
            try
            {
                if (this.dataCB.SelectedIndex != -1)
                {
                    Library.Caixa caixa = (Library.Caixa)this.dataCB.SelectedItem;
                    //atualizando caixa atual com valores do banco de dados;
                    caixa = Library.CaixaBD.FindCaixaById(caixa.Id);
                    List<Library.CaixaTransacao> transacoes = Library.CaixaTransacaoBD.FindAdvanced(new QItem("ct.idCaixa", caixa.Id));

                    this.transacoesDGV.Rows.Clear();
                    foreach (Library.CaixaTransacao ct in transacoes)
                    {
                        if (ct.Despesa != null)
                            this.transacoesDGV.Rows.Add(ct.Id, Library.Classes.StringFunctions.CortarString(ct.Despesa.Descricao, 110).Replace(char.ConvertFromUtf32(13) + char.ConvertFromUtf32(10), " "), ct.Tipo, ct.Valor, ct.Hora);
                        else if (ct.Venda != null)
                        {
                            if (ct.VendaParcela == null)
                                this.transacoesDGV.Rows.Add(ct.Id, ct.Venda.Cliente.Nome, ct.Tipo, ct.Valor, ct.Hora);
                            else
                                this.transacoesDGV.Rows.Add(ct.Id, ct.VendaParcela.Venda.Cliente.Nome, ct.Tipo, ct.Valor, ct.Hora);
                        }
                        else
                            this.transacoesDGV.Rows.Add(ct.Id, "Indisponível", ct.Tipo, ct.Valor, ct.Hora);
                    }
                    this.saldoTextBox.Text = caixa.Saldo.ConvertToMoneyString();

                    this.statusLabel.Text = string.Format("Caixa {0}", caixa.Status);
                    this.DisabilitarPartes(caixa);
                }
                else
                {
                    this.encerrarButton.Enabled = false;
                    this.entradaPanel.Enabled = false;
                    this.retiradaPanel.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                Library.Diagnostics.Logger.Error(ex);
            }
        }

        private void DisabilitarPartes(Library.Caixa caixa)
        {
            if (caixa.Status == "Aberto")
            {
                this.encerrarButton.Enabled = true;
                this.entradaPanel.Enabled = true;
                this.retiradaPanel.Enabled = true;
            }
            if (caixa.Status == "Fechado")
            {
                this.encerrarButton.Enabled = false;
                this.entradaPanel.Enabled = false;
                this.retiradaPanel.Enabled = false;
            }
        }

        private void DeleteRow(int index)
        {
            try
            {
                Forms.Caixa.TrocaDevolucao trocadevolucao = new Forms.Caixa.TrocaDevolucao();
                trocadevolucao.CaixaTransacao = Library.CaixaTransacaoBD.FindCaixaTransacaoById((long)this.transacoesDGV.Rows[index].Cells[0].Value);
                trocadevolucao.ShowDialog(this);
                //Library.VendaBD.DeleteById((long)this.transacoesDGV.Rows[index].Cells[0].Value);
                //this.transacoesDGV.Rows.RemoveAt(index);
                //this.DialogResult = DialogResult.Ignore;
                Refreshs();

            }
            catch (Exception ex)
            {
                Library.Diagnostics.Logger.Error(ex);
            }
        }

        private void buttonDevolver_Click(object sender, EventArgs e)
        {
            if (this.transacoesDGV.SelectedRows.Count >= 1)
            {
                if (MessageBox.Show("Deseja realmente devolver esta transação?", "Aviso", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    Forms.Caixa.TrocaDevolucao trocadevolucao = new Forms.Caixa.TrocaDevolucao();
                    trocadevolucao.CaixaTransacao = Library.CaixaTransacaoBD.FindCaixaTransacaoById((long)this.transacoesDGV.SelectedRows[0].Cells[0].Value);
                    trocadevolucao.ShowDialog(this);
                    Refreshs();
                }
            }
            else
            {
                MessageBox.Show("Selecione uma transação!");
            }
        }

        private void Caixa_KeyDown(object sender, KeyEventArgs e)
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
