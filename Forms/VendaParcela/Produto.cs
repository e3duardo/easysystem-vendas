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

namespace Forms.Produto
{
    public partial class Produto : Form
    {
        /******************************************************/
        string fpProdutoDeletarMsg = "Deseja realmente excluir este produto?";
        string fpProdutoDeletarMsgTitle = "Excluir";
        string fpProdutoDeletarNoSelected = "Selecione um produto";

        string fpProdutoValidateNome = "Informe um nome.";
        string fpProdutoValidatePrecoVenda = "Informe um preço de venda.";
        string fpProdutoValidateSetor = "Informe um setor.";
        string fpProdutoValidateFornecedor = "Informe um fornecedor.";
        string fpProdutoValidatePrecoCustoTB = "Informe um preço de custo.";
        string fpProdutoValidateImpostoTB = "Informe um imposto.";
        string fpProdutoValidateLucroTB = "Informe um lucro.";
        /******************************************************/


        private string Modo { get; set; }

        public long IdSelecionado { get; set; }
        public int IndexSelecionado { get; set; }

        private Library.Produto produto;

        public Produto()
        {
            InitializeComponent();
        }



        // //////FUNÇÕES DE EVENTOS
        private void Produto_Load(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            this.MenuDisabler(true, false, false, false, false);
            this.RefreshForm();
            this.Modo = "visualizar";
            this.Cursor = Cursors.Default;
        }

        private void novoButton_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            this.MenuDisabler(false, false, true, true, false);
            this.InputDisabler(true);
            /************BEGIN************/
            this.ShowValues();

            codigoTB.Text = Library.ProdutoBD.GetNextId().ToString();
            vendidoTB.Text = "0";

            this.nomeTB.Focus();
            /*************END*************/
            this.Modo = "Cadastrar";
            this.Cursor = Cursors.Default;
        }

