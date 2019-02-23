using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Library.Classes;




namespace Forms.Setor
{
    public partial class Setor : Form
    {
        /******************************************************/
        string fstSetorDeletarMsg = "Deseja realmente excluir este setor?";
        string fstSetorDeletarMsgTitle = "Excluir";
        string fstSetorDeletarNoSelected = "Selecione um setor";

        string fstSetorValidateNome = "Informe um nome.";
        /******************************************************/


        private string modo = "visualizar";
        private string Modo
        {
            get { return modo; }
            set { this.modo = value; }
        }

        public int IndexSelecionado { get; set; }

        private Library.Setor setor;

        public Setor()
        {
            InitializeComponent();
        }

        /*
         * FUNÇÕES DE EVENTOS
         */

        private void Setor_Load(object sender, EventArgs e)
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

            codigoTB.Text = Library.SetorBD.GetNextId().ToString();

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
            //achando idSetor selecionado na grid
            long idSetor = 0;
            for (int i = 0; i < dataGridView1.SelectedRows.Count; i++)
            {
                idSetor = (long)this.dataGridView1.SelectedRows[i].Cells["idDGVTBC"].Value;
            }
            //mostrando setor selecionado no formulario
            this.setor = Library.SetorBD.FindSetorById(idSetor);
            this.ShowValues(this.setor);
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
                    //criando um setor com valores do formulário
                    this.setor = this.ReturnSetorFromForm();
                    //salvando setor
                    Library.SetorBD.Save(this.setor);
                    this.dataGridView1.Rows.Add(this.setor.Id, this.setor.Nome, this.setor.DataCadastro);
                }
                else
                {
                    this.setor = this.UpdateSetorFromForm();
                    //atualizando setor
                    Library.SetorBD.Update(this.setor);

                    foreach (DataGridViewRow d in dataGridView1.Rows)
                    {
                        if ((long)d.Cells[0].Value == this.setor.Id)
                        {
                            d.Cells[0].Value = this.setor.Id;
                            d.Cells[1].Value = this.setor.Nome;
                            d.Cells[2].Value = this.setor.DataCadastro;
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
            //achando idSetor selecionado na grid
            long idSetor = 0;
            for (int i = 0; i < dataGridView1.SelectedRows.Count; i++)
            {
                idSetor = (long)this.dataGridView1.SelectedRows[i].Cells["idDGVTBC"].Value;
            }
            if (MessageBox.Show(this.fstSetorDeletarMsg, this.fstSetorDeletarMsgTitle, MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                //se não tiver selecionado mostra mensagem se estiver deleta e atualiza formulario
                if (dataGridView1.SelectedRows.Count != 1)
                {
                    MessageBox.Show(this.fstSetorDeletarNoSelected);
                }
                else
                {
                    Library.SetorBD.DeleteById(idSetor);
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
            
            List<Library.Setor> setores;
            if (this.filtrosTextBox.Text == "")
            {
                setores = Library.SetorBD.FindAdvanced();
            }
            else
            {
                long id;
                if (long.TryParse(this.filtrosTextBox.Text, out id))
                {
                    setores = Library.SetorBD.FindAdvanced(new QItem("s.id", id));
                }
                else
                {
                    setores = Library.SetorBD.FindAdvanced(new QItem("s.nome LIKE %%", this.filtrosTextBox.Text));
                }
            }

            this.dataGridView1.Rows.Clear();

            foreach (Library.Setor s in setores)
            {
                this.dataGridView1.Rows.Add(s.Id, s.Nome, s.DataCadastro);
            }

            /*************END*************/
            this.Modo = "Pesquisar";
            this.Cursor = Cursors.Default;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            this.MenuDisabler(true, true, false, false, true);
            this.InputDisabler(false);
            /************BEGIN************/
            //achando idSetor selecionado na grid
            long idSetor = 0;
            for (int i = 0; i < dataGridView1.SelectedRows.Count; i++)
            {
                idSetor = (long)this.dataGridView1.SelectedRows[i].Cells["idDGVTBC"].Value;
            }
            //mostrando setor selecionado no formulario
            this.setor = Library.SetorBD.FindSetorById(idSetor);
            this.ShowValues(setor);
            /*************END*************/
            this.Modo = "Selecionar";
            this.Cursor = Cursors.Default;
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            editarButton.PerformClick();
        }
        
        private void Setor_FormClosed(object sender, FormClosedEventArgs e)
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
                List<Library.Setor> setores = Library.SetorBD.FindAdvanced();

                int i = 0;
                this.dataGridView1.Rows.Clear();
                foreach (Library.Setor c in setores)
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
                    form.FillSetor();
                }
            }
        }

        //mostrar valores no formulario
        private void ShowValues(Library.Setor setor)
        {
            this.codigoTB.Text = string.Format("{0}", setor.Id);
            this.nomeTB.Text = setor.Nome;
            this.descricaoTB.Text = setor.Descricao;
            //setor.DataCadastro;
        }
        private void ShowValues()
        {
            this.codigoTB.Text = "";
            this.nomeTB.Text = "";
            this.descricaoTB.Text = "";
        }

        //retornar objeto setor com valores do formulario
        private Library.Setor ReturnSetorFromForm()
        {
            Library.Setor setorTemp = new Library.Setor();

            //setorTemp.Id = ;
            setorTemp.Nome = this.nomeTB.Text;
            setorTemp.Descricao = this.descricaoTB.Text;
            setorTemp.DataCadastro = DateTime.Now;

            return setorTemp;
        }

        //atualizar objeto setor com valores do formulario
        private Library.Setor UpdateSetorFromForm()
        {
            Library.Setor setorTemp = this.setor;

            //setorTemp.Id = ;
            setorTemp.Nome = this.nomeTB.Text;
            setorTemp.Descricao = this.descricaoTB.Text;
            //setorTemp.DataCadastro = DateTime.Now;

            return setorTemp;
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
                this.errorProvider.SetError(this.nomeTB, this.fstSetorValidateNome);
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

        
    }
}
