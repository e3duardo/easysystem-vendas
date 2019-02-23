namespace Forms.Cartao
{
    partial class Cartao
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Cartao));
            this.panel = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dataCB = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panelCaixa = new System.Windows.Forms.Panel();
            this.transacoesDGV = new System.Windows.Forms.DataGridView();
            this.tcodigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tcliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ttipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnTipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.thora = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.valor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label7 = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.panel.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panelCaixa.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.transacoesDGV)).BeginInit();
            this.SuspendLayout();
            // 
            // panel
            // 
            this.panel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel.Controls.Add(this.panel1);
            this.panel.Controls.Add(this.panelCaixa);
            this.panel.Location = new System.Drawing.Point(0, 0);
            this.panel.Margin = new System.Windows.Forms.Padding(0);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(861, 610);
            this.panel.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.Silver;
            this.panel1.Controls.Add(this.dataCB);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(861, 58);
            this.panel1.TabIndex = 0;
            // 
            // dataCB
            // 
            this.dataCB.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataCB.FormattingEnabled = true;
            this.dataCB.Location = new System.Drawing.Point(15, 25);
            this.dataCB.Name = "dataCB";
            this.dataCB.Size = new System.Drawing.Size(174, 24);
            this.dataCB.TabIndex = 1;
            this.dataCB.SelectedIndexChanged += new System.EventHandler(this.dataCB_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(174, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Selecione uma data de vencimento";
            // 
            // panelCaixa
            // 
            this.panelCaixa.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panelCaixa.BackColor = System.Drawing.SystemColors.Control;
            this.panelCaixa.Controls.Add(this.transacoesDGV);
            this.panelCaixa.Controls.Add(this.label7);
            this.panelCaixa.Location = new System.Drawing.Point(0, 59);
            this.panelCaixa.Margin = new System.Windows.Forms.Padding(0, 1, 0, 0);
            this.panelCaixa.Name = "panelCaixa";
            this.panelCaixa.Size = new System.Drawing.Size(861, 551);
            this.panelCaixa.TabIndex = 1;
            // 
            // transacoesDGV
            // 
            this.transacoesDGV.AllowUserToAddRows = false;
            this.transacoesDGV.AllowUserToDeleteRows = false;
            this.transacoesDGV.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.transacoesDGV.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.transacoesDGV.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.transacoesDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.transacoesDGV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.tcodigo,
            this.tcliente,
            this.ttipo,
            this.ColumnTipo,
            this.thora,
            this.Column1,
            this.valor});
            this.transacoesDGV.Location = new System.Drawing.Point(3, 39);
            this.transacoesDGV.MultiSelect = false;
            this.transacoesDGV.Name = "transacoesDGV";
            this.transacoesDGV.ReadOnly = true;
            this.transacoesDGV.RowHeadersVisible = false;
            this.transacoesDGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.transacoesDGV.Size = new System.Drawing.Size(855, 509);
            this.transacoesDGV.TabIndex = 1;
            this.transacoesDGV.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.transacoesDGV_CellDoubleClick);
            // 
            // tcodigo
            // 
            this.tcodigo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.tcodigo.HeaderText = "Código";
            this.tcodigo.Name = "tcodigo";
            this.tcodigo.ReadOnly = true;
            this.tcodigo.Visible = false;
            // 
            // tcliente
            // 
            this.tcliente.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.tcliente.HeaderText = "Cliente";
            this.tcliente.Name = "tcliente";
            this.tcliente.ReadOnly = true;
            // 
            // ttipo
            // 
            this.ttipo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.ttipo.HeaderText = "Tipo";
            this.ttipo.Name = "ttipo";
            this.ttipo.ReadOnly = true;
            this.ttipo.Visible = false;
            // 
            // ColumnTipo
            // 
            this.ColumnTipo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ColumnTipo.HeaderText = "Tipo";
            this.ColumnTipo.Name = "ColumnTipo";
            this.ColumnTipo.ReadOnly = true;
            this.ColumnTipo.Width = 51;
            // 
            // thora
            // 
            this.thora.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridViewCellStyle1.NullValue = null;
            this.thora.DefaultCellStyle = dataGridViewCellStyle1;
            this.thora.HeaderText = "Nº Parcelas";
            this.thora.Name = "thora";
            this.thora.ReadOnly = true;
            this.thora.Width = 86;
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle2.Format = "C2";
            dataGridViewCellStyle2.NullValue = null;
            this.Column1.DefaultCellStyle = dataGridViewCellStyle2;
            this.Column1.HeaderText = "Valor parcelas";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 97;
            // 
            // valor
            // 
            this.valor.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridViewCellStyle3.Format = "C2";
            dataGridViewCellStyle3.NullValue = null;
            this.valor.DefaultCellStyle = dataGridViewCellStyle3;
            this.valor.HeaderText = "Valor total";
            this.valor.Name = "valor";
            this.valor.ReadOnly = true;
            this.valor.Width = 77;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(3, 14);
            this.label7.Margin = new System.Windows.Forms.Padding(3, 15, 3, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(168, 18);
            this.label7.TabIndex = 0;
            this.label7.Text = "Controle de cartões";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 610);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(861, 22);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // Cartao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(861, 632);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.panel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MinimumSize = new System.Drawing.Size(510, 452);
            this.Name = "Cartao";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cartão";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Cartao_FormClosed);
            this.Load += new System.EventHandler(this.Cartao_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Cartao_KeyDown);
            this.panel.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panelCaixa.ResumeLayout(false);
            this.panelCaixa.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.transacoesDGV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.DataGridView transacoesDGV;
        private System.Windows.Forms.Panel panelCaixa;
        private System.Windows.Forms.ComboBox dataCB;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.DataGridViewTextBoxColumn tcodigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn tcliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn ttipo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnTipo;
        private System.Windows.Forms.DataGridViewTextBoxColumn thora;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn valor;

    }
}