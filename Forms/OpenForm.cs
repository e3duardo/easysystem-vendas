using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Library.Converter;

namespace Forms
{
    public class OpenForm
    {
        static public Library.Logon LogonAtual()
        {
            List<Library.Logon> logons = Library.LogonBD.FindAdvanced();

            if (logons.Count == 1)
            {
                return logons[0];
            }
            return null;
        }


        static public void RemoveForm(Form form)
        {

        }

        static public void RefreshProdutos()
        {
            foreach (Form a in System.Windows.Forms.Application.OpenForms)
            {
                if (a is Forms.Start)
                {
                    Forms.Start st = (Forms.Start)a;
                    st.RefreshStatusProdutos();
                    break;
                }
            }
        }

        static public void RefreshDividas()
        {
            foreach (Form a in System.Windows.Forms.Application.OpenForms)
            {
                if (a is Forms.Start)
                {
                    Forms.Start st = (Forms.Start)a;
                    st.RefreshStatusDividasVenda();
                    break;
                }
            }
        }

        static public void RefreshCondicionais()
        {
            foreach (Form a in System.Windows.Forms.Application.OpenForms)
            {
                if (a is Forms.Start)
                {
                    Forms.Start st = (Forms.Start)a;
                    st.RefreshStatusCondicionais();
                    break;
                }
            }
        }


        //opens

        static public void OpenCaixa()
        {
            bool verifica = false;

            foreach (Form a in System.Windows.Forms.Application.OpenForms)
            {
                if (a is Forms.Caixa.Caixa)
                {
                    a.BringToFront();
                    verifica = true;
                    break;
                }
            }

            if (!verifica)
            {
                if (LogonAtual().Funcionario.Permissao.financeiroCaixa.IntToBool())
                {
                    Forms.Caixa.Caixa childFormCaixa = new Forms.Caixa.Caixa();
                    childFormCaixa.Show();
                    childFormCaixa.Disposed += delegate { childFormCaixa.Dispose(); };
                }
                else
                    MessageBox.Show("Sem permissão!");
            }
        }

        static public void OpenCargo()
        {
            bool verifica = false;

            foreach (Form a in System.Windows.Forms.Application.OpenForms)
            {
                if (a is Forms.Cargo.Cargo)
                {
                    a.BringToFront();
                    verifica = true;
                    break;
                }
            }

            if (!verifica)
            {
                if (LogonAtual().Funcionario.Permissao.cadastrosCargo.IntToBool())
                {
                    Forms.Cargo.Cargo childFormCargo = new Forms.Cargo.Cargo();
                    childFormCargo.Show();
                    childFormCargo.Disposed += delegate { childFormCargo.Dispose(); };
                }
                else
                    MessageBox.Show("Sem permissão!");
            }
        }

        static public void OpenCartao()
        {
            bool verifica = false;

            foreach (Form a in System.Windows.Forms.Application.OpenForms)
            {
                if (a is Forms.Cartao.Cartao)
                {
                    a.BringToFront();
                    verifica = true;
                    break;
                }
            }

            if (!verifica)
            {
                if (LogonAtual().Funcionario.Permissao.financeiroCartoes.IntToBool())
                {
                    Forms.Cartao.Cartao childFormCartao = new Forms.Cartao.Cartao();
                    childFormCartao.Show();
                    childFormCartao.Disposed += delegate { childFormCartao.Dispose(); };
                }
                else
                    MessageBox.Show("Sem permissão!");
            }
        }

        static public void OpenCheque()
        {
            bool verifica = false;

            foreach (Form a in System.Windows.Forms.Application.OpenForms)
            {
                if (a is Forms.Cargo.Cargo)
                {
                    a.BringToFront();
                    verifica = true;
                    break;
                }
            }

            if (!verifica)
            {
                if (LogonAtual().Funcionario.Permissao.financeiroCheques.IntToBool())
                {
                    Forms.Cheque.Cheque childFormCheque = new Forms.Cheque.Cheque();
                    childFormCheque.Show();
                    childFormCheque.Disposed += delegate { childFormCheque.Dispose(); };
                }
                else
                    MessageBox.Show("Sem permissão!");
            }
        }

        static public void OpenClienteFisica()
        {
            bool verifica = false;

            foreach (Form a in System.Windows.Forms.Application.OpenForms)
            {
                if (a is Forms.Cliente.ClienteFisica)
                {
                    a.BringToFront();
                    verifica = true;
                    break;
                }
            }

            if (!verifica)
            {
                if (LogonAtual().Funcionario.Permissao.cadastrosPessoaFisica.IntToBool())
                {
                    Forms.Cliente.ClienteFisica childFormClienteFisica = new Forms.Cliente.ClienteFisica();
                    childFormClienteFisica.Show();
                    childFormClienteFisica.Disposed += delegate { childFormClienteFisica.Dispose(); };
                }
                else
                    MessageBox.Show("Sem permissão!");
            }

        }

