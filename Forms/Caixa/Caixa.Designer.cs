namespace Forms.Caixa
{
    partial class Caixa
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Caixa));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.saldoLabel = new System.Windows.Forms.Label();
            this.panel = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label10 = new System.Windows.Forms.Label();
            this.buttonDevolver = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.retiradaPanel = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.retirarButton = new System.Windows.Forms.Button();
            this.retiradaTB = new Library.Windows.Forms.MoneyTextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.encerrarButton = new System.Windows.Forms.Button();
            this.imprimirButton = new System.Windows.Forms.Button();
            this.dataCB = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.entradaPanel = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.entrarButton = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.entradaTB = new Library.Windows.Forms.MoneyTextBox();
            this.panelCaixa = new System.Windows.Forms.Panel();
            this.transacoesDGV = new System.Windows.Forms.DataGridView();
            this.tcodigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tcliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ttipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.valor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.thora = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label7 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.statusLabel = new System.Windows.Forms.Label();
            this.saldoTextBox = new Library.Windows.Forms.MoneyTextBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.panel.SuspendLayout();
            this.panel3.SuspendLayout();
            this.retiradaPanel.SuspendLayout();
            this.panel1.SuspendLayout();
            this.entradaPanel.SuspendLayout();
            this.panelCaixa.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.transacoesDGV)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Valor:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 31);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Valor:";
            // 
            // saldoLabel
            // 
            this.saldoLabel.AutoSize = true;
            this.saldoLabel.Location = new System.Drawing.Point(9, 36);
            this.saldoLabel.Name = "saldoLabel";
            this.saldoLabel.Size = new System.Drawing.Size(37, 13);
            this.saldoLabel.TabIndex = 1;
            this.saldoLabel.Text = "Saldo:";
            // 
            // panel
            // 
            this.panel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel.Controls.Add(this.panel5);
            this.panel.Controls.Add(this.panel3);
            this.panel.Controls.Add(this.retiradaPanel);
            this.panel.Controls.Add(this.panel1);
            this.panel.Controls.Add(this.entradaPanel);
            this.panel.Controls.Add(this.panelCaixa);
            this.panel.Controls.Add(this.panel2);
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
            this.panel5.Location = new System.Drawing.Point(661, 494);
            this.panel5.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(200, 116);
            this.panel5.TabIndex = 5;
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.BackColor = System.Drawing.SystemColors.Control;
            this.panel3.Controls.Add(this.label10);
            this.panel3.Controls.Add(this.buttonDevolver);
            this.panel3.Controls.Add(this.label11);
            this.panel3.Location = new System.Drawing.Point(661, 415);
            this.panel3.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(200, 78);
            this.panel3.TabIndex = 4;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(3, 9);
            this.label10.Margin = new System.Windows.Forms.Padding(3, 15, 3, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(98, 18);
            this.label10.TabIndex = 0;
            this.label10.Text = "Devolução:";
            // 
            // buttonDevolver
            // 
            this.buttonDevolver.Location = new System.Drawing.Point(116, 46);
            this.buttonDevolver.Name = "buttonDevolver";
            this.buttonDevolver.Size = new System.Drawing.Size(75, 23);
            this.buttonDevolver.TabIndex = 3;
            this.buttonDevolver.Text = "Devolver";
            this.buttonDevolver.UseVisualStyleBackColor = true;
            this.buttonDevolver.Click += new System.EventHandler(this.buttonDevolver_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(9, 31);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(118, 13);
            this.label11.TabIndex = 1;
            this.label11.Text = "Transação selecionada";
            // 
            // retiradaPanel
            // 
            this.retiradaPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.retiradaPanel.BackColor = System.Drawing.SystemColors.Control;
            this.retiradaPanel.Controls.Add(this.label8);
            this.retiradaPanel.Controls.Add(this.label4);
            this.retiradaPanel.Controls.Add(this.retirarButton);
            this.retiradaPanel.Controls.Add(this.label1);
            this.retiradaPanel.Controls.Add(this.retiradaTB);
            this.retiradaPanel.Location = new System.Drawing.Point(661, 309);
            this.retiradaPanel.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.retiradaPanel.Name = "retiradaPanel";
            this.retiradaPanel.Size = new System.Drawing.Size(200, 105);
            this.retiradaPanel.TabIndex = 4;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(132, 13);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(35, 13);
            this.label8.TabIndex = 4;
            this.label8.Text = "(Hoje)";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(3, 9);
            this.label4.Margin = new System.Windows.Forms.Padding(3, 15, 3, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(130, 18);
            this.label4.TabIndex = 0;
            this.label4.Text = "Fazer retirada:";
            // 
            // retirarButton
            // 
            this.retirarButton.Location = new System.Drawing.Point(116, 75);
            this.retirarButton.Name = "retirarButton";
            this.retirarButton.Size = new System.Drawing.Size(75, 23);
            this.retirarButton.TabIndex = 3;
            this.retirarButton.Text = "Retirar";
            this.retirarButton.UseVisualStyleBackColor = true;
            this.retirarButton.Click += new System.EventHandler(this.retirarButton_Click);
            // 
            // retiradaTB
            // 
            this.retiradaTB.Location = new System.Drawing.Point(9, 49);
            this.retiradaTB.Name = "retiradaTB";
            this.retiradaTB.Size = new System.Drawing.Size(182, 20);
            this.retiradaTB.TabIndex = 2;
            this.retiradaTB.Text = "R$ 0,00";
            this.retiradaTB.Value = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            this.retiradaTB.Leave += new System.EventHandler(this.retiradaTB_Leave);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.Silver;
            this.panel1.Controls.Add(this.encerrarButton);
            this.panel1.Controls.Add(this.imprimirButton);
            this.panel1.Controls.Add(this.dataCB);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(861, 98);
            this.panel1.TabIndex = 0;
            // 
            // encerrarButton
            // 
            this.encerrarButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.encerrarButton.Image = ((System.Drawing.Image)(resources.GetObject("encerrarButton.Image")));
            this.encerrarButton.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.encerrarButton.Location = new System.Drawing.Point(779, 14);
            this.encerrarButton.Name = "encerrarButton";
            this.encerrarButton.Size = new System.Drawing.Size(70, 70);
            this.encerrarButton.TabIndex = 3;
            this.encerrarButton.Text = "Encerrar";
            this.encerrarButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.encerrarButton.UseVisualStyleBackColor = true;
            this.encerrarButton.Click += new System.EventHandler(this.encerrarButton_Click);
            // 
            // imprimirButton
            // 
            this.imprimirButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.imprimirButton.Image = ((System.Drawing.Image)(resources.GetObject("imprimirButton.Image")));
            this.imprimirButton.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.imprimirButton.Location = new System.Drawing.Point(703, 14);
            this.imprimirButton.Name = "imprimirButton";
            this.imprimirButton.Size = new System.Drawing.Size(70, 70);
            this.imprimirButton.TabIndex = 2;
            this.imprimirButton.Text = "Imprimir";
            this.imprimirButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.imprimirButton.UseVisualStyleBackColor = true;
            this.imprimirButton.Click += new System.EventHandler(this.imprimirButton_Click);
            // 
            // dataCB
            // 
            this.dataCB.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataCB.FormattingEnabled = true;
            this.dataCB.Location = new System.Drawing.Point(17, 52);
            this.dataCB.Name = "dataCB";
            this.dataCB.Size = new System.Drawing.Size(152, 24);
            this.dataCB.TabIndex = 1;
            this.dataCB.SelectedIndexChanged += new System.EventHandler(this.dataCB_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(240, 26);
            this.label2.TabIndex = 0;
            this.label2.Text = "Movimentos em aberto:";
            // 
            // entradaPanel
            // 
            this.entradaPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.entradaPanel.BackColor = System.Drawing.SystemColors.Control;
            this.entradaPanel.Controls.Add(this.label6);
            this.entradaPanel.Controls.Add(this.entrarButton);
            this.entradaPanel.Controls.Add(this.label5);
            this.entradaPanel.Controls.Add(this.label3);
            this.entradaPanel.Controls.Add(this.entradaTB);
            this.entradaPanel.Location = new System.Drawing.Point(661, 203);
            this.entradaPanel.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.entradaPanel.Name = "entradaPanel";
            this.entradaPanel.Size = new System.Drawing.Size(200, 105);
            this.entradaPanel.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(132, 13);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 13);
            this.label6.TabIndex = 4;
            this.label6.Text = "(Hoje)";
            // 
            // entrarButton
            // 
            this.entrarButton.Location = new System.Drawing.Point(116, 75);
            this.entrarButton.Name = "entrarButton";
            this.entrarButton.Size = new System.Drawing.Size(75, 23);
            this.entrarButton.TabIndex = 3;
            this.entrarButton.Text = "Entrar";
            this.entrarButton.UseVisualStyleBackColor = true;
            this.entrarButton.Click += new System.EventHandler(this.entrarButton_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(3, 9);
            this.label5.Margin = new System.Windows.Forms.Padding(3, 15, 3, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(129, 18);
            this.label5.TabIndex = 0;
            this.label5.Text = "Fazer entrada:";
            // 
            // entradaTB
            // 
            this.entradaTB.Location = new System.Drawing.Point(9, 49);
            this.entradaTB.Name = "entradaTB";
            this.entradaTB.Size = new System.Drawing.Size(182, 20);
            this.entradaTB.TabIndex = 2;
            this.entradaTB.Text = "R$ 0,00";
            this.entradaTB.Value = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            this.entradaTB.Leave += new System.EventHandler(this.entradaTB_Leave);
            // 
            // panelCaixa
            // 
            this.panelCaixa.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panelCaixa.BackColor = System.Drawing.SystemColors.Control;
            this.panelCaixa.Controls.Add(this.transacoesDGV);
            this.panelCaixa.Controls.Add(this.label7);
            this.panelCaixa.Location = new System.Drawing.Point(0, 99);
            this.panelCaixa.Margin = new System.Windows.Forms.Padding(0, 1, 0, 0);
            this.panelCaixa.Name = "panelCaixa";
            this.panelCaixa.Size = new System.Drawing.Size(660, 511);
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
            this.transacoesDGV.Size = new System.Drawing.Size(654, 469);
            this.transacoesDGV.TabIndex = 1;
            this.transacoesDGV.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.transacoesDGV_CellContentClick);
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
            dataGridViewCellStyle3.Format = "C2";
            dataGridViewCellStyle3.NullValue = null;
            this.valor.DefaultCellStyle = dataGridViewCellStyle3;
            this.valor.HeaderText = "Valor";
            this.valor.Name = "valor";
            this.valor.ReadOnly = true;
            this.valor.Width = 54;
            // 
            // thora
            // 
            this.thora.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridViewCellStyle4.Format = "t";
            dataGridViewCellStyle4.NullValue = null;
            this.thora.DefaultCellStyle = dataGridViewCellStyle4;
            this.thora.HeaderText = "Hora";
            this.thora.Name = "thora";
            this.thora.ReadOnly = true;
            this.thora.Width = 53;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(3, 14);
            this.label7.Margin = new System.Windows.Forms.Padding(3, 15, 3, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(197, 18);
            this.label7.TabIndex = 0;
            this.label7.Text = "Controle de transações";
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel2.Controls.Add(this.saldoLabel);
            this.panel2.Controls.Add(this.statusLabel);
            this.panel2.Controls.Add(this.saldoTextBox);
            this.panel2.Location = new System.Drawing.Point(661, 99);
            this.panel2.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(200, 103);
            this.panel2.TabIndex = 2;
            // 
            // statusLabel
            // 
            this.statusLabel.AutoSize = true;
            this.statusLabel.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusLabel.Location = new System.Drawing.Point(3, 14);
            this.statusLabel.Margin = new System.Windows.Forms.Padding(3, 15, 3, 0);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(59, 18);
            this.statusLabel.TabIndex = 0;
            this.statusLabel.Text = "Caixa:";
            // 
            // saldoTextBox
            // 
            this.saldoTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saldoTextBox.Location = new System.Drawing.Point(9, 54);
            this.saldoTextBox.Name = "saldoTextBox";
            this.saldoTextBox.ReadOnly = true;
            this.saldoTextBox.Size = new System.Drawing.Size(182, 29);
            this.saldoTextBox.TabIndex = 2;
            this.saldoTextBox.Text = "R$ 0,00";
            this.saldoTextBox.Value = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 610);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(861, 22);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // Caixa
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
            this.Name = "Caixa";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Caixa";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Caixa_FormClosed);
            this.Load += new System.EventHandler(this.Caixa_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Caixa_KeyDown);
            this.panel.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.retiradaPanel.ResumeLayout(false);
            this.retiradaPanel.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.entradaPanel.ResumeLayout(false);
            this.entradaPanel.PerformLayout();
            this.panelCaixa.ResumeLayout(false);
            this.panelCaixa.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.transacoesDGV)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel;
        private Library.Windows.Forms.MoneyTextBox saldoTextBox;
        private System.Windows.Forms.DataGridView transacoesDGV;
        private System.Windows.Forms.Button retirarButton;
        private Library.Windows.Forms.MoneyTextBox retiradaTB;
        private System.Windows.Forms.Panel panelCaixa;
        private System.Windows.Forms.ComboBox dataCB;
        private System.Windows.Forms.Button entrarButton;
        private Library.Windows.Forms.MoneyTextBox entradaTB;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button encerrarButton;
        private System.Windows.Forms.Button imprimirButton;
        private System.Windows.Forms.Panel retiradaPanel;
        private System.Windows.Forms.Panel entradaPanel;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label saldoLabel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label statusLabel;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button buttonDevolver;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.DataGridViewTextBoxColumn tcodigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn tcliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn ttipo;
        private System.Windows.Forms.DataGridViewTextBoxColumn valor;
        private System.Windows.Forms.DataGridViewTextBoxColumn thora;
    }
}