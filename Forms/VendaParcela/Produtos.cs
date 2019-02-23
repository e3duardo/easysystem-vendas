using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Library.Classes;

namespace Forms.Produto
{
    public partial class Produtos : UserControl
    {
        private delegate void InvokeDelegate(int index);

        private string RemoverProdutoMsg = "Deseja realmente remover este produto?";
        private string RemoverProdutoMsgTitle = "Remover produto";
        private string ValidateProdutoQuantidade = "Você deve informar o produto e a quantidade";
        private string ValidateProdutos = "Por favor adicione um produto!";

        public decimal ValorProdutos
        {
            get
            {
                decimal precoTMP = 0;

                foreach (DataGridViewRow row in this.produtoDGV.Rows)
                    precoTMP += (decimal)row.Cells[4].Value;

                return precoTMP;
            }
        }
        public decimal ValorProdutosAVista
        {
            get
            {
                decimal precoTMP = 0;

                foreach (DataGridViewRow row in this.produtoDGV.Rows)
                    precoTMP += (decimal)row.Cells[6].Value;

                return precoTMP;
            }
        }

        public List<Library.Classes.QItemProduto> produtos
        {
            get
            {
                List<Library.Classes.QItemProduto> produtosTMP = new List<Library.Classes.QItemProduto>();

                foreach (DataGridViewRow row in this.produtoDGV.Rows)
                {
                    Library.Produto produto = Library.ProdutoBD.FindProdutoById((long)row.Cells[0].Value);
                    Library.Classes.QItemProduto QItem = new Library.Classes.QItemProduto(produto, double.Parse(row.Cells[2].Value.ToString()), (decimal)row.Cells[3].Value, (decimal)row.Cells[4].Value);
                    produtosTMP.Add(QItem);
                }

                return produtosTMP;
            }
            set
            {
                List<Library.Classes.QItemProduto> produtosTMP = value;

                foreach (Library.Classes.QItemProduto QItem in produtosTMP)
                {
                    this.produtoDGV.Rows.Add(new object[] { QItem.Produto.Id, QItem.Produto.Nome, QItem.Quantidade, QItem.PretoUnitario, QItem.PrecoTotal });
                }
            }
        }



        public Produtos()
        {
            InitializeComponent();

        }

        //load's
        private void produtos_Load(object sender, EventArgs e)
        {
            FillProduto();

            this.produtoNomeCB.SelectedIndex = -1;
            this.produtoCodigoSistemaTB.Text = "";
            this.produtoCodigoBarraTB.Text = "";
            moneyTextBox1.Text = "";



            if (AVistaVisible)
            {
                this.precoAVista.Visible = true;
                this.Column1.Visible = true;
            }
            else
            {
                this.precoAVista.Visible = false;
                this.Column1.Visible = false;
            }
        }

        //click's
        private void produtoButton_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            Forms.OpenForm.OpenProduto();

            this.Cursor = Cursors.Default;
        }

        private void adicionarProdutoButton_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                Library.Produto produto = null;

                long produtoId = 0;
                long.TryParse(this.produtoCodigoSistemaTB.Text, out produtoId);

                string produtoCodigoBarra = this.produtoCodigoBarraTB.Text;

                decimal quantidade = 0;
                decimal.TryParse(this.produtoQuantidadeTB.Text, out quantidade);

                if (quantidade == 0 & Control.ModifierKeys == Keys.Control)
                {
                    quantidade = 1;
                }

                if (produtoId >= 0 & this.produtoCodigoSistemaRB.Checked == true)
                {
                    produto = Library.ProdutoBD.FindProdutoById(produtoId);
                }
                if (produtoCodigoBarra != "" & this.produtoCodigoBarraRB.Checked == true)
                {
                    List<Library.Produto> produtos = Library.ProdutoBD.FindAdvanced(new QItem("p.codigoBarra", produtoCodigoBarra));
                    if (produtos.Count == 1)
                    {
                        produto = produtos[0];
                    }
                }
                if (this.produtoNomeRB.Checked == true)
                {
                    if (this.produtoNomeCB.SelectedItem != null)
                        produto = (Library.Produto)this.produtoNomeCB.SelectedItem;
                }

