using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Library.Converter;
using Library.Classes;


namespace Forms.Venda
{
    public partial class Venda : Form
    {
        private Library.Venda venda;

        private Forms.FormaPagamento formaPagamento;

        public Library.Condicional orcamento { set; get; }



        public Venda()
        {
            InitializeComponent();
        }


        // //////FUNÇÕES DE EVENTOS
        private void Venda_Load(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            this.RefreshForm();

            this.Cursor = Cursors.Default;
        }

        private void funcionarioButton_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            Forms.OpenForm.OpenFuncionario();

            this.Cursor = Cursors.Default;
        }

        private void produtoButton_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            Forms.OpenForm.OpenProduto();

            this.Cursor = Cursors.Default;
        }

        private void clienteButton_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            Forms.OpenForm.OpenClienteFisica();

            this.Cursor = Cursors.Default;
        }

        private void idClienteTB_KeyUp(object sender, KeyEventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            long tmpIdCliente = 0;
            long.TryParse(this.idClienteTB.Text, out tmpIdCliente);

            Library.Cliente cliente = Library.ClienteBD.FindClienteById(tmpIdCliente);

            if (cliente != null)
            {
                int i = 0;
                foreach (Library.Cliente c in this.idClienteCB.Items)
                {
                    if (c.Id == cliente.Id)
                    {
                        this.idClienteCB.SelectedIndex = i;
                        break;
                    }
                    i++;
                }
            }
            else
                this.idClienteCB.SelectedIndex = -1;

            this.Cursor = Cursors.Default;
        }

        private void idClienteCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            if (this.idClienteCB.SelectedIndex != -1)
            {

                Library.Cliente cliente = (Library.Cliente)this.idClienteCB.SelectedItem;

                if (cliente != null)
                {
                    this.idClienteTB.Text = string.Format("{0}", cliente.Id);
                }
                else
                {
                    this.idClienteTB.Text = "";
                }



            }


            this.Cursor = Cursors.Default;


        }

        private void idClienteTB_Leave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            long tmpIdCliente = 0;
            long.TryParse(this.idClienteTB.Text, out tmpIdCliente);

            Library.Cliente cliente = Library.ClienteBD.FindClienteById(tmpIdCliente);

            if (cliente == null)
            {
                this.idClienteTB.Text = "";
                this.idClienteCB.SelectedIndex = -1;
            }

            this.Cursor = Cursors.Default;
        }

        private void idClienteTB_TextChanged(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            try
            {
                long t = 0;
                long.TryParse(this.idClienteTB.Text, out t);
                Library.Cliente cliente = Library.ClienteBD.FindClienteById(t);

                if (cliente != null)
                {
                    PerformLimiteCliente(cliente);
                }
                else
                {

                    textBoxLimiteVendaAPrazo.Text = "";
                    textBoxStatusVendaAPrazo.Text = "";

                    textBoxStatusVendaAPrazo.BackColor = DefaultBackColor;
                    textBoxLimiteVendaAPrazo.BackColor = DefaultBackColor;
                }
            }
            catch (Exception ex)
            {
                Library.Diagnostics.Logger.Error(ex);
            }

            this.Cursor = Cursors.Default;
        }

        private void salvarButton_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            try
            {
                if (ValidateForm())
                {
                    if (ValidadePrecoVenda())
                    {
                        //instanciando nova forma de pagamento e definindo seu valor
                        formaPagamento = new Forms.FormaPagamento();

                        Library.Cliente cliente = (Library.Cliente)this.idClienteCB.SelectedItem;
                        if (cliente.AptoVendaAPrazo == 1)
                            formaPagamento.aptoAPrazo = true;
                        else
                            formaPagamento.aptoAPrazo = false;
                        formaPagamento.diaPagamento = cliente.VencimentoVendaAPrazo;

                        formaPagamento.ValorTotal = this.valorTotalTextBox.Text.ConvertToDecimal();
                        formaPagamento.ValorTotalAVista = this.produtos1.ValorProdutosAVista;
                        //mostrando texto na toolbar
                        this.toolbarStatusTSSL.Text = this.fvVendaToolbarAbrindoFormaPagamento;
                        //abrindo forma de pagamento
                        formaPagamento.ShowDialog(this);
                        //se confirnada forma de pagamento
                        if (formaPagamento.DialogResult == DialogResult.OK)
                        {
                            //mostrando texto na toolbar
                            this.toolbarStatusTSSL.Text = this.fvVendaToolbarSalvandoVenda;
                            //salvando venda
                            this.venda = this.ReturnVendaFromForm();
                            this.venda.Pago = 0;
                            this.venda.FormaPagamento = "";
                            this.venda.Entrada = formaPagamento.Entrada;
                            Library.VendaBD.Save(this.venda);

                            //mostrando texto na toolbar
                            this.toolbarStatusTSSL.Text = this.fvVendaToolbarSalvandoProdutos;
                            //salvando produtos
                            foreach (Library.VendaProduto a in ReturnVendaProdutoFromForm(long.Parse(this.codigoTB.Text)))
                            {
                                Library.VendaProdutoBD.Save(a);

                                Library.Produto produtoTMP = a.Produto;
                                produtoTMP.Estoque -= (double)a.Quantidade;
                                produtoTMP.Vendido += (double)a.Quantidade;
                                Library.ProdutoBD.Update(produtoTMP);
                            }

                            //instanciando e definindo valores de uma transação
                            Library.CaixaTransacao caixaTransacao = new Library.CaixaTransacao();
                            caixaTransacao.Venda = this.venda;
                            caixaTransacao.Caixa = Library.CaixaBD.GetCaixaToday();
                            caixaTransacao.Hora = TimeSpan.Parse(this.venda.Data.GetValueOrDefault().ToShortTimeString());
                            caixaTransacao.Tipo = "Venda";
                            caixaTransacao.Valor = (decimal)this.venda.Valor;

                            //coletando a forma de pagamento
                            switch (formaPagamento.Forma)
                            {
                                case "avista":
                                    //atualisando venda
                                    this.venda.FormaPagamento = "avista";
                                    this.venda.Pago = 1;
                                    this.venda.Valor = formaPagamento.ValorTotalTextBox;
                                    Library.VendaBD.Update(this.venda);
                                    //salvando transacao

                                    caixaTransacao.Valor = this.venda.Valor;
                                    Library.CaixaTransacaoBD.Save(caixaTransacao);

                                    break;
                                case "aprazo":
                                    //atualisando venda
                                    this.venda.FormaPagamento = "aprazo";
                                    Library.VendaBD.Update(this.venda);

                                    //mostrando texto na toolbar
                                    this.toolbarStatusTSSL.Text = this.fvVendaToolbarSalvandoParcelas;
                                    //salvando parcelas
                                    foreach (Library.VendaParcela a in this.ReturnVendaParcela(formaPagamento.ParcelasDGV, long.Parse(this.codigoTB.Text)))
                                    {
                                        Library.VendaParcelaBD.Save(a);
                                    }

                                    //salvando transacao
                                    if (formaPagamento.Entrada != 0)
                                    {
                                        caixaTransacao.Valor = formaPagamento.Entrada;
                                        Library.CaixaTransacaoBD.Save(caixaTransacao);
                                    }
                                    break;
                                case "cartao":
                                    //atualisando venda
                                    this.venda.FormaPagamento = "cartao";
                                    //this.venda.Pago = 1;
                                    Library.VendaBD.Update(this.venda);


                                    Library.Cartao cartao = new Library.Cartao();
                                    //cartao.Servico = Library.ServicoBD.FindServicoById(idServicoAtual);
                                    cartao.Venda = this.venda;
                                    cartao.Data = this.venda.Data.GetValueOrDefault(DateTime.MinValue);
                                    cartao.Tipo = formaPagamento.CartaoTipo;
                                    cartao.Valor = this.venda.Valor - formaPagamento.Entrada;
                                    cartao.Parcelas = formaPagamento.Quantidade;
                                    Library.CartaoBD.Save(cartao);


                                    //salvando transacao
                                    if (formaPagamento.Entrada != 0)
                                    {
                                        caixaTransacao.Valor = formaPagamento.Entrada;
                                        Library.CaixaTransacaoBD.Save(caixaTransacao);
                                    }

                                    break;
                                case "cheque":
                                    //atualisando venda
                                    this.venda.FormaPagamento = "cheque";
                                    Library.VendaBD.Update(this.venda);

                                    //mostrando texto na toolbar
                                    this.toolbarStatusTSSL.Text = this.fvVendaToolbarSalvandoParcelas;
                                    //salvando parcelas
                                    foreach (Library.Cheque a in this.ReturnCheque(formaPagamento.ParcelasDGV, long.Parse(this.codigoTB.Text)))
                                    {
                                        Library.ChequeBD.Save(a);
                                    }

                                    //salvando transacao
                                    if (formaPagamento.Entrada != 0)
                                    {
                                        caixaTransacao.Valor = formaPagamento.Entrada;
                                        Library.CaixaTransacaoBD.Save(caixaTransacao);
                                    }
                                    break;
                            }
                            //*************************************
                            // COMISSÂO
                            //

                            if (this.venda.Funcionario.Comissao == 1)
                            {
                                Library.Comissao comissao = new Library.Comissao();
                                comissao.Funcionario = venda.Funcionario;
                                comissao.Venda = venda;
                                comissao.Tipo = "Venda";
                                comissao.Pago = 0;

                                decimal valor = 0;
                                decimal comissaoPadrao = venda.Funcionario.ComissaoVenda;
                                if (comissaoPadrao != 0)
                                {
                                    valor = (decimal)(venda.Valor * (comissaoPadrao / 100));
                                    comissao.Porcentagem = venda.Funcionario.ComissaoVenda;


                                    comissao.Valor = (decimal)valor;

                                    Library.ComissaoBD.Save(comissao);
                                }
                            }



                            //
                            // END COMISSÂO
                            //*************************************

                            //vai imprimir?
                            if (MessageBox.Show(this.fvVendaImprimirMsg, this.fvVendaImprimirMsgTitle, MessageBoxButtons.YesNo) == DialogResult.Yes)
                            {
                                this.toolbarStatusTSSL.Text = "Imprimindo";
                                //print = new Library.Windows.Forms.Print(Library.Classes.Print.PrintVenda(this.venda), "Venda");
                                //print.ShowDialog(this);
                                //notav = new Reports.nota_venda();
                                //notav.Venda = this.venda;
                                //notav.ShowDialog(this);
                                Library.Classes.Print.PrintVenda(this.venda);
                            }


                            //limpando produtos
                            this.produtos1.Clear();
                            //limpando form
                            this.RefreshForm();
                            //atualizar forms externos
                            this.RefreshChilds();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Library.Diagnostics.Logger.Error(ex);
            }
            finally
            {

            }

            this.Cursor = Cursors.Default;
        }

        private void limparButton_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            ShowValues();

            this.Cursor = Cursors.Default;
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            this.dataTB.Text = DateTime.Now.ToString();
        }

        private void Venda_KeyDown(object sender, KeyEventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            switch (e.KeyCode)
            {
                case Keys.F8:
                    this.funcionarioCB.Focus();
                    break;
                case Keys.F12:
                    this.idClienteCB.Focus();
                    break;
            }

            this.Cursor = Cursors.Default;
        }

        private void Venda_FormClosed(object sender, FormClosedEventArgs e)
        {
            Forms.OpenForm.RemoveForm(this);
        }


        // //////FUNÇÕES DE VALIDAÇÕS
        private void funcionarioCB_Validating(object sender, CancelEventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            this.ValidateFuncionario();
            this.Cursor = Cursors.Default;
        }

        private void idClienteTB_Validating(object sender, CancelEventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            this.ValidateIdCliente();
            this.Cursor = Cursors.Default;
        }

        private void idClienteCB_Validating(object sender, CancelEventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            this.ValidateIdCliente();
            this.Cursor = Cursors.Default;
        }
    }
}
