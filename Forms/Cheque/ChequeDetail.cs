using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Library.Converter;

namespace Forms.Cheque
{
    public partial class ChequeDetail : Form
    {
        public Library.Cheque Cheque { get; set; }

        Forms.Venda.VendaDetail vendaDetail = null;

        public ChequeDetail()
        {
            InitializeComponent();
        }

        private void ChequeDetail_Load(object sender, EventArgs e)
        {
            ShowValues();
        }

        private void pagarButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja pagar?", "Pergunta:", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                this.Cheque.Pago = 1;

                //instanciando e definindo valores de uma transação
                Library.CaixaTransacao caixaTransacao = new Library.CaixaTransacao();
                caixaTransacao.Cheque = this.Cheque;
                caixaTransacao.Caixa = Library.CaixaBD.GetCaixaToday();
                caixaTransacao.Hora = TimeSpan.Parse(DateTime.Now.ToShortTimeString());
                caixaTransacao.Tipo = "Cheque";
                caixaTransacao.Valor = this.Cheque.Valor;
                Library.CaixaTransacaoBD.Save(caixaTransacao);


                Library.ChequeBD.Update(Cheque);

                ShowValues();
            }
        }

        private void moreButton_Click(object sender, EventArgs e)
        {
            if (this.Cheque.Venda != null)
            {
                vendaDetail = new Forms.Venda.VendaDetail();
                vendaDetail.Venda = this.Cheque.Venda;
                vendaDetail.ShowDialog(this);
            }
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void ShowValues()
        {
            this.codigoTB.Text = this.Cheque.Id.ToString();
            this.numeroTB.Text = this.Cheque.Numero;
            this.dataTB.Text = this.Cheque.Data.ToShortDateString();
            this.valorTB.Text = this.Cheque.Valor.ConvertToMoneyString();
            if (this.Cheque.Pago == 1)
            {
                this.pagoTB.Text = "Sim";
                this.pagarButton.Enabled = false;
            }
            else
            {
                this.pagoTB.Text = "Não";
                this.pagarButton.Enabled = true;
            }

            if (this.Cheque.Venda != null)
            {
                groupBox1.Text = "Detalhes da venda";
                this.servicoCodigoTB.Text = this.Cheque.Venda.Id.ToString();
                this.servicoClienteNomeTB.Text = this.Cheque.Venda.Cliente.Nome;
                this.servicoDataTB.Text = this.Cheque.Venda.Data.ToString();
                this.servicoValorTB.Text = this.Cheque.Venda.Valor.ConvertToMoneyString();
            }
            
        }

        private void ChequeDetail_KeyDown(object sender, KeyEventArgs e)
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
