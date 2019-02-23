namespace Forms.Venda
{
    partial class QuitarParcela
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(QuitarParcela));
            this.panel2 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.vendasDGV = new System.Windows.Forms.DataGridView();
            this.codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idCliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idFuncionario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.data = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.valor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.parcelasDGV = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnNumeroParcela = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idVenda = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataDGVTBC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.valorDGVCBC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pagoDGVTBC = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.pesquisarButton = new System.Windows.Forms.Button();
            this.codigoTB = new System.Windows.Forms.TextBox();
            this.nomeTB = new System.Windows.Forms.TextBox();
            this.produtoL = new System.Windows.Forms.Label();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.selecionarButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.descontarParcelaCB = new System.Windows.Forms.CheckBox();
            this.descontarParcelaTB = new System.Windows.Forms.TextBox();
            this.quitarButton = new System.Windows.Forms.Button();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vendasDGV)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.parcelasDGV)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.SystemColors.Control;
            this.panel2.Controls.Add(this.label3);
            this.panel2.Location = new System.Drawing.Point(0, 1);
            this.panel2.Margin = new System.Windows.Forms.Padding(0, 1, 0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(573, 183);
            this.panel2.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 15);
            this.label3.Margin = new System.Windows.Forms.Padding(3, 15, 3, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 18);
            this.label3.TabIndex = 13;
            this.label3.Text = "Vendas:";
            // 
            // vendasDGV
            // 
            this.vendasDGV.AllowUserToAddRows = false;
            this.vendasDGV.AllowUserToDeleteRows = false;
            this.vendasDGV.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.vendasDGV.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.vendasDGV.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.vendasDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.vendasDGV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.codigo,
            this.idCliente,
            this.idFuncionario,
            this.data,
            this.valor});
            this.vendasDGV.Location = new System.Drawing.Point(3, 3);
            this.vendasDGV.MultiSelect = false;
            this.vendasDGV.Name = "vendasDGV";
            this.vendasDGV.ReadOnly = true;
            this.vendasDGV.RowHeadersVisible = false;
            this.vendasDGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.vendasDGV.Size = new System.Drawing.Size(561, 160);
            this.vendasDGV.TabIndex = 0;
            this.vendasDGV.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.vendasDGV_CellClick);
            // 
            // codigo
            // 
            this.codigo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.codigo.HeaderText = "Cod. da venda";
            this.codigo.Name = "codigo";
            this.codigo.ReadOnly = true;
            // 
            // idCliente
            // 
            this.idCliente.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.idCliente.DataPropertyName = "idCliente";
            this.idCliente.HeaderText = "Cliente";
            this.idCliente.Name = "idCliente";
            this.idCliente.ReadOnly = true;
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
            this.data.DataPropertyName = "data";
            dataGridViewCellStyle1.Format = "d";
            dataGridViewCellStyle1.NullValue = null;
            this.data.DefaultCellStyle = dataGridViewCellStyle1;
            this.data.HeaderText = "Data";
            this.data.Name = "data";
            this.data.ReadOnly = true;
            // 
            // valor
            // 
            dataGridViewCellStyle2.Format = "C2";
            dataGridViewCellStyle2.NullValue = null;
            this.valor.DefaultCellStyle = dataGridViewCellStyle2;
            this.valor.HeaderText = "Valor";
            this.valor.Name = "valor";
            this.valor.ReadOnly = true;
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.BackColor = System.Drawing.SystemColors.Control;
            this.panel3.Controls.Add(this.label4);
            this.panel3.Location = new System.Drawing.Point(0, 185);
            this.panel3.Margin = new System.Windows.Forms.Padding(0, 1, 0, 1);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(573, 183);
            this.panel3.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 15);
            this.label4.Margin = new System.Windows.Forms.Padding(3, 15, 3, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 18);
            this.label4.TabIndex = 13;
            this.label4.Text = "Parcelas:";
            // 
            // parcelasDGV
            // 
            this.parcelasDGV.AllowUserToAddRows = false;
            this.parcelasDGV.AllowUserToDeleteRows = false;
            this.parcelasDGV.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.parcelasDGV.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.parcelasDGV.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.parcelasDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.parcelasDGV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.ColumnNumeroParcela,
            this.idVenda,
            this.dataDGVTBC,
            this.valorDGVCBC,
            this.pagoDGVTBC});
            this.parcelasDGV.Location = new System.Drawing.Point(3, 199);
            this.parcelasDGV.MultiSelect = false;
            this.parcelasDGV.Name = "parcelasDGV";
            this.parcelasDGV.ReadOnly = true;
            this.parcelasDGV.RowHeadersVisible = false;
            this.parcelasDGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.parcelasDGV.Size = new System.Drawing.Size(561, 161);
            this.parcelasDGV.TabIndex = 2;
            // 
            // id
            // 
            this.id.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.id.HeaderText = "#";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Visible = false;
            // 
            // ColumnNumeroParcela
            // 
            this.ColumnNumeroParcela.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ColumnNumeroParcela.HeaderText = "Nº Parcela";
            this.ColumnNumeroParcela.Name = "ColumnNumeroParcela";
            this.ColumnNumeroParcela.ReadOnly = true;
            this.ColumnNumeroParcela.Width = 81;
            // 
            // idVenda
            // 
            this.idVenda.HeaderText = "Venda";
            this.idVenda.Name = "idVenda";
            this.idVenda.ReadOnly = true;
            this.idVenda.Visible = false;
            // 
            // dataDGVTBC
            // 
            dataGridViewCellStyle3.Format = "d";
            dataGridViewCellStyle3.NullValue = null;
            this.dataDGVTBC.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataDGVTBC.HeaderText = "Vencimento";
            this.dataDGVTBC.Name = "dataDGVTBC";
            this.dataDGVTBC.ReadOnly = true;
            // 
            // valorDGVCBC
            // 
            dataGridViewCellStyle4.Format = "C2";
            dataGridViewCellStyle4.NullValue = null;
            this.valorDGVCBC.DefaultCellStyle = dataGridViewCellStyle4;
            this.valorDGVCBC.HeaderText = "Valor";
            this.valorDGVCBC.Name = "valorDGVCBC";
            this.valorDGVCBC.ReadOnly = true;
            // 
            // pagoDGVTBC
            // 
            this.pagoDGVTBC.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.pagoDGVTBC.FalseValue = "0";
            this.pagoDGVTBC.HeaderText = "Pago";
            this.pagoDGVTBC.IndeterminateValue = "0";
            this.pagoDGVTBC.Name = "pagoDGVTBC";
            this.pagoDGVTBC.ReadOnly = true;
            this.pagoDGVTBC.TrueValue = "1";
            this.pagoDGVTBC.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 41);
            this.label1.Margin = new System.Windows.Forms.Padding(3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "Código da venda:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 84);
            this.label2.Margin = new System.Windows.Forms.Padding(3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "Nome do cliente:";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel4, 0, 2);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 162F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 62F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(567, 589);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.pesquisarButton, 0, 5);
            this.tableLayoutPanel2.Controls.Add(this.label1, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.label2, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.codigoTB, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.nomeTB, 0, 4);
            this.tableLayoutPanel2.Controls.Add(this.produtoL, 0, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 6;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 18F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 18F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(567, 162);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // pesquisarButton
            // 
            this.pesquisarButton.Location = new System.Drawing.Point(3, 127);
            this.pesquisarButton.Name = "pesquisarButton";
            this.pesquisarButton.Size = new System.Drawing.Size(75, 23);
            this.pesquisarButton.TabIndex = 5;
            this.pesquisarButton.Text = "Pesquisar";
            this.pesquisarButton.UseVisualStyleBackColor = true;
            this.pesquisarButton.Click += new System.EventHandler(this.pesquisarButton_Click);
            // 
            // codigoTB
            // 
            this.codigoTB.Location = new System.Drawing.Point(3, 59);
            this.codigoTB.Name = "codigoTB";
            this.codigoTB.Size = new System.Drawing.Size(246, 20);
            this.codigoTB.TabIndex = 2;
            // 
            // nomeTB
            // 
            this.nomeTB.Location = new System.Drawing.Point(3, 102);
            this.nomeTB.Name = "nomeTB";
            this.nomeTB.Size = new System.Drawing.Size(246, 20);
            this.nomeTB.TabIndex = 4;
            // 
            // produtoL
            // 
            this.produtoL.AutoSize = true;
            this.produtoL.Dock = System.Windows.Forms.DockStyle.Top;
            this.produtoL.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.produtoL.Location = new System.Drawing.Point(3, 3);
            this.produtoL.Margin = new System.Windows.Forms.Padding(3);
            this.produtoL.Name = "produtoL";
            this.produtoL.Size = new System.Drawing.Size(561, 18);
            this.produtoL.TabIndex = 0;
            this.produtoL.Text = "Filtros:";
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.selecionarButton, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.vendasDGV, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.parcelasDGV, 0, 2);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 162);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 3;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(567, 363);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // selecionarButton
            // 
            this.selecionarButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.selecionarButton.Location = new System.Drawing.Point(489, 169);
            this.selecionarButton.Name = "selecionarButton";
            this.selecionarButton.Size = new System.Drawing.Size(75, 24);
            this.selecionarButton.TabIndex = 1;
            this.selecionarButton.Text = "Selecionar";
            this.selecionarButton.UseVisualStyleBackColor = true;
            this.selecionarButton.Click += new System.EventHandler(this.selecionarButton_Click);
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel4.ColumnCount = 2;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 62F));
            this.tableLayoutPanel4.Controls.Add(this.descontarParcelaCB, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.descontarParcelaTB, 0, 1);
            this.tableLayoutPanel4.Controls.Add(this.quitarButton, 1, 0);
            this.tableLayoutPanel4.Location = new System.Drawing.Point(0, 525);
            this.tableLayoutPanel4.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 2;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(567, 64);
            this.tableLayoutPanel4.TabIndex = 0;
            // 
            // descontarParcelaCB
            // 
            this.descontarParcelaCB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.descontarParcelaCB.AutoSize = true;
            this.descontarParcelaCB.Location = new System.Drawing.Point(364, 11);
            this.descontarParcelaCB.Name = "descontarParcelaCB";
            this.descontarParcelaCB.Size = new System.Drawing.Size(138, 17);
            this.descontarParcelaCB.TabIndex = 0;
            this.descontarParcelaCB.Text = "Pagar valor em parcela:";
            this.descontarParcelaCB.UseVisualStyleBackColor = true;
            this.descontarParcelaCB.CheckedChanged += new System.EventHandler(this.descontarParcelaCB_CheckedChanged);
            // 
            // descontarParcelaTB
            // 
            this.descontarParcelaTB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.descontarParcelaTB.Location = new System.Drawing.Point(364, 34);
            this.descontarParcelaTB.Name = "descontarParcelaTB";
            this.descontarParcelaTB.Size = new System.Drawing.Size(138, 20);
            this.descontarParcelaTB.TabIndex = 1;
            // 
            // quitarButton
            // 
            this.quitarButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.quitarButton.Image = ((System.Drawing.Image)(resources.GetObject("quitarButton.Image")));
            this.quitarButton.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.quitarButton.Location = new System.Drawing.Point(508, 3);
            this.quitarButton.Name = "quitarButton";
            this.tableLayoutPanel4.SetRowSpan(this.quitarButton, 2);
            this.quitarButton.Size = new System.Drawing.Size(56, 58);
            this.quitarButton.TabIndex = 2;
            this.quitarButton.Text = "Receber";
            this.quitarButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.quitarButton.UseVisualStyleBackColor = true;
            this.quitarButton.Click += new System.EventHandler(this.quitarButton_Click);
            // 
            // QuitarParcela
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(573, 595);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "QuitarParcela";
            this.Padding = new System.Windows.Forms.Padding(3);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Receber crediário";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.QuitarParcela_FormClosed);
            this.Load += new System.EventHandler(this.QuitarParcela_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vendasDGV)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.parcelasDGV)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label produtoL;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button pesquisarButton;
        private System.Windows.Forms.TextBox codigoTB;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox nomeTB;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Button selecionarButton;
        private System.Windows.Forms.DataGridView vendasDGV;
        private System.Windows.Forms.DataGridView parcelasDGV;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.CheckBox descontarParcelaCB;
        private System.Windows.Forms.TextBox descontarParcelaTB;
        private System.Windows.Forms.Button quitarButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnNumeroParcela;
        private System.Windows.Forms.DataGridViewTextBoxColumn idVenda;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataDGVTBC;
        private System.Windows.Forms.DataGridViewTextBoxColumn valorDGVCBC;
        private System.Windows.Forms.DataGridViewCheckBoxColumn pagoDGVTBC;
        private System.Windows.Forms.DataGridViewTextBoxColumn codigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn idCliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn idFuncionario;
        private System.Windows.Forms.DataGridViewTextBoxColumn data;
        private System.Windows.Forms.DataGridViewTextBoxColumn valor;

    }
}