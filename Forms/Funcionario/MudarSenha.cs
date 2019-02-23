using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace Forms.Funcionario
{
    public partial class MudarSenha : Form
    {
        string ffFuncionarioValidateSenha = "Informe uma senha.";
        string ffFuncionarioValidateSenhaLength = "As senhas devem conter no mínimo 4 e no máximo 8 caracteres.";
        string ffFuncionarioValidateSenhaIncompatible = "As senhas não conferem.";

        private Library.Funcionario funcionario;

        public MudarSenha()
        {
            InitializeComponent();
        }

        private void MudarSenha_Load(object sender, EventArgs e)
        {
            this.senhaNovaTB.Enabled = false;
            this.senhaNovaConfirmarTB.Enabled = false;
            ShowValues();
        }

        private void logarButton_Click(object sender, EventArgs e)
        {
            string message = "";

            if (Library.FuncionarioBD.Logar(this.loginTB.Text, this.senhaTB.Text, out funcionario, out message))
            {
                this.mensagemL.Text = message;
                this.senhaNovaTB.Enabled = true;
                this.senhaNovaConfirmarTB.Enabled = true;
            }
            else
            {
                this.mensagemL.Text = message;
                this.senhaNovaTB.Enabled = false;
                this.senhaNovaConfirmarTB.Enabled = false;
            }
        }

        private void aplicarButton_Click(object sender, EventArgs e)
        {
            if (ValidateForm())
            {
                this.funcionario.Senha = new Library.Classes.Password(senhaNovaTB.Text).ToString();

                Library.FuncionarioBD.Update(this.funcionario);

                this.senhaNovaTB.Enabled = false;
                this.senhaNovaConfirmarTB.Enabled = false;

                MessageBox.Show("Senha alterada com sucesso.");

                ShowValues();
            }
        }

        private void cancelarButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void MudarSenha_FormClosed(object sender, FormClosedEventArgs e)
        {
            Forms.OpenForm.RemoveForm(this);
        }

        private void senhaTextBox_Validating(object sender, CancelEventArgs e)
        {
            ValidateSenha();
        }

        private bool ValidateSenha()
        {
            if (this.senhaNovaTB.Text == "")
            {
                this.errorProvider.SetError(this.senhaNovaTB, this.ffFuncionarioValidateSenha);
                return false;
            }
            else if ((this.senhaNovaTB.TextLength < 4) || (this.senhaNovaTB.TextLength > 8))
            {
                this.errorProvider.SetError(this.senhaNovaTB, this.ffFuncionarioValidateSenhaLength);
                return false;
            }
            else if (this.senhaNovaTB.Text != this.senhaNovaConfirmarTB.Text)
            {
                this.errorProvider.SetError(this.senhaNovaTB, this.ffFuncionarioValidateSenhaIncompatible);
                return false;
            }
            else
            {
                this.errorProvider.SetError(this.senhaNovaTB, "");
            }
            return true;
        }

        private bool ValidateForm()
        {
            bool bValidSenha = ValidateSenha();


            if (bValidSenha)
                return true;

            return false;
        }

        public void ShowValues()
        {
            this.loginTB.Focus();

            this.loginTB.Text = "";
            this.senhaTB.Text = "";

            this.mensagemL.Text = "";

            this.senhaNovaTB.Text = "";
            this.senhaNovaConfirmarTB.Text = "";

        }

        private void MudarSenha_KeyDown(object sender, KeyEventArgs e)
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