        static public void OpenClienteJuridica()
        {
            bool verifica = false;

            foreach (Form a in System.Windows.Forms.Application.OpenForms)
            {
                if (a is Forms.Cliente.ClienteJuridica)
                {
                    a.BringToFront();
                    verifica = true;
                    break;
                }
            }

            if (!verifica)
            {
                if (LogonAtual().Funcionario.Permissao.cadastrosPessoaJuridica.IntToBool())
                {
                    Forms.Cliente.ClienteJuridica childFormClienteJuridica = new Forms.Cliente.ClienteJuridica();
                    childFormClienteJuridica.Show();
                    childFormClienteJuridica.Disposed += delegate { childFormClienteJuridica.Dispose(); };
                }
                else
                    MessageBox.Show("Sem permissão!");
            }

        }

        static public void OpenComissao()
        {
            bool verifica = false;

            foreach (Form a in System.Windows.Forms.Application.OpenForms)
            {
                if (a is Forms.Comissao.Comissao)
                {
                    a.BringToFront();
                    verifica = true;
                    break;
                }
            }

            if (!verifica)
            {
                if (LogonAtual().Funcionario.Permissao.cadastrosComissoes.IntToBool())
                {
                    Forms.Comissao.Comissao childFormComissao = new Forms.Comissao.Comissao();
                    childFormComissao.Show();
                    childFormComissao.Disposed += delegate { childFormComissao.Dispose(); };
                }
                else
                    MessageBox.Show("Sem permissão!");
            }

        }

        static public void OpenDespesa()
        {
            bool verifica = false;

            foreach (Form a in System.Windows.Forms.Application.OpenForms)
            {
                if (a is Forms.Despesa.Despesa)
                {
                    a.BringToFront();
                    verifica = true;
                    break;
                }
            }

            if (!verifica)
            {
                if (LogonAtual().Funcionario.Permissao.financeiroDespesa.IntToBool())
                {
                    Forms.Despesa.Despesa childFormDespesa = new Forms.Despesa.Despesa();
                    childFormDespesa.Show();
                    childFormDespesa.Disposed += delegate { childFormDespesa.Dispose(); };
                }
                else
                    MessageBox.Show("Sem permissão!");
            }

        }

        static public void OpenEstoque()
        {
            bool verifica = false;

            foreach (Form a in System.Windows.Forms.Application.OpenForms)
            {
                if (a is Forms.Produto.Estoque)
                {
                    a.BringToFront();
                    verifica = true;
                    break;
                }
            }

            if (!verifica)
            {
                if (LogonAtual().Funcionario.Permissao.cadastrosEstoque.IntToBool())
                {
                    Forms.Produto.Estoque childFormEstoque = new Forms.Produto.Estoque();
                    childFormEstoque.Show();
                    childFormEstoque.Disposed += delegate { childFormEstoque.Dispose(); };

                }
                else
                    MessageBox.Show("Sem permissão!");
            }

        }

        static public void OpenFuncionario()
        {
            bool verifica = false;

            foreach (Form a in System.Windows.Forms.Application.OpenForms)
            {
                if (a is Forms.Funcionario.Funcionario)
                {
                    a.BringToFront();
                    verifica = true;
                    break;
                }
            }

            if (!verifica)
            {
                if (LogonAtual().Funcionario.Permissao.cadastrosFuncionario.IntToBool())
                {
                    Forms.Funcionario.Funcionario childFormFuncionario = new Forms.Funcionario.Funcionario();
                    childFormFuncionario.Show();
                    childFormFuncionario.Disposed += delegate { childFormFuncionario.Dispose(); };
                }
                else
                    MessageBox.Show("Sem permissão!");
            }

        }

        static public void OpenFornecedor()
        {
            bool verifica = false;

            foreach (Form a in System.Windows.Forms.Application.OpenForms)
            {
                if (a is Forms.Fornecedor.Fornecedor)
                {
                    a.BringToFront();
                    verifica = true;
                    break;
                }
            }

            if (!verifica)
            {
                if (LogonAtual().Funcionario.Permissao.cadastrosFornecedor.IntToBool())
                {
                    Forms.Fornecedor.Fornecedor childFormFornecedor = new Forms.Fornecedor.Fornecedor();
                    childFormFornecedor.Show();
                    childFormFornecedor.Disposed += delegate { childFormFornecedor.Dispose(); };
                }
                else
                    MessageBox.Show("Sem permissão!");
            }
        }

