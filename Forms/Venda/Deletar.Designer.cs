namespace Forms.Venda
{
    /// <summary>
    /// deletarVenda
    /// </summary>
    partial class Deletar
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Deletar));
            this.panel = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.produtoL = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.codigoTB = new System.Windows.Forms.TextBox();
            this.dataTB = new System.Windows.Forms.TextBox();
            this.pesquisarButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.nomeTB = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.vendasDGV = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idCliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idFuncionario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.data = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.valor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel3 = new System.Windows.Forms.Panel();
            this.deletarButton = new System.Windows.Forms.Button();
            this.panel.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vendasDGV)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel
            // 
            this.panel.Controls.Add(this.panel1);
            this.panel.Controls.Add(this.panel2);
            this.panel.Controls.Add(this.panel3);
            this.panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel.Location = new System.Drawing.Point(0, 0);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(591, 481);
            this.panel.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.Controls.Add(this.produtoL);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.codigoTB);
            this.panel1.Controls.Add(this.dataTB);
            this.panel1.Controls.Add(this.pesquisarButton);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.nomeTB);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(591, 168);
            this.panel1.TabIndex = 0;
            // 
            // produtoL
            // 
            this.produtoL.AutoSize = true;
            this.produtoL.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.produtoL.Location = new System.Drawing.Point(12, 15);
            this.produtoL.Margin = new System.Windows.Forms.Padding(3, 15, 3, 0);
            this.produtoL.Name = "produtoL";
            this.produtoL.Size = new System.Drawing.Size(65, 18);
            this.produtoL.TabIndex = 0;
            this.produtoL.Text = "Filtros:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Código:";
            // 
            // codigoTB
            // 
            this.codigoTB.Location = new System.Drawing.Point(17, 65);
            this.codigoTB.Margin = new System.Windows.Forms.Padding(3, 3, 19, 5);
            this.codigoTB.Name = "codigoTB";
            this.codigoTB.Size = new System.Drawing.Size(128, 20);
            this.codigoTB.TabIndex = 2;
            // 
            // dataTB
            // 
            this.dataTB.Location = new System.Drawing.Point(167, 65);
            this.dataTB.Margin = new System.Windows.Forms.Padding(3, 3, 19, 5);
            this.dataTB.Name = "dataTB";
            this.dataTB.Size = new System.Drawing.Size(128, 20);
            this.dataTB.TabIndex = 4;
            // 
            // pesquisarButton
            // 
            this.pesquisarButton.Location = new System.Drawing.Point(17, 134);
            this.pesquisarButton.Name = "pesquisarButton";
            this.pesquisarButton.Size = new System.Drawing.Size(75, 23);
            this.pesquisarButton.TabIndex = 7;
            this.pesquisarButton.Text = "Pesquisar";
            this.pesquisarButton.UseVisualStyleBackColor = true;
            this.pesquisarButton.Click += new System.EventHandler(this.pesquisarButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 90);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Cliente:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(167, 49);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Data:";
            // 
            // nomeTB
            // 
            this.nomeTB.Location = new System.Drawing.Point(17, 106);
            this.nomeTB.Margin = new System.Windows.Forms.Padding(3, 3, 19, 5);
            this.nomeTB.Name = "nomeTB";
            this.nomeTB.Size = new System.Drawing.Size(278, 20);
            this.nomeTB.TabIndex = 6;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.SystemColors.Control;
            this.panel2.Controls.Add(this.vendasDGV);
            this.panel2.Location = new System.Drawing.Point(0, 169);
            this.panel2.Margin = new System.Windows.Forms.Padding(0, 1, 0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(591, 239);
            this.panel2.TabIndex = 1;
            // 
            // vendasDGV
            // 
            this.vendasDGV.AllowUserToAddRows = false;
            this.vendasDGV.AllowUserToDeleteRows = false;
            this.vendasDGV.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.vendasDGV.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.vendasDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.vendasDGV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.idCliente,
            this.idFuncionario,
            this.data,
            this.valor});
            this.vendasDGV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.vendasDGV.Location = new System.Drawing.Point(0, 0);
            this.vendasDGV.Name = "vendasDGV";
            this.vendasDGV.ReadOnly = true;
            this.vendasDGV.RowHeadersVisible = false;
            this.vendasDGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.vendasDGV.Size = new System.Drawing.Size(591, 239);
            this.vendasDGV.TabIndex = 0;
            // 
            // id
            // 
            this.id.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.id.DataPropertyName = "id";
            this.id.HeaderText = "Cod.";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Width = 52;
            // 
            // idCliente
            // 
            this.idCliente.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.idCliente.DataPropertyName = "idCliente";
            this.idCliente.HeaderText = "Cliente";
            this.idCliente.Name = "idCliente";
            this.idCliente.ReadOnly = true;
            this.idCliente.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // idFuncionario
            // 
            this.idFuncionario.DataPropertyName = "idFuncionario";
            this.idFuncionario.HeaderText = "Funcionário";
            this.idFuncionario.Name = "idFuncionario";
            this.idFuncionario.ReadOnly = true;
            this.idFuncionario.Visible = false;
            // 
            // data
            // 
            this.data.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.data.DataPropertyName = "data";
            dataGridViewCellStyle3.Format = "d";
            dataGridViewCellStyle3.NullValue = null;
            this.data.DefaultCellStyle = dataGridViewCellStyle3;
            this.data.HeaderText = "Data";
            this.data.Name = "data";
            this.data.ReadOnly = true;
            this.data.Width = 53;
            // 
            // valor
            // 
            this.valor.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.valor.DataPropertyName = "valor";
            dataGridViewCellStyle4.Format = "C2";
            dataGridViewCellStyle4.NullValue = null;
            this.valor.DefaultCellStyle = dataGridViewCellStyle4;
            this.valor.HeaderText = "Valor";
            this.valor.Name = "valor";
            this.valor.ReadOnly = true;
            this.valor.Width = 54;
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.BackColor = System.Drawing.Color.Silver;
            this.panel3.Controls.Add(this.deletarButton);
            this.panel3.Location = new System.Drawing.Point(0, 409);
            this.panel3.Margin = new System.Windows.Forms.Padding(0, 1, 0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(591, 72);
            this.panel3.TabIndex = 2;
            // 
            // deletarButton
            // 
            this.deletarButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.deletarButton.Image = ((System.Drawing.Image)(resources.GetObject("deletarButton.Image")));
            this.deletarButton.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.deletarButton.Location = new System.Drawing.Point(524, 9);
            this.deletarButton.Name = "deletarButton";
            this.deletarButton.Size = new System.Drawing.Size(55, 55);
            this.deletarButton.TabIndex = 0;
            this.deletarButton.Text = "Excluir";
            this.deletarButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.deletarButton.UseVisualStyleBackColor = true;
            this.deletarButton.Click += new System.EventHandler(this.deletarButton_Click);
            // 
            // Deletar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(591, 481);
            this.Controls.Add(this.panel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(592, 295);
            this.Name = "Deletar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Excluir venda";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Deletar_FormClosed);
            this.Load += new System.EventHandler(this.Deletar_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Deletar_KeyDown);
            this.panel.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.vendasDGV)).EndInit();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.DataGridView vendasDGV;
        private System.Windows.Forms.Button deletarButton;
        private System.Windows.Forms.Button pesquisarButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox codigoTB;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox nomeTB;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox dataTB;
       // //private System.Windows.Forms.BindingSource clienteBindingSource;
        //
        //private System.Windows.Forms.BindingSource parcelaBindingSource;
        //private //Main.DataBases.datasetTableAdapters.ClienteTableAdapter clienteTableAdapter;
        //private //Main.DataBases.datasetTableAdapters.VendaTableAdapter //;
        //private //Main.DataBases.datasetTableAdapters.TableAdapterManager tableAdapterManager;
        //private //Main.DataBases.datasetTableAdapters.ParcelaTableAdapter parcelaTableAdapter;
        //private System.Windows.Forms.BindingSource vendaBindingSource;
       // //private System.Windows.Forms.BindingSource funcionarioBindingSource;
        //private //Main.DataBases.datasetTableAdapters.FuncionarioTableAdapter funcionarioTableAdapter;
        //private //Main.DataBases.datasetTableAdapters.SystemTableAdapter systemTableAdapter;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label produtoL;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn idCliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn idFuncionario;
        private System.Windows.Forms.DataGridViewTextBoxColumn data;
        private System.Windows.Forms.DataGridViewTextBoxColumn valor;
       // //private System.Windows.Forms.BindingSource caixaControleBindingSource;
        //private //Main.DataBases.datasetTableAdapters.CaixaControleTableAdapter caixaControleTableAdapter;

    }
}