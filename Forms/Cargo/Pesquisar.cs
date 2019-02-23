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
    public partial class Pesquisar : Form
    {
        public Pesquisar()
        {
            InitializeComponent();
        }

        private void Pesquisar_Load(object sender, EventArgs e)
        {

        }

        private void pesquisarButton_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            /************BEGIN************/
            List<Library.Cargo> cargos = null;
            long idCargo = 0;
            long.TryParse(this.codigoTB.Text, out idCargo);

            if (this.nomeTB.Text != "")
                cargos = Library.CargoBD.FindAdvanced(new QItem("cg.nome LIKE %%", this.nomeTB.Text));

            if (idCargo != 0)
                cargos = Library.CargoBD.FindAdvanced(new QItem("cg.id", this.codigoTB.Text));

            if (this.nomeTB.Text == "" & idCargo == 0)
                cargos = Library.CargoBD.FindAdvanced();

            this.resultadoDGV.Rows.Clear();
            if (cargos != null)
                foreach (Library.Cargo cg in cargos)
                {
                    this.resultadoDGV.Rows.Add(cg.Id, cg.Nome, cg.DataCadastro);
                }
            /*************END*************/
            this.Cursor = Cursors.Default;
        }

        private void selecionarButton_Click(object sender, EventArgs e)
        {

        }

        private void Pesquisar_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    this.Close();
                    break;
            }
        }



        /*
        Seguranca seguranca = new Seguranca("pesquisarCargo");

        private long _idCargo;

        public long idCargo
        {
            get { return _idCargo; }
            set { _idCargo = value; }
        }
         
        private void pesquisarButton_Click(object sender, EventArgs e)
        {
            try
            {/*
                long id;
                bool result = long.TryParse(idTextBox.Text,out id);
                if (result)
                {
                    //Main.DataBases.dataset.CargoDataTable dtable = //this.cargoTableAdapter.GetDataById(id);
                    resultadoDataGridView.DataSource = dtable;
                }
                else
                {
                    //Main.DataBases.dataset.CargoDataTable dtable = //this.cargoTableAdapter.GetDataByNome(nomeTextBox.Text);
                    resultadoDataGridView.DataSource = dtable;
                }
            }
            catch (Exception exception)
            {
                Library.Diagnostics.Logger.Error(ex);
            }
        }
        
        private void selecionarButton_Click(object sender, EventArgs e)
        {
            if (resultadoDataGridView.SelectedRows.Count == 1)
            {
                this.idCargo = (long)resultadoDataGridView.CurrentRow.Cells[0].Value;
                DialogResult = DialogResult.OK;
            }
            else
            {
                Console.Write("nãoselecionado");
            }
        }
        
        private void cargoPesquisar_Load(object sender, EventArgs e)
        {
            //.Fill(//this.dataset.Seguranca);
            //.Fill(//this.dataset.Funcionario);
            //.Fill(//this.dataset.System);

            resultadoDataGridView.DataSource = new DataTable();

            if (seguranca.VerificaSeguranca())
            {
                panel.Enabled = true;
            }
            else
            {
                panel.Enabled = false;
            }
        }
        
        protected override bool ProcessCmdKey(ref System.Windows.Forms.Message msg, System.Windows.Forms.Keys keyData)
        {
            try
            {
                if (msg.WParam.ToInt32() == (int)Keys.Escape)
                {
                    this.Close();
                }
                else
                {
                    return base.ProcessCmdKey(ref msg, keyData);
                }
            }
            catch (Exception Ex)
            {
                Library.Diagnostics.Logger.Error(ex);
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
        */
    }
}

