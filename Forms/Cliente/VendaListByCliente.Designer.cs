namespace Forms.Cliente
{
    partial class VendaListByCliente
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VendaListByCliente));
            this.dataGridViewResultado = new System.Windows.Forms.DataGridView();
            this.ColumnNome = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnData = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSaldoDevedor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewResultado)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewResultado
            // 
            this.dataGridViewResultado.AllowUserToAddRows = false;
            this.dataGridViewResultado.AllowUserToDeleteRows = false;
            this.dataGridViewResultado.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewResultado.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridViewResultado.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dataGridViewResultado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewResultado.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnNome,
            this.ColumnData,
            this.ColumnSaldoDevedor});
            this.dataGridViewResultado.Location = new System.Drawing.Point(12, 12);
            this.dataGridViewResultado.MultiSelect = false;
            this.dataGridViewResultado.Name = "dataGridViewResultado";
            this.dataGridViewResultado.ReadOnly = true;
            this.dataGridViewResultado.RowHeadersVisible = false;
            this.dataGridViewResultado.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewResultado.Size = new System.Drawing.Size(650, 462);
            this.dataGridViewResultado.TabIndex = 1;
            // 
            // ColumnNome
            // 
            this.ColumnNome.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnNome.HeaderText = "Nome";
            this.ColumnNome.Name = "ColumnNome";
            this.ColumnNome.ReadOnly = true;
            // 
            // ColumnData
            // 
            dataGridViewCellStyle1.Format = "d";
            dataGridViewCellStyle1.NullValue = null;
            this.ColumnData.DefaultCellStyle = dataGridViewCellStyle1;
            this.ColumnData.HeaderText = "Vencimento";
            this.ColumnData.Name = "ColumnData";
            this.ColumnData.ReadOnly = true;
            // 
            // ColumnSaldoDevedor
            // 
            this.ColumnSaldoDevedor.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle2.Format = "C2";
            dataGridViewCellStyle2.NullValue = null;
            this.ColumnSaldoDevedor.DefaultCellStyle = dataGridViewCellStyle2;
            this.ColumnSaldoDevedor.HeaderText = "Saldo Devedor";
            this.ColumnSaldoDevedor.Name = "ColumnSaldoDevedor";
            this.ColumnSaldoDevedor.ReadOnly = true;
            this.ColumnSaldoDevedor.Width = 110;
            // 
            // VendaListByCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(674, 486);
            this.Controls.Add(this.dataGridViewResultado);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "VendaListByCliente";
            this.Text = "Controle de vendas atrasadas";
            this.Load += new System.EventHandler(this.VendaListByCliente_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.VendaListByCliente_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewResultado)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewResultado;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnNome;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnData;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnSaldoDevedor;
    }
}