                /***********************************************************************************/
                if (quantidade != 0 & produto != null)
                {
                    errorProvider.SetError(this.produtoAdicionarButton, "");
                    errorProvider.SetIconAlignment(this.produtoAdicionarButton, ErrorIconAlignment.MiddleRight);

                    int gridRowIndex = 0;
                    if (this.CheckProdutoAdicionado(produto.Id, out gridRowIndex))
                    {
                        decimal quant = (decimal)this.produtoDGV.Rows[gridRowIndex].Cells[2].Value;
                        quantidade = quantidade + quant;


                        this.produtoDGV.Rows[gridRowIndex].Cells[2].Value = quantidade;

                        if (moneyTextBox1.Value != 0)
                        {
                            this.produtoDGV.Rows[gridRowIndex].Cells[3].Value = moneyTextBox1.Value;
                            this.produtoDGV.Rows[gridRowIndex].Cells[4].Value = moneyTextBox1.Value * quantidade;
                            //this.produtoDGV.Rows[gridRowIndex].Cells[4].Value = produto.PrecoVenda * quantidade;
                            this.produtoDGV.Rows[gridRowIndex].Cells[5].Value = moneyTextBox1.Value;
                            this.produtoDGV.Rows[gridRowIndex].Cells[6].Value = moneyTextBox1.Value * quantidade;
                        }
                        else
                        {
                                this.produtoDGV.Rows[gridRowIndex].Cells[3].Value = produto.PrecoVenda;
                                this.produtoDGV.Rows[gridRowIndex].Cells[4].Value = produto.PrecoVenda * quantidade;
                                //this.produtoDGV.Rows[gridRowIndex].Cells[4].Value = produto.PrecoVenda * quantidade;
                                this.produtoDGV.Rows[gridRowIndex].Cells[5].Value = produto.PrecoVendaAVista;
                                this.produtoDGV.Rows[gridRowIndex].Cells[6].Value = produto.PrecoVendaAVista * quantidade;
                        }
                    }
                    else
                    {
                        if (moneyTextBox1.Value == 0)
                        {
                            //this.produtoDGV.Rows.Add(new object[] { produto.Id, produto.Nome, quantidade, produto.PrecoVenda, (produto.PrecoVenda * quantidade) });
                            this.produtoDGV.Rows.Add(new object[] { produto.Id, produto.Nome, quantidade, produto.PrecoVenda, (produto.PrecoVenda * quantidade), produto.PrecoVendaAVista, (produto.PrecoVendaAVista * quantidade) });
                        }
                        else
                        {
                            this.produtoDGV.Rows.Add(new object[] { produto.Id, produto.Nome, quantidade, moneyTextBox1.Value, (moneyTextBox1.Value * quantidade), moneyTextBox1.Value, (moneyTextBox1.Value * quantidade) });
                        }
                    }
                    this.produtoQuantidadeTB.Text = "";
                }
                else
                {
                    this.errorProvider.SetIconAlignment(this.produtoAdicionarButton, ErrorIconAlignment.MiddleLeft);
                    this.errorProvider.SetError(this.produtoAdicionarButton, this.ValidateProdutoQuantidade);
                }
                this.ParentForm.Refresh();
            }
            catch (Exception ex)
            {
                Library.Diagnostics.Logger.Error(ex);
            }

            this.Cursor = Cursors.Default;
        }


        private void produtoCodigoSistemaTB_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            produtoCodigoSistemaRB.Checked = true;
            produtoCodigoBarraRB.Checked = false;
            produtoNomeRB.Checked = false;

            this.Cursor = Cursors.Default;
        }

        private void produtoCodigoBarraTB_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            produtoCodigoSistemaRB.Checked = false;
            produtoCodigoBarraRB.Checked = true;
            produtoNomeRB.Checked = false;

            this.Cursor = Cursors.Default;
        }

        private void produtoNomeCB_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            produtoCodigoSistemaRB.Checked = false;
            produtoCodigoBarraRB.Checked = false;
            produtoNomeRB.Checked = true;

            this.Cursor = Cursors.Default;
        }

        //keyup's
        private void produtoCodigoSistemaTB_KeyUp(object sender, KeyEventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            long tmpIdProduto = 0;
            long.TryParse(this.produtoCodigoSistemaTB.Text, out tmpIdProduto);

            Library.Produto produto = Library.ProdutoBD.FindProdutoById(tmpIdProduto);

            if (produto != null)
            {
                this.produtoCodigoBarraTB.Text = produto.CodigoBarra;
                int i = 0;
                foreach (Library.Produto p in this.produtoNomeCB.Items)
                {
                    if (p.Id == produto.Id)
                    {
                        this.produtoNomeCB.SelectedIndex = i;
                        break;
                    }
                    i++;
                }
            }
            else
            {
                this.produtoCodigoBarraTB.Text = "";
                this.produtoNomeCB.SelectedIndex = -1;
            }
            this.Cursor = Cursors.Default;
        }

        private void produtoCodigoBarraTB_KeyUp(object sender, KeyEventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            if (this.produtoCodigoBarraTB.Text != "")
            {
                List<Library.Produto> produtos = Library.ProdutoBD.FindAdvanced(new QItem("p.codigoBarra", this.produtoCodigoBarraTB.Text));
                if (produtos.Count > 0)
                {
                    this.produtoCodigoSistemaTB.Text = string.Format("{0}", produtos[0].Id);
                    int i = 0;
                    foreach (Library.Produto p in this.produtoNomeCB.Items)
                    {
                        if (p.Id == produtos[0].Id)
                        {
                            this.produtoNomeCB.SelectedIndex = i;
                            break;
                        }
                        i++;
                    }
                }
                else
                {
                    this.produtoCodigoSistemaTB.Text = "";
                    this.produtoNomeCB.SelectedIndex = -1;
                }

            }
            this.Cursor = Cursors.Default;
        }

        //leave's
        private void produtoCodigoSistemaTB_Leave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            if (this.produtoCodigoSistemaTB.Text != "")
            {
                long tmpIdProduto = 0;
                long.TryParse(this.produtoCodigoSistemaTB.Text, out tmpIdProduto);

                Library.Produto produto = Library.ProdutoBD.FindProdutoById(tmpIdProduto);

                if (produto == null)
                {
                    this.produtoCodigoSistemaTB.Text = "";
                    this.produtoCodigoBarraTB.Text = "";
                    this.produtoNomeCB.SelectedIndex = -1;
                }
            }
            this.Cursor = Cursors.Default;
        }

        private void produtoCodigoBarraTB_Leave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            if (this.produtoCodigoBarraTB.Text != "")
            {
                List<Library.Produto> produtos = Library.ProdutoBD.FindAdvanced(new QItem("p.codigoBarra", this.produtoCodigoBarraTB.Text));
                if (produtos.Count == 0)
                {
                    this.produtoCodigoSistemaTB.Text = "";
                    this.produtoCodigoBarraTB.Text = "";
                    this.produtoNomeCB.SelectedIndex = -1;
                }
            }
            this.Cursor = Cursors.Default;
        }

        //selectedindexchanched's
        private void produtoNomeCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            if (this.produtoNomeCB.SelectedIndex != -1)
            {
                Library.Produto produto = (Library.Produto)this.produtoNomeCB.SelectedItem;

                if (produto != null)
                    this.produtoCodigoSistemaTB.Text = string.Format("{0}", produto.Id);
                else
                    this.produtoCodigoSistemaTB.Text = "";
                if (produto.CodigoBarra != null)
                    this.produtoCodigoBarraTB.Text = produto.CodigoBarra;
                else
                    this.produtoCodigoBarraTB.Text = "";
            }

            this.Cursor = Cursors.Default;
        }

        //cellclick's
        private void produtoDGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            try
            {
                if (e.RowIndex != -1)
                    if (produtoDGV.Columns[e.ColumnIndex].Name == "deleteColumn")
                        if (MessageBox.Show(this.RemoverProdutoMsg, this.RemoverProdutoMsgTitle, MessageBoxButtons.YesNo) == DialogResult.Yes)
                            this.produtoDGV.BeginInvoke(new InvokeDelegate(DeleteRow), new object[] { e.RowIndex });


            }
            catch (Exception ex)
            {
                Library.Diagnostics.Logger.Error(ex);
            }

            this.Cursor = Cursors.Default;
        }



        //methods
        private bool CheckProdutoAdicionado(long idProduto, out int gridRowIndex)
        {
            try
            {
                int vendaProdutoCount = this.produtoDGV.Rows.Count;
                for (int i = 0; i < vendaProdutoCount; i++)
                {
                    DataGridViewRow vendaProdutoEspecifico = (DataGridViewRow)this.produtoDGV.Rows[i];

                    if (idProduto == (long)vendaProdutoEspecifico.Cells[0].Value)
                    {
                        gridRowIndex = i;
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                Library.Diagnostics.Logger.Error(ex);
            }
            gridRowIndex = 0;
            return false;
        }

        private void DeleteRow(int index)
        {
            try
            {
                this.produtoDGV.Rows.RemoveAt(index);
                this.ParentForm.Refresh();
            }
            catch (Exception ex)
            {
                Library.Diagnostics.Logger.Error(ex);
            }
        }

        public void FillProduto()
        {
            this.produtoNomeCB.DisplayMember = "nome";
            this.produtoNomeCB.ValueMember = "id";
            this.produtoNomeCB.DataSource = Library.ProdutoBD.FindAdvanced(new QItem("ORDER BY","p.nome"));
        }

        public bool Validar()
        {
            if (this.produtoDGV.RowCount <= 0)
            {
                errorProvider.SetError(this.produtoL, ValidateProdutos);
                return false;
            }
            else
                errorProvider.SetError(this.produtoL, "");

            return true;
        }

        public void Clear()
        {
            this.produtoCodigoSistemaTB.Text = "";
            this.produtoCodigoBarraTB.Text = "";
            this.moneyTextBox1.Text = "";
            this.produtoNomeCB.SelectedIndex = -1;

            this.produtoDGV.Rows.Clear();
        }
    }
}
