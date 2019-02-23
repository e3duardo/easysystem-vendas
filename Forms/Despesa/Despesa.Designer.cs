namespace Forms.Despesa
{
    /// <summary>
    /// despesa
    /// </summary>
    partial class Despesa
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Despesa));
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.novoButton = new System.Windows.Forms.Button();
            this.salvarButton = new System.Windows.Forms.Button();
            this.cancelarButton = new System.Windows.Forms.Button();
            this.dataDTP = new Library.Windows.Forms.DateTextBox();
            this.descricaoTB = new System.Windows.Forms.TextBox();
            this.codigoTB = new System.Windows.Forms.TextBox();
            this.valorTB = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
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
            this.novoButton.Location = new System.Drawing.Point(150, 7);
            this.novoButton.Margin = new System.Windows.Forms.Padding(0);
            this.novoButton.Name = "novoButton";
            this.novoButton.Size = new System.Drawing.Size(60, 60);
            this.novoButton.TabIndex = 0;
            this.novoButton.Text = "&Novo";
            this.novoButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.novoButton.UseVisualStyleBackColor = true;
            this.novoButton.Click += new System.EventHandler(this.novoButton_Click);
            // 
            // salvarButton
            // 
            this.salvarButton.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.salvarButton.Image = ((System.Drawing.Image)(resources.GetObject("salvarButton.Image")));
            this.salvarButton.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.salvarButton.Location = new System.Drawing.Point(218, 7);
            this.salvarButton.Margin = new System.Windows.Forms.Padding(0);
            this.salvarButton.Name = "salvarButton";
            this.salvarButton.Size = new System.Drawing.Size(60, 60);
            this.salvarButton.TabIndex = 1;
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
            this.cancelarButton.Location = new System.Drawing.Point(286, 7);
            this.cancelarButton.Margin = new System.Windows.Forms.Padding(0);
            this.cancelarButton.Name = "cancelarButton";
            this.cancelarButton.Size = new System.Drawing.Size(60, 60);
            this.cancelarButton.TabIndex = 2;
            this.cancelarButton.Text = "&Cancelar";
            this.cancelarButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.cancelarButton.UseVisualStyleBackColor = true;
            this.cancelarButton.Click += new System.EventHandler(this.cancelarButton_Click);
            // 
            // dataDTP
            // 
            this.dataDTP.Location = new System.Drawing.Point(16, 81);
            this.dataDTP.Margin = new System.Windows.Forms.Padding(3, 3, 19, 3);
            this.dataDTP.MaxLength = 10;
            this.dataDTP.Name = "dataDTP";
            this.dataDTP.Size = new System.Drawing.Size(88, 20);
            this.dataDTP.TabIndex = 3;
            this.dataDTP.Text = "01/01/0001";
            this.dataDTP.Value = new System.DateTime(((long)(0)));
            this.dataDTP.Validating += new System.ComponentModel.CancelEventHandler(this.dataDTP_Validating);
            // 
            // descricaoTB
            // 
            this.descricaoTB.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.descricaoTB.Location = new System.Drawing.Point(136, 35);
            this.descricaoTB.Margin = new System.Windows.Forms.Padding(3, 3, 19, 3);
            this.descricaoTB.Multiline = true;
            this.descricaoTB.Name = "descricaoTB";
            this.tableLayoutPanel3.SetRowSpan(this.descricaoTB, 5);
            this.descricaoTB.Size = new System.Drawing.Size(328, 112);
            this.descricaoTB.TabIndex = 7;
            // 
            // codigoTB
            // 
            this.codigoTB.Location = new System.Drawing.Point(16, 35);
            this.codigoTB.Margin = new System.Windows.Forms.Padding(3, 3, 19, 3);
            this.codigoTB.Name = "codigoTB";
            this.codigoTB.ReadOnly = true;
            this.codigoTB.Size = new System.Drawing.Size(88, 20);
            this.codigoTB.TabIndex = 1;
            // 
            // valorTB
            // 
            this.valorTB.Location = new System.Drawing.Point(16, 127);
            this.valorTB.Margin = new System.Windows.Forms.Padding(3, 3, 19, 3);
            this.valorTB.Name = "valorTB";
            this.valorTB.Size = new System.Drawing.Size(88, 20);
            this.valorTB.TabIndex = 5;
            this.valorTB.Leave += new System.EventHandler(this.valorTB_Leave);
            this.valorTB.Validating += new System.ComponentModel.CancelEventHandler(this.valorTB_Validating);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 15);
            this.label4.Margin = new System.Windows.Forms.Padding(3);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Código";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(136, 15);
            this.label3.Margin = new System.Windows.Forms.Padding(3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Descrição";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 107);
            this.label2.Margin = new System.Windows.Forms.Padding(3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Valor";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 61);
            this.label1.Margin = new System.Windows.Forms.Padding(3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Data";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 76F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(497, 239);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.BackColor = System.Drawing.SystemColors.ControlDark;
            this.tableLayoutPanel2.ColumnCount = 7;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.cancelarButton, 5, 1);
            this.tableLayoutPanel2.Controls.Add(this.salvarButton, 3, 1);
            this.tableLayoutPanel2.Controls.Add(this.novoButton, 1, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(497, 75);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.BackColor = System.Drawing.SystemColors.Control;
            this.tableLayoutPanel3.ColumnCount = 5;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 350F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this.dataDTP, 1, 4);
            this.tableLayoutPanel3.Controls.Add(this.label3, 3, 1);
            this.tableLayoutPanel3.Controls.Add(this.valorTB, 1, 6);
            this.tableLayoutPanel3.Controls.Add(this.label4, 1, 1);
            this.tableLayoutPanel3.Controls.Add(this.codigoTB, 1, 2);
            this.tableLayoutPanel3.Controls.Add(this.label2, 1, 5);
            this.tableLayoutPanel3.Controls.Add(this.label1, 1, 3);
            this.tableLayoutPanel3.Controls.Add(this.descricaoTB, 3, 2);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 76);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 8;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(497, 163);
            this.tableLayoutPanel3.TabIndex = 1;
            // 
            // Despesa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(497, 239);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(503, 271);
            this.Name = "Despesa";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Despesa";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Despesa_FormClosed);
            this.Load += new System.EventHandler(this.Despesa_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Despesa_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.Button novoButton;
        private System.Windows.Forms.Button salvarButton;
        private System.Windows.Forms.Button cancelarButton;
        private System.Windows.Forms.TextBox descricaoTB;
        private System.Windows.Forms.TextBox valorTB;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private Library.Windows.Forms.DateTextBox dataDTP;
        private System.Windows.Forms.TextBox codigoTB;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;

    }
}