using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Library.Classes;
using Library.Converter;




namespace Forms.Fornecedor
{
    public partial class Fornecedor : Form
    {
        /******************************************************/
        string ffrFornecedorDeletarMsg = "Deseja realmente excluir este fornecedor?";
        string ffrFornecedorDeletarMsgTitle = "Excluir";
        string ffrFornecedorDeletarNoSelected = "Selecione um fornecedor";

        string ffrFornecedorValidateNome = "Informe um nome.";
        string ffrFornecedorValidateCnpj = "Informe um CNPJ.";
        string ffrFornecedorValidateCnpjInvalid = "CNPJ com formato inválido.";
        string ffrFornecedorValidateEmailInvalid = "Email com formato inválido.";
        /******************************************************/


        private string modo = "visualizar";
        private string Modo
        {
            get { return modo; }
            set { this.modo = value; }
        }

        public int IndexSelecionado { get; set; }

        private Library.Fornecedor fornecedor;

        public Fornecedor()
        {
            InitializeComponent();
        }


        /*
         * FUNÇÕES DE EVENTOS
         */

        private void Fornecedor_Load(object sender, EventArgs e)
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

            codigoTB.Text = Library.FornecedorBD.GetNextId().ToString();

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
            //achando idFornecedor selecionado na grid
            long idFornecedor = 0;
            for (int i = 0; i < dataGridView1.SelectedRows.Count; i++)
            {
                idFornecedor = (long)this.dataGridView1.SelectedRows[i].Cells["idDGVTBC"].Value;
            }
            //mostrando fornecedor selecionado no formulario
            this.fornecedor = Library.FornecedorBD.FindById(idFornecedor);
            this.ShowValues(this.fornecedor);
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
                    //criando um fornecedor com valores do formulário
                    this.fornecedor = this.ReturnCargoFromForm();
                    //salvando fornecedor
                    Library.FornecedorBD.Save(this.fornecedor);

