using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using Library.Converter;
using Library.Classes;

namespace Forms.Venda
{
    partial class Venda
    {
        /*************************************************/
        string fvVendaToolbarAbrindoFormaPagamento = "Abrindo Forma de Pagamento";
        string fvVendaToolbarSalvandoVenda = "Salvando Venda";
        string fvVendaToolbarSalvandoProdutos = "Salvando Produtos";
        string fvVendaToolbarSalvandoParcelas = "Salvando Parcelas";
        string fvVendaToolbarNovaVenda = "Nova venda código: {0}";

        string fvVendaImprimirMsg = "Deseja imprimir esta venda?";
        string fvVendaImprimirMsgTitle = "Imprimir";

        string fvVendaValidateFuncionario = "Por favor informe o funcionário!";
        string fvVendaValidateCliente = "Por favor informe o cliente!";
        /*************************************************/



        private void RefreshForm()
        {
            try
            {
                this.FillCliente();
                this.FillFuncionario();

                this.ShowValues();

                if (this.orcamento != null)
                {
                    this.ShowOrcamento(this.orcamento);
                    this.Refresh();
                }

                this.toolbarStatusTSSL.Text = string.Format(this.fvVendaToolbarNovaVenda, this.codigoTB.Text);
            }
            catch (Exception ex)
            {
                Library.Diagnostics.Logger.Error(ex);
            }
        }

        private void RefreshChilds()
        {
            Forms.OpenForm.RefreshProdutos();
        }

        public override void Refresh()
        {
            this.valorTotalTextBox.Text = this.produtos1.ValorProdutos.ConvertToMoneyString();
        }

        private decimal PerformLimiteCliente(Library.Cliente cliente)
        {

            textBoxLimiteVendaAPrazo.Text = "0";

            decimal limite = cliente.LimiteVendaAPrazo;
            decimal dividas = Library.ClienteBD.GetParcelasAtrasadasValorById(cliente.Id);
            decimal novoLimite = limite - dividas - this.produtos1.ValorProdutos;

            if (cliente.AptoVendaAPrazo == 0)
            {
                textBoxStatusVendaAPrazo.Text = "Negada";
                textBoxStatusVendaAPrazo.BackColor = Color.FromArgb(250, 200, 187);
                textBoxLimiteVendaAPrazo.BackColor = Color.FromArgb(250, 200, 187);
                return 0;
            }
            else
            {
                if (novoLimite <= 0)
                {
                    textBoxStatusVendaAPrazo.Text = "Sem limite";
                    textBoxStatusVendaAPrazo.BackColor = Color.FromArgb(250, 200, 187);
                    textBoxLimiteVendaAPrazo.BackColor = Color.FromArgb(250, 200, 187);
                    return 0;
                }
                else
                {
                    textBoxLimiteVendaAPrazo.Text = novoLimite.ConvertToMoneyString();
                    textBoxStatusVendaAPrazo.Text = "Aprovado";
                    textBoxStatusVendaAPrazo.BackColor = Color.FromArgb(200, 240, 180);
                    textBoxLimiteVendaAPrazo.BackColor = Color.FromArgb(200, 240, 180);
                    return novoLimite;
                }
            }
        }

        public void FillCliente()
        {
            this.idClienteCB.DisplayMember = "nome";
            this.idClienteCB.ValueMember = "id";
            this.idClienteCB.DataSource = Library.ClienteBD.FindAdvanced(new QItem("ORDER BY", "c.nome"));
        }

        public void FillFuncionario()
        {
            this.funcionarioCB.DisplayMember = "nome";
            this.funcionarioCB.ValueMember = "id";
            this.funcionarioCB.DataSource = Library.FuncionarioBD.FindAdvanced(new QItem("ORDER BY", "f.nome"));
        }

        public void FillProduto()
        {
            produtos1.FillProduto();
        }

        private void ShowValues()
        {
            this.codigoTB.Text = string.Format("{0}", Library.VendaBD.GetNextId());
            this.funcionarioCB.SelectedIndex = -1;
            this.dataTB.Text = string.Format("{0}", DateTime.Now);

            this.idClienteTB.Text = "";
            this.idClienteCB.SelectedIndex = -1;


            this.valorTotalTextBox.Text = "";
        }

