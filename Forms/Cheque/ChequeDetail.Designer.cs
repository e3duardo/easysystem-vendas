namespace Forms.Cheque
{
    partial class ChequeDetail
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChequeDetail));
            this.label5 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.idLabel = new System.Windows.Forms.Label();
            this.pagarButton = new System.Windows.Forms.Button();
            this.pagoTB = new System.Windows.Forms.TextBox();
            this.valorTB = new System.Windows.Forms.TextBox();
            this.numeroTB = new System.Windows.Forms.TextBox();
            this.dataTB = new System.Windows.Forms.TextBox();
            this.codigoTB = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.moreButton = new System.Windows.Forms.Button();
            this.servicoCodigoTB = new System.Windows.Forms.TextBox();
            this.servicoValorTB = new System.Windows.Forms.TextBox();
            this.servicoDataTB = new System.Windows.Forms.TextBox();
            this.servicoClienteNomeTB = new System.Windows.Forms.TextBox();
            this.okButton = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 19);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Código:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 142);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(34, 13);
            this.label8.TabIndex = 6;
            this.label8.Text = "Valor:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 101);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(33, 13);
            this.label7.TabIndex = 4;
            this.label7.Text = "Data:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 60);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(42, 13);
            this.label6.TabIndex = 2;
            this.label6.Text = "Cliente:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 173);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Pago:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 132);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Valor:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Número:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 91);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Data:";
            // 
            // idLabel
            // 
            this.idLabel.AutoSize = true;
            this.idLabel.Location = new System.Drawing.Point(12, 9);
            this.idLabel.Name = "idLabel";
            this.idLabel.Size = new System.Drawing.Size(43, 13);
            this.idLabel.TabIndex = 0;
            this.idLabel.Text = "Código:";
            // 
            // pagarButton
            // 
            this.pagarButton.Location = new System.Drawing.Point(70, 188);
            this.pagarButton.Name = "pagarButton";
            this.pagarButton.Size = new System.Drawing.Size(58, 23);
            this.pagarButton.TabIndex = 10;
            this.pagarButton.Text = "Receber";
            this.pagarButton.UseVisualStyleBackColor = true;
            this.pagarButton.Click += new System.EventHandler(this.pagarButton_Click);
            // 
            // pagoTB
            // 
            this.pagoTB.BackColor = System.Drawing.SystemColors.ControlLight;
            this.pagoTB.Location = new System.Drawing.Point(12, 189);
            this.pagoTB.Margin = new System.Windows.Forms.Padding(3, 3, 3, 5);
            this.pagoTB.Name = "pagoTB";
            this.pagoTB.ReadOnly = true;
            this.pagoTB.Size = new System.Drawing.Size(52, 20);
            this.pagoTB.TabIndex = 9;
            // 
            // valorTB
            // 
            this.valorTB.BackColor = System.Drawing.SystemColors.ControlLight;
            this.valorTB.Location = new System.Drawing.Point(12, 148);
            this.valorTB.Margin = new System.Windows.Forms.Padding(3, 3, 3, 5);
            this.valorTB.Name = "valorTB";
            this.valorTB.ReadOnly = true;
            this.valorTB.Size = new System.Drawing.Size(116, 20);
            this.valorTB.TabIndex = 7;
            // 
            // numeroTB
            // 
            this.numeroTB.BackColor = System.Drawing.SystemColors.ControlLight;
            this.numeroTB.Location = new System.Drawing.Point(12, 66);
            this.numeroTB.Margin = new System.Windows.Forms.Padding(3, 3, 3, 5);
            this.numeroTB.Name = "numeroTB";
            this.numeroTB.ReadOnly = true;
            this.numeroTB.Size = new System.Drawing.Size(116, 20);
            this.numeroTB.TabIndex = 3;
            // 
            // dataTB
            // 
            this.dataTB.BackColor = System.Drawing.SystemColors.ControlLight;
            this.dataTB.Location = new System.Drawing.Point(12, 107);
            this.dataTB.Margin = new System.Windows.Forms.Padding(3, 3, 3, 5);
            this.dataTB.Name = "dataTB";
            this.dataTB.ReadOnly = true;
            this.dataTB.Size = new System.Drawing.Size(116, 20);
            this.dataTB.TabIndex = 5;
            // 
            // codigoTB
            // 
            this.codigoTB.BackColor = System.Drawing.SystemColors.ControlLight;
            this.codigoTB.Location = new System.Drawing.Point(12, 25);
            this.codigoTB.Margin = new System.Windows.Forms.Padding(3, 3, 3, 5);
            this.codigoTB.Name = "codigoTB";
            this.codigoTB.ReadOnly = true;
            this.codigoTB.Size = new System.Drawing.Size(116, 20);
            this.codigoTB.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.moreButton);
            this.groupBox1.Controls.Add(this.servicoCodigoTB);
            this.groupBox1.Controls.Add(this.servicoValorTB);
            this.groupBox1.Controls.Add(this.servicoDataTB);
            this.groupBox1.Controls.Add(this.servicoClienteNomeTB);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Location = new System.Drawing.Point(190, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(205, 218);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Detalhes";
            // 
            // moreButton
            // 
            this.moreButton.Location = new System.Drawing.Point(6, 186);
            this.moreButton.Name = "moreButton";
            this.moreButton.Size = new System.Drawing.Size(80, 23);
            this.moreButton.TabIndex = 8;
            this.moreButton.Text = "Mais detalhes";
            this.moreButton.UseVisualStyleBackColor = true;
            this.moreButton.Click += new System.EventHandler(this.moreButton_Click);
            // 
            // servicoCodigoTB
            // 
            this.servicoCodigoTB.BackColor = System.Drawing.SystemColors.ControlLight;
            this.servicoCodigoTB.Location = new System.Drawing.Point(6, 35);
            this.servicoCodigoTB.Margin = new System.Windows.Forms.Padding(3, 3, 3, 5);
            this.servicoCodigoTB.Name = "servicoCodigoTB";
            this.servicoCodigoTB.ReadOnly = true;
            this.servicoCodigoTB.Size = new System.Drawing.Size(116, 20);
            this.servicoCodigoTB.TabIndex = 1;
            // 
            // servicoValorTB
            // 
            this.servicoValorTB.BackColor = System.Drawing.SystemColors.ControlLight;
            this.servicoValorTB.Location = new System.Drawing.Point(6, 158);
            this.servicoValorTB.Margin = new System.Windows.Forms.Padding(3, 3, 3, 5);
            this.servicoValorTB.Name = "servicoValorTB";
            this.servicoValorTB.ReadOnly = true;
            this.servicoValorTB.Size = new System.Drawing.Size(116, 20);
            this.servicoValorTB.TabIndex = 7;
            // 
            // servicoDataTB
            // 
            this.servicoDataTB.BackColor = System.Drawing.SystemColors.ControlLight;
            this.servicoDataTB.Location = new System.Drawing.Point(6, 117);
            this.servicoDataTB.Margin = new System.Windows.Forms.Padding(3, 3, 3, 5);
            this.servicoDataTB.Name = "servicoDataTB";
            this.servicoDataTB.ReadOnly = true;
            this.servicoDataTB.Size = new System.Drawing.Size(116, 20);
            this.servicoDataTB.TabIndex = 5;
            // 
            // servicoClienteNomeTB
            // 
            this.servicoClienteNomeTB.BackColor = System.Drawing.SystemColors.ControlLight;
            this.servicoClienteNomeTB.Location = new System.Drawing.Point(6, 76);
            this.servicoClienteNomeTB.Margin = new System.Windows.Forms.Padding(3, 3, 3, 5);
            this.servicoClienteNomeTB.Name = "servicoClienteNomeTB";
            this.servicoClienteNomeTB.ReadOnly = true;
            this.servicoClienteNomeTB.Size = new System.Drawing.Size(194, 20);
            this.servicoClienteNomeTB.TabIndex = 3;
            // 
            // okButton
            // 
            this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.okButton.Location = new System.Drawing.Point(320, 250);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 12;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // ChequeDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(407, 285);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.pagarButton);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.pagoTB);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.valorTB);
            this.Controls.Add(this.numeroTB);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dataTB);
            this.Controls.Add(this.idLabel);
            this.Controls.Add(this.codigoTB);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "ChequeDetail";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Detalhes de cheque";
            this.Load += new System.EventHandler(this.ChequeDetail_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ChequeDetail_KeyDown);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button pagarButton;
        private System.Windows.Forms.TextBox pagoTB;
        private System.Windows.Forms.TextBox valorTB;
        private System.Windows.Forms.TextBox numeroTB;
        private System.Windows.Forms.TextBox dataTB;
        private System.Windows.Forms.TextBox codigoTB;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button moreButton;
        private System.Windows.Forms.TextBox servicoCodigoTB;
        private System.Windows.Forms.TextBox servicoValorTB;
        private System.Windows.Forms.TextBox servicoDataTB;
        private System.Windows.Forms.TextBox servicoClienteNomeTB;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label idLabel;
    }
}