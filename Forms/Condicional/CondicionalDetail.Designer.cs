namespace Forms.Condicional
{
    partial class CondicionalDetail
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CondicionalDetail));
            this.idLabel = new System.Windows.Forms.Label();
            this.idFuncionarioLabel = new System.Windows.Forms.Label();
            this.dataLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.OrcamentoProdutoDGV = new System.Windows.Forms.DataGridView();
            this.codigoProduto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idProduto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quantidade = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.preco = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.precoTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codigoTB = new System.Windows.Forms.TextBox();
            this.dataTB = new System.Windows.Forms.TextBox();
            this.vendedorTB = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.clienteTB = new System.Windows.Forms.TextBox();
            this.okButton = new System.Windows.Forms.Button();
            this.valorTotalTB = new System.Windows.Forms.TextBox();
            this.imprimirButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.venderButton = new System.Windows.Forms.Button();
            this.deletarButton = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            ((System.ComponentModel.ISupportInitialize)(this.OrcamentoProdutoDGV)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // idLabel
            // 
            this.idLabel.AutoSize = true;
            this.idLabel.Location = new System.Drawing.Point(12, 26);
            this.idLabel.Name = "idLabel";
            this.idLabel.Size = new System.Drawing.Size(43, 13);
            this.idLabel.TabIndex = 1;
            this.idLabel.Text = "Código:";
            // 
            // idFuncionarioLabel
            // 
            this.idFuncionarioLabel.AutoSize = true;
            this.idFuncionarioLabel.Location = new System.Drawing.Point(12, 147);
            this.idFuncionarioLabel.Name = "idFuncionarioLabel";
            this.idFuncionarioLabel.Size = new System.Drawing.Size(65, 13);
            this.idFuncionarioLabel.TabIndex = 7;
            this.idFuncionarioLabel.Text = "Funcionário:";
            // 
            // dataLabel
            // 
            this.dataLabel.AutoSize = true;
            this.dataLabel.Location = new System.Drawing.Point(12, 67);
            this.dataLabel.Name = "dataLabel";
            this.dataLabel.Size = new System.Drawing.Size(33, 13);
            this.dataLabel.TabIndex = 3;
            this.dataLabel.Text = "Data:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 188);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Produtos:";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(396, 456);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "Valor total:";
            // 
            // OrcamentoProdutoDGV
            // 
            this.OrcamentoProdutoDGV.AllowUserToAddRows = false;
            this.OrcamentoProdutoDGV.AllowUserToDeleteRows = false;
            this.OrcamentoProdutoDGV.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.OrcamentoProdutoDGV.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.OrcamentoProdutoDGV.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.OrcamentoProdutoDGV.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.OrcamentoProdutoDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.OrcamentoProdutoDGV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.codigoProduto,
            this.idProduto,
            this.quantidade,
            this.preco,
            this.precoTotal});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.InactiveCaption;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.OrcamentoProdutoDGV.DefaultCellStyle = dataGridViewCellStyle6;
            this.OrcamentoProdutoDGV.Location = new System.Drawing.Point(12, 204);
            this.OrcamentoProdutoDGV.Name = "OrcamentoProdutoDGV";
            this.OrcamentoProdutoDGV.ReadOnly = true;
            this.OrcamentoProdutoDGV.RowHeadersVisible = false;
            this.OrcamentoProdutoDGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.OrcamentoProdutoDGV.Size = new System.Drawing.Size(500, 249);
            this.OrcamentoProdutoDGV.TabIndex = 14;
            // 
            // codigoProduto
            // 
            this.codigoProduto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.codigoProduto.HeaderText = "Cod.";
            this.codigoProduto.Name = "codigoProduto";
            this.codigoProduto.ReadOnly = true;
            this.codigoProduto.Width = 52;
            // 
            // idProduto
            // 
            this.idProduto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.idProduto.HeaderText = "Produto";
            this.idProduto.Name = "idProduto";
            this.idProduto.ReadOnly = true;
            this.idProduto.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.idProduto.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // quantidade
            // 
            this.quantidade.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.quantidade.HeaderText = "Quantidade";
            this.quantidade.Name = "quantidade";
            this.quantidade.ReadOnly = true;
            this.quantidade.Width = 85;
            // 
            // preco
            // 
            this.preco.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridViewCellStyle4.Format = "C2";
            dataGridViewCellStyle4.NullValue = null;
            this.preco.DefaultCellStyle = dataGridViewCellStyle4;
            this.preco.HeaderText = "Preço";
            this.preco.Name = "preco";
            this.preco.ReadOnly = true;
            this.preco.Width = 58;
            // 
            // precoTotal
            // 
            this.precoTotal.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridViewCellStyle5.Format = "C2";
            dataGridViewCellStyle5.NullValue = null;
            this.precoTotal.DefaultCellStyle = dataGridViewCellStyle5;
            this.precoTotal.HeaderText = "Total";
            this.precoTotal.Name = "precoTotal";
            this.precoTotal.ReadOnly = true;
            this.precoTotal.Width = 54;
            // 
            // codigoTB
            // 
            this.codigoTB.BackColor = System.Drawing.SystemColors.ControlLight;
            this.codigoTB.Location = new System.Drawing.Point(12, 42);
            this.codigoTB.Margin = new System.Windows.Forms.Padding(3, 3, 3, 5);
            this.codigoTB.Name = "codigoTB";
            this.codigoTB.ReadOnly = true;
            this.codigoTB.Size = new System.Drawing.Size(116, 20);
            this.codigoTB.TabIndex = 2;
            // 
            // dataTB
            // 
            this.dataTB.BackColor = System.Drawing.SystemColors.ControlLight;
            this.dataTB.Location = new System.Drawing.Point(12, 83);
            this.dataTB.Margin = new System.Windows.Forms.Padding(3, 3, 3, 5);
            this.dataTB.Name = "dataTB";
            this.dataTB.ReadOnly = true;
            this.dataTB.Size = new System.Drawing.Size(116, 20);
            this.dataTB.TabIndex = 4;
            // 
            // vendedorTB
            // 
            this.vendedorTB.BackColor = System.Drawing.SystemColors.ControlLight;
            this.vendedorTB.Location = new System.Drawing.Point(12, 163);
            this.vendedorTB.Margin = new System.Windows.Forms.Padding(3, 3, 19, 5);
            this.vendedorTB.Name = "vendedorTB";
            this.vendedorTB.ReadOnly = true;
            this.vendedorTB.Size = new System.Drawing.Size(272, 20);
            this.vendedorTB.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(12, 108);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Cliente:";
            // 
            // clienteTB
            // 
            this.clienteTB.BackColor = System.Drawing.SystemColors.ControlLight;
            this.clienteTB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clienteTB.Location = new System.Drawing.Point(12, 124);
            this.clienteTB.Name = "clienteTB";
            this.clienteTB.Size = new System.Drawing.Size(272, 20);
            this.clienteTB.TabIndex = 6;
            // 
            // okButton
            // 
            this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.okButton.Location = new System.Drawing.Point(454, 500);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(58, 23);
            this.okButton.TabIndex = 17;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // valorTotalTB
            // 
            this.valorTotalTB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.valorTotalTB.BackColor = System.Drawing.SystemColors.ControlLight;
            this.valorTotalTB.Location = new System.Drawing.Point(396, 472);
            this.valorTotalTB.Margin = new System.Windows.Forms.Padding(3, 3, 19, 5);
            this.valorTotalTB.Name = "valorTotalTB";
            this.valorTotalTB.ReadOnly = true;
            this.valorTotalTB.Size = new System.Drawing.Size(116, 20);
            this.valorTotalTB.TabIndex = 16;
            // 
            // imprimirButton
            // 
            this.imprimirButton.Image = ((System.Drawing.Image)(resources.GetObject("imprimirButton.Image")));
            this.imprimirButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.imprimirButton.Location = new System.Drawing.Point(6, 77);
            this.imprimirButton.Name = "imprimirButton";
            this.imprimirButton.Size = new System.Drawing.Size(72, 23);
            this.imprimirButton.TabIndex = 1;
            this.imprimirButton.Text = "Imprimir";
            this.imprimirButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.imprimirButton.UseVisualStyleBackColor = true;
            this.imprimirButton.Click += new System.EventHandler(this.imprimirButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.venderButton);
            this.groupBox1.Controls.Add(this.deletarButton);
            this.groupBox1.Controls.Add(this.imprimirButton);
            this.groupBox1.Location = new System.Drawing.Point(428, 27);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(84, 106);
            this.groupBox1.TabIndex = 19;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Ações";
            // 
            // venderButton
            // 
            this.venderButton.Image = ((System.Drawing.Image)(resources.GetObject("venderButton.Image")));
            this.venderButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.venderButton.Location = new System.Drawing.Point(6, 19);
            this.venderButton.Name = "venderButton";
            this.venderButton.Size = new System.Drawing.Size(72, 23);
            this.venderButton.TabIndex = 0;
            this.venderButton.Text = "Vender";
            this.venderButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.venderButton.UseVisualStyleBackColor = true;
            this.venderButton.Click += new System.EventHandler(this.venderButton_Click);
            // 
            // deletarButton
            // 
            this.deletarButton.Image = ((System.Drawing.Image)(resources.GetObject("deletarButton.Image")));
            this.deletarButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.deletarButton.Location = new System.Drawing.Point(6, 48);
            this.deletarButton.Name = "deletarButton";
            this.deletarButton.Size = new System.Drawing.Size(72, 23);
            this.deletarButton.TabIndex = 0;
            this.deletarButton.Text = "Devolver";
            this.deletarButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.deletarButton.UseVisualStyleBackColor = true;
            this.deletarButton.Click += new System.EventHandler(this.deletarButton_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 526);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(524, 22);
            this.statusStrip1.TabIndex = 18;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(524, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // CondicionalDetail
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(524, 548);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.clienteTB);
            this.Controls.Add(this.dataTB);
            this.Controls.Add(this.dataLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.idFuncionarioLabel);
            this.Controls.Add(this.idLabel);
            this.Controls.Add(this.valorTotalTB);
            this.Controls.Add(this.vendedorTB);
            this.Controls.Add(this.codigoTB);
            this.Controls.Add(this.OrcamentoProdutoDGV);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "CondicionalDetail";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Condicional - Detalhes";
            this.Load += new System.EventHandler(this.OrcamentoDetail_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CondicionalDetail_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.OrcamentoProdutoDGV)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView OrcamentoProdutoDGV;
        private System.Windows.Forms.TextBox codigoTB;
        private System.Windows.Forms.TextBox dataTB;
        private System.Windows.Forms.TextBox vendedorTB;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox clienteTB;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.TextBox valorTotalTB;
        private System.Windows.Forms.Button imprimirButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button deletarButton;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.Label idLabel;
        private System.Windows.Forms.Label idFuncionarioLabel;
        private System.Windows.Forms.Label dataLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button venderButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn codigoProduto;
        private System.Windows.Forms.DataGridViewTextBoxColumn idProduto;
        private System.Windows.Forms.DataGridViewTextBoxColumn quantidade;
        private System.Windows.Forms.DataGridViewTextBoxColumn preco;
        private System.Windows.Forms.DataGridViewTextBoxColumn precoTotal;
    }
}