        private Library.Venda ReturnVendaFromForm()
        {
            this.venda = new Library.Venda();

            this.venda.Id = long.Parse(this.codigoTB.Text);

            Library.Cliente clientetmp = (Library.Cliente)this.idClienteCB.SelectedItem;
            if (clientetmp.Id == long.Parse(this.idClienteTB.Text))
            {
                this.venda.Cliente = clientetmp;
            }
            else
            {
                this.venda.Cliente = null;
            }

            this.venda.Funcionario = (Library.Funcionario)this.funcionarioCB.SelectedItem;

            this.venda.Data = DateTime.Parse(this.dataTB.Text);
            this.venda.Valor = this.valorTotalTextBox.Text.ConvertToDecimal();

            return venda;
        }

        private List<Library.VendaProduto> ReturnVendaProdutoFromForm(long idVendaAtual)
        {
            try
            {
                List<Library.VendaProduto> vendaProdutoArray = new List<Library.VendaProduto>();

                foreach (Library.Classes.QItemProduto p in this.produtos1.produtos)
                {
                    Library.VendaProduto VendaProduto = new Library.VendaProduto();
                    VendaProduto.Venda = Library.VendaBD.FindVendaById(idVendaAtual);
                    VendaProduto.Produto = p.Produto;
                    VendaProduto.Quantidade = p.Quantidade;
                    VendaProduto.Preco = p.PrecoTotal;
                    VendaProduto.PrecoTotal = p.PrecoTotal;

                    vendaProdutoArray.Add(VendaProduto);
                }
                return vendaProdutoArray;
            }
            catch (Exception ex)
            {
                Library.Diagnostics.Logger.Error(ex);
            }

            return null;
        }

        private Library.VendaParcela[] ReturnVendaParcela(DataGridView dataGrid, long idVendaAtual)
        {
            try
            {
                int vendaParcelaCount = dataGrid.Rows.Count;

                Library.VendaParcela[] vendaParcelaArray = new Library.VendaParcela[vendaParcelaCount];

                for (int i = 0; i < vendaParcelaCount; i++)
                {
                    vendaParcelaArray[i] = new Library.VendaParcela();
                    vendaParcelaArray[i].Venda = Library.VendaBD.FindVendaById(idVendaAtual);
                    vendaParcelaArray[i].Data = DateTime.Parse(dataGrid.Rows[i].Cells[1].Value.ToString());
                    vendaParcelaArray[i].Pago = 0;
                    vendaParcelaArray[i].Valor = (decimal)dataGrid.Rows[i].Cells[0].Value;
                }
                return vendaParcelaArray;
            }
            catch (Exception ex)
            {
                Library.Diagnostics.Logger.Error(ex);
            }

            return null;
        }

        private Library.Cheque[] ReturnCheque(DataGridView dataGrid, long idVendaAtual)
        {
            try
            {
                int chequeCount = dataGrid.Rows.Count;

                Library.Cheque[] chequeArray = new Library.Cheque[chequeCount];

                for (int i = 0; i < chequeCount; i++)
                {
                    chequeArray[i] = new Library.Cheque();
                    chequeArray[i].Venda = Library.VendaBD.FindVendaById(idVendaAtual);
                    chequeArray[i].Data = DateTime.Parse(dataGrid.Rows[i].Cells[2].Value.ToString());
                    chequeArray[i].Numero = dataGrid.Rows[i].Cells[0].Value.ToString();
                    chequeArray[i].Valor = (decimal)dataGrid.Rows[i].Cells[1].Value;
                }
                return chequeArray;
            }
            catch (Exception ex)
            {
                Library.Diagnostics.Logger.Error(ex);
            }

            return null;
        }

