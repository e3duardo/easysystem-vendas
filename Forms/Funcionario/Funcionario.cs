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


namespace Forms.Funcionario
{
    public partial class Funcionario : Form
    {
        /******************************************************/
        string ffFuncionarioDeletarMsg = "Deseja realmente excluir este funcionário?";
        string ffFuncionarioDeletarMsgTitle = "Excluir";
        string ffFuncionarioDeletarNoSelected = "Selecione um funcionário";

        string ffFuncionarioValidateCargo = "Informe um cargo.";
        string ffFuncionarioValidateCpf = "Informe um CPF.";
        string ffFuncionarioValidateCpfInvalid = "CPF com formato inválido.";
        string ffFuncionarioValidateEmail = "Informe um email.";
        string ffFuncionarioValidateEmailInvalid = "Email com formato inválido.";
        string ffFuncionarioValidateNome = "Informe um nome.";
        string ffFuncionarioValidateLogin = "Informe um login.";
        string ffFuncionarioValidateSenha = "Informe uma senha.";
        string ffFuncionarioValidateSenhaLength = "As senhas devem conter no mínimo 4 e no máximo 8 caracteres.";
        string ffFuncionarioValidateSenhaIncompatible = "As senhas não conferem.";
        string ffFuncionarioValidateSeguranca = "Informe uma segurança.";
        /******************************************************/


        private string modo = "visualizar";
        private string Modo
        {
            get { return modo; }
            set { this.modo = value; }
        }

        public int IndexSelecionado { get; set; }

        private Library.Funcionario funcionario;

        public Funcionario()
        {
            InitializeComponent();
        }



        /*
         * FUNÇÕES DE EVENTOS
         */

