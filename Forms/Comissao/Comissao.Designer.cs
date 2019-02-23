namespace Forms.Comissao
{
    partial class Comissao
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Comissao));
            this.comissoesDGV = new System.Windows.Forms.DataGridView();
            this.Column2 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.descontarButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.comissoesDGV)).BeginInit();
            this.SuspendLayout();
            // 
            // comissoesDGV
            // 
            this.comissoesDGV.AllowUserToAddRows = false;
            this.comissoesDGV.AllowUserToDeleteRows = false;
            this.comissoesDGV.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.comissoesDGV.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.comissoesDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.comissoesDGV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column2,
            this.Column1,
            this.Column3,
            this.Column4,
            this.Column7,
            this.Column5,
            this.Column6});
            this.comissoesDGV.Location = new System.Drawing.Point(12, 12);
            this.comissoesDGV.Name = "comissoesDGV";
            this.comissoesDGV.RowHeadersVisible = false;
            this.comissoesDGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.comissoesDGV.Size = new System.Drawing.Size(549, 394);
            this.comissoesDGV.TabIndex = 0;
            this.comissoesDGV.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.comissoesDGV_CellDoubleClick);
            // 
            // Column2
            // 
            this.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column2.HeaderText = "";
            this.Column2.Name = "Column2";
            this.Column2.Width = 5;
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Column1.HeaderText = "Cod.";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 52;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Funcionário";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Tipo";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // Column7
            // 
            this.Column7.HeaderText = "Porcentagem";
            this.Column7.Name = "Column7";
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Valor";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // Column6
            // 
            this.Column6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column6.FalseValue = "0";
            this.Column6.HeaderText = "Pago";
            this.Column6.IndeterminateValue = "0";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            this.Column6.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column6.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Column6.TrueValue = "1";
            this.Column6.Width = 55;
            // 
            // descontarButton
            // 
            this.descontarButton.Location = new System.Drawing.Point(432, 412);
            this.descontarButton.Name = "descontarButton";
            this.descontarButton.Size = new System.Drawing.Size(129, 23);
            this.descontarButton.TabIndex = 1;
            this.descontarButton.Text = "Descontar selecionados";
            this.descontarButton.UseVisualStyleBackColor = true;
            this.descontarButton.Click += new System.EventHandler(this.descontarButton_Click);
            // 
            // Comissao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(573, 447);
            this.Controls.Add(this.descontarButton);
            this.Controls.Add(this.comissoesDGV);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "Comissao";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Comissão";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Comissao_FormClosed);
            this.Load += new System.EventHandler(this.Comissao_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Comissao_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.comissoesDGV)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView comissoesDGV;
        private System.Windows.Forms.Button descontarButton;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column6;
    }
}