        static public void OpenMudarSenha()
        {
            bool verifica = false;

            foreach (Form a in System.Windows.Forms.Application.OpenForms)
            {
                if (a is Forms.Funcionario.MudarSenha)
                {
                    a.BringToFront();
                    verifica = true;
                    break;
                }
            }

            if (!verifica)
            {
                if (LogonAtual().Funcionario.Permissao.cadastrosMudarSenha.IntToBool())
                {
                    Forms.Funcionario.MudarSenha childFormMudarSenha = new Forms.Funcionario.MudarSenha();
                    childFormMudarSenha.Show();
                    childFormMudarSenha.Disposed += delegate { childFormMudarSenha.Dispose(); };
                }
                else
                    MessageBox.Show("Sem permissão!");
            }
        }

        static public void OpenCondicional()
        {
            bool verifica = false;

            foreach (Form a in System.Windows.Forms.Application.OpenForms)
            {
                if (a is Forms.Condicional.Condicional)
                {
                    a.BringToFront();
                    verifica = true;
                    break;
                }
            }

            if (!verifica)
            {
                if (LogonAtual().Funcionario.Permissao.vendaCondicional.IntToBool())
                {
                    Forms.Condicional.Condicional childFormOrcamento = new Forms.Condicional.Condicional();
                    childFormOrcamento.Show();
                    childFormOrcamento.Disposed += delegate { childFormOrcamento.Dispose(); };
                }
                else
                    MessageBox.Show("Sem permissão!");
            }
        }

        static public void OpenCondicionalList()
        {
            bool verifica = false;

            foreach (Form a in System.Windows.Forms.Application.OpenForms)
            {
                if (a is Forms.Condicional.CondicionalList)
                {
                    a.BringToFront();
                    verifica = true;
                    //break;
                }
            }

            if (!verifica)
            {
                if (LogonAtual().Funcionario.Permissao.vendaCondicionaisListar.IntToBool())
                {
                    Forms.Condicional.CondicionalList childFormOrcamentoList = new Forms.Condicional.CondicionalList();
                    childFormOrcamentoList.Show();
                    childFormOrcamentoList.Disposed += delegate { childFormOrcamentoList.Dispose(); };
                }
                else
                    MessageBox.Show("Sem permissão!");

            }
        }

        static public void OpenProduto()
        {
            bool verifica = false;

            foreach (Form a in System.Windows.Forms.Application.OpenForms)
            {
                if (a is Forms.Produto.Produto)
                {
                    a.BringToFront();
                    verifica = true;
                    break;
                }
            }

            if (!verifica)
            {
                if (LogonAtual().Funcionario.Permissao.cadastrosProduto.IntToBool())
                {
                    Forms.Produto.Produto childFormProduto = new Forms.Produto.Produto();
                    childFormProduto.Show();
                    childFormProduto.Disposed += delegate { childFormProduto.Dispose(); };
                }
                else
                    MessageBox.Show("Sem permissão!");
            }
        }

