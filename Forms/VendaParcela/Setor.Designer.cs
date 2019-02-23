namespace Forms.Setor
{
    partial class Setor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Setor));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
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
            this.descricaoDGVTBC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.filtrosGB = new System.Windows.Forms.GroupBox();
            this.pesquisarButton = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.filtrosTextBox = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.codigoL = new System.Windows.Forms.Label();
            this.descricaoTB = new System.Windows.Forms.TextBox();
            this.nomeL = new System.Windows.Forms.Label();
            this.nomeTB = new System.Windows.Forms.TextBox();
            this.descricaoL = new System.Windows.Forms.Label();
            this.codigoTB = new System.Windows.Forms.TextBox();
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
            this.SuspendLayout();
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
            this.novoButton.Location = new System.Drawing.Point(184, 10);
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
            this.editarButton.Location = new System.Drawing.Point(252, 10);
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
            this.salvarButton.Location = new System.Drawing.Point(320, 10);
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
            this.cancelarButton.Location = new System.Drawing.Point(388, 10);
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
            this.excluirButton.Location = new System.Drawing.Point(456, 10);
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
            this.HorizontalSplit.Size = new System.Drawing.Size(700, 458);
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
            this.tableLayoutPanel1.Location = new System.Drawing.Point(456, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 106F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(244, 377);
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
            this.descricaoDGVTBC});
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
            this.dataGridView1.Size = new System.Drawing.Size(232, 259);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
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
            this.dataCadastroDGVTBC.Width = 70;
            // 
            // descricaoDGVTBC
            // 
            this.descricaoDGVTBC.DataPropertyName = "descricao";
            this.descricaoDGVTBC.HeaderText = "Descrição";
            this.descricaoDGVTBC.Name = "descricaoDGVTBC";
            this.descricaoDGVTBC.ReadOnly = true;
            this.descricaoDGVTBC.Visible = false;
            // 
            // filtrosGB
            // 
            this.filtrosGB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.filtrosGB.Controls.Add(this.pesquisarButton);
            this.filtrosGB.Controls.Add(this.label4);
            this.filtrosGB.Controls.Add(this.filtrosTextBox);
            this.filtrosGB.Location = new System.Drawing.Point(6, 6);
            this.filtrosGB.Margin = new System.Windows.Forms.Padding(6);
            this.filtrosGB.Name = "filtrosGB";
            this.filtrosGB.Size = new System.Drawing.Size(232, 94);
            this.filtrosGB.TabIndex = 1;
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
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 23);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Nome ou código:";
            // 
            // filtrosTextBox
            // 
            this.filtrosTextBox.Location = new System.Drawing.Point(6, 39);
            this.filtrosTextBox.Margin = new System.Windows.Forms.Padding(3, 3, 19, 3);
            this.filtrosTextBox.Name = "filtrosTextBox";
            this.filtrosTextBox.Size = new System.Drawing.Size(208, 20);
            this.filtrosTextBox.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.Controls.Add(this.codigoL);
            this.panel1.Controls.Add(this.descricaoTB);
            this.panel1.Controls.Add(this.nomeL);
            this.panel1.Controls.Add(this.nomeTB);
            this.panel1.Controls.Add(this.descricaoL);
            this.panel1.Controls.Add(this.codigoTB);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(0, 0, 1, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(455, 377);
            this.panel1.TabIndex = 0;
            // 
            // codigoL
            // 
            this.codigoL.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.codigoL.AutoSize = true;
            this.codigoL.Location = new System.Drawing.Point(34, 29);
            this.codigoL.Name = "codigoL";
            this.codigoL.Size = new System.Drawing.Size(43, 13);
            this.codigoL.TabIndex = 0;
            this.codigoL.Text = "Código:";
            // 
            // descricaoTB
            // 
            this.descricaoTB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.descricaoTB.Location = new System.Drawing.Point(37, 127);
            this.descricaoTB.Margin = new System.Windows.Forms.Padding(3, 3, 19, 5);
            this.descricaoTB.Multiline = true;
            this.descricaoTB.Name = "descricaoTB";
            this.descricaoTB.Size = new System.Drawing.Size(384, 116);
            this.descricaoTB.TabIndex = 5;
            // 
            // nomeL
            // 
            this.nomeL.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.nomeL.AutoSize = true;
            this.nomeL.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nomeL.Location = new System.Drawing.Point(34, 70);
            this.nomeL.Name = "nomeL";
            this.nomeL.Size = new System.Drawing.Size(38, 13);
            this.nomeL.TabIndex = 2;
            this.nomeL.Text = "Nome:";
            // 
            // nomeTB
            // 
            this.nomeTB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.nomeTB.Location = new System.Drawing.Point(37, 86);
            this.nomeTB.Margin = new System.Windows.Forms.Padding(3, 3, 19, 5);
            this.nomeTB.Name = "nomeTB";
            this.nomeTB.Size = new System.Drawing.Size(384, 20);
            this.nomeTB.TabIndex = 3;
            // 
            // descricaoL
            // 
            this.descricaoL.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.descricaoL.AutoSize = true;
            this.descricaoL.Location = new System.Drawing.Point(34, 111);
            this.descricaoL.Name = "descricaoL";
            this.descricaoL.Size = new System.Drawing.Size(58, 13);
            this.descricaoL.TabIndex = 4;
            this.descricaoL.Text = "Descrição:";
            // 
            // codigoTB
            // 
            this.codigoTB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.codigoTB.Location = new System.Drawing.Point(37, 45);
            this.codigoTB.Margin = new System.Windows.Forms.Padding(3, 3, 19, 5);
            this.codigoTB.Name = "codigoTB";
            this.codigoTB.ReadOnly = true;
            this.codigoTB.Size = new System.Drawing.Size(384, 20);
            this.codigoTB.TabIndex = 1;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 458);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(700, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // Setor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(700, 480);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.HorizontalSplit);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(463, 415);
            this.Name = "Setor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Setores";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Setor_FormClosed);
            this.Load += new System.EventHandler(this.Setor_Load);
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
        private System.Windows.Forms.TextBox descricaoTB;
        private System.Windows.Forms.TextBox nomeTB;
        private System.Windows.Forms.TextBox codigoTB;
        private System.Windows.Forms.Label descricaoL;
        private System.Windows.Forms.Label nomeL;
        private System.Windows.Forms.Label codigoL;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.GroupBox filtrosGB;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox filtrosTextBox;
        private System.Windows.Forms.Button pesquisarButton;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDGVTBC;
        private System.Windows.Forms.DataGridViewTextBoxColumn nomeDGVTBC;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataCadastroDGVTBC;
        private System.Windows.Forms.DataGridViewTextBoxColumn descricaoDGVTBC;
    }
}