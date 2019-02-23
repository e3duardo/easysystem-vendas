using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Library.Converter;




namespace Forms.Funcionario
{
    public partial class Permissoes : Form
    {
        private string modo = "visualizar";
        private string Modo
        {
            get { return modo; }
            set { this.modo = value; }
        }

        private List<Library.Permissoes> permissoes;
        private int IndexSelected;
        private int IndexCount;

        public Permissoes()
        {
            InitializeComponent();
        }


        private void Permissoes_Load(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            this.MenuDisabler(true, true, false, false, false);
            this.RefreshForm();
            this.Cursor = Cursors.Default;
        }


        private void novoButton_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            this.MenuDisabler(false, false, true, true, false);
            this.InputDisabler(true);
            /************BEGIN************/
            this.ShowValues();

            codigoTB.Text = Library.PermissoesBD.GetNextId().ToString();
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


                if (this.modo == "Cadastrar")
                {
                    //criando um Seguranca com valores do formulário
                    Library.Permissoes permissoesTMP = this.ReturnFromForm();
                    //salvando Seguranca
                    Library.PermissoesBD.Save(permissoesTMP);
                }
                else
                {
                    Library.Permissoes permissoesTMP = this.UpdateFromForm();
                    //atualizando Seguranca
                    Library.PermissoesBD.Update(permissoesTMP);
                }
                List<Library.Logon> logons = Library.LogonBD.FindAdvanced();


                if (logons.Count == 1)
                {
                    if (this.permissoes[IndexSelected].Id == logons[0].Funcionario.Permissao.Id)
                    {
                        Application.Restart();
                    }
                }

                //atualizando formulário
                RefreshForm();
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

            if (MessageBox.Show("Deseja realmente excluir este Seguranca?", "Excluir", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Library.PermissoesBD.Delete(permissoes[IndexSelected]);
                this.RefreshForm();
            }

            /*************END*************/
            this.Modo = "Excluir";
            this.Cursor = Cursors.Default;
        }


        private void anteriorButton_Click(object sender, EventArgs e)
        {
            this.MenuDisabler(true, true, false, false, true);

            IndexSelected--;
            this.ShowValues(Library.PermissoesBD.FindById(permissoes[IndexSelected].Id));

            enableDisable();
        }

        private void proximoButton_Click(object sender, EventArgs e)
        {
            this.MenuDisabler(true, true, false, false, true);

            IndexSelected++;
            this.ShowValues(Library.PermissoesBD.FindById(permissoes[IndexSelected].Id));

            enableDisable();
        }

        public void enableDisable()
        {
            this.MenuDisabler(true, true, false, false, true);
            this.InputDisabler(false);


            proximoButton.Enabled = true;
            anteriorButton.Enabled = true;

            if (IndexCount == IndexSelected + 1)
            {
                proximoButton.Enabled = false;
            }
            if (IndexSelected == 0)
            {
                anteriorButton.Enabled = false;
            }

        }



        //atualizar formulario
        private void RefreshForm()
        {
            try
            {
                //desabilitando certos menus e campos
                this.MenuDisabler(true, true, false, false, true);
                this.InputDisabler(false);

                //preenchendo um dataset e ligando-o na grid
                permissoes = Library.PermissoesBD.FindAdvanced();

                IndexCount = permissoes.Count;
                IndexSelected = 0;
                enableDisable();


                //se tiver algum cliente, mostra o primeiro nos formularios
                if (IndexCount >= 1)
                {
                    this.ShowValues(Library.PermissoesBD.FindById(permissoes[IndexSelected].Id));
                }
            }
            catch (Exception ex)
            {
                Library.Diagnostics.Logger.Error(ex); ;
            }
        }
        private void RefreshChilds()
        {
            foreach (Form a in System.Windows.Forms.Application.OpenForms)
            {
                if (a is Forms.Produto.Produto)
                {
                    Forms.Funcionario.Funcionario form = (Forms.Funcionario.Funcionario)a;
                    form.FillSeguranca();
                }
            }
        }