        static public void OpenProdutoId(long id)
        {
            bool verifica = false;

            foreach (Form a in System.Windows.Forms.Application.OpenForms)
            {
                if (a is Forms.Produto.Produto)
                {
                    Forms.Produto.Produto form = (Forms.Produto.Produto)a;
                    form.BringToFront();
                    verifica = true;

                    if (MessageBox.Show("A tela de produtos já está aberta, deseja mesmo selecionar este item? Quaisquer mudanças não salvas serão descartadas", "Produto", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        form.SelectById(id);
                    }

                    break;
                }
            }

            if (!verifica)
            {
                if (LogonAtual().Funcionario.Permissao.cadastrosProduto.IntToBool())
                {
                    Forms.Produto.Produto childFormProduto = new Forms.Produto.Produto();
                    childFormProduto.IdSelecionado = id;
                    childFormProduto.Show();
                    childFormProduto.Disposed += delegate { childFormProduto.Dispose(); };
                }
                else
                    MessageBox.Show("Sem permissão!");
            }
        }

        static public void OpenPermissoes()
        {
            bool verifica = false;

            foreach (Form a in System.Windows.Forms.Application.OpenForms)
            {
                if (a is Forms.Funcionario.Permissoes)
                {
                    a.BringToFront();
                    verifica = true;
                    break;
                }
            }

            if (!verifica)
            {
                if (LogonAtual().Funcionario.Permissao.cadastrosPermissoes.IntToBool())
                {
                    Forms.Funcionario.Permissoes childFormSeguranca = new Forms.Funcionario.Permissoes();
                    childFormSeguranca.Show();
                    childFormSeguranca.Disposed += delegate { childFormSeguranca.Dispose(); };
                }
                else
                    MessageBox.Show("Sem permissão!");
            }
        }

        static public void OpenSetor()
        {
            try
            {
                bool verifica = false;

                foreach (Form a in System.Windows.Forms.Application.OpenForms)
                {
                    if (a is Forms.Setor.Setor)
                    {
                        a.BringToFront();
                        verifica = true;
                        break;
                    }
                }

                if (!verifica)
                {
                    if (LogonAtual().Funcionario.Permissao.cadastrosSetor.IntToBool())
                    {
                        Forms.Setor.Setor childFormSetor = new Forms.Setor.Setor();
                        childFormSetor.Show();
                        childFormSetor.Disposed += delegate { childFormSetor.Dispose(); };
                    }
                    else
                        MessageBox.Show("Sem permissão!");
                }
            }
            catch (Exception ex)
            {
                Library.Diagnostics.Logger.Error(ex);
            }
        }

        static public void OpenVenda()
        {
            bool verifica = false;

            foreach (Form a in System.Windows.Forms.Application.OpenForms)
            {
                if (a is Forms.Venda.Venda)
                {
                    a.BringToFront();
                    verifica = true;
                    break;
                }
            }

            if (!verifica)
            {
                if (LogonAtual().Funcionario.Permissao.vendaVenda.IntToBool())
                {
                    Forms.Venda.Venda childFormVenda = new Forms.Venda.Venda();
                    childFormVenda.Show();
                    childFormVenda.Disposed += delegate { childFormVenda.Dispose(); };
                }
                else
                    MessageBox.Show("Sem permissão!");
            }
        }

        static public void OpenVendaDeletar()
        {
            bool verifica = false;

            foreach (Form a in System.Windows.Forms.Application.OpenForms)
            {
                if (a is Forms.Venda.Deletar)
                {
                    a.BringToFront();
                    verifica = true;
                    break;
                }
            }

            if (!verifica)
            {
                //todo: venda deletar.... revisar se possivel
                if (LogonAtual().Funcionario.Permissao.vendaVenda.IntToBool())
                {
                    Forms.Venda.Deletar childFormVendaDeletar = new Forms.Venda.Deletar();
                    childFormVendaDeletar.Show();
                    childFormVendaDeletar.Disposed += delegate { childFormVendaDeletar.Dispose(); };
                }
                else
                    MessageBox.Show("Sem permissão!");
            }
        }

        static public void OpenVendaList()
        {
            bool verifica = false;

            foreach (Form a in System.Windows.Forms.Application.OpenForms)
            {
                if (a is Forms.Venda.VendaList)
                {
                    a.BringToFront();
                    verifica = true;
                    break;
                }
            }

            if (!verifica)
            {
                if (LogonAtual().Funcionario.Permissao.vendaVendasListar.IntToBool())
                {
                    Forms.Venda.VendaList childFormVendaList = new Forms.Venda.VendaList();
                    childFormVendaList.Show();
                    childFormVendaList.Disposed += delegate { childFormVendaList.Dispose(); };
                }
                else
                    MessageBox.Show("Sem permissão!");
            }
        }

        static public void OpenVendaQuitar()
        {
            bool verifica = false;

            foreach (Form a in System.Windows.Forms.Application.OpenForms)
            {
                if (a is Forms.Venda.QuitarParcela)
                {
                    a.BringToFront();
                    verifica = true;
                    break;
                }
            }

            if (!verifica)
            {
                if (LogonAtual().Funcionario.Permissao.financeiroReceberParcelas.IntToBool())
                {
                    Forms.Venda.QuitarParcela childFormVendaQuitar = new Forms.Venda.QuitarParcela();
                    childFormVendaQuitar.Show();
                    childFormVendaQuitar.Disposed += delegate { childFormVendaQuitar.Dispose(); };
                }
                else
                    MessageBox.Show("Sem permissão!");
            }
        }

        static public void OpenVendaListByCliente()
        {
            bool verifica = false;

            foreach (Form a in System.Windows.Forms.Application.OpenForms)
            {
                if (a is Forms.Cliente.VendaListByCliente)
                {
                    a.BringToFront();
                    verifica = true;
                    break;
                }
            }

            if (!verifica)
            {
                //todo:LOL revisar isto, muito importante
                if (LogonAtual().Funcionario.Permissao.vendaVendasListar.IntToBool())
                {
                    Forms.Cliente.VendaListByCliente childFormVendaList = new Forms.Cliente.VendaListByCliente();
                    childFormVendaList.Show();
                    childFormVendaList.Disposed += delegate { childFormVendaList.Dispose(); };
                }
                else
                    MessageBox.Show("Sem permissão!");
            }
        }
    }
}
