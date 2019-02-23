using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Library.Converter;
using Library.Classes;

namespace Forms.Venda
{
    public partial class VendaDetail : Form
    {
        string fvDeletarMsgSmall = "Desseja mesmo remover esta venda?";
        string fvDeletarMsgLarger = "Excluindo esta venda, todos seus produtos e parcelas serão removidos também, mas, por precaução, não retornará seus valores ao Caixa.";
        string fvDeletarMsgTitle = "Exclusão de venda";


        //private Library.Windows.Forms.Print print;
        //Reports.nota_venda notav;

        public Library.Venda Venda { get; set; }

        Forms.VendaParcela.VendaParcelaGrid vendaParcela = null;
        Forms.Cheque.ChequeGrid cheque = null;

        /*************************************************/

        public VendaDetail()
        {
            InitializeComponent();
        }


        private void VendaDetail_Load(object sender, EventArgs e)
        {
            this.ShowValues();
            this.ShowProdutos();
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            this.DialogResult = DialogResult.OK;

            this.Cursor = Cursors.Default;
        }

        private void imprimirButton_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            //print = new Library.Windows.Forms.Print(Library.Classes.Print.GeneratorStringVenda(this.Venda), "Venda");
            //print.ShowDialog(this);
            //notav = new Reports.nota_venda();
            //notav.Venda = this.Venda;
            //notav.ShowDialog(this);

            Library.Classes.Print.PrintVenda(this.Venda);

            this.Cursor = Cursors.Default;
        }

        private void deletarButton_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            if (Library.Windows.Forms.MessageBox.Show(this.fvDeletarMsgTitle, this.fvDeletarMsgSmall, this.fvDeletarMsgLarger, "Sim", "Não", global::Resources.Properties.Resources.dialog_warning) == DialogResult.OK)
            {
                Library.VendaBD.Delete(this.Venda);
                this.DialogResult = DialogResult.Ignore;
            }

            this.Cursor = Cursors.Default;
        }

        private void parcelasTSMI_Click(object sender, EventArgs e)
        {
            vendaParcela = new Forms.VendaParcela.VendaParcelaGrid();
            vendaParcela.VendaParcelas = Library.VendaParcelaBD.FindAdvanced(new QItem("v.id", this.Venda.Id));
            vendaParcela.ShowDialog(this);
        }

        private void chequesTSMI_Click(object sender, EventArgs e)
        {
            cheque = new Forms.Cheque.ChequeGrid();
            cheque.Cheques = Library.ChequeBD.FindAdvanced(new QItem("v.id", this.Venda.Id));
            cheque.ShowDialog(this);
        }

        private void ShowValues()
        {
            this.codigoTB.Text = this.Venda.Id.ToString();
            this.dataTB.Text = this.Venda.Data.ToString();
            this.clienteTB.Text = this.Venda.Cliente.Nome.ToString();
            this.vendedorTB.Text = this.Venda.Funcionario.Nome.ToString();
            this.valorTotalTB.Text = this.Venda.Valor.ConvertToMoneyString();


            if (this.Venda.Pago == 1)
                this.pagoTB.Text = "Sim";
            else
                this.pagoTB.Text = "Não";

            parcelasTSMI.Enabled = false;
            chequesTSMI.Enabled = false;
            switch (this.Venda.FormaPagamento)
            {
                case "avista":
                    this.formaDePagamentoTB.Text = "À vista";
                    break;
                case "aprazo":
                    this.formaDePagamentoTB.Text = "À prazo";
                    parcelasTSMI.Enabled = true;
                    break;
                case "cartao":
                    this.formaDePagamentoTB.Text = "Cartão";
                    break;
                case "cheque":
                    this.formaDePagamentoTB.Text = "Cheque";
                    chequesTSMI.Enabled = true;
                    break;
                default:
                    this.formaDePagamentoTB.Text = this.Venda.FormaPagamento;
                    break;
            }
        }

        private void ShowProdutos()
        {
            //Library.VendaProduto[] VendaProdutos = Library.VendaProdutoBD.FindAdvanced("v.id = " + this.Venda.Id);
            List<Library.VendaProduto> VendaProdutos = Library.VendaProdutoBD.FindAdvanced(new QItem("v.id", this.Venda.Id));

            this.vendaProdutoDGV.Rows.Clear();

            foreach (Library.VendaProduto a in VendaProdutos)
            {
                if (a != null & a.Produto != null)
                {
                    this.vendaProdutoDGV.Rows.Add(a.Produto.Id, a.Produto.Nome, a.Quantidade, a.Preco, a.PrecoTotal);
                }
            }
        }


    }
}