        private void Funcionario_Load(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            this.MenuDisabler(true, false, false, false, false);
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

            codigoTB.Text = Library.FuncionarioBD.GetNextId().ToString();

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
            this.Modo = "Editar";
            /************BEGIN************/
            //achando idFuncionario selecionado na grid
            long idFuncionario = 0;
            for (int i = 0; i < dataGridView1.SelectedRows.Count; i++)
            {
                idFuncionario = (long)this.dataGridView1.SelectedRows[i].Cells["idDGVTBC"].Value;
            }
            //mostrando funcionario selecionado no formulario
            this.funcionario = Library.FuncionarioBD.FindById(idFuncionario);
            this.ShowValues(this.funcionario);
            /*************END*************/
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
                    //criando um funcionario com valores do formulário
                    this.funcionario = this.ReturnFuncionarioFromForm();
                    //salvando funcionario
                    Library.FuncionarioBD.Save(this.funcionario);

                    this.dataGridView1.Rows.Add(this.funcionario.Id, this.funcionario.Nome, this.funcionario.DataCadastro);
                }
                else
                {
                    this.funcionario = this.UpdateFuncionarioFromForm();
                    //atualizando funcionario
                    Library.FuncionarioBD.Update(this.funcionario);

                    foreach (DataGridViewRow d in dataGridView1.Rows)
                    {
                        if ((long)d.Cells[0].Value == this.funcionario.Id)
                        {
                            d.Cells[0].Value = this.funcionario.Id;
                            d.Cells[1].Value = this.funcionario.Nome;
                            d.Cells[2].Value = this.funcionario.DataCadastro;
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
            //achando idFuncionario selecionado na grid
            long idFuncionario = 0;
            for (int i = 0; i < dataGridView1.SelectedRows.Count; i++)
            {
                idFuncionario = (long)this.dataGridView1.SelectedRows[i].Cells["idDGVTBC"].Value;
            }
            if (MessageBox.Show(this.ffFuncionarioDeletarMsg, this.ffFuncionarioDeletarMsgTitle, MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                //se não tiver selecionado mostra mensagem se estiver deleta e atualiza formulario
                if (dataGridView1.SelectedRows.Count != 1)
                {
                    MessageBox.Show(this.ffFuncionarioDeletarNoSelected);
                }
                else
                {
                    Library.FuncionarioBD.DeleteById(idFuncionario);
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
            List<Library.Funcionario> funcionarios;
            if (this.filtrosTextBox.Text == "")
            {
                funcionarios = Library.FuncionarioBD.FindAdvanced();
            }
            else
            {
                long id;
                if (long.TryParse(this.filtrosTextBox.Text, out id))
                {
                    funcionarios = Library.FuncionarioBD.FindAdvanced(new QItem("f.id", id));
                }
                else
                {
                    funcionarios = Library.FuncionarioBD.FindAdvanced(new QItem("f.nome LIKE %%", this.filtrosTextBox.Text));
                }
            }

            this.dataGridView1.Rows.Clear();
            foreach (Library.Funcionario c in funcionarios)
            {
                this.dataGridView1.Rows.Add(c.Id, c.Nome, c.DataCadastro);
            }
            /*************END*************/
            this.Modo = "Pesquisar";
            this.Cursor = Cursors.Default;
        }
        
        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            this.MenuDisabler(true, true, false, false, true);
            this.InputDisabler(false);
            this.Modo = "Selecionar";
            /************BEGIN************/
            if (dataGridView1.SelectedRows.Count == 1)
            {
                //achando idCargo selecionado na grid
                long idFuncionario = (long)this.dataGridView1.SelectedRows[0].Cells["idDGVTBC"].Value;
                //mostrando cargo selecionado no formulario
                this.funcionario = Library.FuncionarioBD.FindById(idFuncionario);
                this.ShowValues(funcionario);
            }
            /*************END*************/
            this.Cursor = Cursors.Default;
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            editarButton.PerformClick();
        }

        private void cargoButton_Click(object sender, EventArgs e)
        {
            Forms.OpenForm.OpenCargo();
        }

        private void segurancaButton_Click(object sender, EventArgs e)
        {
            Forms.OpenForm.OpenPermissoes();
        }

        private void Funcionario_FormClosed(object sender, FormClosedEventArgs e)
        {
            Forms.OpenForm.RemoveForm(this);
        }

        private void salarioTB_Leave(object sender, EventArgs e)
        {
            this.salarioTB.Text = this.salarioTB.Text.ConvertToMoneyString();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (this.dataGridView1.SelectedRows.Count == 1)
                IndexSelecionado = this.dataGridView1.Rows.IndexOf(this.dataGridView1.SelectedRows[0]);
        }
        
        private void checkBoxComissao_CheckedChanged(object sender, EventArgs e)
        {
            comissaoVendaTB.Enabled = !checkBoxComissao.Checked;
        }

        /*
         * 
         * FUNÇÕES DO FORMULÁRIO
         * 
         */

        //atualizar formulario
        private void RefreshForm()
        {
            try
            {
                //desabilitando certos menus e campos
                this.MenuDisabler(true, false, false, false, false);
                this.InputDisabler(false);

                FillCargo();
                FillSeguranca();

                //preenchendo um dataset e ligando-o na grid
                List<Library.Funcionario> funcionarios = Library.FuncionarioBD.FindAdvanced();

                int i = 0;
                this.dataGridView1.Rows.Clear();
                foreach (Library.Funcionario c in funcionarios)
                {
                    if (i == 0)
                        this.ShowValues(c);

                    this.dataGridView1.Rows.Add(c.Id, c.Nome, c.DataCadastro);

                    i++;
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
                    form.FillFuncionario();
                }
                if (a is Forms.Venda.Venda)
                {
                    Forms.Venda.Venda form = (Forms.Venda.Venda)a;
                    form.FillFuncionario();
                }
            }
        }

        public void FillCargo()
        {
            //this.idCargoCB.Items.Clear();
            this.idCargoCB.DisplayMember = "nome";
            this.idCargoCB.ValueMember = "id";
            this.idCargoCB.DataSource = Library.CargoBD.FindAdvanced(new QItem("ORDER BY", "cg.nome"));
            //this.idCargoCB.Items.AddRange(Library.CargoBD.FindAdvanced());
        }
        public void FillSeguranca()
        {
            //this.idSegurancaCB.Items.Clear();
            this.idSegurancaCB.DisplayMember = "nome";
            this.idSegurancaCB.ValueMember = "id";
            this.idSegurancaCB.DataSource = Library.PermissoesBD.FindAdvanced(new QItem("ORDER BY", "s.nome"));
            //this.idSegurancaCB.Items.AddRange(Library.SegurancaBD.FindAdvanced());
        }

        //mostrar valores no formulario
        private void ShowValues(Library.Funcionario funcionario)
        {
            int ci = 0;
            foreach (Library.Cargo c in this.idCargoCB.Items)
            {
                if (c.Id == funcionario.Cargo.Id)
                {
                    this.idCargoCB.SelectedIndex = ci;
                    break;
                }
                ci++;
            }
            int si = 0;
            foreach (Library.Permissoes s in this.idSegurancaCB.Items)
            {
                if (s.Id == funcionario.Permissao.Id)
                {
                    this.idSegurancaCB.SelectedIndex = si;
                    break;
                }
                si++;
            }

            this.codigoTB.Text = string.Format("{0}", funcionario.Id);
            //this.idCargoCB.SelectedItem = string.Format("{0}", funcionario.Cargo.Id);
            //this.idSegurancaCB.SelectedItem = string.Format("{0}", funcionario.Seguranca.Id);
            this.loginTB.Text = funcionario.Login;
            this.senhaTB.Text = funcionario.Senha;
            this.bairroTB.Text = funcionario.Bairro;
            this.cepTB.Text = funcionario.Cep;
            this.celularTB.Text = funcionario.Celular;
            this.cidadeTB.Text = funcionario.Cidade;
            this.cpfTB.Text = funcionario.Cpf;
            this.emailTB.Text = funcionario.Email;
            this.enderecoTB.Text = funcionario.Endereco;
            this.estadoCB.Text = funcionario.Estado;
            this.diaPagamentoNUP.Text = string.Format("{0}", funcionario.DiaPagamento);
            this.nascimentoDTP.Value = (DateTime)funcionario.Nascimento;
            this.nomeTB.Text = funcionario.Nome;
            this.rgTB.Text = funcionario.Rg;
            this.salarioTB.Text = funcionario.Salario.ConvertToMoneyString();
            this.siteTB.Text = funcionario.Site;
            this.telefoneTB.Text = funcionario.Telefone;
            this.comissaoVendaTB.Text = funcionario.ComissaoVenda.ConvertToPercentString();

            if (funcionario.Comissao == 1)
                this.checkBoxComissao.Checked = true;
            else
                this.checkBoxComissao.Checked = false;

            this.senhaConfirmarTB.Text = "";

            if (Modo == "Editar")
            {
                this.senhaTB.ReadOnly = true;
                this.senhaConfirmarTB.ReadOnly = true;
            }
        }
        private void ShowValues()
        {
            this.codigoTB.Text = "";
            this.idCargoCB.SelectedIndex = -1;
            this.idSegurancaCB.SelectedIndex = -1;
            this.loginTB.Text = "";
            this.senhaTB.Text = "";
            this.bairroTB.Text = "";
            this.cepTB.Text = "";
            this.celularTB.Text = "";
            this.cidadeTB.Text = "";
            this.cpfTB.Text = "";
            this.emailTB.Text = "";
            this.enderecoTB.Text = "";
            this.estadoCB.Text = "";
            this.diaPagamentoNUP.Text = "";
            this.nascimentoDTP.Text = "";
            this.nomeTB.Text = "";
            this.rgTB.Text = "";
            this.salarioTB.Text = "";
            this.siteTB.Text = "";
            this.telefoneTB.Text = "";
            this.comissaoVendaTB.Text = "";
            this.checkBoxComissao.Checked = false;
            this.senhaConfirmarTB.Text = "";
        }

        //retornar objeto funcionario com valores do formulario
        private Library.Funcionario ReturnFuncionarioFromForm()
        {
            Library.Funcionario funcionarioTemp = new Library.Funcionario();

            //funcionarioTemp.Id =  long.Parse(this.codigoTB.Text);
            funcionarioTemp.Cargo = (Library.Cargo)this.idCargoCB.SelectedItem;
            funcionarioTemp.Permissao = (Library.Permissoes)this.idSegurancaCB.SelectedItem;
            funcionarioTemp.Login = this.loginTB.Text;
            funcionarioTemp.Senha = this.senhaTB.Text;
            funcionarioTemp.Bairro = this.bairroTB.Text;
            funcionarioTemp.Cep = this.cepTB.Text;
            funcionarioTemp.Celular = this.celularTB.Text;
            funcionarioTemp.Cidade = this.cidadeTB.Text;
            funcionarioTemp.Cpf = this.cpfTB.Text;
            funcionarioTemp.Email = this.emailTB.Text;
            funcionarioTemp.Endereco = this.enderecoTB.Text;
            funcionarioTemp.Estado = this.estadoCB.Text;
            int diaPagamento = 0;
            int.TryParse(this.diaPagamentoNUP.Text, out diaPagamento);
            funcionarioTemp.DiaPagamento = diaPagamento;
            funcionarioTemp.Nascimento = this.nascimentoDTP.Value;
            funcionarioTemp.Nome = this.nomeTB.Text;
            funcionarioTemp.Rg = this.rgTB.Text;
            funcionarioTemp.Salario = this.salarioTB.Text.ConvertToDecimal();
            funcionarioTemp.Site = this.siteTB.Text;
            funcionarioTemp.Telefone = this.telefoneTB.Text;
            funcionarioTemp.ComissaoVenda = this.comissaoVendaTB.Text.ConvertToInt();
            if (this.checkBoxComissao.Checked)
                funcionarioTemp.Comissao = 1;
            else
                funcionarioTemp.Comissao = 0;

            funcionarioTemp.DataCadastro = DateTime.Now;

            return funcionarioTemp;
        }

        //atualizar objeto funcionario com valores do formulario
        private Library.Funcionario UpdateFuncionarioFromForm()
        {
            Library.Funcionario funcionarioTemp = this.funcionario;

            funcionarioTemp.Id = long.Parse(this.codigoTB.Text);
            funcionarioTemp.Cargo = (Library.Cargo)this.idCargoCB.SelectedItem;
            funcionarioTemp.Permissao = (Library.Permissoes)this.idSegurancaCB.SelectedItem;
            funcionarioTemp.Login = this.loginTB.Text;
            //funcionarioTemp.Senha = this.senhaTB.Text;
            funcionarioTemp.Bairro = this.bairroTB.Text;
            funcionarioTemp.Cep = this.cepTB.Text;
            funcionarioTemp.Celular = this.celularTB.Text;
            funcionarioTemp.Cidade = this.cidadeTB.Text;
            funcionarioTemp.Cpf = this.cpfTB.Text;
            funcionarioTemp.Email = this.emailTB.Text;
            funcionarioTemp.Endereco = this.enderecoTB.Text;
            funcionarioTemp.Estado = this.estadoCB.Text;
            int diaPagamento = 0;
            int.TryParse(this.diaPagamentoNUP.Text, out diaPagamento);
            funcionarioTemp.DiaPagamento = diaPagamento;
            funcionarioTemp.Nascimento = this.nascimentoDTP.Value;
            funcionarioTemp.Nome = this.nomeTB.Text;
            funcionarioTemp.Rg = this.rgTB.Text;
            funcionarioTemp.Salario = this.salarioTB.Text.ConvertToDecimal();
            funcionarioTemp.Site = this.siteTB.Text;
            funcionarioTemp.Telefone = this.telefoneTB.Text;
            funcionarioTemp.ComissaoVenda = this.comissaoVendaTB.Text.ConvertToInt();
            if (this.checkBoxComissao.Checked)
                funcionarioTemp.Comissao = 1;
            else
                funcionarioTemp.Comissao = 0;
            //funcionarioTemp.DataCadastro = DateTime.Now;

            return funcionarioTemp;
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




        /*
         * 
         * FUNÇÕES DE VALIDAÇÕS
         * 
         */
        private void idCargoCB_Validating(object sender, CancelEventArgs e)
        {
            ValidateCargo();
        }
        private void cpfTextBox_Validating(object sender, CancelEventArgs e)
        {
            ValidateCpf();
        }
        private void emailTextBox_Validating(object sender, CancelEventArgs e)
        {
            ValidateEmail();
        }
        private void nomeTextBox_Validating(object sender, CancelEventArgs e)
        {
            ValidateNome();
        }
        private void loginTextBox_Validating(object sender, CancelEventArgs e)
        {
            ValidateLogin();
        }
        private void segurancaTextBox_Validating(object sender, CancelEventArgs e)
        {
            ValidateSeguranca();
        }
        private void senhaTextBox_Validating(object sender, CancelEventArgs e)
        {
            ValidateSenha();
        }


        private void cpfTextBox_TextChanged(object sender, EventArgs e)
        {
            ValidateCpf();
        }
        private void emailTextBox_TextChanged(object sender, EventArgs e)
        {
            ValidateEmail();
        }


        private bool ValidateCargo()
        {
            if (this.idCargoCB.SelectedIndex == -1)
            {
                this.errorProvider.SetError(this.cargoButton, this.ffFuncionarioValidateCargo);
                return false;
            }
            else
            {
                this.errorProvider.SetError(this.cargoButton, "");
            }
            return true;
        }
        private bool ValidateNome()
        {
            if (this.nomeTB.Text == "")
            {
                this.errorProvider.SetError(this.nomeTB, this.ffFuncionarioValidateNome);
                return false;
            }
            else
            {
                this.errorProvider.SetError(this.nomeTB, "");
            }
            return true;
        }
        private bool ValidateLogin()
        {
            if (this.loginTB.Text == "")
            {
                this.errorProvider.SetError(this.loginTB, this.ffFuncionarioValidateLogin);
                return false;
            }
            else
            {
                this.errorProvider.SetError(this.loginTB, "");
            }
            return true;
        }
        private bool ValidateSeguranca()
        {
            if (this.idSegurancaCB.SelectedIndex == -1)
            {
                this.errorProvider.SetError(this.segurancaButton, this.ffFuncionarioValidateSeguranca);
                return false;
            }
            else
            {
                this.errorProvider.SetError(this.segurancaButton, "");
            }
            return true;
        }
        private bool ValidateSenha()
        {
            if (this.modo == "Cadastrar")
            {
                if (this.senhaTB.Text == "")
                {
                    this.errorProvider.SetError(this.senhaTB, this.ffFuncionarioValidateSenha);
                    return false;
                }
                else if ((this.senhaTB.TextLength < 4) || (this.senhaTB.TextLength > 8))
                {
                    this.errorProvider.SetError(this.senhaTB, this.ffFuncionarioValidateSenhaLength);
                    return false;
                }
                else if (this.senhaTB.Text != this.senhaConfirmarTB.Text)
                {
                    this.errorProvider.SetError(this.senhaTB, this.ffFuncionarioValidateSenhaIncompatible);
                    return false;
                }
                else
                {
                    this.errorProvider.SetError(this.senhaTB, "");
                }
            }
            return true;
        }
        private bool ValidateCpf()
        {
            if (this.cpfTB.Text == "")
            {
                this.warnigProvider.SetError(this.cpfTB, this.ffFuncionarioValidateCpf);
                return false;
            }
            else if (Library.Classes.Validacao.BoolCPF(this.cpfTB.Text) == false)
            {
                this.warnigProvider.SetError(this.cpfTB, this.ffFuncionarioValidateCpfInvalid);
            }
            else
            {
                this.warnigProvider.SetError(this.cpfTB, "");
            }
            return true;
        }
        private bool ValidateEmail()
        {
            if (this.emailTB.Text == "")
            {
                this.warnigProvider.SetError(this.emailTB, this.ffFuncionarioValidateEmail);
                return false;
            }
            else if (Library.Classes.Validacao.BoolEmail(this.emailTB.Text) == false)
            {
                this.warnigProvider.SetError(this.emailTB, this.ffFuncionarioValidateEmailInvalid);
            }
            else
            {
                this.warnigProvider.SetError(this.emailTB, "");
            }
            return true;
        }

        private bool ValidateForm()
        {
            bool bValidCargo = ValidateCargo();
            bool bValidNome = ValidateNome();
            bool bValidLogin = ValidateLogin();
            bool bValidSeguranca = ValidateSeguranca();
            bool bValidSenha = ValidateSenha();


            if (bValidCargo & bValidNome & bValidLogin & bValidSeguranca & bValidSenha)
                return true;

            return false;
        }

        private void Funcionario_KeyDown(object sender, KeyEventArgs e)
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
                case Keys.Escape:
                    this.Close();
                    break;
            }
        }
    }
}
