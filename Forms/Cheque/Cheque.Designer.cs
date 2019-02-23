namespace Forms.Cheque
{
    partial class Cheque
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Cheque));
            this.panel = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label10 = new System.Windows.Forms.Label();
            this.buttonReceber = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dataCB = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panelCaixa = new System.Windows.Forms.Panel();
            this.transacoesDGV = new System.Windows.Forms.DataGridView();
            this.tcodigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tcliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ttipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.valor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.thora = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label7 = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.panel.SuspendLayout();
            this.panel3.SuspendLayout();
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
            this.panel.Controls.Add(this.panel5);
            this.panel.Controls.Add(this.panel3);
            this.panel.Controls.Add(this.panel1);
            this.panel.Controls.Add(this.panelCaixa);
            this.panel.Location = new System.Drawing.Point(0, 0);
            this.panel.Margin = new System.Windows.Forms.Padding(0);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(861, 610);
            this.panel.TabIndex = 0;
            // 
            // panel5
            // 
            this.panel5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel5.BackColor = System.Drawing.SystemColors.Control;
            this.panel5.Location = new System.Drawing.Point(711, 155);
            this.panel5.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(150, 455);
            this.panel5.TabIndex = 6;
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.BackColor = System.Drawing.SystemColors.Control;
            this.panel3.Controls.Add(this.label10);
            this.panel3.Controls.Add(this.buttonReceber);
            this.panel3.Controls.Add(this.label11);
            this.panel3.Location = new System.Drawing.Point(711, 59);
            this.panel3.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(150, 95);
            this.panel3.TabIndex = 5;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(3, 9);
            this.label10.Margin = new System.Windows.Forms.Padding(3, 15, 3, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(81, 18);
            this.label10.TabIndex = 0;
            this.label10.Text = "Receber:";
            // 
            // buttonReceber
            // 
            this.buttonReceber.Location = new System.Drawing.Point(63, 64);
            this.buttonReceber.Name = "buttonReceber";
            this.buttonReceber.Size = new System.Drawing.Size(75, 23);
            this.buttonReceber.TabIndex = 3;
            this.buttonReceber.Text = "Receber";
            this.buttonReceber.UseVisualStyleBackColor = true;
            this.buttonReceber.Click += new System.EventHandler(this.buttonReceber_Click);
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(3, 31);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(142, 30);
            this.label11.TabIndex = 1;
            this.label11.Text = "Retornar valores do cheque selecionado ao caixa";
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
            this.dataCB.Size = new System.Drawing.Size(152, 24);
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
            this.panelCaixa.Size = new System.Drawing.Size(710, 551);
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
            this.valor,
            this.thora});
            this.transacoesDGV.Location = new System.Drawing.Point(3, 39);
            this.transacoesDGV.MultiSelect = false;
            this.transacoesDGV.Name = "transacoesDGV";
            this.transacoesDGV.ReadOnly = true;
            this.transacoesDGV.RowHeadersVisible = false;
            this.transacoesDGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.transacoesDGV.Size = new System.Drawing.Size(704, 509);
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
            this.ttipo.Width = 51;
            // 
            // valor
            // 
            this.valor.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridViewCellStyle1.Format = "C2";
            dataGridViewCellStyle1.NullValue = null;
            this.valor.DefaultCellStyle = dataGridViewCellStyle1;
            this.valor.HeaderText = "Valor";
            this.valor.Name = "valor";
            this.valor.ReadOnly = true;
            this.valor.Width = 54;
            // 
            // thora
            // 
            this.thora.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridViewCellStyle2.Format = "t";
            dataGridViewCellStyle2.NullValue = null;
            this.thora.DefaultCellStyle = dataGridViewCellStyle2;
            this.thora.HeaderText = "Número";
            this.thora.Name = "thora";
            this.thora.ReadOnly = true;
            this.thora.Width = 67;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(3, 14);
            this.label7.Margin = new System.Windows.Forms.Padding(3, 15, 3, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(174, 18);
            this.label7.TabIndex = 0;
            this.label7.Text = "Controle de cheques";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 610);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(861, 22);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // Cheque
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
            this.Name = "Cheque";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cheque";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Cheque_FormClosed);
            this.Load += new System.EventHandler(this.Cheque_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Cheque_KeyDown);
            this.panel.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
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
        private System.Windows.Forms.DataGridViewTextBoxColumn valor;
        private System.Windows.Forms.DataGridViewTextBoxColumn thora;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button buttonReceber;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Panel panel5;

    }
}