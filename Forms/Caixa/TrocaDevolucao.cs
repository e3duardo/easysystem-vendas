using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Library.Classes;

namespace Forms.Caixa
{
    public partial class TrocaDevolucao : Form
    {
        public Library.CaixaTransacao CaixaTransacao { get; set; }

        public TrocaDevolucao()
        {
            InitializeComponent();
        }

        private void TrocaDevolucao_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Library.Funcionario funcionario;

            string message = "";

            if (Library.FuncionarioBD.Logar(this.textBoxLogin.Text, this.textBoxSenha.Text, out funcionario, out message))
            {
                if (funcionario.Permissao.financeiroTrocaDevolucao == 1)
                {
                    Deletes();
                }
                else
                {
                    MessageBox.Show("Sem permissão!");
                }
            }
        }

        private void Deletes()
        {
            try
            {
                if (CaixaTransacao.Despesa != null)
                {
                    //despesa
                    CaixaTransacao.Caixa.Saldo -= CaixaTransacao.Valor;
                    Library.CaixaBD.Update(CaixaTransacao.Caixa);

                    //delete
                    Library.CaixaTransacaoBD.Delete(CaixaTransacao);
                    Library.DespesaBD.Delete(CaixaTransacao.Despesa);
                }
                else if (CaixaTransacao.Venda != null)
                {
                    if (CaixaTransacao.VendaParcela == null)
                    {
                        //vendaparcelada
                        Library.Venda venda = CaixaTransacao.Venda;

                        List<Library.CaixaTransacao> transacoes = Library.CaixaTransacaoBD.FindAdvanced(new QItem("v.id", venda.Id));
                        if (transacoes.Count == 1)
                        {
                            bool algumaPaga = false;
                            foreach (Library.VendaParcela vp in Library.VendaParcelaBD.FindAdvanced(new QItem("v.id", venda.Id)))
                            {
                                if (vp.Pago == 1)
                                {
                                    algumaPaga = true;
                                    break;
                                }
                            }
                            if (!algumaPaga)
                            {
                                CaixaTransacao.Caixa.Saldo -= CaixaTransacao.Valor;
                                Library.CaixaBD.Update(CaixaTransacao.Caixa);

                                Library.VendaParcelaBD.DeleteByVenda(venda);

                                foreach (Library.VendaProduto vp in Library.VendaProdutoBD.FindAdvanced(new QItem("v.id", venda.Id)))
                                {
                                    vp.Produto.Estoque += vp.Quantidade.GetValueOrDefault(0);
                                    Library.ProdutoBD.Update(vp.Produto);
                                }
                                Library.VendaProdutoBD.DeleteByVenda(venda);

                                Library.VendaBD.Delete(venda);
                                Library.CaixaTransacaoBD.Delete(CaixaTransacao);

                            }
                            else
                                MessageBox.Show("Já existe parcelas pagas, você não pode devolver uma venda assim!");
                        }
                        else
                            MessageBox.Show("Esta venda tem uma entrada, você não pode devolver uma venda assim!");
                    }
                    else
                    {
                        //venda a vista
                        CaixaTransacao.Caixa.Saldo -= CaixaTransacao.Valor;
                        Library.CaixaBD.Update(CaixaTransacao.Caixa);

                        Library.Venda venda = CaixaTransacao.Venda;

                        foreach (Library.VendaProduto vp in Library.VendaProdutoBD.FindAdvanced(new QItem("v.id", venda.Id)))
                        {
                            vp.Produto.Estoque += vp.Quantidade.GetValueOrDefault(0);
                            Library.ProdutoBD.Update(vp.Produto);
                        }

                        //delete
                        Library.CaixaTransacaoBD.Delete(CaixaTransacao);

                        Library.VendaProdutoBD.DeleteByVenda(venda);

                        Library.VendaBD.Delete(venda);
                    }
                }
                else if (CaixaTransacao.Cheque != null)
                {
                    CaixaTransacao.Caixa.Saldo -= CaixaTransacao.Valor;
                    Library.CaixaBD.Update(CaixaTransacao.Caixa);

                    Library.ChequeBD.Delete(CaixaTransacao.Cheque);
                    Library.CaixaTransacaoBD.Delete(CaixaTransacao);
                    //MessageBox.Show("");
                }
                else
                {
                    if (CaixaTransacao.Cheque == null & CaixaTransacao.Comissao == null)
                    {
                        CaixaTransacao.Caixa.Saldo -= CaixaTransacao.Valor;
                        Library.CaixaBD.Update(CaixaTransacao.Caixa);

                        Library.CaixaTransacaoBD.Delete(CaixaTransacao);
                        //MessageBox.Show("");
                    }
                }
            }
            catch (Exception ex)
            {
                Library.Diagnostics.Logger.Error(ex);
                MessageBox.Show("Houve um erro, ação não efetuada.");
                this.DialogResult = DialogResult.Cancel;
            }
            finally
            {
                MessageBox.Show("Operação bem sucedida.");
                this.DialogResult = DialogResult.OK;
            }
        }

        private void TrocaDevolucao_KeyDown(object sender, KeyEventArgs e)
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
