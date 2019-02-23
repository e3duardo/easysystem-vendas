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
    public partial class Comissao : Form
    {
        Forms.Comissao.ComissaoVendaDetail cvd = null;

        public Comissao()
        {
            InitializeComponent();
        }


        private void Comissao_Load(object sender, EventArgs e)
        {
            List<Library.Comissao> comissoes = Library.ComissaoBD.FindAdvanced();

            this.comissoesDGV.Rows.Clear();
            foreach (Library.Comissao comissao in comissoes)
            {
                this.comissoesDGV.Rows.Add(false, comissao.Id, comissao.Funcionario.Nome, comissao.Tipo, comissao.Porcentagem.ConvertToPercentString(), comissao.Valor.ConvertToMoneyString(), comissao.Pago);
            }
        }

        private void descontarButton_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < this.comissoesDGV.RowCount; i++ )
            {
                if ((bool)this.comissoesDGV[0, i].Value)
                {
                    Library.Comissao comissao = Library.ComissaoBD.FindComissaoById((long)this.comissoesDGV[1, i].Value);
                    comissao.Pago = 1;

                    //instanciando e definindo valores de uma transação
                    Library.CaixaTransacao caixaTransacao = new Library.CaixaTransacao();
                    caixaTransacao.Comissao = comissao;
                    caixaTransacao.Caixa = Library.CaixaBD.GetCaixaToday();
                    caixaTransacao.Hora = TimeSpan.Parse(DateTime.Now.ToShortTimeString());
                    caixaTransacao.Tipo = "Comissão";
                    caixaTransacao.Valor = comissao.Valor;
                    Library.CaixaTransacaoBD.Save(caixaTransacao);


                    Library.ComissaoBD.Update(comissao);

                    this.AtualizarGrid();
                }
            }
        }

        private void comissoesDGV_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow rowSelected = this.comissoesDGV.SelectedRows[0];

            Library.Comissao comissao = Library.ComissaoBD.FindComissaoById((long)rowSelected.Cells[1].Value);

            if (comissao.Venda != null)
            {
                cvd = new Forms.Comissao.ComissaoVendaDetail();
                cvd.Comissao = comissao;

                cvd.ShowDialog(this);
            }
        }

        private void Comissao_FormClosed(object sender, FormClosedEventArgs e)
        {
            Forms.OpenForm.RemoveForm(this);
        }

        private void AtualizarGrid()
        {
            List<Library.Comissao> comissoes = Library.ComissaoBD.FindAdvanced();

            this.comissoesDGV.Rows.Clear();
            foreach (Library.Comissao comissao in comissoes)
            {
                this.comissoesDGV.Rows.Add(false, comissao.Id, comissao.Funcionario.Nome, comissao.Tipo, comissao.Porcentagem.ConvertToPercentString(), comissao.Valor.ConvertToMoneyString(), comissao.Pago);
            }
        }

        private void Comissao_KeyDown(object sender, KeyEventArgs e)
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
