using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Library.Converter;

namespace Forms.Comissao
{
    public partial class ComissaoVendaDetail : Form
    {
        public Library.Comissao Comissao { get; set; }

        Forms.Venda.VendaDetail vendaDetail = null;

        public ComissaoVendaDetail()
        {
            InitializeComponent();
        }


        private void ComissaoVendaDetail_Load(object sender, EventArgs e)
        {
            ShowValues();
        }

        private void pagarButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja pagar?", "Pergunta:", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                this.Comissao.Pago = 1;

                //instanciando e definindo valores de uma transação
                Library.CaixaTransacao caixaTransacao = new Library.CaixaTransacao();
                caixaTransacao.Comissao = this.Comissao;
                caixaTransacao.Caixa = Library.CaixaBD.GetCaixaToday();
                caixaTransacao.Hora = TimeSpan.Parse(DateTime.Now.ToShortTimeString());
                caixaTransacao.Tipo = "Comissão";
                caixaTransacao.Valor = this.Comissao.Valor;
                Library.CaixaTransacaoBD.Save(caixaTransacao);


                Library.ComissaoBD.Update(this.Comissao);

                ShowValues();
            }
        }

        private void vendaMoreButton_Click(object sender, EventArgs e)
        {
            vendaDetail = new Forms.Venda.VendaDetail();

            vendaDetail.Venda = this.Comissao.Venda;

            vendaDetail.ShowDialog(this);
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }


        private void ShowValues()
        {
            this.codigoTB.Text = this.Comissao.Id.ToString();
            this.funcionarioTB.Text = this.Comissao.Funcionario.Nome;
            this.porcentagemTB.Text = this.Comissao.Porcentagem.ConvertToPercentString();
            this.valorTB.Text = this.Comissao.Valor.ConvertToMoneyString();
            if (this.Comissao.Pago == 1)
            {
                this.pagoTB.Text = "Sim";
                this.pagarButton.Enabled = false;
            }
            else
            {
                this.pagoTB.Text = "Não";
                this.pagarButton.Enabled = true;
            }

            this.vendaCodigoTB.Text = this.Comissao.Venda.Id.ToString();
            this.vendaClienteNomeTB.Text = this.Comissao.Venda.Cliente.Nome;
            this.vendaDataTB.Text = this.Comissao.Venda.Data.ToString();
            this.vendaValorTB.Text = this.Comissao.Venda.Valor.ConvertToMoneyString();
        }

        private void ComissaoVendaDetail_KeyDown(object sender, KeyEventArgs e)
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