                    this.dataGridView1.Rows.Add(this.fornecedor.Id, this.fornecedor.Nome, this.fornecedor.DataCadastro);
                }
                else
                {
                    this.fornecedor = this.UpdateCargoFromForm();
                    //atualizando fornecedor
                    Library.FornecedorBD.Update(this.fornecedor);

                    foreach (DataGridViewRow d in dataGridView1.Rows)
                    {
                        if ((long)d.Cells[0].Value == this.fornecedor.Id)
                        {
                            d.Cells[0].Value = this.fornecedor.Id;
                            d.Cells[1].Value = this.fornecedor.Nome;
                            d.Cells[2].Value = this.fornecedor.DataCadastro;
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
            //achando idFornecedor selecionado na grid
            long idFornecedor = 0;
            for (int i = 0; i < dataGridView1.SelectedRows.Count; i++)
            {
                idFornecedor = (long)this.dataGridView1.SelectedRows[i].Cells["idDGVTBC"].Value;
            }
            //instanciando novo fornecedorBD
            if (MessageBox.Show(this.ffrFornecedorDeletarMsg, this.ffrFornecedorDeletarMsgTitle, MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                //se não tiver selecionado mostra mensagem se estiver deleta e atualiza formulario
                if (dataGridView1.SelectedRows.Count != 1)
                {
                    MessageBox.Show(this.ffrFornecedorDeletarNoSelected);
                }
                else
                {
                    Library.FornecedorBD.DeleteById(idFornecedor);
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
            List<Library.Fornecedor> fornecedores;
            if (this.filtrosTextBox.Text == "")
            {
                fornecedores = Library.FornecedorBD.FindAdvanced();
            }
            else
            {
                long id;
                if (long.TryParse(this.filtrosTextBox.Text, out id))
                {
                    fornecedores = Library.FornecedorBD.FindAdvanced(new QItem("f.id", id));
                }
                else
                {
                    fornecedores = Library.FornecedorBD.FindAdvanced(new QItem("f.nome LIKE %%", this.filtrosTextBox.Text));
                }
            }
            this.dataGridView1.Rows.Clear();
            foreach (Library.Fornecedor c in fornecedores)
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
                long idFornecedor = (long)this.dataGridView1.SelectedRows[0].Cells["idDGVTBC"].Value;
                //mostrando cargo selecionado no formulario
                this.fornecedor = Library.FornecedorBD.FindById(idFornecedor);
                this.ShowValues(fornecedor);
            }
            /*************END*************/
            this.Cursor = Cursors.Default;
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            editarButton.PerformClick();
        }

        private void Fornecedor_FormClosed(object sender, FormClosedEventArgs e)
        {
            Forms.OpenForm.RemoveForm(this);
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (this.dataGridView1.SelectedRows.Count == 1)
                IndexSelecionado = this.dataGridView1.Rows.IndexOf(this.dataGridView1.SelectedRows[0]);
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

                //preenchendo um dataset e ligando-o na grid
                List<Library.Fornecedor> fornecedores = Library.FornecedorBD.FindAdvanced();

                int i = 0;
                this.dataGridView1.Rows.Clear();
                foreach (Library.Fornecedor c in fornecedores)
                {
                    if (i == 0)
                        this.ShowValues(c);

                    this.dataGridView1.Rows.Add(c.Id, c.Nome, c.DataCadastro);

                    i++;
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
                    Forms.Produto.Produto form = (Forms.Produto.Produto)a;
                    form.FillFornecedor();
                }
            }
        }

        //mostrar valores no formulario
        private void ShowValues(Library.Fornecedor fornecedor)
        {
            this.codigoTB.Text = string.Format("{0}", fornecedor.Id);
            this.nomeTB.Text = fornecedor.Nome;
            this.bairroTB.Text = fornecedor.Bairro;
            this.cepTB.Text = fornecedor.Cep;
            this.cidadeTB.Text = fornecedor.Cidade;
            this.contatoTB.Text = fornecedor.Contato;
            this.emailTB.Text = fornecedor.Email;
            this.enderecoTB.Text = fornecedor.Endereco;
            this.estadoCB.Text = fornecedor.Estado;
            this.faxTB.Text = fornecedor.Fax;
            this.inscricaoEstadualTB.Text = fornecedor.InscricaoEstadual;
            this.nomeTB.Text = fornecedor.Nome;
            this.siteTB.Text = fornecedor.Site;
            this.telefoneTB.Text = fornecedor.Telefone;
        }
        private void ShowValues()
        {
            this.codigoTB.Text = "";
            this.nomeTB.Text = "";
            this.bairroTB.Text = "";
            this.cepTB.Text = "";
            this.cidadeTB.Text = "";
            this.contatoTB.Text = "";
            this.emailTB.Text = "";
            this.enderecoTB.Text = "";
            this.estadoCB.Text = "";
            this.faxTB.Text = "";
            this.inscricaoEstadualTB.Text = "";
            this.nomeTB.Text = "";
            this.siteTB.Text = "";
            this.telefoneTB.Text = "";
        }

        //retornar objeto fornecedor com valores do formulario
        private Library.Fornecedor ReturnCargoFromForm()
        {
            Library.Fornecedor fornecedorTemp = new Library.Fornecedor();

            //fornecedorTemp.Id =  long.Parse(this.codigoTB.Text);
            fornecedorTemp.Bairro = this.bairroTB.Text;
            fornecedorTemp.Cep = this.cepTB.Text;
            fornecedorTemp.Cidade = this.cidadeTB.Text;
            fornecedorTemp.Cnpj = this.cnpjTB.Text;
            fornecedorTemp.Contato = this.contatoTB.Text;
            fornecedorTemp.Email = this.emailTB.Text;
            fornecedorTemp.Endereco = this.enderecoTB.Text;
            fornecedorTemp.Estado = this.estadoCB.Text;
            fornecedorTemp.Fax = this.faxTB.Text;
            fornecedorTemp.InscricaoEstadual =  this.inscricaoEstadualTB.Text;
            fornecedorTemp.Nome =  this.nomeTB.Text;
            fornecedorTemp.Site =  this.siteTB.Text;
            fornecedorTemp.Telefone =  this.telefoneTB.Text;
            fornecedorTemp.DataCadastro = DateTime.Now;

            return fornecedorTemp;
        }

        //atualizar objeto fornecedor com valores do formulario
        private Library.Fornecedor UpdateCargoFromForm()
        {
            Library.Fornecedor fornecedorTemp = this.fornecedor;

            fornecedorTemp.Id =  long.Parse(this.codigoTB.Text);
            fornecedorTemp.Bairro = this.bairroTB.Text;
            fornecedorTemp.Cep = this.cepTB.Text;
            fornecedorTemp.Cidade = this.cidadeTB.Text;
            fornecedorTemp.Cnpj = this.cnpjTB.Text;
            fornecedorTemp.Contato = this.contatoTB.Text;
            fornecedorTemp.Email = this.emailTB.Text;
            fornecedorTemp.Endereco = this.enderecoTB.Text;
            fornecedorTemp.Estado = this.estadoCB.Text;
            fornecedorTemp.Fax = this.faxTB.Text;
            fornecedorTemp.InscricaoEstadual = this.inscricaoEstadualTB.Text;
            fornecedorTemp.Nome = this.nomeTB.Text;
            fornecedorTemp.Site = this.siteTB.Text;
            fornecedorTemp.Telefone = this.telefoneTB.Text;
            //fornecedorTemp.DataCadastro = DateTime.Now;

            return fornecedorTemp;
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
        private void cnpjTB_Validating(object sender, CancelEventArgs e)
        {
            ValidateCnpj();
        }
        private void emailTB_Validating(object sender, CancelEventArgs e)
        {
            ValidateEmail();
        }
        private void nomeTB_Validating(object sender, CancelEventArgs e)
        {
            ValidateNome();
        }

        private void cnpjTB_TextChanged(object sender, EventArgs e)
        {
            ValidateCnpj();
        }
        private void emailTB_TextChanged(object sender, EventArgs e)
        {
            ValidateEmail();
        }


        private bool ValidateCnpj()
        {
            if (this.cnpjTB.Text == "")
            {
                this.warnigProvider.SetError(this.cnpjTB, this.ffrFornecedorValidateCnpj);
                return false;
            }
            else if (Library.Classes.Validacao.BoolCPF(this.cnpjTB.Text) == false)
            {
                this.warnigProvider.SetError(this.cnpjTB, this.ffrFornecedorValidateCnpjInvalid);
            }
            else
            {
                this.warnigProvider.SetError(this.cnpjTB, "");
            }
            return true;
        }
        private bool ValidateEmail()
        {
            if (Library.Classes.Validacao.BoolEmail(this.emailTB.Text) == false)
            {
                this.warnigProvider.SetError(this.emailTB, this.ffrFornecedorValidateEmailInvalid);
            }
            else
            {
                this.warnigProvider.SetError(this.emailTB, "");
            }
            return true;
        }
        private bool ValidateNome()
        {
            if (this.nomeTB.Text == "")
            {
                this.errorProvider.SetError(this.nomeTB, this.ffrFornecedorValidateNome);
                return false;
            }
            else
            {
                this.errorProvider.SetError(this.nomeTB, "");
            }
            return true;
        }


        private bool ValidateForm()
        {
            bool bValidNome = ValidateNome();

            if (bValidNome)
            {
                return true;
            }
            return false;
        }

        private void Fornecedor_KeyDown(object sender, KeyEventArgs e)
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
