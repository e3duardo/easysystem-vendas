using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Library.Classes;

namespace Library.Controls
{

    public enum tipo { Cargo, ClienteFisica, ClienteJuridica, Fornecedor, Funcionario, Produto, Seguranca, Setor, Veiculo };

    public partial class SearchBox : UserControl
    {
        public SearchBox()
        {
            InitializeComponent();
        }

        private void pesquisarButton_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;


            this.resultadoDGV.Rows.Clear();
            
            List<Library.Cargo> cargos;
            List<Library.Cliente> clientes;
            List<Library.Fornecedor> fornecedores;
            List<Library.Funcionario> funcionarios;
            List<Library.Produto> produtos;
            List<Library.Permissoes> segurancas;
            List<Library.Setor> setores;


            switch (this.Tipo)
            {
                case tipo.Cargo:

                    if (this.filtrosTextBox.Text == "")
                        cargos = Library.CargoBD.FindAdvanced();
                    else
                    {
                        long id;
                        if (long.TryParse(this.filtrosTextBox.Text, out id))
                            cargos = Library.CargoBD.FindAdvanced(new QItem("c.id", id));
                        else
                            cargos = Library.CargoBD.FindAdvanced(new QItem("c.nome LIKE %%", this.filtrosTextBox.Text));
                    }

                    foreach (Library.Cargo s in cargos)
                        this.resultadoDGV.Rows.Add(s.Id, s.Nome, s.DataCadastro);

                    break;
                case tipo.ClienteFisica:
                
                    if (this.filtrosTextBox.Text == "")
                        clientes = Library.ClienteBD.FindAdvanced();
                    else
                    {
                        long id;
                        if (long.TryParse(this.filtrosTextBox.Text, out id))
                            clientes = Library.ClienteBD.FindAdvanced(new QItem("c.id", id));
                        else
                            clientes = Library.ClienteBD.FindAdvanced(new QItem("c.nome LIKE %%", this.filtrosTextBox.Text));
                    }

                    foreach (Library.Cliente s in clientes)
                        this.resultadoDGV.Rows.Add(s.Id, s.Nome, s.DataCadastro);

                    break;
                case tipo.ClienteJuridica:
                   
                    if (this.filtrosTextBox.Text == "")
                        clientes = Library.ClienteBD.FindAdvanced();
                    else
                    {
                        long id;
                        if (long.TryParse(this.filtrosTextBox.Text, out id))
                            clientes = Library.ClienteBD.FindAdvanced(new QItem("c.id", id));
                        else
                            clientes = Library.ClienteBD.FindAdvanced(new QItem("c.nome LIKE %%", this.filtrosTextBox.Text));
                    }

                    foreach (Library.Cliente s in clientes)
                        this.resultadoDGV.Rows.Add(s.Id, s.Nome, s.DataCadastro);

                    break;
                case tipo.Fornecedor:
              
                    if (this.filtrosTextBox.Text == "")
                        fornecedores = Library.FornecedorBD.FindAdvanced();
                    else
                    {
                        long id;
                        if (long.TryParse(this.filtrosTextBox.Text, out id))
                            fornecedores = Library.FornecedorBD.FindAdvanced(new QItem("f.id", id));
                        else
                            fornecedores = Library.FornecedorBD.FindAdvanced(new QItem("f.nome LIKE %%", this.filtrosTextBox.Text));
                    }

                    foreach (Library.Fornecedor s in fornecedores)
                        this.resultadoDGV.Rows.Add(s.Id, s.Nome, s.DataCadastro);

                    break;
                case tipo.Funcionario:

                    if (this.filtrosTextBox.Text == "")
                        funcionarios = Library.FuncionarioBD.FindAdvanced();
                    else
                    {
                        long id;
                        if (long.TryParse(this.filtrosTextBox.Text, out id))
                            funcionarios = Library.FuncionarioBD.FindAdvanced(new QItem("f.id", id));
                        else
                            funcionarios = Library.FuncionarioBD.FindAdvanced(new QItem("f.nome LIKE %%", this.filtrosTextBox.Text));
                    }

                    foreach (Library.Funcionario s in funcionarios)
                        this.resultadoDGV.Rows.Add(s.Id, s.Nome, s.DataCadastro);

                    break;
                case tipo.Produto:

                    if (this.filtrosTextBox.Text == "")
                        produtos = Library.ProdutoBD.FindAdvanced();
                    else
                    {
                        long id;
                        if (long.TryParse(this.filtrosTextBox.Text, out id))
                            produtos = Library.ProdutoBD.FindAdvanced(new QItem("p.id", id));
                        else
                            produtos = Library.ProdutoBD.FindAdvanced(new QItem("p.nome LIKE %%", this.filtrosTextBox.Text));
                    }

                    foreach (Library.Produto s in produtos)
                        this.resultadoDGV.Rows.Add(s.Id, s.Nome, s.DataCadastro);

                    break;
                case tipo.Seguranca:
               
                    if (this.filtrosTextBox.Text == "")
                        segurancas = Library.PermissoesBD.FindAdvanced();
                    else
                    {
                        long id;
                        if (long.TryParse(this.filtrosTextBox.Text, out id))
                            segurancas = Library.PermissoesBD.FindAdvanced(new QItem("s.id", id));
                        else
                            segurancas = Library.PermissoesBD.FindAdvanced(new QItem("s.nome LIKE %%", this.filtrosTextBox.Text));
                    }

                    foreach (Library.Permissoes s in segurancas)
                        this.resultadoDGV.Rows.Add(s.Id, s.Nome, s.DataCadastro);

                    break;
                case tipo.Setor:
           
                    if (this.filtrosTextBox.Text == "")
                        setores = Library.SetorBD.FindAdvanced();
                    else
                    {
                        long id;
                        if (long.TryParse(this.filtrosTextBox.Text, out id))
                            setores = Library.SetorBD.FindAdvanced(new QItem("s.id", id));
                        else
                            setores = Library.SetorBD.FindAdvanced(new QItem("s.nome LIKE %%", this.filtrosTextBox.Text));
                    }

                    foreach (Library.Setor s in setores)
                        this.resultadoDGV.Rows.Add(s.Id, s.Nome, s.DataCadastro);

                    break;
                default:
                    break;

            }




            this.Cursor = Cursors.Default;
        }

        public long idSelecionado()
        {
            if (this.resultadoDGV.SelectedRows.Count == 1)
            {
                long idTMP = 0;
                long.TryParse(this.resultadoDGV.SelectedRows[0].Cells[0].Value.ToString(), out idTMP);
                return idTMP;
            }
            return 0;
        }

        public void PerformLoad()
        {
            this.pesquisarButton.PerformClick();
        }
    }
}