        private Library.Cartao[] ReturnCartao(DataGridView dataGrid, long idVendaAtual)
        {
            try
            {
                int cartaoCount = dataGrid.Rows.Count;

                Library.Cartao[] cartaoArray = new Library.Cartao[cartaoCount];

                for (int i = 0; i < cartaoCount; i++)
                {
                    cartaoArray[i] = new Library.Cartao();
                    cartaoArray[i].Venda = Library.VendaBD.FindVendaById(idVendaAtual);
                    cartaoArray[i].Data = DateTime.Parse(dataGrid.Rows[i].Cells[1].Value.ToString());
                    cartaoArray[i].Tipo = "Crédito";
                    cartaoArray[i].Valor = (decimal)dataGrid.Rows[i].Cells[0].Value;
                }
                return cartaoArray;
            }
            catch (Exception ex)
            {
                Library.Diagnostics.Logger.Error(ex);
            }

            return null;
        }

        public void ShowOrcamento(Library.Condicional orcamento)
        {
            List<Library.CondicionalProduto> OrcamentoProdutos = Library.CondicionalProdutoBD.FindAdvanced(new QItem("o.id", orcamento.Id));

            List<Library.Classes.QItemProduto> QItems = new List<Library.Classes.QItemProduto>();

            foreach (Library.CondicionalProduto a in OrcamentoProdutos)
            {
                Library.Classes.QItemProduto QItem = new Library.Classes.QItemProduto(a.Produto, (int)a.Quantidade, (decimal)a.Preco, (decimal)a.PrecoTotal);
                QItems.Add(QItem);
            }

            produtos1.produtos = QItems;

            int fi = 0;
            foreach (Library.Funcionario f in funcionarioCB.Items)
            {
                if (f.Id == orcamento.Funcionario.Id)
                {
                    funcionarioCB.SelectedIndex = fi;
                    break;
                }
                fi++;
            }

            int ci = 0;
            foreach (Library.Cliente c in idClienteCB.Items)
            {
                if (c.Id == orcamento.Cliente.Id)
                {
                    idClienteCB.SelectedIndex = ci;
                    break;
                }
                ci++;
            }
        }

        private bool ValidateFuncionario()
        {
            if (this.funcionarioCB.SelectedIndex == -1)
            {
                this.errorProvider.SetError(this.funcionarioButton, this.fvVendaValidateFuncionario);
                return false;
            }
            else
            {
                this.errorProvider.SetError(this.funcionarioButton, "");
            }
            return true;
        }

        private bool ValidateIdCliente()
        {
            long tmpIdCliente = 0;
            long.TryParse(this.idClienteTB.Text, out tmpIdCliente);

            if (tmpIdCliente == 0 & this.idClienteCB.SelectedIndex == -1)
            {
                this.errorProvider.SetError(this.clienteButton, this.fvVendaValidateCliente);
                return false;
            }
            else
            {
                this.errorProvider.SetError(this.clienteButton, "");
            }
            return true;
        }

        private bool ValidateForm()
        {
            bool bValidIdCliente = this.ValidateIdCliente();
            bool bValidFuncionario = this.ValidateFuncionario();
            bool bValidProdutos = this.produtos1.Validar();

            if (bValidIdCliente & bValidFuncionario & bValidProdutos)
            {
                salvarButton.BackColor = System.Drawing.SystemColors.Control;
                salvarButton.UseVisualStyleBackColor = true;
                return true;
            }
            salvarButton.BackColor = Color.FromArgb(222, 143, 141);
            return false;
        }


        private bool ValidadePrecoVenda()
        {
            foreach (Library.Classes.QItemProduto qp in this.produtos1.produtos)
            {
                if (qp.PrecoTotal == 0)
                {
                    if (MessageBox.Show("Esta venda tem um produto com valor total de R$ 0,00, deseja salva-la assim mesmo?", "Aviso", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        return true;
                    else
                        return false;
                }
            }

            if (this.valorTotalTextBox.Text.ConvertToDecimal() <= 0)
            {
                if (MessageBox.Show("Esta venda tem um valor total de R$ 0,00, deseja salva-la assim mesmo?", "Aviso", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    return true;
                else
                    return false;
            }
            return true;
        }

    
    }
}
