using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Library.Converter;


namespace Forms.Despesa
{
    public partial class Despesa : Form
    {
        /******************************************************/
        string fdDespesaValidateValor = "Informe um valor.";
        string fdDespesaValidateData = "Informe uma data.";
        /******************************************************/


        private string modo = "visualizar";
        private string Modo
        {
            get { return modo; }
            set { this.modo = value; }
        }

        private Library.Despesa despesa;

        public Despesa()
        {
            InitializeComponent();
        }


        /*
         * FUNÇÕES DE EVENTOS
         */
        private void Despesa_Load(object sender, EventArgs e)
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

            codigoTB.Text = Library.DespesaBD.GetNextId().ToString();

            /*************END*************/
            this.Modo = "Cadastrar";
            this.Cursor = Cursors.Default;
        }

        private void salvarButton_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            if (ValidateForm())
            {
                this.MenuDisabler(true, false, false, false, false);
                this.InputDisabler(false);
                /************BEGIN************/

                //criando um despesa com valores do formulário
                this.despesa = this.ReturnDespesaFromForm();
                //salvando cargo
                Library.DespesaBD.Save(this.despesa);

                //transacao
                Library.CaixaTransacao caixaTransacao = new Library.CaixaTransacao();
                caixaTransacao.Despesa = this.despesa;
                caixaTransacao.Caixa = Library.CaixaBD.GetCaixa(this.despesa.Data.GetValueOrDefault());
                caixaTransacao.Hora = TimeSpan.Parse(DateTime.Now.ToShortTimeString());
                caixaTransacao.Tipo = "Despesa";
                caixaTransacao.Valor = -this.despesa.Valor;

                Library.CaixaTransacaoBD.Save(caixaTransacao);

                //atualizando formulário
                RefreshForm();

                /*************END*************/
                this.Modo = "Salvar";
            }
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

        private void Despesa_FormClosed(object sender, FormClosedEventArgs e)
        {
            Forms.OpenForm.RemoveForm(this);
        }

        private void valorTB_Leave(object sender, EventArgs e)
        {
            this.valorTB.Text = this.valorTB.Text.ConvertToMoneyString();
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
            }
            catch (Exception ex)
            {
                Library.Diagnostics.Logger.Error(ex);
            }
        }

        //mostrar valores no formulario
        private void ShowValues(Library.Despesa despesa)
        {
            this.codigoTB.Text = string.Format("{0}", despesa.Id);
            this.dataDTP.Value = (DateTime)despesa.Data;
            this.descricaoTB.Text = despesa.Descricao;
            this.valorTB.Text = string.Format("{0:C2}", despesa.Valor);

            //despesa.DataCadastro;
        }
        private void ShowValues()
        {
            this.codigoTB.Text = "";
            this.dataDTP.Text = "";
            this.descricaoTB.Text = "";
            this.valorTB.Text = "";
        }

        //retornar objeto despesa com valores do formulario
        private Library.Despesa ReturnDespesaFromForm()
        {
            Library.Despesa despesaTemp = new Library.Despesa();

            //cargoTemp.Id = ;
            despesaTemp.Valor = -this.valorTB.Text.ConvertToDecimal();
            despesaTemp.Descricao = this.descricaoTB.Text;
            despesaTemp.Data = this.dataDTP.Value;

            return despesaTemp;
        }

        //atualizar objeto despesa com valores do formulario
        private Library.Despesa UpdateDespesaFromForm()
        {
            Library.Despesa despesaTemp = this.despesa;

            despesaTemp.Id = long.Parse(this.codigoTB.Text);
            despesaTemp.Valor = this.valorTB.Text.ConvertToDecimal();
            despesaTemp.Descricao = this.descricaoTB.Text;
            despesaTemp.Data = this.dataDTP.Value;

            return despesaTemp;
        }

        private void MenuDisabler(bool novo, bool editar, bool salvar, bool cancelar, bool excluir)
        {
            this.novoButton.Enabled = novo;
            this.salvarButton.Enabled = salvar;
            this.cancelarButton.Enabled = cancelar;
        }
        private void InputDisabler(bool habilitado = true)
        {
            this.tableLayoutPanel3.Enabled = habilitado;
        }



        /*
         * 
         * FUNÇÕES DE VALIDAÇÕS
         * 
         */

        private void valorTB_Validating(object sender, CancelEventArgs e)
        {
            ValidateValor();
        }

        private bool ValidateValor()
        {
            if (this.valorTB.Text == "")
            {
                this.errorProvider.SetError(valorTB, this.fdDespesaValidateValor);
                return false;
            }
            else
            {
                this.errorProvider.SetError(valorTB, "");
            }
            return true;
        }
        private void dataDTP_Validating(object sender, CancelEventArgs e)
        {
            ValidateData();
        }

        private bool ValidateData()
        {
            if (this.dataDTP.Text == "")
            {
                this.errorProvider.SetError(dataDTP, this.fdDespesaValidateData);
                return false;
            }
            else
            {
                this.errorProvider.SetError(dataDTP, "");
            }
            return true;
        }

        private bool ValidateForm()
        {
            bool bValidValor = ValidateValor();
            bool bValidData = ValidateData();

            if (bValidValor & bValidData)
            {
                return true;
            }
            return false;
        }

        private void Despesa_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F2:
                    novoButton.PerformClick();
                    break;
                case Keys.F4:
                    salvarButton.PerformClick();
                    break;
                case Keys.F5:
                    cancelarButton.PerformClick();
                    break;
                case Keys.Escape:
                    this.Close();
                    break;
            }
        }



    }
}
