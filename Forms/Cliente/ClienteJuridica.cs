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


namespace Forms.Cliente
{
    public partial class ClienteJuridica : Form
    {
        /******************************************************/
        string fcClienteJuridicaDeletarMsg = "Deseja realmente excluir este cliente?";
        string fcClienteJuridicaDeletarMsgTitle = "Excluir";
        string fcClienteJuridicaDeletarNoSelected = "Selecione um cliente";

        string fcClienteJuridicaValidateNome = "Informe um nome.";
        string fcClienteJuridicaValidateEmail = "Informe um email.";
        string fcClienteJuridicaValidateEmailInvalid = "Email com formato inválido.";
        /******************************************************/

        private string modo = "visualizar";
        private string Modo
        {
            get { return modo; }
            set { this.modo = value; }
        }

        public int IndexSelecionado { get; set; }

        private Library.Cliente cliente; 

        public ClienteJuridica()
        {
            InitializeComponent();
        }


        /*
         * FUNÇÕES DE EVENTOS
         */

        private void Cliente_Load(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            this.MenuDisabler(true, false, false, false, false);
            this.RefreshForm();
            this.Cursor = Cursors.Default;
        }

        private void novoButton_Click(object sender, EventArgs e)
        {
            this.nomeTB.Focus();
            this.Cursor = Cursors.WaitCursor;
            this.MenuDisabler(false, false, true, true, false);
            this.InputDisabler(true);
            /************BEGIN************/
            this.ShowValues();

            codigoTB.Text = Library.ClienteBD.GetNextId().ToString();

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
            //achando idCliente selecionado na grid
            long idCliente = 0;
            for (int i = 0; i < dataGridView1.SelectedRows.Count; i++)
            {
                idCliente = (long)this.dataGridView1.SelectedRows[i].Cells["idDGVTBC"].Value;
            }
            //mostrando cliente selecionado no formulario
            this.cliente = Library.ClienteBD.FindById(idCliente);
            this.ShowValues(this.cliente);
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
                    //criando um cliente com valores do formulário
                    this.cliente = this.ReturnCargoFromForm();
                    //salvando cliente
                    Library.ClienteBD.Save(this.cliente);

                    this.dataGridView1.Rows.Add(this.cliente.Id, this.cliente.Nome, this.cliente.DataCadastro);
                }
                else
                {
                    this.cliente = this.UpdateCargoFromForm();
                    //atualizando cliente
                    Library.ClienteBD.Update(this.cliente);

                    foreach (DataGridViewRow d in dataGridView1.Rows)
                    {
                        if ((long)d.Cells[0].Value == this.cliente.Id)
                        {
                            d.Cells[0].Value = this.cliente.Id;
                            d.Cells[1].Value = this.cliente.Nome;
                            d.Cells[2].Value = this.cliente.DataCadastro;
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
            //achando idCliente selecionado na grid
            long idCliente = 0;
            for (int i = 0; i < dataGridView1.SelectedRows.Count; i++)
            {
                idCliente = (long)this.dataGridView1.SelectedRows[i].Cells["idDGVTBC"].Value;
            }
            if (MessageBox.Show(this.fcClienteJuridicaDeletarMsg, this.fcClienteJuridicaDeletarMsgTitle, MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                //se não tiver selecionado mostra mensagem se estiver deleta e atualiza formulario
                if (dataGridView1.SelectedRows.Count != 1)
                {
                    MessageBox.Show(this.fcClienteJuridicaDeletarNoSelected);
                }
                else
                {
                    Library.ClienteBD.DeleteById(idCliente);
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
            List<Library.Cliente> clientes;
            if (this.filtrosTextBox.Text == "")
            {
                clientes = Library.ClienteBD.FindAdvanced(new QItem("c.pessoa", "Juridica"));
            }
            else
            {
                long id;
                if (long.TryParse(this.filtrosTextBox.Text, out id))
                {
                    clientes = Library.ClienteBD.FindAdvanced(new QItem("c.pessoa", "Juridica"), new QItem("c.id", id));
                }
                else
                {
                    clientes = Library.ClienteBD.FindAdvanced(new QItem("c.pessoa", "Juridica"), new QItem("c.nome LIKE %%", this.filtrosTextBox.Text));
                }
            }

            this.dataGridView1.Rows.Clear();
            foreach (Library.Cliente c in clientes)
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
                long idCliente = (long)this.dataGridView1.SelectedRows[0].Cells["idDGVTBC"].Value;
                //mostrando cargo selecionado no formulario
                this.cliente = Library.ClienteBD.FindById(idCliente);
                this.ShowValues(cliente);
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

        private void Cliente_FormClosed(object sender, FormClosedEventArgs e)
        {
            Forms.OpenForm.RemoveForm(this);
        }

        private void fisicaButton_Click(object sender, EventArgs e)
        {
            Forms.OpenForm.OpenClienteFisica();
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
                List<Library.Cliente> clientes = Library.ClienteBD.FindAdvanced(new QItem("c.pessoa", "Juridica"));

                int i = 0;
                this.dataGridView1.Rows.Clear();
                foreach (Library.Cliente c in clientes)
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
                if (a is Forms.Condicional.Condicional)
                {
                    Forms.Condicional.Condicional form = (Forms.Condicional.Condicional)a;
                    form.FillCliente();
                }
                if (a is Forms.Venda.Venda)
                {
                    Forms.Venda.Venda form = (Forms.Venda.Venda)a;
                    form.FillCliente();
                }
            }
        }
        //mostrar valores no formulario
        private void ShowValues(Library.Cliente cliente)
        {
            this.codigoTB.Text = string.Format("{0}", cliente.Id);
            this.bairroTB.Text = cliente.Bairro;
            this.celularTB.Text = cliente.Celular;
            this.cepTB.Text = cliente.Cep;
            this.cidadeTB.Text = cliente.Cidade;
            this.cnpjTB.Text = cliente.Cnpj;
            this.emailTB.Text = cliente.Email;
            this.enderecoTB.Text = cliente.Endereco;
            this.estadoCB.Text = cliente.Estado;
            this.faxTB.Text = cliente.Fax;
            this.inscricaoEstadualTB.Text = cliente.InscricaoEstadual;
            this.nomeTB.Text = cliente.Nome;
            this.nomeContatoTB.Text = cliente.NomeContato;
            this.nomeFantasiaTB.Text = cliente.NomeFantasia;
            this.observacoesTB.Text = cliente.Observacoes;
            this.siteTB.Text = cliente.Site;
            this.telefoneTB.Text = cliente.Telefone;

            this.numericUpDownVencimentoVendaAPrazo.Value = cliente.VencimentoVendaAPrazo;
            this.textBoxLimiteVendaAPrazo.Text = cliente.LimiteVendaAPrazo.ConvertToMoneyString();
            if (cliente.AptoVendaAPrazo == 0)
                this.checkBoxAptoVendaAPrazo.Checked = false;
            else
                this.checkBoxAptoVendaAPrazo.Checked = true;

        }
        private void ShowValues()
        {
            this.codigoTB.Text = "";
            this.bairroTB.Text = "";
            this.celularTB.Text = "";
            this.cepTB.Text = "";
            this.cidadeTB.Text = "";
            this.cnpjTB.Text = "";
            this.emailTB.Text = "";
            this.enderecoTB.Text = "";
            this.estadoCB.Text = "";
            this.faxTB.Text = "";
            this.inscricaoEstadualTB.Text = "";
            this.nomeTB.Text = "";
            this.nomeContatoTB.Text = "";
            this.nomeFantasiaTB.Text = "";
            this.observacoesTB.Text = "";
            this.siteTB.Text = "";
            this.telefoneTB.Text = "";

            this.numericUpDownVencimentoVendaAPrazo.Value = 1;
            this.textBoxLimiteVendaAPrazo.Text = "";
            this.checkBoxAptoVendaAPrazo.Checked = true;
        }

        //retornar objeto cliente com valores do formulario
        private Library.Cliente ReturnCargoFromForm()
        {
            Library.Cliente clienteTemp = new Library.Cliente();

            //clienteTemp.Id =  long.Parse(this.codigoTB.Text);
            clienteTemp.Bairro =  this.bairroTB.Text;
            clienteTemp.Celular =  this.celularTB.Text;
            clienteTemp.Cep = this.cepTB.Text;
            clienteTemp.Cidade = this.cidadeTB.Text;
            clienteTemp.Cnpj = this.cnpjTB.Text;
            clienteTemp.Email =  this.emailTB.Text;
            clienteTemp.Endereco =  this.enderecoTB.Text;
            clienteTemp.Estado =  this.estadoCB.Text;
            clienteTemp.Fax = this.faxTB.Text;
            clienteTemp.InscricaoEstadual = this.inscricaoEstadualTB.Text;
            clienteTemp.Nome =  this.nomeTB.Text;
            clienteTemp.NomeContato = this.nomeContatoTB.Text;
            clienteTemp.NomeFantasia = this.nomeFantasiaTB.Text;
            clienteTemp.Observacoes = this.observacoesTB.Text;
            clienteTemp.Site =  this.siteTB.Text;
            clienteTemp.Telefone =  this.telefoneTB.Text;
            clienteTemp.DataCadastro = DateTime.Now;

            clienteTemp.Cpf = null;
            clienteTemp.Rg = null;
            clienteTemp.ReferenciaComercial = null;
            clienteTemp.Nascimento = null;

            clienteTemp.LimiteVendaAPrazo = this.textBoxLimiteVendaAPrazo.Text.ConvertToDecimal();
            if (checkBoxAptoVendaAPrazo.Checked)
                clienteTemp.AptoVendaAPrazo = 1;
            else
                clienteTemp.AptoVendaAPrazo = 0;
            clienteTemp.VencimentoVendaAPrazo = (int)this.numericUpDownVencimentoVendaAPrazo.Value;
            
            clienteTemp.Pessoa = "Juridica";

            return clienteTemp;
        }

        //atualizar objeto cliente com valores do formulario
        private Library.Cliente UpdateCargoFromForm()
        {
            Library.Cliente clienteTemp = this.cliente;

            clienteTemp.Id =  long.Parse(this.codigoTB.Text);
            clienteTemp.Bairro = this.bairroTB.Text;
            clienteTemp.Celular = this.celularTB.Text;
            clienteTemp.Cep = this.cepTB.Text;
            clienteTemp.Cidade = this.cidadeTB.Text;
            clienteTemp.Cnpj = this.cnpjTB.Text;
            clienteTemp.Email = this.emailTB.Text;
            clienteTemp.Endereco = this.enderecoTB.Text;
            clienteTemp.Estado = this.estadoCB.Text;
            clienteTemp.Fax = this.faxTB.Text;
            clienteTemp.InscricaoEstadual = this.inscricaoEstadualTB.Text;
            clienteTemp.Nome = this.nomeTB.Text;
            clienteTemp.NomeContato = this.nomeContatoTB.Text;
            clienteTemp.NomeFantasia = this.nomeFantasiaTB.Text;
            clienteTemp.Observacoes = this.observacoesTB.Text;
            clienteTemp.Site = this.siteTB.Text;
            clienteTemp.Telefone = this.telefoneTB.Text;
            //clienteTemp.DataCadastro = DateTime.Now;

            clienteTemp.LimiteVendaAPrazo = this.textBoxLimiteVendaAPrazo.Text.ConvertToDecimal();
            if (checkBoxAptoVendaAPrazo.Checked)
                clienteTemp.AptoVendaAPrazo = 1;
            else
                clienteTemp.AptoVendaAPrazo = 0;
            clienteTemp.VencimentoVendaAPrazo = this.numericUpDownVencimentoVendaAPrazo.Text.ConvertToInt();

            return clienteTemp;
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
            panel1.Enabled = habilitado;
            tableLayoutPanel1.Enabled = !habilitado;
        }


        /*
         * 
         * FUNÇÕES DE VALIDAÇÕS
         * 
         */
        private void emailTextBox_Validating(object sender, CancelEventArgs e)
        {
            ValidateEmail();
        }
        private void nomeTextBox_Validating(object sender, CancelEventArgs e)
        {
            ValidateNome();
        }
            
        private void emailTextBox_TextChanged(object sender, EventArgs e)
        {
            ValidateEmail();
        }

        private bool ValidateNome()
        {
            if (this.nomeTB.Text == "")
            {
                this.errorProvider.SetError(nomeTB, this.fcClienteJuridicaValidateNome);
                return false;
            }
            else
            {
                this.errorProvider.SetError(nomeTB, "");
            }
            return true;
        }
        private bool ValidateEmail()
        {
            if (this.emailTB.Text == "")
            {
                this.warnigProvider.SetError(emailTB, this.fcClienteJuridicaValidateEmail);
                return false;
            }
            else if (Library.Classes.Validacao.BoolEmail(this.emailTB.Text) == false)
            {
                this.warnigProvider.SetError(emailTB, this.fcClienteJuridicaValidateEmailInvalid);
            }
            else
            {
                this.warnigProvider.SetError(emailTB, "");
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

        private void checkBoxAptoVendaAPrazo_CheckedChanged(object sender, EventArgs e)
        {
            if (!checkBoxAptoVendaAPrazo.Checked)
            {
                textBoxLimiteVendaAPrazo.Text = "0";
                numericUpDownVencimentoVendaAPrazo.Value = 1;
            }

            this.textBoxLimiteVendaAPrazo.ReadOnly = !checkBoxAptoVendaAPrazo.Checked;
            this.numericUpDownVencimentoVendaAPrazo.ReadOnly = !checkBoxAptoVendaAPrazo.Checked;
        }

        private void ClienteJuridica_KeyDown(object sender, KeyEventArgs e)
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
