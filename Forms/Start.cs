using System;
using System.Reflection;
using System.Windows.Forms;
using System.Collections;
using System.Collections.Generic;
using Library.Classes;
using Library.Converter;
using System.IO;
using System.Security.AccessControl;

namespace Forms
{
    public partial class Start : Form
    {
        public Start()
        {
            List<Library.Logon> logons = Library.LogonBD.FindAdvanced();
            if (logons == null || logons.Count > 1)
            {
                MessageBox.Show("ADEUS");
                this.Close();
            }
            else if (logons.Count == 0)
            {
                MessageBox.Show("Erro ao tentar logar no sistema, tente novamente!.");
                Application.Restart();
            }
            else
            {
                InitializeComponent();
            }
        }

        private void Start_Load(object sender, EventArgs e)
        {
            Perm_ToolBar();
            Perm_Visible();
            this.labelVersion.Text = String.Format("v{0}", AssemblyVersion);
            this.RefreshStatusProdutos();
            this.RefreshStatusDividasVenda();
            this.RefreshStatusCondicionais();
        }


        public void Perm_ToolBar()
        {
            List<Library.Logon> logons = Library.LogonBD.FindAdvanced();

            if (logons.Count == 1)
            {
                toolStripMenuItemSair.Text = string.Format("<{0}> Sair", logons[0].Funcionario.Nome);

                this.button1.Enabled = logons[0].Funcionario.Permissao.cadastrosPessoaFisica.IntToBool();
                this.button2.Enabled = logons[0].Funcionario.Permissao.cadastrosPessoaJuridica.IntToBool();
                this.button3.Enabled = logons[0].Funcionario.Permissao.cadastrosFornecedor.IntToBool();
                this.button4.Enabled = logons[0].Funcionario.Permissao.cadastrosProduto.IntToBool();
                this.button5.Enabled = logons[0].Funcionario.Permissao.vendaCondicional.IntToBool();
                this.button6.Enabled = logons[0].Funcionario.Permissao.vendaVenda.IntToBool();
            }
        }

        public void Perm_Visible()
        {
            List<Library.Logon> logons = Library.LogonBD.FindAdvanced();

            if (logons.Count == 1)
            {
                toolStripMenuItemSair.Text = string.Format("<{0}> Sair", logons[0].Funcionario.Nome);

                #region cadastros
                bool caPessoaFisica = logons[0].Funcionario.Permissao.cadastrosPessoaFisica.IntToBool();
                bool caPessoaJuridica = logons[0].Funcionario.Permissao.cadastrosPessoaJuridica.IntToBool();

                bool caFuncionario = logons[0].Funcionario.Permissao.cadastrosFuncionario.IntToBool();
                bool caCargo = logons[0].Funcionario.Permissao.cadastrosCargo.IntToBool();
                bool caPermissoes = logons[0].Funcionario.Permissao.cadastrosPermissoes.IntToBool();
                bool caMudarSenha = logons[0].Funcionario.Permissao.cadastrosMudarSenha.IntToBool();
                bool caComissoes = logons[0].Funcionario.Permissao.cadastrosComissoes.IntToBool();

                bool caProduto = logons[0].Funcionario.Permissao.cadastrosProduto.IntToBool();
                bool caFornecedor = logons[0].Funcionario.Permissao.cadastrosFornecedor.IntToBool();
                bool caSetor = logons[0].Funcionario.Permissao.cadastrosSetor.IntToBool();
                bool caEstoque = logons[0].Funcionario.Permissao.cadastrosEstoque.IntToBool();

                bool caCliente = caPessoaFisica | caPessoaJuridica;
                bool caFuncionario2 = caFuncionario | caCargo | caPermissoes | caMudarSenha | caComissoes;
                bool caProduto2 = caProduto | caFornecedor | caSetor | caEstoque;

                bool ca = caCliente | caFuncionario2 | caCargo | caProduto2;

                pessoaFisicaTSMI.Visible = caPessoaFisica;
                pessoaJuridicaTSMI.Visible = caPessoaJuridica;
                clienteTSMI.Visible = caCliente;

                funcionarioTSMI.Visible = caFuncionario;
                cargoTSMI.Visible = caCargo;
                mudarSenhaTSMI.Visible = caMudarSenha;
                permissoesTSMI.Visible = caPermissoes;
                comissaoTSMI.Visible = caComissoes;
                funcionario1TSMI.Visible = caFuncionario2;

                produtoTSMI.Visible = caProduto;
                fornecedorTSMI.Visible = caFornecedor;
                setorTSMI.Visible = caSetor;
                estoqueTSMI.Visible = caEstoque;
                produto1TSMI.Visible = caProduto2;

                cadastrosTSMI.Visible = ca;
                #endregion

                #region financeiro
                bool fiCaixa = logons[0].Funcionario.Permissao.financeiroCaixa.IntToBool();
                bool fiDespesa = logons[0].Funcionario.Permissao.financeiroDespesa.IntToBool();
                bool fiReceberParcela = logons[0].Funcionario.Permissao.financeiroReceberParcelas.IntToBool();
                bool fiCheques = logons[0].Funcionario.Permissao.financeiroCheques.IntToBool();
                bool fiCartoes = logons[0].Funcionario.Permissao.financeiroCartoes.IntToBool();

                bool fi = fiCaixa | fiDespesa | fiReceberParcela | fiCheques | fiCartoes;

                caixaTSMI.Visible = fiCaixa;
                despesaTSMI.Visible = fiDespesa;
                receberParcelasTSMI.Visible = fiReceberParcela;
                chequesTSMI.Visible = fiCheques;
                cartoesTSMI.Visible = fiCartoes;
                financeiroTSMI.Visible = fi;
                #endregion

                #region venda
                bool veVenda = logons[0].Funcionario.Permissao.vendaVenda.IntToBool();
                bool veCondicional = logons[0].Funcionario.Permissao.vendaCondicional.IntToBool();
                bool veVendasListar = logons[0].Funcionario.Permissao.vendaVendasListar.IntToBool();
                bool veCondicionaisListar = logons[0].Funcionario.Permissao.vendaCondicionaisListar.IntToBool();

                bool ve = veVenda | veCondicional | veVendasListar | veCondicionaisListar;


                vendaTSMI.Visible = veVenda;
                condicionalTSMI.Visible = veCondicional;
                vendasListarTSMI.Visible = veVendasListar;
                condicionaisListarTSMI.Visible = veCondicionaisListar;
                venda1TSMI.Visible = ve;
                #endregion

                bool maBackup = logons[0].Funcionario.Permissao.manutencaoBackup.IntToBool();
                this.backupToolStripMenuItem.Visible = maBackup;
                this.manutencaoToolStripMenuItem.Visible = maBackup;



            }
        }