        //mostrar valores no formulario
        private void ShowValues(Library.Permissoes permissao)
        {
            this.codigoTB.Text = string.Format("{0}", permissao.Id);
            this.descricaoTB.Text = permissao.Descricao;
            this.nomeTB.Text = permissao.Nome;

            #region tabInicial

            this.cadastrosCheckBoxPessoaFisica.Checked = permissao.cadastrosPessoaFisica.IntToBool();
            this.cadastrosCheckBoxPessoaJuridica.Checked = permissao.cadastrosPessoaJuridica.IntToBool();
            this.cadastrosCheckBoxFuncionario.Checked = permissao.cadastrosFuncionario.IntToBool();
            this.cadastrosCheckBoxCargo.Checked = permissao.cadastrosCargo.IntToBool();
            this.cadastrosCheckBoxPermissoes.Checked = permissao.cadastrosPermissoes.IntToBool();
            this.cadastrosCheckBoxMudarSenha.Checked = permissao.cadastrosMudarSenha.IntToBool();
            this.cadastrosCheckBoxComissoes.Checked = permissao.cadastrosComissoes.IntToBool();
            this.cadastrosCheckBoxProduto.Checked = permissao.cadastrosProduto.IntToBool();
            this.cadastrosCheckBoxFornecedor.Checked = permissao.cadastrosFornecedor.IntToBool();
            this.cadastrosCheckBoxSetor.Checked = permissao.cadastrosSetor.IntToBool();
            this.cadastrosCheckBoxEstoque.Checked = permissao.cadastrosEstoque.IntToBool();

            this.financeiroCheckBoxCaixa.Checked = permissao.financeiroCaixa.IntToBool();
            this.financeiroCheckBoxTrocaDevolucao.Checked = permissao.financeiroTrocaDevolucao.IntToBool();
            this.financeiroCheckBoxDespesa.Checked = permissao.financeiroDespesa.IntToBool();
            this.financeiroCheckBoxReceberParcelas.Checked = permissao.financeiroReceberParcelas.IntToBool();
            this.financeiroCheckBoxCheques.Checked = permissao.financeiroCheques.IntToBool();
            this.financeiroCheckBoxCartoes.Checked = permissao.financeiroCartoes.IntToBool();

            this.vendaCheckBoxVenda.Checked = permissao.vendaVenda.IntToBool();
            this.vendaCheckBoxCondicional.Checked = permissao.vendaCondicional.IntToBool();
            this.vendaCheckBoxVendasListar.Checked = permissao.vendaVendasListar.IntToBool();
            this.vendaCheckBoxCondicionaisListar.Checked = permissao.vendaCondicionaisListar.IntToBool();

            this.manutencaoCheckBoxBackup.Checked = permissao.manutencaoBackup.IntToBool();
            #endregion
        }
        private void ShowValues()
        {
            this.codigoTB.Text = "";
            this.descricaoTB.Text = "";
            this.nomeTB.Text = "";

            #region tabInicial

            this.cadastrosCheckBoxPessoaFisica.Checked = true;
            this.cadastrosCheckBoxPessoaJuridica.Checked = true;
            this.cadastrosCheckBoxFuncionario.Checked = true;
            this.cadastrosCheckBoxCargo.Checked = true;
            this.cadastrosCheckBoxPermissoes.Checked = true;
            this.cadastrosCheckBoxMudarSenha.Checked = true;
            this.cadastrosCheckBoxComissoes.Checked = true;
            this.cadastrosCheckBoxProduto.Checked = true;
            this.cadastrosCheckBoxFornecedor.Checked = true;
            this.cadastrosCheckBoxSetor.Checked = true;
            this.cadastrosCheckBoxEstoque.Checked = true;

            this.financeiroCheckBoxCaixa.Checked = true;
            this.financeiroCheckBoxTrocaDevolucao.Checked = true;
            this.financeiroCheckBoxDespesa.Checked = true;
            this.financeiroCheckBoxReceberParcelas.Checked = true;
            this.financeiroCheckBoxCheques.Checked = true;
            this.financeiroCheckBoxCartoes.Checked = true;

            this.vendaCheckBoxVenda.Checked = true;
            this.vendaCheckBoxCondicional.Checked = true;
            this.vendaCheckBoxVendasListar.Checked = true;
            this.vendaCheckBoxCondicionaisListar.Checked = true;

            this.manutencaoCheckBoxBackup.Checked = true;
            #endregion
        }

