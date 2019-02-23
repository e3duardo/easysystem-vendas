using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Library.Classes;




namespace Forms.Cargo
{
    public partial class Cargo : Form
    {
        /******************************************************/
        string fcgCargoDeletarMsg = "Deseja realmente excluir este cargo?";
        string fcgCargoDeletarMsgTitle = "Excluir";
        string fcgCargoDeletarNoSelected = "Selecione um cargo";

        string fcgCargoValidateNome = "Informe um nome.";
        /******************************************************/

        private string modo = "visualizar";
        private string Modo
        {
            get { return modo; }
            set { this.modo = value; }
        }

        public int IndexSelecionado { get; set; }

        private Library.Cargo cargo;


        public Cargo()
        {
            InitializeComponent();
        }


        /*
         * FUNÇÕES DE EVENTOS
         */

        private void Cargo_Load(object sender, EventArgs e)
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

            codigoTB.Text = Library.CargoBD.GetNextId().ToString();

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
            //achando idCargo selecionado na grid
            long idCargo = 0;
            for (int i = 0; i < dataGridView1.SelectedRows.Count; i++)
            {
                idCargo = (long)this.dataGridView1.SelectedRows[i].Cells["idDGVTBC"].Value;
            }
            //mostrando cargo selecionado no formulario
            this.cargo = Library.CargoBD.FindById(idCargo);
            this.ShowValues(this.cargo);
            /*************END*************/
            this.Modo = "Editar";
            this.Cursor = Cursors.Default;
        }

        private void salvarButton_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            /************BEGIN************/
            if (this.ValidateForm())
            {
                this.MenuDisabler(true, false, false, false, false);
                this.InputDisabler(false);


                if (this.modo == "Cadastrar")
                {
                    //criando um cargo com valores do formulário
                    this.cargo = this.ReturnCargoFromForm();
                    //salvando cargo
                    Library.CargoBD.Save(this.cargo);

                    this.dataGridView1.Rows.Add(this.cargo.Id, this.cargo.Nome, this.cargo.DataCadastro);
                }
                else
                {
                    this.cargo = this.UpdateCargoFromForm();
                    //atualizando cargo
                    Library.CargoBD.Update(this.cargo);

                    foreach (DataGridViewRow d in dataGridView1.Rows)
                    {
                        if ((long)d.Cells[0].Value == this.cargo.Id)
                        {
                            d.Cells[0].Value = this.cargo.Id;
                            d.Cells[1].Value = this.cargo.Nome;
                            d.Cells[2].Value = this.cargo.DataCadastro;
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
            //achando idCargo selecionado na grid
            long idCargo = 0;
            for (int i = 0; i < dataGridView1.SelectedRows.Count; i++)
            {
                idCargo = (long)this.dataGridView1.SelectedRows[i].Cells["idDGVTBC"].Value;
            }
            if (MessageBox.Show(this.fcgCargoDeletarMsg, this.fcgCargoDeletarMsgTitle, MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                //se não tiver selecionado mostra mensagem se estiver deleta e atualiza formulario
                if (dataGridView1.SelectedRows.Count != 1)
                {
                    MessageBox.Show(this.fcgCargoDeletarNoSelected);
                }
                else
                {
                    Library.CargoBD.DeleteById(idCargo);
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
            List<Library.Cargo> cargos;
            if (this.filtrosTextBox.Text == "")
            {
                cargos = Library.CargoBD.FindAdvanced();
            }
            else
            {
                long id;
                if (long.TryParse(this.filtrosTextBox.Text, out id))
                {
                    cargos = Library.CargoBD.FindAdvanced(new QItem("cg.id", id));
                }
                else
                {
                    cargos = Library.CargoBD.FindAdvanced(new QItem("cg.nome LIKE %%", this.filtrosTextBox.Text));
                }
            }

            this.dataGridView1.Rows.Clear();
            foreach (Library.Cargo c in cargos)
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
                long idCargo = (long)this.dataGridView1.SelectedRows[0].Cells["idDGVTBC"].Value;
                //mostrando cargo selecionado no formulario
                this.cargo = Library.CargoBD.FindById(idCargo);
                this.ShowValues(cargo);
            }
            /*************END*************/
            this.Cursor = Cursors.Default;
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            editarButton.PerformClick();
        }

        private void Cargo_FormClosed(object sender, FormClosedEventArgs e)
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

                List<Library.Cargo> cargos = Library.CargoBD.FindAdvanced();

                int i = 0;
                this.dataGridView1.Rows.Clear();
                foreach (Library.Cargo c in cargos)
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
                if (a is Forms.Funcionario.Funcionario)
                {
                    Forms.Funcionario.Funcionario form = (Forms.Funcionario.Funcionario)a;
                    form.FillCargo();
                }
            }
        }

        //mostrar valores no formulario
        private void ShowValues(Library.Cargo cargo)
        {
            this.codigoTB.Text = string.Format("{0}", cargo.Id);
            this.nomeTB.Text = cargo.Nome;
            this.descricaoTB.Text = cargo.Descricao;
            //cargo.DataCadastro;
        }
        private void ShowValues()
        {
            this.codigoTB.Text = "";
            this.nomeTB.Text = "";
            this.descricaoTB.Text = "";
        }

        //retornar objeto cargo com valores do formulario
        private Library.Cargo ReturnCargoFromForm()
        {
            Library.Cargo cargoTemp = new Library.Cargo();

            //cargoTemp.Id = ;
            cargoTemp.Nome = this.nomeTB.Text;
            cargoTemp.Descricao = this.descricaoTB.Text;
            cargoTemp.DataCadastro = DateTime.Now;

            return cargoTemp;
        }

        //atualizar objeto cargo com valores do formulario
        private Library.Cargo UpdateCargoFromForm()
        {
            Library.Cargo cargoTemp = this.cargo;

            //cargoTemp.Id = ;
            cargoTemp.Nome = this.nomeTB.Text;
            cargoTemp.Descricao = this.descricaoTB.Text;
            //cargoTemp.DataCadastro = DateTime.Now;

            return cargoTemp;
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
        private void nomeTB_Validating(object sender, CancelEventArgs e)
        {
            ValidateNome();
        }

        private bool ValidateNome()
        {
            if (this.nomeTB.Text == "")
            {
                errorProvider.SetError(nomeTB, this.fcgCargoValidateNome);
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
            {
                return true;
            }
            return false;
        }

        private void Cargo_KeyDown(object sender, KeyEventArgs e)
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