        public void RefreshStatusProdutos()
        {
            try
            {
                string str = "";

                int total = Library.ProdutoBD.GetCountByTipoEstoque();
                if (total == 0)
                    str += "Nenhum produto cadastrado. ";
                else if (total == 1)
                    str += "Um produto cadastrado. ";
                else
                    str += string.Format("{0} produtos cadastrados. ", total);



                int acabando = Library.ProdutoBD.GetCountByTipoEstoque("acabando");
                if (acabando == 0)
                    str += "";
                else
                    str += string.Format("{0} acabando. ", acabando);


                int acabado = Library.ProdutoBD.GetCountByTipoEstoque("acabado");
                if (acabado == 0)
                    str += "";
                else
                    str += string.Format("{0} em falta. ", acabado);

                this.produtoTSSL.Text = str;
            }
            catch (Exception ex)
            {
                Library.Diagnostics.Logger.Error(ex);
            }
        }

        public void RefreshStatusDividasVenda()
        {
            try
            {
                List<Library.Cliente> clientes = Library.ClienteBD.FindAdvanced();

                //int total = 0;
                decimal totalDividas = 0;
                foreach (Library.Cliente c in clientes)
                {
                    List<Library.VendaParcela> vendasparcelas = Library.ClienteBD.GetParcelasAtrasadasById(c.Id);
                    totalDividas += vendasparcelas.Count;
                }

                string str = "";

                //int total = Library.ProdutoBD.GetCountByTipoEstoque();
                if (totalDividas == 0)
                    str += "Nenhum cliente com parcelas em atraso. ";
                else if (totalDividas == 1)
                    str += "Um cliente com parcelas em atraso. ";
                else
                    str += string.Format("{0} clientes com parcelas em atraso. ", totalDividas);

                this.toolStripStatusDividasVenda.Text = str;
            }
            catch (Exception ex)
            {
                Library.Diagnostics.Logger.Error(ex);
            }
        }

        public void RefreshStatusCondicionais()
        {
            try
            {
                List<Library.Condicional> orcamento = Library.CondicionalBD.FindAdvanced();

                string str = "";

                //int total = Library.ProdutoBD.GetCountByTipoEstoque();
                if (orcamento.Count == 0)
                    str += "Nenhum cliente com condicionais. ";
                else if (orcamento.Count == 1)
                    str += "Um cliente com condicional. ";
                else
                    str += string.Format("{0} clientes com condicionais. ", orcamento.Count);

                this.toolStripStatusLabelCondicional.Text = str;
            }
            catch (Exception ex)
            {
                Library.Diagnostics.Logger.Error(ex);
            }
        }

        public string AssemblyVersion
        {
            get { return Assembly.GetExecutingAssembly().GetName().Version.ToString(); }
        }



        #region Cadastros
        private void pessoaFisicaTSMI_Click(object sender, EventArgs e)
        {
            Forms.OpenForm.OpenClienteFisica();
        }

        private void pessoaJuridicaTSMI_Click(object sender, EventArgs e)
        {
            Forms.OpenForm.OpenClienteJuridica();
        }

        private void fornecedorTSMI_Click(object sender, EventArgs e)
        {
            Forms.OpenForm.OpenFornecedor();
        }

        private void funcionario_TSMI_Click(object sender, EventArgs e)
        {
            Forms.OpenForm.OpenFuncionario();
        }