        //retornar objeto Seguranca com valores do formulario
        private Library.Permissoes ReturnFromForm()
        {
            Library.Permissoes permissoesTemp = new Library.Permissoes();

            //SegurancaTemp.Id =  long.Parse(this.codigoTB.Text);
            permissoesTemp.Descricao = this.descricaoTB.Text;
            permissoesTemp.Nome = this.nomeTB.Text;
            permissoesTemp.DataCadastro = DateTime.Now;

            
            AdicionarTabCadastros(permissoesTemp);
            AdicionarTabFinanceiro(permissoesTemp);
            AdicionarTabVenda(permissoesTemp);
            AdicionarTabRelatorios(permissoesTemp);
            AdicionarTabManutencao(permissoesTemp);

            return permissoesTemp;
        }

        //atualizar objeto Seguranca com valores do formulario
        private Library.Permissoes UpdateFromForm()
        {
            Library.Permissoes permissoesTemp = this.permissoes[IndexSelected];

            permissoesTemp.Id = long.Parse(this.codigoTB.Text);
            permissoesTemp.Descricao = this.descricaoTB.Text;
            permissoesTemp.Nome = this.nomeTB.Text;
            //SegurancaTemp.DataCadastro = DateTime.Now;

            AdicionarTabCadastros(permissoesTemp);
            AdicionarTabFinanceiro(permissoesTemp);
            AdicionarTabVenda(permissoesTemp);
            AdicionarTabRelatorios(permissoesTemp);
            AdicionarTabManutencao(permissoesTemp);

            return permissoesTemp;
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
            this.HorizontalSplit.Panel2.Enabled = habilitado;
        }




        private void nomeTextBox_Validating(object sender, CancelEventArgs e)
        {
            ValidateNome();
        }

        private bool ValidateNome()
        {
            if (this.nomeTB.Text == "")
            {
                errorProvider.SetError(nomeTB, "Por favor entre seu nome");
                return false;
            }
            else
            {
                errorProvider.SetError(nomeTB, "");
            }
            return true;
        }

        private bool ValidateForm()
        {
            bool bValidNome = ValidateNome();

            if (bValidNome)
                return true;

            return false;
        }




        #region tabCadastros
        private void AdicionarTabCadastros(Library.Permissoes permissoes)
        {
            if (cadastrosCheckBoxPessoaFisica.Checked)
                permissoes.cadastrosPessoaFisica = 1;
            else
                permissoes.cadastrosPessoaFisica = 0;
            //
            if (cadastrosCheckBoxPessoaJuridica.Checked)
                permissoes.cadastrosPessoaJuridica = 1;
            else
                permissoes.cadastrosPessoaJuridica = 0;
            //
            if (cadastrosCheckBoxFuncionario.Checked)
                permissoes.cadastrosFuncionario = 1;
            else
                permissoes.cadastrosFuncionario = 0;
            //
            if (cadastrosCheckBoxCargo.Checked)
                permissoes.cadastrosCargo = 1;
            else
                permissoes.cadastrosCargo = 0;
            //
            if (cadastrosCheckBoxPermissoes.Checked)
                permissoes.cadastrosPermissoes = 1;
            else
                permissoes.cadastrosPermissoes = 0;
            //
            if (cadastrosCheckBoxMudarSenha.Checked)
                permissoes.cadastrosMudarSenha = 1;
            else
                permissoes.cadastrosMudarSenha = 0;
            //
            if (cadastrosCheckBoxComissoes.Checked)
                permissoes.cadastrosComissoes = 1;
            else
                permissoes.cadastrosComissoes = 0;
            //
            if (cadastrosCheckBoxProduto.Checked)
                permissoes.cadastrosProduto = 1;
            else
                permissoes.cadastrosProduto = 0;
            //
            if (cadastrosCheckBoxFornecedor.Checked)
                permissoes.cadastrosFornecedor = 1;
            else
                permissoes.cadastrosFornecedor = 0;
            //
            if (cadastrosCheckBoxSetor.Checked)
                permissoes.cadastrosSetor = 1;
            else
                permissoes.cadastrosSetor = 0;
            //
            if (cadastrosCheckBoxEstoque.Checked)
                permissoes.cadastrosEstoque = 1;
            else
                permissoes.cadastrosEstoque = 0;
        }
        #endregion

