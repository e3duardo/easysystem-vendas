using System.ComponentModel;
namespace Forms.Produto
{
    partial class Produtos
    {
        [Category("Advanced")]
        [Description("Mostra campos de preço à vista.")]
        [DisplayName("À Vista Visible")]
        public bool AVistaVisible { get; set; }



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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Produtos));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.produtoCodigoBarraRB = new Library.Windows.Forms.RadioButton();
            this.produtoCodigoSistemaRB = new Library.Windows.Forms.RadioButton();
            this.produtoNomeRB = new Library.Windows.Forms.RadioButton();
            this.produtoCodigoSistemaTB = new Library.Windows.Forms.TextBox();
            this.produtoCodigoBarraTB = new Library.Windows.Forms.TextBox();
            this.produtoNomeCB = new Library.Windows.Forms.ComboBox();
            this.produtoQuantidadeL = new Library.Windows.Forms.Label();
            this.produtoQuantidadeTB = new Library.Windows.Forms.TextBox();
            this.produtoAdicionarButton = new Library.Windows.Forms.Button();
            this.produtoDGV = new Library.Windows.Forms.DataGridView();
            this.produtoButton = new Library.Windows.Forms.Button();
            this.produtoL = new System.Windows.Forms.Label();
            this.label1 = new Library.Windows.Forms.Label();
            this.moneyTextBox1 = new Library.Windows.Forms.MoneyTextBox();
            this.codigoProduto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idProduto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quantidade = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.preco = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.precoTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.precoAVista = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.deleteColumn = new System.Windows.Forms.DataGridViewImageColumn();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.produtoDGV)).BeginInit();
            this.SuspendLayout();
            // 
            // errorProvider
            // 
            this.errorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProvider.ContainerControl = this;
            this.errorProvider.Icon = ((System.Drawing.Icon)(resources.GetObject("errorProvider.Icon")));
            // 
            // produtoCodigoBarraRB
            // 
            this.produtoCodigoBarraRB.AutoSize = true;
            this.produtoCodigoBarraRB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.produtoCodigoBarraRB.Location = new System.Drawing.Point(125, 50);
            this.produtoCodigoBarraRB.Name = "produtoCodigoBarraRB";
            this.produtoCodigoBarraRB.Size = new System.Drawing.Size(105, 17);
            this.produtoCodigoBarraRB.TabIndex = 3;
            this.produtoCodigoBarraRB.Text = "Código de barras";
            this.produtoCodigoBarraRB.UseVisualStyleBackColor = true;
            // 
            // produtoCodigoSistemaRB
            // 
            this.produtoCodigoSistemaRB.AutoSize = true;
            this.produtoCodigoSistemaRB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.produtoCodigoSistemaRB.Location = new System.Drawing.Point(1, 50);
            this.produtoCodigoSistemaRB.Name = "produtoCodigoSistemaRB";
            this.produtoCodigoSistemaRB.Size = new System.Drawing.Size(111, 17);
            this.produtoCodigoSistemaRB.TabIndex = 1;
            this.produtoCodigoSistemaRB.Text = "Código do sistema";
            this.produtoCodigoSistemaRB.UseVisualStyleBackColor = true;
            // 
            // produtoNomeRB
            // 
            this.produtoNomeRB.AutoSize = true;
            this.produtoNomeRB.Checked = true;
            this.produtoNomeRB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.produtoNomeRB.Location = new System.Drawing.Point(249, 50);
            this.produtoNomeRB.Name = "produtoNomeRB";
            this.produtoNomeRB.Size = new System.Drawing.Size(56, 17);
            this.produtoNomeRB.TabIndex = 5;
            this.produtoNomeRB.TabStop = true;
            this.produtoNomeRB.Text = "Nome:";
            this.produtoNomeRB.UseVisualStyleBackColor = true;
            // 
            // produtoCodigoSistemaTB
            // 
            this.produtoCodigoSistemaTB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.produtoCodigoSistemaTB.Location = new System.Drawing.Point(0, 71);
            this.produtoCodigoSistemaTB.Name = "produtoCodigoSistemaTB";
            this.produtoCodigoSistemaTB.Size = new System.Drawing.Size(118, 20);
            this.produtoCodigoSistemaTB.TabIndex = 2;
            this.produtoCodigoSistemaTB.Click += new System.EventHandler(this.produtoCodigoSistemaTB_Click);
            this.produtoCodigoSistemaTB.KeyUp += new System.Windows.Forms.KeyEventHandler(this.produtoCodigoSistemaTB_KeyUp);
            this.produtoCodigoSistemaTB.Leave += new System.EventHandler(this.produtoCodigoSistemaTB_Leave);
            // 
            // produtoCodigoBarraTB
            // 
            this.produtoCodigoBarraTB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.produtoCodigoBarraTB.Location = new System.Drawing.Point(124, 71);
            this.produtoCodigoBarraTB.Name = "produtoCodigoBarraTB";
            this.produtoCodigoBarraTB.Size = new System.Drawing.Size(118, 20);
            this.produtoCodigoBarraTB.TabIndex = 4;
            this.produtoCodigoBarraTB.Click += new System.EventHandler(this.produtoCodigoBarraTB_Click);
            this.produtoCodigoBarraTB.KeyUp += new System.Windows.Forms.KeyEventHandler(this.produtoCodigoBarraTB_KeyUp);
            this.produtoCodigoBarraTB.Leave += new System.EventHandler(this.produtoCodigoBarraTB_Leave);
            // 
            // produtoNomeCB
            // 
            this.produtoNomeCB.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.produtoNomeCB.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.produtoNomeCB.DisplayMember = "id";
            this.produtoNomeCB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.produtoNomeCB.FormattingEnabled = true;
            this.produtoNomeCB.Location = new System.Drawing.Point(248, 71);
            this.produtoNomeCB.Name = "produtoNomeCB";
            this.produtoNomeCB.Size = new System.Drawing.Size(207, 21);
            this.produtoNomeCB.TabIndex = 6;
            this.produtoNomeCB.ValueMember = "id";
            this.produtoNomeCB.SelectedIndexChanged += new System.EventHandler(this.produtoNomeCB_SelectedIndexChanged);
            this.produtoNomeCB.Click += new System.EventHandler(this.produtoNomeCB_Click);
            // 
            // produtoQuantidadeL
            // 
            this.produtoQuantidadeL.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.produtoQuantidadeL.AutoSize = true;
            this.produtoQuantidadeL.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.produtoQuantidadeL.Location = new System.Drawing.Point(532, 52);
            this.produtoQuantidadeL.Name = "produtoQuantidadeL";
            this.produtoQuantidadeL.Size = new System.Drawing.Size(62, 13);
            this.produtoQuantidadeL.TabIndex = 8;
            this.produtoQuantidadeL.Text = "Quantidade";
            // 
            // produtoQuantidadeTB
            // 
            this.produtoQuantidadeTB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.produtoQuantidadeTB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.produtoQuantidadeTB.Location = new System.Drawing.Point(532, 71);
            this.produtoQuantidadeTB.Name = "produtoQuantidadeTB";
            this.produtoQuantidadeTB.Size = new System.Drawing.Size(64, 20);
            this.produtoQuantidadeTB.TabIndex = 9;
            // 
            // produtoAdicionarButton
            // 
            this.produtoAdicionarButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.produtoAdicionarButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.produtoAdicionarButton.Location = new System.Drawing.Point(688, 68);
            this.produtoAdicionarButton.Name = "produtoAdicionarButton";
            this.produtoAdicionarButton.Size = new System.Drawing.Size(71, 23);
            this.produtoAdicionarButton.TabIndex = 12;
            this.produtoAdicionarButton.Text = "Adicionar";
            this.produtoAdicionarButton.UseVisualStyleBackColor = true;
            this.produtoAdicionarButton.Click += new System.EventHandler(this.adicionarProdutoButton_Click);
            // 
            // produtoDGV
            // 
            this.produtoDGV.AllowUserToAddRows = false;
            this.produtoDGV.AllowUserToDeleteRows = false;
            this.produtoDGV.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.produtoDGV.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.produtoDGV.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.produtoDGV.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.produtoDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.produtoDGV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.codigoProduto,
            this.idProduto,
            this.quantidade,
            this.preco,
            this.precoTotal,
            this.precoAVista,
            this.Column1,
            this.deleteColumn});
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.InactiveCaption;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.produtoDGV.DefaultCellStyle = dataGridViewCellStyle5;
            this.produtoDGV.Location = new System.Drawing.Point(0, 100);
            this.produtoDGV.Name = "produtoDGV";
            this.produtoDGV.ReadOnly = true;
            this.produtoDGV.RowHeadersVisible = false;
            this.produtoDGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.produtoDGV.Size = new System.Drawing.Size(759, 378);
            this.produtoDGV.TabIndex = 13;
            this.produtoDGV.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.produtoDGV_CellClick);
            // 
            // produtoButton
            // 
            this.produtoButton.Image = ((System.Drawing.Image)(resources.GetObject("produtoButton.Image")));
            this.produtoButton.Location = new System.Drawing.Point(461, 70);
            this.produtoButton.Margin = new System.Windows.Forms.Padding(3, 3, 3, 5);
            this.produtoButton.Name = "produtoButton";
            this.produtoButton.Size = new System.Drawing.Size(23, 23);
            this.produtoButton.TabIndex = 7;
            this.produtoButton.UseVisualStyleBackColor = true;
            this.produtoButton.Click += new System.EventHandler(this.produtoButton_Click);
            // 
            // produtoL
            // 
            this.produtoL.AutoSize = true;
            this.produtoL.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.produtoL.Location = new System.Drawing.Point(-3, 15);
            this.produtoL.Margin = new System.Windows.Forms.Padding(3, 15, 3, 0);
            this.produtoL.Name = "produtoL";
            this.produtoL.Size = new System.Drawing.Size(88, 18);
            this.produtoL.TabIndex = 0;
            this.produtoL.Text = "Produtos:";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(602, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Preço";
            // 
            // moneyTextBox1
            // 
            this.moneyTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.moneyTextBox1.Location = new System.Drawing.Point(602, 71);
            this.moneyTextBox1.Margin = new System.Windows.Forms.Padding(3, 3, 19, 5);
            this.moneyTextBox1.Name = "moneyTextBox1";
            this.moneyTextBox1.Size = new System.Drawing.Size(64, 20);
            this.moneyTextBox1.TabIndex = 11;
            this.moneyTextBox1.Text = "R$ 0,00";
            this.moneyTextBox1.Value = new decimal(new int[] {
            0,
            0,
            0,
            131072});
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
            this.preco.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle1.Format = "C2";
            dataGridViewCellStyle1.NullValue = null;
            this.preco.DefaultCellStyle = dataGridViewCellStyle1;
            this.preco.HeaderText = "Preço";
            this.preco.Name = "preco";
            this.preco.ReadOnly = true;
            this.preco.Width = 58;
            // 
            // precoTotal
            // 
            this.precoTotal.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle2.Format = "C2";
            dataGridViewCellStyle2.NullValue = null;
            this.precoTotal.DefaultCellStyle = dataGridViewCellStyle2;
            this.precoTotal.HeaderText = "Total";
            this.precoTotal.Name = "precoTotal";
            this.precoTotal.ReadOnly = true;
            this.precoTotal.Width = 54;
            // 
            // precoAVista
            // 
            this.precoAVista.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle3.Format = "C2";
            dataGridViewCellStyle3.NullValue = null;
            this.precoAVista.DefaultCellStyle = dataGridViewCellStyle3;
            this.precoAVista.HeaderText = "Preço à vista";
            this.precoAVista.Name = "precoAVista";
            this.precoAVista.ReadOnly = true;
            this.precoAVista.Width = 92;
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle4.Format = "C2";
            dataGridViewCellStyle4.NullValue = null;
            this.Column1.DefaultCellStyle = dataGridViewCellStyle4;
            this.Column1.HeaderText = "Total";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 54;
            // 
            // deleteColumn
            // 
            this.deleteColumn.FillWeight = 22F;
            this.deleteColumn.HeaderText = "";
            this.deleteColumn.Image = ((System.Drawing.Image)(resources.GetObject("deleteColumn.Image")));
            this.deleteColumn.MinimumWidth = 22;
            this.deleteColumn.Name = "deleteColumn";
            this.deleteColumn.ReadOnly = true;
            this.deleteColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.deleteColumn.ToolTipText = "Deletar produto";
            this.deleteColumn.Width = 22;
            // 
            // Produtos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.moneyTextBox1);
            this.Controls.Add(this.produtoL);
            this.Controls.Add(this.produtoButton);
            this.Controls.Add(this.produtoCodigoBarraRB);
            this.Controls.Add(this.produtoCodigoSistemaRB);
            this.Controls.Add(this.produtoNomeRB);
            this.Controls.Add(this.produtoCodigoSistemaTB);
            this.Controls.Add(this.produtoCodigoBarraTB);
            this.Controls.Add(this.produtoNomeCB);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.produtoQuantidadeL);
            this.Controls.Add(this.produtoQuantidadeTB);
            this.Controls.Add(this.produtoAdicionarButton);
            this.Controls.Add(this.produtoDGV);
            this.Name = "Produtos";
            this.Size = new System.Drawing.Size(759, 481);
            this.Load += new System.EventHandler(this.produtos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.produtoDGV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Library.Windows.Forms.Button produtoButton;
        private Library.Windows.Forms.RadioButton produtoCodigoBarraRB;
        private Library.Windows.Forms.RadioButton produtoCodigoSistemaRB;
        private Library.Windows.Forms.RadioButton produtoNomeRB;
        private Library.Windows.Forms.TextBox produtoCodigoSistemaTB;
        private Library.Windows.Forms.TextBox produtoCodigoBarraTB;
        private Library.Windows.Forms.ComboBox produtoNomeCB;
        private Library.Windows.Forms.Label produtoQuantidadeL;
        private Library.Windows.Forms.TextBox produtoQuantidadeTB;
        private Library.Windows.Forms.Button produtoAdicionarButton;
        private Library.Windows.Forms.DataGridView produtoDGV;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.Label produtoL;
        private Library.Windows.Forms.Label label1;
        private Library.Windows.Forms.MoneyTextBox moneyTextBox1;
        private System.Windows.Forms.DataGridViewTextBoxColumn codigoProduto;
        private System.Windows.Forms.DataGridViewTextBoxColumn idProduto;
        private System.Windows.Forms.DataGridViewTextBoxColumn quantidade;
        private System.Windows.Forms.DataGridViewTextBoxColumn preco;
        private System.Windows.Forms.DataGridViewTextBoxColumn precoTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn precoAVista;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewImageColumn deleteColumn;
    }
}
