﻿namespace Forms.Fornecedor
{
    partial class Fornecedor
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Fornecedor));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.idLabel = new System.Windows.Forms.Label();
            this.observacoesLabel = new System.Windows.Forms.Label();
            this.siteLabel = new System.Windows.Forms.Label();
            this.emailLabel = new System.Windows.Forms.Label();
            this.inscricaoEstadualLabel = new System.Windows.Forms.Label();
            this.cnpjLabel = new System.Windows.Forms.Label();
            this.faxLabel = new System.Windows.Forms.Label();
            this.telefoneLabel = new System.Windows.Forms.Label();
            this.cepLabel = new System.Windows.Forms.Label();
            this.estadoLabel = new System.Windows.Forms.Label();
            this.cidadeLabel = new System.Windows.Forms.Label();
            this.bairroLabel = new System.Windows.Forms.Label();
            this.enderecoLabel = new System.Windows.Forms.Label();
            this.contatoLabel = new System.Windows.Forms.Label();
            this.nomeLabel = new System.Windows.Forms.Label();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.novoButton = new System.Windows.Forms.Button();
            this.editarButton = new System.Windows.Forms.Button();
            this.salvarButton = new System.Windows.Forms.Button();
            this.cancelarButton = new System.Windows.Forms.Button();
            this.excluirButton = new System.Windows.Forms.Button();
            this.HorizontalSplit = new System.Windows.Forms.SplitContainer();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.idDGVTBC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nomeDGVTBC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataCadastroDGVTBC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bairroDGVTBC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cepDGVTBC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cidadeDGVTBC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cnpjDGVTBC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contatoDGVTBC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.emailDGVTBC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.enderecoDGVTBC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.estadoDGVTBC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.faxDGVTBC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.inscricaoEstadualDGVTBC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.siteDGVTBC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.telefoneDGVTBC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.filtrosGB = new System.Windows.Forms.GroupBox();
            this.pesquisarButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.filtrosTextBox = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cnpjTB = new System.Windows.Forms.TextBox();
            this.nomeTB = new System.Windows.Forms.TextBox();
            this.codigoTB = new System.Windows.Forms.TextBox();
            this.contatoTB = new System.Windows.Forms.TextBox();
            this.enderecoTB = new System.Windows.Forms.TextBox();
            this.bairroTB = new System.Windows.Forms.TextBox();
            this.cidadeTB = new System.Windows.Forms.TextBox();
            this.estadoCB = new System.Windows.Forms.ComboBox();
            this.cepTB = new System.Windows.Forms.TextBox();
            this.telefoneTB = new System.Windows.Forms.TextBox();
            this.faxTB = new System.Windows.Forms.TextBox();
            this.inscricaoEstadualTB = new System.Windows.Forms.TextBox();
            this.emailTB = new System.Windows.Forms.TextBox();
            this.observacoesTB = new System.Windows.Forms.TextBox();
            this.siteTB = new System.Windows.Forms.TextBox();
            this.warnigProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.HorizontalSplit)).BeginInit();
            this.HorizontalSplit.Panel1.SuspendLayout();
            this.HorizontalSplit.Panel2.SuspendLayout();
            this.HorizontalSplit.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.filtrosGB.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.warnigProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // idLabel
            // 
            this.idLabel.AutoSize = true;
            this.idLabel.Location = new System.Drawing.Point(50, 29);
            this.idLabel.Name = "idLabel";
            this.idLabel.Size = new System.Drawing.Size(43, 13);
            this.idLabel.TabIndex = 0;
            this.idLabel.Text = "Código:";
            // 
            // observacoesLabel
            // 
            this.observacoesLabel.AutoSize = true;
            this.observacoesLabel.Location = new System.Drawing.Point(494, 30);
            this.observacoesLabel.Name = "observacoesLabel";
            this.observacoesLabel.Size = new System.Drawing.Size(73, 13);
            this.observacoesLabel.TabIndex = 24;
            this.observacoesLabel.Text = "Observações:";
            // 
            // siteLabel
            // 
            this.siteLabel.AutoSize = true;
            this.siteLabel.Location = new System.Drawing.Point(494, 275);
            this.siteLabel.Name = "siteLabel";
            this.siteLabel.Size = new System.Drawing.Size(28, 13);
            this.siteLabel.TabIndex = 28;
            this.siteLabel.Text = "Site:";
            // 
            // emailLabel
            // 
            this.emailLabel.AutoSize = true;
            this.emailLabel.Location = new System.Drawing.Point(494, 234);
            this.emailLabel.Name = "emailLabel";
            this.emailLabel.Size = new System.Drawing.Size(35, 13);
            this.emailLabel.TabIndex = 26;
            this.emailLabel.Text = "Email:";
            // 
            // inscricaoEstadualLabel
            // 
            this.inscricaoEstadualLabel.AutoSize = true;
            this.inscricaoEstadualLabel.Location = new System.Drawing.Point(272, 314);
            this.inscricaoEstadualLabel.Name = "inscricaoEstadualLabel";
            this.inscricaoEstadualLabel.Size = new System.Drawing.Size(96, 13);
            this.inscricaoEstadualLabel.TabIndex = 22;
            this.inscricaoEstadualLabel.Text = "Inscrição estadual:";
            // 
            // cnpjLabel
            // 
            this.cnpjLabel.AutoSize = true;
            this.cnpjLabel.Location = new System.Drawing.Point(50, 314);
            this.cnpjLabel.Name = "cnpjLabel";
            this.cnpjLabel.Size = new System.Drawing.Size(37, 13);
            this.cnpjLabel.TabIndex = 20;
            this.cnpjLabel.Text = "CNPJ:";
            // 
            // faxLabel
            // 
            this.faxLabel.AutoSize = true;
            this.faxLabel.Location = new System.Drawing.Point(272, 275);
            this.faxLabel.Name = "faxLabel";
            this.faxLabel.Size = new System.Drawing.Size(27, 13);
            this.faxLabel.TabIndex = 18;
            this.faxLabel.Text = "Fax:";
            // 
            // telefoneLabel
            // 
            this.telefoneLabel.AutoSize = true;
            this.telefoneLabel.Location = new System.Drawing.Point(50, 275);
            this.telefoneLabel.Name = "telefoneLabel";
            this.telefoneLabel.Size = new System.Drawing.Size(52, 13);
            this.telefoneLabel.TabIndex = 16;
            this.telefoneLabel.Text = "Telefone:";
            // 
            // cepLabel
            // 
            this.cepLabel.AutoSize = true;
            this.cepLabel.Location = new System.Drawing.Point(348, 234);
            this.cepLabel.Name = "cepLabel";
            this.cepLabel.Size = new System.Drawing.Size(31, 13);
            this.cepLabel.TabIndex = 14;
            this.cepLabel.Text = "CEP:";
            // 
            // estadoLabel
            // 
            this.estadoLabel.AutoSize = true;
            this.estadoLabel.Location = new System.Drawing.Point(272, 234);
            this.estadoLabel.Name = "estadoLabel";
            this.estadoLabel.Size = new System.Drawing.Size(43, 13);
            this.estadoLabel.TabIndex = 12;
            this.estadoLabel.Text = "Estado:";
            // 
            // cidadeLabel
            // 
            this.cidadeLabel.AutoSize = true;
            this.cidadeLabel.Location = new System.Drawing.Point(50, 234);
            this.cidadeLabel.Name = "cidadeLabel";
            this.cidadeLabel.Size = new System.Drawing.Size(43, 13);
            this.cidadeLabel.TabIndex = 10;
            this.cidadeLabel.Text = "Cidade:";
            // 
            // bairroLabel
            // 
            this.bairroLabel.AutoSize = true;
            this.bairroLabel.Location = new System.Drawing.Point(50, 193);
            this.bairroLabel.Name = "bairroLabel";
            this.bairroLabel.Size = new System.Drawing.Size(37, 13);
            this.bairroLabel.TabIndex = 8;
            this.bairroLabel.Text = "Bairro:";
            // 
            // enderecoLabel
            // 
            this.enderecoLabel.AutoSize = true;
            this.enderecoLabel.Location = new System.Drawing.Point(50, 152);
            this.enderecoLabel.Name = "enderecoLabel";
            this.enderecoLabel.Size = new System.Drawing.Size(56, 13);
            this.enderecoLabel.TabIndex = 6;
            this.enderecoLabel.Text = "Endereço:";
            // 
            // contatoLabel
            // 
            this.contatoLabel.AutoSize = true;
            this.contatoLabel.Location = new System.Drawing.Point(50, 111);
            this.contatoLabel.Name = "contatoLabel";
            this.contatoLabel.Size = new System.Drawing.Size(47, 13);
            this.contatoLabel.TabIndex = 4;
            this.contatoLabel.Text = "Contato:";
            // 
            // nomeLabel
            // 
            this.nomeLabel.AutoSize = true;
            this.nomeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nomeLabel.Location = new System.Drawing.Point(50, 70);
            this.nomeLabel.Name = "nomeLabel";
            this.nomeLabel.Size = new System.Drawing.Size(38, 13);
            this.nomeLabel.TabIndex = 2;
            this.nomeLabel.Text = "Nome:";
            // 
            // errorProvider
            // 
            this.errorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProvider.ContainerControl = this;
            this.errorProvider.Icon = ((System.Drawing.Icon)(resources.GetObject("errorProvider.Icon")));
            // 
            // novoButton
            // 
            this.novoButton.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.novoButton.Image = ((System.Drawing.Image)(resources.GetObject("novoButton.Image")));
            this.novoButton.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.novoButton.Location = new System.Drawing.Point(328, 10);
            this.novoButton.Name = "novoButton";
            this.novoButton.Size = new System.Drawing.Size(60, 60);
            this.novoButton.TabIndex = 0;
            this.novoButton.Text = "&Novo";
            this.novoButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.novoButton.UseVisualStyleBackColor = true;
            this.novoButton.Click += new System.EventHandler(this.novoButton_Click);
            // 
            // editarButton
            // 
            this.editarButton.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.editarButton.Image = ((System.Drawing.Image)(resources.GetObject("editarButton.Image")));
            this.editarButton.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.editarButton.Location = new System.Drawing.Point(396, 10);
            this.editarButton.Name = "editarButton";
            this.editarButton.Size = new System.Drawing.Size(60, 60);
            this.editarButton.TabIndex = 1;
            this.editarButton.Text = "&Editar";
            this.editarButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.editarButton.UseVisualStyleBackColor = true;
            this.editarButton.Click += new System.EventHandler(this.editarButton_Click);
            // 
            // salvarButton
            // 
            this.salvarButton.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.salvarButton.Image = ((System.Drawing.Image)(resources.GetObject("salvarButton.Image")));
            this.salvarButton.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.salvarButton.Location = new System.Drawing.Point(464, 10);
            this.salvarButton.Name = "salvarButton";
            this.salvarButton.Size = new System.Drawing.Size(60, 60);
            this.salvarButton.TabIndex = 2;
            this.salvarButton.Text = "&Salvar";
            this.salvarButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.salvarButton.UseVisualStyleBackColor = true;
            this.salvarButton.Click += new System.EventHandler(this.salvarButton_Click);
            // 
            // cancelarButton
            // 
            this.cancelarButton.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cancelarButton.Image = ((System.Drawing.Image)(resources.GetObject("cancelarButton.Image")));
            this.cancelarButton.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.cancelarButton.Location = new System.Drawing.Point(532, 10);
            this.cancelarButton.Name = "cancelarButton";
            this.cancelarButton.Size = new System.Drawing.Size(60, 60);
            this.cancelarButton.TabIndex = 3;
            this.cancelarButton.Text = "&Cancelar";
            this.cancelarButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.cancelarButton.UseVisualStyleBackColor = true;
            this.cancelarButton.Click += new System.EventHandler(this.cancelarButton_Click);
            // 
            // excluirButton
            // 
            this.excluirButton.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.excluirButton.Image = ((System.Drawing.Image)(resources.GetObject("excluirButton.Image")));
            this.excluirButton.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.excluirButton.Location = new System.Drawing.Point(600, 10);
            this.excluirButton.Name = "excluirButton";
            this.excluirButton.Size = new System.Drawing.Size(60, 60);
            this.excluirButton.TabIndex = 4;
            this.excluirButton.Text = "Exc&luir";
            this.excluirButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.excluirButton.UseVisualStyleBackColor = true;
            this.excluirButton.Click += new System.EventHandler(this.excluirButton_Click);
            // 
            // HorizontalSplit
            // 
            this.HorizontalSplit.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.HorizontalSplit.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.HorizontalSplit.IsSplitterFixed = true;
            this.HorizontalSplit.Location = new System.Drawing.Point(0, 0);
            this.HorizontalSplit.Margin = new System.Windows.Forms.Padding(0);
            this.HorizontalSplit.Name = "HorizontalSplit";
            this.HorizontalSplit.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // HorizontalSplit.Panel1
            // 
            this.HorizontalSplit.Panel1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.HorizontalSplit.Panel1.Controls.Add(this.novoButton);
            this.HorizontalSplit.Panel1.Controls.Add(this.editarButton);
            this.HorizontalSplit.Panel1.Controls.Add(this.excluirButton);
            this.HorizontalSplit.Panel1.Controls.Add(this.salvarButton);
            this.HorizontalSplit.Panel1.Controls.Add(this.cancelarButton);
            this.HorizontalSplit.Panel1MinSize = 80;
            // 
            // HorizontalSplit.Panel2
            // 
            this.HorizontalSplit.Panel2.Controls.Add(this.tableLayoutPanel1);
            this.HorizontalSplit.Panel2.Controls.Add(this.panel1);
            this.HorizontalSplit.Size = new System.Drawing.Size(989, 565);
            this.HorizontalSplit.SplitterDistance = 80;
            this.HorizontalSplit.SplitterWidth = 1;
            this.HorizontalSplit.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.BackColor = System.Drawing.SystemColors.Control;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.dataGridView1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.filtrosGB, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(745, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 106F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(244, 490);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDGVTBC,
            this.nomeDGVTBC,
            this.dataCadastroDGVTBC,
            this.bairroDGVTBC,
            this.cepDGVTBC,
            this.cidadeDGVTBC,
            this.cnpjDGVTBC,
            this.contatoDGVTBC,
            this.emailDGVTBC,
            this.enderecoDGVTBC,
            this.estadoDGVTBC,
            this.faxDGVTBC,
            this.inscricaoEstadualDGVTBC,
            this.siteDGVTBC,
            this.telefoneDGVTBC});
            this.dataGridView1.Location = new System.Drawing.Point(6, 112);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(6);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidth = 16;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(232, 372);
            this.dataGridView1.TabIndex = 1;
            //this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            this.dataGridView1.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_RowEnter);
            this.dataGridView1.SelectionChanged += new System.EventHandler(this.dataGridView1_SelectionChanged);
            // 
            // idDGVTBC
            // 
            this.idDGVTBC.DataPropertyName = "id";
            this.idDGVTBC.HeaderText = "Cod.";
            this.idDGVTBC.Name = "idDGVTBC";
            this.idDGVTBC.ReadOnly = true;
            this.idDGVTBC.Width = 50;
            // 
            // nomeDGVTBC
            // 
            this.nomeDGVTBC.DataPropertyName = "nome";
            this.nomeDGVTBC.HeaderText = "Nome";
            this.nomeDGVTBC.Name = "nomeDGVTBC";
            this.nomeDGVTBC.ReadOnly = true;
            // 
            // dataCadastroDGVTBC
            // 
            this.dataCadastroDGVTBC.DataPropertyName = "dataCadastro";
            dataGridViewCellStyle1.Format = "d";
            dataGridViewCellStyle1.NullValue = null;
            this.dataCadastroDGVTBC.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataCadastroDGVTBC.HeaderText = "Data";
            this.dataCadastroDGVTBC.Name = "dataCadastroDGVTBC";
            this.dataCadastroDGVTBC.ReadOnly = true;
            this.dataCadastroDGVTBC.Width = 80;
            // 
            // bairroDGVTBC
            // 
            this.bairroDGVTBC.DataPropertyName = "bairro";
            this.bairroDGVTBC.HeaderText = "Bairro";
            this.bairroDGVTBC.Name = "bairroDGVTBC";
            this.bairroDGVTBC.ReadOnly = true;
            this.bairroDGVTBC.Visible = false;
            // 
            // cepDGVTBC
            // 
            this.cepDGVTBC.DataPropertyName = "cep";
            this.cepDGVTBC.HeaderText = "CEP";
            this.cepDGVTBC.Name = "cepDGVTBC";
            this.cepDGVTBC.ReadOnly = true;
            this.cepDGVTBC.Visible = false;
            // 
            // cidadeDGVTBC
            // 
            this.cidadeDGVTBC.DataPropertyName = "cidade";
            this.cidadeDGVTBC.HeaderText = "Cidade";
            this.cidadeDGVTBC.Name = "cidadeDGVTBC";
            this.cidadeDGVTBC.ReadOnly = true;
            this.cidadeDGVTBC.Visible = false;
            // 
            // cnpjDGVTBC
            // 
            this.cnpjDGVTBC.DataPropertyName = "cnpj";
            this.cnpjDGVTBC.HeaderText = "CNPJ";
            this.cnpjDGVTBC.Name = "cnpjDGVTBC";
            this.cnpjDGVTBC.ReadOnly = true;
            this.cnpjDGVTBC.Visible = false;
            // 
            // contatoDGVTBC
            // 
            this.contatoDGVTBC.DataPropertyName = "contato";
            this.contatoDGVTBC.HeaderText = "Contato";
            this.contatoDGVTBC.Name = "contatoDGVTBC";
            this.contatoDGVTBC.ReadOnly = true;
            this.contatoDGVTBC.Visible = false;
            // 
            // emailDGVTBC
            // 
            this.emailDGVTBC.DataPropertyName = "email";
            this.emailDGVTBC.HeaderText = "Email";
            this.emailDGVTBC.Name = "emailDGVTBC";
            this.emailDGVTBC.ReadOnly = true;
            this.emailDGVTBC.Visible = false;
            // 
            // enderecoDGVTBC
            // 
            this.enderecoDGVTBC.DataPropertyName = "endereco";
            this.enderecoDGVTBC.HeaderText = "Endereço";
            this.enderecoDGVTBC.Name = "enderecoDGVTBC";
            this.enderecoDGVTBC.ReadOnly = true;
            this.enderecoDGVTBC.Visible = false;
            // 
            // estadoDGVTBC
            // 
            this.estadoDGVTBC.DataPropertyName = "estado";
            this.estadoDGVTBC.HeaderText = "Estado";
            this.estadoDGVTBC.Name = "estadoDGVTBC";
            this.estadoDGVTBC.ReadOnly = true;
            this.estadoDGVTBC.Visible = false;
            // 
            // faxDGVTBC
            // 
            this.faxDGVTBC.DataPropertyName = "fax";
            this.faxDGVTBC.HeaderText = "Fax";
            this.faxDGVTBC.Name = "faxDGVTBC";
            this.faxDGVTBC.ReadOnly = true;
            this.faxDGVTBC.Visible = false;
            // 
            // inscricaoEstadualDGVTBC
            // 
            this.inscricaoEstadualDGVTBC.DataPropertyName = "inscricaoEstadual";
            this.inscricaoEstadualDGVTBC.HeaderText = "InscricaoEstadual";
            this.inscricaoEstadualDGVTBC.Name = "inscricaoEstadualDGVTBC";
            this.inscricaoEstadualDGVTBC.ReadOnly = true;
            this.inscricaoEstadualDGVTBC.Visible = false;
            // 
            // siteDGVTBC
            // 
            this.siteDGVTBC.DataPropertyName = "site";
            this.siteDGVTBC.HeaderText = "Site";
            this.siteDGVTBC.Name = "siteDGVTBC";
            this.siteDGVTBC.ReadOnly = true;
            this.siteDGVTBC.Visible = false;
            // 
            // telefoneDGVTBC
            // 
            this.telefoneDGVTBC.DataPropertyName = "telefone";
            this.telefoneDGVTBC.HeaderText = "Telefone";
            this.telefoneDGVTBC.Name = "telefoneDGVTBC";
            this.telefoneDGVTBC.ReadOnly = true;
            this.telefoneDGVTBC.Visible = false;
            // 
            // filtrosGB
            // 
            this.filtrosGB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.filtrosGB.Controls.Add(this.pesquisarButton);
            this.filtrosGB.Controls.Add(this.label1);
            this.filtrosGB.Controls.Add(this.filtrosTextBox);
            this.filtrosGB.Location = new System.Drawing.Point(6, 6);
            this.filtrosGB.Margin = new System.Windows.Forms.Padding(6);
            this.filtrosGB.Name = "filtrosGB";
            this.filtrosGB.Size = new System.Drawing.Size(232, 94);
            this.filtrosGB.TabIndex = 0;
            this.filtrosGB.TabStop = false;
            this.filtrosGB.Text = "Filtros";
            // 
            // pesquisarButton
            // 
            this.pesquisarButton.Location = new System.Drawing.Point(6, 66);
            this.pesquisarButton.Name = "pesquisarButton";
            this.pesquisarButton.Size = new System.Drawing.Size(75, 23);
            this.pesquisarButton.TabIndex = 2;
            this.pesquisarButton.Text = "Pesquisar";
            this.pesquisarButton.UseVisualStyleBackColor = true;
            this.pesquisarButton.Click += new System.EventHandler(this.pesquisarButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nome ou código:";
            // 
            // filtrosTextBox
            // 
            this.filtrosTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.filtrosTextBox.Location = new System.Drawing.Point(6, 39);
            this.filtrosTextBox.Margin = new System.Windows.Forms.Padding(3, 3, 19, 3);
            this.filtrosTextBox.Name = "filtrosTextBox";
            this.filtrosTextBox.Size = new System.Drawing.Size(204, 20);
            this.filtrosTextBox.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.Controls.Add(this.idLabel);
            this.panel1.Controls.Add(this.observacoesLabel);
            this.panel1.Controls.Add(this.cnpjTB);
            this.panel1.Controls.Add(this.siteLabel);
            this.panel1.Controls.Add(this.emailLabel);
            this.panel1.Controls.Add(this.nomeTB);
            this.panel1.Controls.Add(this.inscricaoEstadualLabel);
            this.panel1.Controls.Add(this.codigoTB);
            this.panel1.Controls.Add(this.cnpjLabel);
            this.panel1.Controls.Add(this.contatoTB);
            this.panel1.Controls.Add(this.faxLabel);
            this.panel1.Controls.Add(this.enderecoTB);
            this.panel1.Controls.Add(this.telefoneLabel);
            this.panel1.Controls.Add(this.bairroTB);
            this.panel1.Controls.Add(this.cepLabel);
            this.panel1.Controls.Add(this.cidadeTB);
            this.panel1.Controls.Add(this.estadoLabel);
            this.panel1.Controls.Add(this.estadoCB);
            this.panel1.Controls.Add(this.cidadeLabel);
            this.panel1.Controls.Add(this.cepTB);
            this.panel1.Controls.Add(this.bairroLabel);
            this.panel1.Controls.Add(this.telefoneTB);
            this.panel1.Controls.Add(this.enderecoLabel);
            this.panel1.Controls.Add(this.faxTB);
            this.panel1.Controls.Add(this.contatoLabel);
            this.panel1.Controls.Add(this.inscricaoEstadualTB);
            this.panel1.Controls.Add(this.nomeLabel);
            this.panel1.Controls.Add(this.emailTB);
            this.panel1.Controls.Add(this.observacoesTB);
            this.panel1.Controls.Add(this.siteTB);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(0, 0, 1, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(744, 490);
            this.panel1.TabIndex = 0;
            // 
            // cnpjTB
            // 
            this.cnpjTB.Location = new System.Drawing.Point(50, 332);
            this.cnpjTB.Name = "cnpjTB";
            this.cnpjTB.Size = new System.Drawing.Size(200, 20);
            this.cnpjTB.TabIndex = 21;
            this.cnpjTB.TextChanged += new System.EventHandler(this.cnpjTB_TextChanged);
            this.cnpjTB.Validating += new System.ComponentModel.CancelEventHandler(this.cnpjTB_Validating);
            // 
            // nomeTB
            // 
            this.nomeTB.Location = new System.Drawing.Point(50, 86);
            this.nomeTB.Margin = new System.Windows.Forms.Padding(3, 3, 19, 5);
            this.nomeTB.MaxLength = 50;
            this.nomeTB.Name = "nomeTB";
            this.nomeTB.Size = new System.Drawing.Size(422, 20);
            this.nomeTB.TabIndex = 3;
            this.nomeTB.Validating += new System.ComponentModel.CancelEventHandler(this.nomeTB_Validating);
            // 
            // codigoTB
            // 
            this.codigoTB.Location = new System.Drawing.Point(50, 45);
            this.codigoTB.Margin = new System.Windows.Forms.Padding(3, 3, 19, 5);
            this.codigoTB.MaxLength = 50;
            this.codigoTB.Name = "codigoTB";
            this.codigoTB.ReadOnly = true;
            this.codigoTB.Size = new System.Drawing.Size(155, 20);
            this.codigoTB.TabIndex = 1;
            // 
            // contatoTB
            // 
            this.contatoTB.Location = new System.Drawing.Point(50, 127);
            this.contatoTB.Margin = new System.Windows.Forms.Padding(3, 3, 19, 5);
            this.contatoTB.MaxLength = 50;
            this.contatoTB.Name = "contatoTB";
            this.contatoTB.Size = new System.Drawing.Size(422, 20);
            this.contatoTB.TabIndex = 5;
            // 
            // enderecoTB
            // 
            this.enderecoTB.Location = new System.Drawing.Point(50, 168);
            this.enderecoTB.Margin = new System.Windows.Forms.Padding(3, 3, 19, 5);
            this.enderecoTB.MaxLength = 50;
            this.enderecoTB.Name = "enderecoTB";
            this.enderecoTB.Size = new System.Drawing.Size(422, 20);
            this.enderecoTB.TabIndex = 7;
            // 
            // bairroTB
            // 
            this.bairroTB.Location = new System.Drawing.Point(50, 209);
            this.bairroTB.Margin = new System.Windows.Forms.Padding(3, 3, 19, 5);
            this.bairroTB.MaxLength = 30;
            this.bairroTB.Name = "bairroTB";
            this.bairroTB.Size = new System.Drawing.Size(200, 20);
            this.bairroTB.TabIndex = 9;
            // 
            // cidadeTB
            // 
            this.cidadeTB.Location = new System.Drawing.Point(50, 250);
            this.cidadeTB.Margin = new System.Windows.Forms.Padding(3, 3, 19, 5);
            this.cidadeTB.MaxLength = 50;
            this.cidadeTB.Name = "cidadeTB";
            this.cidadeTB.Size = new System.Drawing.Size(200, 20);
            this.cidadeTB.TabIndex = 11;
            // 
            // estadoCB
            // 
            this.estadoCB.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.estadoCB.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.estadoCB.FormattingEnabled = true;
            this.estadoCB.Items.AddRange(new object[] {
            "AC",
            "AL",
            "AP",
            "AM",
            "BA",
            "CE",
            "DF",
            "ES",
            "GO",
            "MA",
            "MT",
            "MS",
            "MG",
            "PA",
            "PB",
            "PR",
            "PE",
            "PI",
            "RJ",
            "RN",
            "RS",
            "RO",
            "RR",
            "SC",
            "SP",
            "SE",
            "TO"});
            this.estadoCB.Location = new System.Drawing.Point(272, 250);
            this.estadoCB.Margin = new System.Windows.Forms.Padding(3, 3, 19, 5);
            this.estadoCB.Name = "estadoCB";
            this.estadoCB.Size = new System.Drawing.Size(52, 21);
            this.estadoCB.TabIndex = 13;
            // 
            // cepTB
            // 
            this.cepTB.Location = new System.Drawing.Point(349, 251);
            this.cepTB.Margin = new System.Windows.Forms.Padding(3, 3, 19, 5);
            this.cepTB.Name = "cepTB";
            this.cepTB.Size = new System.Drawing.Size(123, 20);
            this.cepTB.TabIndex = 15;
            // 
            // telefoneTB
            // 
            this.telefoneTB.Location = new System.Drawing.Point(50, 291);
            this.telefoneTB.Margin = new System.Windows.Forms.Padding(3, 3, 19, 5);
            this.telefoneTB.Name = "telefoneTB";
            this.telefoneTB.Size = new System.Drawing.Size(200, 20);
            this.telefoneTB.TabIndex = 17;
            // 
            // faxTB
            // 
            this.faxTB.Location = new System.Drawing.Point(272, 291);
            this.faxTB.Margin = new System.Windows.Forms.Padding(3, 3, 19, 5);
            this.faxTB.Name = "faxTB";
            this.faxTB.Size = new System.Drawing.Size(200, 20);
            this.faxTB.TabIndex = 19;
            // 
            // inscricaoEstadualTB
            // 
            this.inscricaoEstadualTB.Location = new System.Drawing.Point(272, 332);
            this.inscricaoEstadualTB.Margin = new System.Windows.Forms.Padding(3, 3, 19, 5);
            this.inscricaoEstadualTB.MaxLength = 20;
            this.inscricaoEstadualTB.Name = "inscricaoEstadualTB";
            this.inscricaoEstadualTB.Size = new System.Drawing.Size(200, 20);
            this.inscricaoEstadualTB.TabIndex = 23;
            // 
            // emailTB
            // 
            this.emailTB.Location = new System.Drawing.Point(494, 250);
            this.emailTB.Margin = new System.Windows.Forms.Padding(3, 3, 19, 5);
            this.emailTB.MaxLength = 50;
            this.emailTB.Name = "emailTB";
            this.emailTB.Size = new System.Drawing.Size(200, 20);
            this.emailTB.TabIndex = 27;
            this.emailTB.TextChanged += new System.EventHandler(this.emailTB_TextChanged);
            this.emailTB.Validating += new System.ComponentModel.CancelEventHandler(this.emailTB_Validating);
            // 
            // observacoesTB
            // 
            this.observacoesTB.Location = new System.Drawing.Point(494, 46);
            this.observacoesTB.Margin = new System.Windows.Forms.Padding(3, 3, 19, 5);
            this.observacoesTB.MaxLength = 2000;
            this.observacoesTB.Multiline = true;
            this.observacoesTB.Name = "observacoesTB";
            this.observacoesTB.Size = new System.Drawing.Size(200, 183);
            this.observacoesTB.TabIndex = 25;
            // 
            // siteTB
            // 
            this.siteTB.Location = new System.Drawing.Point(494, 291);
            this.siteTB.Margin = new System.Windows.Forms.Padding(3, 3, 19, 5);
            this.siteTB.MaxLength = 50;
            this.siteTB.Name = "siteTB";
            this.siteTB.Size = new System.Drawing.Size(200, 20);
            this.siteTB.TabIndex = 29;
            // 
            // warnigProvider
            // 
            this.warnigProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.warnigProvider.ContainerControl = this;
            this.warnigProvider.Icon = ((System.Drawing.Icon)(resources.GetObject("warnigProvider.Icon")));
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 565);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(989, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // Fornecedor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(989, 587);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.HorizontalSplit);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MinimumSize = new System.Drawing.Size(752, 519);
            this.Name = "Fornecedor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Fornecedores";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Fornecedor_FormClosed);
            this.Load += new System.EventHandler(this.Fornecedor_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Fornecedor_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.HorizontalSplit.Panel1.ResumeLayout(false);
            this.HorizontalSplit.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.HorizontalSplit)).EndInit();
            this.HorizontalSplit.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.filtrosGB.ResumeLayout(false);
            this.filtrosGB.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.warnigProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.SplitContainer HorizontalSplit;
        private System.Windows.Forms.Button novoButton;
        private System.Windows.Forms.Button editarButton;
        private System.Windows.Forms.Button excluirButton;
        private System.Windows.Forms.Button salvarButton;
        private System.Windows.Forms.Button cancelarButton;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.GroupBox filtrosGB;
        private System.Windows.Forms.Button pesquisarButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox filtrosTextBox;
        private System.Windows.Forms.TextBox cnpjTB;
        private System.Windows.Forms.TextBox nomeTB;
        private System.Windows.Forms.TextBox codigoTB;
        private System.Windows.Forms.TextBox contatoTB;
        private System.Windows.Forms.TextBox enderecoTB;
        private System.Windows.Forms.TextBox bairroTB;
        private System.Windows.Forms.TextBox cidadeTB;
        private System.Windows.Forms.ComboBox estadoCB;
        private System.Windows.Forms.TextBox cepTB;
        private System.Windows.Forms.TextBox telefoneTB;
        private System.Windows.Forms.TextBox faxTB;
        private System.Windows.Forms.TextBox inscricaoEstadualTB;
        private System.Windows.Forms.TextBox emailTB;
        private System.Windows.Forms.TextBox siteTB;
        private System.Windows.Forms.TextBox observacoesTB;
        private System.Windows.Forms.ErrorProvider warnigProvider;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label idLabel;
        private System.Windows.Forms.Label observacoesLabel;
        private System.Windows.Forms.Label siteLabel;
        private System.Windows.Forms.Label emailLabel;
        private System.Windows.Forms.Label inscricaoEstadualLabel;
        private System.Windows.Forms.Label cnpjLabel;
        private System.Windows.Forms.Label faxLabel;
        private System.Windows.Forms.Label telefoneLabel;
        private System.Windows.Forms.Label cepLabel;
        private System.Windows.Forms.Label estadoLabel;
        private System.Windows.Forms.Label cidadeLabel;
        private System.Windows.Forms.Label bairroLabel;
        private System.Windows.Forms.Label enderecoLabel;
        private System.Windows.Forms.Label contatoLabel;
        private System.Windows.Forms.Label nomeLabel;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDGVTBC;
        private System.Windows.Forms.DataGridViewTextBoxColumn nomeDGVTBC;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataCadastroDGVTBC;
        private System.Windows.Forms.DataGridViewTextBoxColumn bairroDGVTBC;
        private System.Windows.Forms.DataGridViewTextBoxColumn cepDGVTBC;
        private System.Windows.Forms.DataGridViewTextBoxColumn cidadeDGVTBC;
        private System.Windows.Forms.DataGridViewTextBoxColumn cnpjDGVTBC;
        private System.Windows.Forms.DataGridViewTextBoxColumn contatoDGVTBC;
        private System.Windows.Forms.DataGridViewTextBoxColumn emailDGVTBC;
        private System.Windows.Forms.DataGridViewTextBoxColumn enderecoDGVTBC;
        private System.Windows.Forms.DataGridViewTextBoxColumn estadoDGVTBC;
        private System.Windows.Forms.DataGridViewTextBoxColumn faxDGVTBC;
        private System.Windows.Forms.DataGridViewTextBoxColumn inscricaoEstadualDGVTBC;
        private System.Windows.Forms.DataGridViewTextBoxColumn siteDGVTBC;
        private System.Windows.Forms.DataGridViewTextBoxColumn telefoneDGVTBC;
    }
}