        #region tabFinanceiro
        private void AdicionarTabFinanceiro(Library.Permissoes permissoes)
        {
            if (financeiroCheckBoxCaixa.Checked)
                permissoes.financeiroCaixa = 1;
            else
                permissoes.financeiroCaixa = 0;
            //
            if (financeiroCheckBoxTrocaDevolucao.Checked)
                permissoes.financeiroTrocaDevolucao = 1;
            else
                permissoes.financeiroTrocaDevolucao = 0;
            //
            if (financeiroCheckBoxDespesa.Checked)
                permissoes.financeiroDespesa = 1;
            else
                permissoes.financeiroDespesa = 0;
            //
            if (financeiroCheckBoxReceberParcelas.Checked)
                permissoes.financeiroReceberParcelas = 1;
            else
                permissoes.financeiroReceberParcelas = 0;
            //
            if (financeiroCheckBoxCheques.Checked)
                permissoes.financeiroCheques = 1;
            else
                permissoes.financeiroCheques = 0;
            //
            if (financeiroCheckBoxCartoes.Checked)
                permissoes.financeiroCartoes = 1;
            else
                permissoes.financeiroCartoes = 0;
        }
        #endregion

        #region tabVenda
        private void AdicionarTabVenda(Library.Permissoes permissoes)
        {
            if (vendaCheckBoxVenda.Checked)
                permissoes.vendaVenda = 1;
            else
                permissoes.vendaVenda = 0;
            //
            if (vendaCheckBoxCondicional.Checked)
                permissoes.vendaCondicional = 1;
            else
                permissoes.vendaCondicional = 0;
            //
            if (vendaCheckBoxVendasListar.Checked)
                permissoes.vendaVendasListar = 1;
            else
                permissoes.vendaVendasListar = 0;
            //
            if (vendaCheckBoxCondicionaisListar.Checked)
                permissoes.vendaCondicionaisListar = 1;
            else
                permissoes.vendaCondicionaisListar = 0;
        }
        #endregion

        #region tabRelatorios
        private void AdicionarTabRelatorios(Library.Permissoes permissoes)
        {

        }
        #endregion

        #region tabManutenção
        private void AdicionarTabManutencao(Library.Permissoes permissoes)
        {
            if (manutencaoCheckBoxBackup.Checked)
                permissoes.manutencaoBackup = 1;
            else
                permissoes.manutencaoBackup = 0;
        }
        #endregion

        private void Permissoes_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F2:
                    novoButton.PerformClick();
                    break;
                case Keys.F3:
                    editarButton.PerformClick();
                    break;
                case Keys.F4:
                    salvarButton.PerformClick();
                    break;
                case Keys.F5:
                    cancelarButton.PerformClick();
                    break;
                case Keys.F6:
                    excluirButton.PerformClick();
                    break;
                case Keys.F7:
                    anteriorButton.PerformClick();
                    break;
                case Keys.F8:
                    proximoButton.PerformClick();
                    break;
                case Keys.Escape:
                    this.Close();
                    break;
            }
        }
    }
}
