using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Library.Converter;

namespace Forms.Cartao
{
    public partial class CartaoDetail : Form
    {
        Forms.Venda.VendaDetail vendaDetail = null;

        public Library.Cartao Cartao { get; set; }

        public CartaoDetail()
        {
            InitializeComponent();
        }

        private void CartaoDetail_Load(object sender, EventArgs e)
        {
            ShowValues();
        }

        private void pagarButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja pagar?", "Pergunta:", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                this.Cartao.Parcelas = 1;

                //instanciando e definindo valores de uma transação
                Library.CaixaTransacao caixaTransacao = new Library.CaixaTransacao();
                caixaTransacao.Cartao = this.Cartao;
                caixaTransacao.Caixa = Library.CaixaBD.GetCaixaToday();
                caixaTransacao.Hora = TimeSpan.Parse(DateTime.Now.ToShortTimeString());
                caixaTransacao.Tipo = "Cartao";
                caixaTransacao.Valor = this.Cartao.Valor;
                Library.CaixaTransacaoBD.Save(caixaTransacao);


                Library.CartaoBD.Update(this.Cartao);

                ShowValues();
            }
        }

        private void moreButton_Click(object sender, EventArgs e)
        {
            if (this.Cartao.Venda != null)
            {
                vendaDetail = new Forms.Venda.VendaDetail();
                vendaDetail.Venda = this.Cartao.Venda;
                vendaDetail.ShowDialog(this);
            }
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void ShowValues()
        {
            this.codigoTB.Text = this.Cartao.Id.ToString();
            this.numeroTB.Text = this.Cartao.Tipo;
            this.dataTB.Text = this.Cartao.Data.ToShortDateString();
            this.valorTB.Text = this.Cartao.Valor.ConvertToMoneyString();
            this.parcelasTB.Text = this.Cartao.Parcelas.ToString();

            if (this.Cartao.Venda != null)
            {
                groupBox1.Text = "Detalhes da venda";
                this.servicoCodigoTB.Text = this.Cartao.Venda.Id.ToString();
                this.servicoClienteNomeTB.Text = this.Cartao.Venda.Cliente.Nome;
                this.servicoDataTB.Text = this.Cartao.Venda.Data.ToString();
                this.servicoValorTB.Text = this.Cartao.Venda.Valor.ConvertToMoneyString();
            }

        }

        private void CartaoDetail_KeyDown(object sender, KeyEventArgs e)
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