        private void cargoTSMI_Click(object sender, EventArgs e)
        {
            Forms.OpenForm.OpenCargo();
        }

        private void segurancaTSMI_Click(object sender, EventArgs e)
        {
            Forms.OpenForm.OpenPermissoes();
        }

        private void mudarSenhaTSMI_Click(object sender, EventArgs e)
        {
            Forms.OpenForm.OpenMudarSenha();
        }

        private void produto_TSMI_Click(object sender, EventArgs e)
        {
            Forms.OpenForm.OpenProduto();
        }

        private void setorTSMI_Click(object sender, EventArgs e)
        {
            Forms.OpenForm.OpenSetor();
        }

        private void estoqueTSMI_Click(object sender, EventArgs e)
        {
            Forms.OpenForm.OpenEstoque();
        }

        private void comissaoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.OpenForm.OpenComissao();
        }
        #endregion

        #region Financeiro
        private void caixa_TSMI_Click(object sender, EventArgs e)
        {
            Forms.OpenForm.OpenCaixa();
        }

        private void despesaTSMI_Click(object sender, EventArgs e)
        {
            Forms.OpenForm.OpenDespesa();
        }

        private void quitarVendaTSMI_Click(object sender, EventArgs e)
        {
            Forms.OpenForm.OpenVendaQuitar();
        }

        private void chequesTSMI_Click(object sender, EventArgs e)
        {
            Forms.OpenForm.OpenCheque();
        }
        private void cartoesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.OpenForm.OpenCartao();
        }
        #endregion

        #region Venda
        private void venda_TSMI_Click(object sender, EventArgs e)
        {
            Forms.OpenForm.OpenVenda();
        }

        private void condicionalTSMI_Click(object sender, EventArgs e)
        {
            Forms.OpenForm.OpenCondicional();
        }

        private void vendasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.OpenForm.OpenVendaList();
        }
        private void condicionaisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.OpenForm.OpenCondicionalList();
        }
        #endregion

        #region Relatórios
        private void vendasToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Reports.Standard Reports = new Reports.Standard();
            Reports.relatorio = "Venda";
            Reports.Show();
            Reports.Disposed += delegate { Reports.Dispose(); };
        }
        #endregion

        #region Manutencao
        private void backupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                saveFileDialog1.Filter = "Arquivo de Backup (.bak)|*.bak";
                saveFileDialog1.Title = "Salvar Arquivo de Backup";
                saveFileDialog1.OverwritePrompt = false;
                saveFileDialog1.ShowDialog();

                if (saveFileDialog1.FileName != "")
                {
                    FileInfo fi = new FileInfo(saveFileDialog1.FileName);
                    AddDirectorySecurity(fi.Directory.ToString(), "NETWORK SERVICE", FileSystemRights.FullControl,
                                     InheritanceFlags.ContainerInherit | InheritanceFlags.ObjectInherit,
                                     PropagationFlags.None, AccessControlType.Allow);

                    Library.Backup.Execute(saveFileDialog1.FileName);

                    MessageBox.Show("Backup efetuado com sucesso!");
                }
            }
            catch (Exception ex)
            {
                Library.Diagnostics.Logger.Error(ex);
            }

        }
        #endregion

        #region Ajuda
        private void sobreTSMI_Click(object sender, EventArgs e)
        {
            bool verifica = false;

            foreach (Form a in System.Windows.Forms.Application.OpenForms)
            {
                if (a is Forms.About)
                {
                    a.BringToFront();
                    verifica = true;
                    break;
                }
            }

            if (!verifica)
            {
                Forms.About form = new Forms.About();
                form.Show();
                form.Disposed += delegate { form.Dispose(); };
            }
        }
        #endregion

        #region Sair
        private void toolStripMenuItemSair_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }
        #endregion

        #region toolbar
        private void produtoTSSL_Click(object sender, EventArgs e)
        {
            Forms.OpenForm.OpenEstoque();
        }
        private void toolStripStatusDividasVenda_Click(object sender, EventArgs e)
        {
            Forms.OpenForm.OpenVendaListByCliente();
        }
        private void toolStripStatusLabelCondicional_Click(object sender, EventArgs e)
        {
            Forms.OpenForm.OpenCondicionalList();
        }
        #endregion



        // Adds an ACL entry on the specified directory for the specified account. 
        public static void AddDirectorySecurity(string FileName, string Account, FileSystemRights Rights, InheritanceFlags Inheritance, PropagationFlags Propogation, AccessControlType ControlType)
        {
            // Create a new DirectoryInfo object. 
            DirectoryInfo dInfo = new DirectoryInfo(FileName);
            // Get a DirectorySecurity object that represents the  
            // current security settings. 
            DirectorySecurity dSecurity = dInfo.GetAccessControl();
            // Add the FileSystemAccessRule to the security settings.  
            dSecurity.AddAccessRule(new FileSystemAccessRule(Account, Rights, Inheritance, Propogation, ControlType));
            // Set the new access settings. 
            dInfo.SetAccessControl(dSecurity);
        }


    }


}
