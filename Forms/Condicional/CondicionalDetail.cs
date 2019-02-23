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

namespace Forms.Condicional
{
    public partial class CondicionalDetail : Form
    {
        string fvDeletarMsgSmall = "Desseja mesmo remover esta Condicional?";
        string fvDeletarMsgLarger = "Excluindo esta Condicional, todos seus produtos serão removidos também.";
        string fvDeletarMsgTitle = "Exclusão de Condicional";

        //private Library.Windows.Forms.Print print;
        //Reports.nota_orcamento notao;

        public Library.Condicional Orcamento { get; set; }
        
        /*************************************************/

        public CondicionalDetail()
        {
            InitializeComponent();
        }


        private void OrcamentoDetail_Load(object sender, EventArgs e)
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

            //print = new Library.Windows.Forms.Print(Library.Classes.Print.GeneratorStringOrcamento(this.Orcamento), "Orçamento");
            //print.ShowDialog(this);
            Library.Classes.Print.PrintCondicional(this.Orcamento);


            this.Cursor = Cursors.Default;
        }

        private void deletarButton_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            if (Library.Windows.Forms.MessageBox.Show(this.fvDeletarMsgTitle, this.fvDeletarMsgSmall, this.fvDeletarMsgLarger, "Sim", "Não", global::Resources.Properties.Resources.dialog_warning) == DialogResult.OK)
            {
                List<Library.CondicionalProduto> OrcamentoProdutos = Library.CondicionalProdutoBD.FindAdvanced(new QItem("o.id", this.Orcamento.Id));

                foreach (Library.CondicionalProduto a in OrcamentoProdutos)
                {
                    Library.Produto produtoTMP = a.Produto;
                    produtoTMP.Estoque += (double)a.Quantidade;
                    Library.ProdutoBD.Update(produtoTMP);
                }

                Library.CondicionalBD.DeleteById(this.Orcamento.Id);

                this.DialogResult = DialogResult.Ignore;
            }

            Forms.OpenForm.RefreshCondicionais();
            Forms.OpenForm.RefreshProdutos();

            this.Cursor = Cursors.Default;
        }

        private void venderButton_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            Forms.Venda.Venda venda = new Forms.Venda.Venda();
            venda.orcamento = this.Orcamento;
            venda.Show();
            venda.Disposed += delegate { venda.Dispose(); };

            List<Library.CondicionalProduto> OrcamentoProdutos = Library.CondicionalProdutoBD.FindAdvanced(new QItem("o.id", this.Orcamento.Id));
            
            foreach (Library.CondicionalProduto a in OrcamentoProdutos)
            {
                Library.Produto produtoTMP = a.Produto;
                produtoTMP.Estoque += (double)a.Quantidade;
                Library.ProdutoBD.Update(produtoTMP);
            }

            Library.CondicionalBD.DeleteById(this.Orcamento.Id);

            Forms.OpenForm.RefreshCondicionais();
            Forms.OpenForm.RefreshProdutos();

            this.Cursor = Cursors.Default;
        }

        private void ShowValues()
        {
            this.codigoTB.Text = this.Orcamento.Id.ToString();
            this.dataTB.Text = this.Orcamento.Data.ToString();
            this.clienteTB.Text = this.Orcamento.Cliente.Nome.ToString();
            this.vendedorTB.Text = this.Orcamento.Funcionario.Nome.ToString();
            this.valorTotalTB.Text = this.Orcamento.Valor.ConvertToMoneyString();
        }

        private void ShowProdutos()
        {
            List<Library.CondicionalProduto> OrcamentoProdutos = Library.CondicionalProdutoBD.FindAdvanced(new QItem("o.id",this.Orcamento.Id));

            this.OrcamentoProdutoDGV.Rows.Clear();
            
            foreach (Library.CondicionalProduto a in OrcamentoProdutos)
            {
                if (a != null & a.Produto != null)
                {                    
                    this.OrcamentoProdutoDGV.Rows.Add(a.Produto.Id, a.Produto.Nome, a.Quantidade, a.Preco, a.PrecoTotal);
                }
            }
        }

        private void CondicionalDetail_KeyDown(object sender, KeyEventArgs e)
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