        private void editarButton_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            this.MenuDisabler(true, false, true, true, false);
            this.InputDisabler(true);
            /************BEGIN************/
            //achando idProduto selecionado na grid
            long idProduto = 0;
            for (int i = 0; i < dataGridView1.SelectedRows.Count; i++)
            {
                idProduto = (long)this.dataGridView1.SelectedRows[i].Cells["idDGVTBC"].Value;
            }
            //mostrando produto selecionado no formulario
            this.produto = Library.ProdutoBD.FindProdutoById(idProduto);
            this.ShowValues(this.produto);
            /*************END*************/
            this.Modo = "Editar";
            this.Cursor = Cursors.Default;
        }

        private void salvarButton_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            /************BEGIN************/
            if (ValidateForm())
            {
                this.MenuDisabler(true, false, false, false, false);
                this.InputDisabler(false);


                if (this.Modo == "Cadastrar")
                {
                    //criando um produto com valores do formulário
                    this.produto = this.ReturnProdutoFromForm();
                    //salvando produto
                    Library.ProdutoBD.Save(this.produto);

                    this.dataGridView1.Rows.Add(this.produto.Id, this.produto.Nome, this.produto.DataCadastro);
                }
                else
                {
                    this.produto = this.UpdateProdutoFromForm();
                    //atualizando produto
                    Library.ProdutoBD.Update(this.produto);

                    foreach (DataGridViewRow d in dataGridView1.Rows)
                    {
                        if ((long)d.Cells[0].Value == this.produto.Id)
                        {
                            d.Cells[0].Value = this.produto.Id;
                            d.Cells[1].Value = this.produto.Nome;
                            d.Cells[2].Value = this.produto.DataCadastro;
                        }
                    }
                }


                //atualizando formulário
                //RefreshForm();
                RefreshChilds();

                this.Modo = "Salvar";
            }
            else
            {
                //mensagem de erro
            }
            /*************END*************/
            this.Cursor = Cursors.Default;
        }

        private void cancelarButton_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            this.MenuDisabler(true, false, false, false, false);
            this.InputDisabler(false);
            /************BEGIN************/
            this.RefreshForm();
            /*************END*************/
            this.Modo = "Cancelar";
            this.Cursor = Cursors.Default;
        }

        private void excluirButton_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            this.InputDisabler(false);
            /************BEGIN************/
            //achando idProduto selecionado na grid
            long idProduto = 0;
            for (int i = 0; i < dataGridView1.SelectedRows.Count; i++)
            {
                idProduto = (long)this.dataGridView1.SelectedRows[i].Cells["idDGVTBC"].Value;
            }
            if (MessageBox.Show(this.fpProdutoDeletarMsg, this.fpProdutoDeletarMsgTitle, MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                //se não tiver selecionado mostra mensagem se estiver deleta e atualiza formulario
                if (dataGridView1.SelectedRows.Count != 1)
                {
                    MessageBox.Show(this.fpProdutoDeletarNoSelected);
                }
                else
                {
                    Library.ProdutoBD.DeleteById(idProduto);
                    this.RefreshForm();
                }
            }

            /*************END*************/
            this.Modo = "Excluir";
            this.Cursor = Cursors.Default;
        }

        private void pesquisarButton_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            this.InputDisabler(false);
            /************BEGIN************/
            List<Library.Produto> produtos;
            if (this.filtrosTextBox.Text == "")
            {
                produtos = Library.ProdutoBD.FindAdvanced();
            }
            else
            {
                long id;
                if (long.TryParse(this.filtrosTextBox.Text, out id))
                {
                    produtos = Library.ProdutoBD.FindAdvanced(new QItem("p.id", id));
                }
                else
                {
                    produtos = Library.ProdutoBD.FindAdvanced(new QItem("p.nome LIKE %%", this.filtrosTextBox.Text));
                }
            }

            this.dataGridView1.Rows.Clear();
            foreach (Library.Produto p in produtos)
            {
                this.dataGridView1.Rows.Add(p.Id, p.Nome, p.DataCadastro);
            }
            /*************END*************/
            this.Modo = "Pesquisar";
            this.Cursor = Cursors.Default;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            this.MenuDisabler(true, true, false, false, true);
            this.InputDisabler(false);
            /************BEGIN************/
            //achando idProduto selecionado na grid
            long idProduto = 0;
            for (int i = 0; i < dataGridView1.SelectedRows.Count; i++)
            {
                idProduto = (long)this.dataGridView1.SelectedRows[i].Cells["idDGVTBC"].Value;
            }
            //mostrando produto selecionado no formulario
            this.produto = Library.ProdutoBD.FindProdutoById(idProduto);
            this.ShowValues(produto);
            /*************END*************/
            this.Modo = "Selecionar";
            this.Cursor = Cursors.Default;
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            editarButton.PerformClick();
        }

        private void setorButton_Click(object sender, EventArgs e)
        {
            Forms.OpenForm.OpenSetor();
        }

        private void fornecedorButton_Click(object sender, EventArgs e)
        {
            Forms.OpenForm.OpenFornecedor();
        }

        private void Produto_FormClosed(object sender, FormClosedEventArgs e)
        {
            Forms.OpenForm.RemoveForm(this);
        }


        private void Produto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode.ToString() == "N")
            {
                this.novoButton.PerformClick();
            }
            if (e.Control && e.KeyCode.ToString() == "E")
            {
                this.editarButton.PerformClick();
            }
            if (e.Control && e.KeyCode.ToString() == "S")
            {
                this.salvarButton.PerformClick();
            }
            if (e.Control && e.KeyCode.ToString() == "R")
            {
                this.cancelarButton.PerformClick();
            }
            if (e.Control && e.KeyCode.ToString() == "X")
            {
                this.excluirButton.PerformClick();
            }

        }


        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (this.dataGridView1.SelectedRows.Count == 1)
                IndexSelecionado = this.dataGridView1.Rows.IndexOf(this.dataGridView1.SelectedRows[0]);
        }



        // //////FUNÇÕES DO FORMULÁRIO

        //atualizar formulario
        private void RefreshForm()
        {
            try
            {
                //desabilitando certos menus e campos
                this.MenuDisabler(true, false, false, false, false);
                this.InputDisabler(false);

                this.FillFornecedor();
                this.FillSetor();

                //preenchendo um dataset e ligando-o na grid
                List<Library.Produto> produtos = Library.ProdutoBD.FindAdvanced();

                int i = 0;
                this.dataGridView1.Rows.Clear();
                foreach (Library.Produto p in produtos)
                {
                    if (i == 0)
                        this.ShowValues(p);

                    this.dataGridView1.Rows.Add(p.Id, p.Nome, p.DataCadastro);

                    i++;
                }

                if (this.IdSelecionado != 0)
                {
                    this.produto = Library.ProdutoBD.FindProdutoById(this.IdSelecionado);
                    this.ShowValues(produto);

                    this.dataGridView1.ClearSelection();

                    for (int p = 0; p < dataGridView1.Rows.Count; p++)
                    {
                        if (long.Parse(this.dataGridView1.Rows[p].Cells["idDGVTBC"].Value.ToString()) == this.IdSelecionado)
                        {
                            this.dataGridView1.Rows[p].Cells["idDGVTBC"].Selected = true;
                            break;
                        }
                    }

                    this.MenuDisabler(true, true, false, false, true);
                    this.InputDisabler(false);
                    this.Modo = "Selecionar";
                }
            }
            catch (Exception ex)
            {
                Library.Diagnostics.Logger.Error(ex);
            }
        }
        private void RefreshChilds()
        {
            foreach (Form a in System.Windows.Forms.Application.OpenForms)
            {
                if (a is Forms.Condicional.Condicional)
                {
                    Forms.Condicional.Condicional form = (Forms.Condicional.Condicional)a;
                    form.FillProduto();
                }
                if (a is Forms.Venda.Venda)
                {
                    Forms.Venda.Venda form = (Forms.Venda.Venda)a;
                    form.FillProduto();
                }
            }
            Forms.OpenForm.RefreshProdutos();
        }

        public void FillFornecedor()
        {
            //this.idFornecedorCB.Items.Clear();
            this.idFornecedorCB.DisplayMember = "nome";
            this.idFornecedorCB.ValueMember = "id";
            //this.idFornecedorCB.Items.AddRange(Library.FornecedorBD.FindAdvanced());
            this.idFornecedorCB.DataSource = Library.FornecedorBD.FindAdvanced(new QItem("ORDER BY", "f.nome"));
        }
        public void FillSetor()
        {
            this.idSetorCB.DisplayMember = "nome";
            this.idSetorCB.ValueMember = "id";
            this.idSetorCB.DataSource = Library.SetorBD.FindAdvanced(new QItem("ORDER BY", "s.nome"));
        }

        //mostrar valores no formulario
        private void ShowValues(Library.Produto produto)
        {
            int fi = 0;
            foreach (Library.Fornecedor f in this.idFornecedorCB.Items)
            {
                if (f.Id == produto.Fornecedor.Id)
                {
                    this.idFornecedorCB.SelectedIndex = fi;
                    break;
                }
                fi++;
            }
            int si = 0;
            foreach (Library.Setor s in this.idSetorCB.Items)
            {
                if (s.Id == produto.Setor.Id)
                {
                    this.idSetorCB.SelectedIndex = si;
                    break;
                }
                si++;

            }

            this.codigoTB.Text = string.Format("{0}", produto.Id);
            this.codigoBarraTB.Text = produto.CodigoBarra;
            this.estoqueTB.Text = string.Format("{0}", produto.Estoque);
            this.estoqueRiscoTB.Text = string.Format("{0}", produto.EstoqueRisco);
            this.impostoTB.Text = string.Format("{0}", produto.Imposto);
            this.lucroTB.Text = string.Format("{0}", produto.Lucro);
            this.nomeTB.Text = produto.Nome;
            this.precoCustoTB.Text = string.Format("{0:C2}", produto.PrecoCusto);
            this.precoTB.Text = string.Format("{0:C2}", produto.PrecoVenda);
            this.precoVendaTB.Text = string.Format("{0:C2}", produto.PrecoVendaAVista);
            this.descontoAVistaTB.Text = string.Format("{0}", produto.DescontoAVista);
            this.vendidoTB.Text = string.Format("{0}", produto.Vendido);
        }
        private void ShowValues()
        {
            this.codigoTB.Text = "";
            this.idFornecedorCB.SelectedIndex = -1;
            this.idSetorCB.SelectedIndex = -1;
            this.codigoBarraTB.Text = "";
            this.estoqueTB.Text = "";
            this.estoqueRiscoTB.Text = "";
            this.impostoTB.Text = "0";
            this.lucroTB.Text = "0";
            this.nomeTB.Text = "";
            this.precoCustoTB.Text = "0";
            this.precoTB.Text = "0";
            this.precoVendaTB.Text = "0";
            this.descontoAVistaTB.Text = "0";
            this.vendidoTB.Text = "";
        }

        //retornar objeto produto com valores do formulario
        private Library.Produto ReturnProdutoFromForm()
        {
            Library.Produto produtoTemp = new Library.Produto();

            //produtoTemp.Id =  long.Parse(this.codigoTB.Text);
            produtoTemp.Fornecedor = (Library.Fornecedor)this.idFornecedorCB.SelectedItem;
            produtoTemp.Setor = (Library.Setor)this.idSetorCB.SelectedItem;
            produtoTemp.CodigoBarra = this.codigoBarraTB.Text;
            produtoTemp.Estoque = this.estoqueTB.Text.ConvertToDouble();
            produtoTemp.EstoqueRisco = this.estoqueRiscoTB.Text.ConvertToDouble();
            produtoTemp.Imposto = this.impostoTB.Text.ConvertToInt();
            produtoTemp.Lucro = this.lucroTB.Text.ConvertToInt();
            produtoTemp.Nome = this.nomeTB.Text;
            produtoTemp.PrecoCusto = this.precoCustoTB.Text.ConvertToDecimal();
            produtoTemp.PrecoVenda = this.precoTB.Text.ConvertToDecimal();
            produtoTemp.PrecoVendaAVista = this.precoVendaTB.Text.ConvertToDecimal();
            produtoTemp.Vendido = this.vendidoTB.Text.ConvertToDouble();
            produtoTemp.DescontoAVista = this.descontoAVistaTB.Text.ConvertToInt();
            produtoTemp.DataCadastro = DateTime.Now;

            return produtoTemp;
        }

        //atualizar objeto produto com valores do formulario
        private Library.Produto UpdateProdutoFromForm()
        {
            Library.Produto produtoTemp = this.produto;

            produtoTemp.Id = long.Parse(this.codigoTB.Text);
            produtoTemp.Fornecedor = (Library.Fornecedor)this.idFornecedorCB.SelectedItem;
            produtoTemp.Setor = (Library.Setor)this.idSetorCB.SelectedItem;
            produtoTemp.CodigoBarra = this.codigoBarraTB.Text;
            produtoTemp.Estoque = this.estoqueTB.Text.ConvertToDouble();
            produtoTemp.EstoqueRisco = this.estoqueRiscoTB.Text.ConvertToDouble();
            produtoTemp.Imposto = this.impostoTB.Text.ConvertToInt();
            produtoTemp.Lucro = this.lucroTB.Text.ConvertToInt();
            produtoTemp.Nome = this.nomeTB.Text;
            produtoTemp.PrecoCusto = this.precoCustoTB.Text.ConvertToDecimal();
            produtoTemp.PrecoVenda = this.precoTB.Text.ConvertToDecimal();
            produtoTemp.PrecoVendaAVista = this.precoVendaTB.Text.ConvertToDecimal();
            produtoTemp.Vendido = this.vendidoTB.Text.ConvertToDouble();
            produtoTemp.DescontoAVista = this.descontoAVistaTB.Text.ConvertToInt();
            //produtoTemp.DataCadastro = DateTime.Now;

            return produtoTemp;
        }

        private void MenuDisabler(bool novo, bool editar, bool salvar, bool cancelar, bool excluir)
        {
            this.novoButton.Enabled = novo;
            this.editarButton.Enabled = editar;
            this.salvarButton.Enabled = salvar;
            this.cancelarButton.Enabled = cancelar;
            this.excluirButton.Enabled = excluir;
        }
        private void InputDisabler(bool habilitado = true)
        {
            this.panel1.Enabled = habilitado;
            this.tableLayoutPanel1.Enabled = !habilitado;
        }

        public void SelectById(long id)
        {
            this.produto = Library.ProdutoBD.FindProdutoById(id);
            this.ShowValues(produto);

            this.dataGridView1.ClearSelection();

            for (int p = 0; p < dataGridView1.Rows.Count; p++)
            {
                if (long.Parse(this.dataGridView1.Rows[p].Cells["idDGVTBC"].Value.ToString()) == id)
                {
                    this.dataGridView1.Rows[p].Cells["idDGVTBC"].Selected = true;
                    break;
                }
            }

            this.MenuDisabler(true, true, false, false, true);
            this.InputDisabler(false);
            this.Modo = "Selecionar";
        }

        private void CalcularPreco()
        {
            if (ValidateForm2())
            {
                decimal precoCusto = this.precoCustoTB.Value.GetValueOrDefault(0);
                decimal imposto = this.impostoTB.Value;
                decimal lucro = this.lucroTB.Value;

                decimal impostosPorcentagem = 0;
                decimal precoVendaComImpostos = 0;
                decimal lucroPorcentagem = 0;
                decimal precoVenda = 0;

                if (this.impostoTB.Text != "" & imposto != 0)
                {
                    //calculando impostos
                    impostosPorcentagem = precoCusto * (imposto / 100);
                    //somando impostos com preço de custo
                    precoVendaComImpostos = precoCusto + impostosPorcentagem;
                }
                else
                {
                    precoVendaComImpostos = precoCusto;
                }

                if (this.lucroTB.Text != "" & lucro != 0)
                {
                    //calculando lucro
                    lucroPorcentagem = precoVendaComImpostos * (lucro / 100);
                    //somando lucro com preço de custo com impostos
                    precoVenda = precoVendaComImpostos + lucroPorcentagem;
                }
                else
                {
                    precoVenda = precoVendaComImpostos;
                }

                this.precoTB.Text = precoVenda.ConvertToMoneyString();

                CalcularPrecoVenda();
            }
        }

        private void CalcularPrecoVenda()
        {
            if (ValidateForm2())
            {
                decimal preco = this.precoTB.Value.GetValueOrDefault(0);
                decimal desconto = this.descontoAVistaTB.Value;

                decimal porcentagem = 0;
                decimal precoVendaComDesconto = 0;

                porcentagem = preco * (desconto / 100);
                precoVendaComDesconto = preco - porcentagem;

                this.precoVendaTB.Text = precoVendaComDesconto.ConvertToMoneyString();
            }
        }

        // //////FUNÇÕES DE VALIDAÇÕS
        private void nomeTextBox_Validating(object sender, CancelEventArgs e)
        {
            ValidateNome();
        }
        private void precoVendaTB_Validating(object sender, CancelEventArgs e)
        {
            ValidatePrecoVenda();
        }
        private void idSetorCB_Validating(object sender, CancelEventArgs e)
        {
            this.ValidateSetor();
        }
        private void idFornecedorCB_Validating(object sender, CancelEventArgs e)
        {
            this.ValidateFornecedor();
        }

        private bool ValidateNome()
        {
            if (this.nomeTB.Text == "")
            {
                this.errorProvider.SetError(this.nomeTB, this.fpProdutoValidateNome);
                return false;
            }
            else
            {
                this.errorProvider.SetError(this.nomeTB, "");
            }
            return true;
        }
        private bool ValidatePrecoVenda()
        {
            if (this.precoTB.Text == "")
            {
                this.errorProvider.SetError(this.precoTB, this.fpProdutoValidatePrecoVenda);
                return false;
            }
            else
            {
                this.errorProvider.SetError(this.precoTB, "");
            }
            return true;
        }
        private bool ValidateSetor()
        {
            if (this.idSetorCB.SelectedIndex == -1)
            {
                this.errorProvider.SetError(this.setorButton, this.fpProdutoValidateSetor);
                return false;
            }
            else
            {
                this.errorProvider.SetError(this.setorButton, "");
            }
            return true;
        }
        private bool ValidateFornecedor()
        {
            if (this.idFornecedorCB.SelectedIndex == -1)
            {
                this.errorProvider.SetError(this.fornecedorButton, this.fpProdutoValidateFornecedor);
                return false;
            }
            else
            {
                this.errorProvider.SetError(this.fornecedorButton, "");
            }
            return true;
        }
        private bool ValidateCusto()
        {
            if (this.precoCustoTB.Text == "")
            {
                this.errorProvider.SetError(this.precoCustoTB, this.fpProdutoValidatePrecoCustoTB);
                return false;
            }
            else
            {
                this.errorProvider.SetError(this.precoCustoTB, "");
            }
            return true;
        }
        private bool ValidateImposto()
        {
            if (this.impostoTB.Text == "")
            {
                this.errorProvider.SetError(this.impostoTB, this.fpProdutoValidateImpostoTB);
                return false;
            }
            else
            {
                this.errorProvider.SetError(this.impostoTB, "");
            }
            return true;
        }
        private bool ValidateLucro()
        {
            if (this.lucroTB.Text == "")
            {
                this.errorProvider.SetError(this.lucroTB, this.fpProdutoValidateLucroTB);
                return false;
            }
            else
            {
                this.errorProvider.SetError(this.lucroTB, "");
            }
            return true;
        }

        private bool ValidateForm()
        {
            bool bValidNome = ValidateNome();
            bool bValidSetor = ValidateSetor();
            bool bValidFornecedor = ValidateFornecedor();
            bool bValidPrecoVenda = ValidatePrecoVenda();

            if (bValidNome & bValidSetor & bValidFornecedor & bValidPrecoVenda)
                return true;

            return false;
        }
        private bool ValidateForm2()
        {
            bool bValidCusto = ValidateCusto();
            bool bValidImposto = ValidateImposto();
            bool bValidLucro = ValidateLucro();

            if (bValidCusto & bValidImposto & bValidLucro)
                return true;

            return false;
        }


        private void precoCustoTB_Leave(object sender, EventArgs e)
        {
            CalcularPreco();
        }
        private void impostoTB_Leave(object sender, EventArgs e)
        {
            CalcularPreco();
        }
        private void lucroTB_Leave(object sender, EventArgs e)
        {
            CalcularPreco();
        }
        private void precoTB_Leave(object sender, EventArgs e)
        {
            CalcularPrecoVenda();
        }
        private void descontoAVistaTB_Leave(object sender, EventArgs e)
        {
            CalcularPrecoVenda();
        }
    }
}
