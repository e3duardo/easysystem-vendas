namespace Forms.Venda
{
    partial class VendaList
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VendaList));
            this.resultadoDGV = new System.Windows.Forms.DataGridView();
            this.label5 = new System.Windows.Forms.Label();
            this.codigoTB = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.clienteNomeTB = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dataTerminoDTP = new Library.Windows.Forms.DateTextBox();
            this.dataInicioDTP = new Library.Windows.Forms.DateTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.noFormaPagamentoRB = new System.Windows.Forms.RadioButton();
            this.chequeRB = new System.Windows.Forms.RadioButton();
            this.avistaRB = new System.Windows.Forms.RadioButton();
            this.aprazoRB = new System.Windows.Forms.RadioButton();
            this.cartaoRB = new System.Windows.Forms.RadioButton();
            this.c = new System.Windows.Forms.Button();
            this.lineSeparator1 = new Library.Controls.LineHorizontalSeparator();
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewImageColumn2 = new System.Windows.Forms.DataGridViewImageColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.deleteColumn = new System.Windows.Forms.DataGridViewImageColumn();
            this.printColumn = new System.Windows.Forms.DataGridViewImageColumn();
            ((System.ComponentModel.ISupportInitialize)(this.resultadoDGV)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // resultadoDGV
            // 
            this.resultadoDGV.AllowUserToAddRows = false;
            this.resultadoDGV.AllowUserToDeleteRows = false;
            this.resultadoDGV.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.resultadoDGV.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.resultadoDGV.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.resultadoDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.resultadoDGV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column6,
            this.Column3,
            this.deleteColumn,
            this.printColumn});
            this.resultadoDGV.Location = new System.Drawing.Point(12, 169);
            this.resultadoDGV.MultiSelect = false;
            this.resultadoDGV.Name = "resultadoDGV";
            this.resultadoDGV.ReadOnly = true;
            this.resultadoDGV.RowHeadersVisible = false;
            this.resultadoDGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.resultadoDGV.Size = new System.Drawing.Size(702, 423);
            this.resultadoDGV.TabIndex = 8;
            this.resultadoDGV.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.resultadoDGV_CellClick);
            this.resultadoDGV.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.resultadoDGV_CellDoubleClick);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 20);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Código:";
            // 
            // codigoTB
            // 
            this.codigoTB.Location = new System.Drawing.Point(6, 37);
            this.codigoTB.Name = "codigoTB";
            this.codigoTB.Size = new System.Drawing.Size(100, 20);
            this.codigoTB.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 60);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(87, 13);
            this.label6.TabIndex = 2;
            this.label6.Text = "Nome do cliente:";
            // 
            // clienteNomeTB
            // 
            this.clienteNomeTB.Location = new System.Drawing.Point(6, 77);
            this.clienteNomeTB.Name = "clienteNomeTB";
            this.clienteNomeTB.Size = new System.Drawing.Size(137, 20);
            this.clienteNomeTB.TabIndex = 3;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dataTerminoDTP);
            this.groupBox2.Controls.Add(this.dataInicioDTP);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Location = new System.Drawing.Point(167, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(266, 42);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Data";
            // 
            // dataTerminoDTP
            // 
            this.dataTerminoDTP.Location = new System.Drawing.Point(158, 16);
            this.dataTerminoDTP.MaxLength = 10;
            this.dataTerminoDTP.Name = "dataTerminoDTP";
            this.dataTerminoDTP.Size = new System.Drawing.Size(100, 20);
            this.dataTerminoDTP.TabIndex = 3;
            this.dataTerminoDTP.Value = new System.DateTime(((long)(0)));
            // 
            // dataInicioDTP
            // 
            this.dataInicioDTP.Location = new System.Drawing.Point(33, 16);
            this.dataInicioDTP.MaxLength = 10;
            this.dataInicioDTP.Name = "dataInicioDTP";
            this.dataInicioDTP.Size = new System.Drawing.Size(100, 20);
            this.dataInicioDTP.TabIndex = 1;
            this.dataInicioDTP.Value = new System.DateTime(((long)(0)));
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(139, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(13, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "a";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(21, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "De";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.noFormaPagamentoRB);
            this.groupBox3.Controls.Add(this.chequeRB);
            this.groupBox3.Controls.Add(this.avistaRB);
            this.groupBox3.Controls.Add(this.aprazoRB);
            this.groupBox3.Controls.Add(this.cartaoRB);
            this.groupBox3.Location = new System.Drawing.Point(560, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(154, 108);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Forma de pagamento";
            // 
            // noFormaPagamentoRB
            // 
            this.noFormaPagamentoRB.AutoSize = true;
            this.noFormaPagamentoRB.Checked = true;
            this.noFormaPagamentoRB.Location = new System.Drawing.Point(80, 15);
            this.noFormaPagamentoRB.Name = "noFormaPagamentoRB";
            this.noFormaPagamentoRB.Size = new System.Drawing.Size(68, 17);
            this.noFormaPagamentoRB.TabIndex = 4;
            this.noFormaPagamentoRB.TabStop = true;
            this.noFormaPagamentoRB.Text = "Sem filtro";
            this.noFormaPagamentoRB.UseVisualStyleBackColor = true;
            // 
            // chequeRB
            // 
            this.chequeRB.AutoSize = true;
            this.chequeRB.Location = new System.Drawing.Point(6, 83);
            this.chequeRB.Name = "chequeRB";
            this.chequeRB.Size = new System.Drawing.Size(62, 17);
            this.chequeRB.TabIndex = 3;
            this.chequeRB.Text = "Cheque";
            this.chequeRB.UseVisualStyleBackColor = true;
            // 
            // avistaRB
            // 
            this.avistaRB.AutoSize = true;
            this.avistaRB.Location = new System.Drawing.Point(6, 14);
            this.avistaRB.Name = "avistaRB";
            this.avistaRB.Size = new System.Drawing.Size(57, 17);
            this.avistaRB.TabIndex = 0;
            this.avistaRB.Text = "À vista";
            this.avistaRB.UseVisualStyleBackColor = true;
            // 
            // aprazoRB
            // 
            this.aprazoRB.AutoSize = true;
            this.aprazoRB.Location = new System.Drawing.Point(6, 60);
            this.aprazoRB.Name = "aprazoRB";
            this.aprazoRB.Size = new System.Drawing.Size(61, 17);
            this.aprazoRB.TabIndex = 2;
            this.aprazoRB.Text = "À prazo";
            this.aprazoRB.UseVisualStyleBackColor = true;
            // 
            // cartaoRB
            // 
            this.cartaoRB.AutoSize = true;
            this.cartaoRB.Location = new System.Drawing.Point(6, 37);
            this.cartaoRB.Name = "cartaoRB";
            this.cartaoRB.Size = new System.Drawing.Size(56, 17);
            this.cartaoRB.TabIndex = 1;
            this.cartaoRB.Text = "Cartão";
            this.cartaoRB.UseVisualStyleBackColor = true;
            // 
            // c
            // 
            this.c.Location = new System.Drawing.Point(650, 132);
            this.c.Name = "c";
            this.c.Size = new System.Drawing.Size(64, 23);
            this.c.TabIndex = 6;
            this.c.Text = "Pesquisar";
            this.c.UseVisualStyleBackColor = true;
            this.c.Click += new System.EventHandler(this.pesquisarButton_Click);
            // 
            // lineSeparator1
            // 
            this.lineSeparator1.Location = new System.Drawing.Point(12, 161);
            this.lineSeparator1.MaximumSize = new System.Drawing.Size(2000, 2);
            this.lineSeparator1.MinimumSize = new System.Drawing.Size(0, 2);
            this.lineSeparator1.Name = "lineSeparator1";
            this.lineSeparator1.Size = new System.Drawing.Size(703, 2);
            this.lineSeparator1.TabIndex = 7;
            // 
            // dataGridViewImageColumn1
            // 
            this.dataGridViewImageColumn1.FillWeight = 22F;
            this.dataGridViewImageColumn1.HeaderText = "";
            this.dataGridViewImageColumn1.Image = global::Forms.Properties.Resources.delete;
            this.dataGridViewImageColumn1.MinimumWidth = 22;
            this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
            this.dataGridViewImageColumn1.ReadOnly = true;
            this.dataGridViewImageColumn1.Width = 22;
            // 
            // dataGridViewImageColumn2
            // 
            this.dataGridViewImageColumn2.FillWeight = 22F;
            this.dataGridViewImageColumn2.HeaderText = "";
            this.dataGridViewImageColumn2.Image = global::Forms.Properties.Resources.printer;
            this.dataGridViewImageColumn2.MinimumWidth = 22;
            this.dataGridViewImageColumn2.Name = "dataGridViewImageColumn2";
            this.dataGridViewImageColumn2.ReadOnly = true;
            this.dataGridViewImageColumn2.Width = 22;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.codigoTB);
            this.groupBox1.Controls.Add(this.clienteNomeTB);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(149, 103);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Básico";
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column1.HeaderText = "Cod.";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 52;
            // 
            // Column2
            // 
            this.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column2.HeaderText = "Cliente";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column6
            // 
            this.Column6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column6.HeaderText = "Forma de pgt.";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            this.Column6.Width = 95;
            // 
            // Column3
            // 
            this.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle2.Format = "d";
            dataGridViewCellStyle2.NullValue = null;
            this.Column3.DefaultCellStyle = dataGridViewCellStyle2;
            this.Column3.HeaderText = "Data";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 53;
            // 
            // deleteColumn
            // 
            this.deleteColumn.FillWeight = 22F;
            this.deleteColumn.HeaderText = "";
            this.deleteColumn.Image = global::Forms.Properties.Resources.delete;
            this.deleteColumn.MinimumWidth = 22;
            this.deleteColumn.Name = "deleteColumn";
            this.deleteColumn.ReadOnly = true;
            this.deleteColumn.Width = 22;
            // 
            // printColumn
            // 
            this.printColumn.FillWeight = 22F;
            this.printColumn.HeaderText = "";
            this.printColumn.Image = global::Forms.Properties.Resources.printer;
            this.printColumn.MinimumWidth = 22;
            this.printColumn.Name = "printColumn";
            this.printColumn.ReadOnly = true;
            this.printColumn.Width = 22;
            // 
            // VendaList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(726, 604);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lineSeparator1);
            this.Controls.Add(this.c);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.resultadoDGV);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "VendaList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Vendas (Pesquisar)";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.VendaList_FormClosed);
            this.Load += new System.EventHandler(this.VendaList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.resultadoDGV)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView resultadoDGV;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox codigoTB;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox clienteNomeTB;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button c;
        private System.Windows.Forms.RadioButton chequeRB;
        private System.Windows.Forms.RadioButton avistaRB;
        private System.Windows.Forms.RadioButton aprazoRB;
        private System.Windows.Forms.RadioButton cartaoRB;
        private System.Windows.Forms.RadioButton noFormaPagamentoRB;
        private Library.Windows.Forms.DateTextBox dataTerminoDTP;
        private Library.Windows.Forms.DateTextBox dataInicioDTP;
        private Library.Controls.LineHorizontalSeparator lineSeparator1;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewImageColumn deleteColumn;
        private System.Windows.Forms.DataGridViewImageColumn printColumn;
    }
}