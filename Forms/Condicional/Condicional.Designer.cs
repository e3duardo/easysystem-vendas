using System.Windows.Forms;
namespace Forms.Condicional
{
    partial class Condicional
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Condicional));
            this.idFuncionarioLabel = new System.Windows.Forms.Label();
            this.idLabel = new System.Windows.Forms.Label();
            this.dataLabel = new System.Windows.Forms.Label();
            this.idClienteLabel = new System.Windows.Forms.Label();
            this.valorTotalLabel = new System.Windows.Forms.Label();
            this.panel = new System.Windows.Forms.Panel();
            this.topPanel = new System.Windows.Forms.Panel();
            this.orcamentoLabel = new System.Windows.Forms.Label();
            this.funcionarioButton = new System.Windows.Forms.Button();
            this.codigoTB = new System.Windows.Forms.TextBox();
            this.funcionarioCB = new System.Windows.Forms.ComboBox();
            this.dataTB = new System.Windows.Forms.TextBox();
            this.midle1Panel = new System.Windows.Forms.Panel();
            this.produtos1 = new Forms.Produto.Produtos();
            this.midle2Panel = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.clienteButton = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.idClienteTB = new System.Windows.Forms.TextBox();
            this.idClienteCB = new System.Windows.Forms.ComboBox();
            this.bottomPanel = new System.Windows.Forms.Panel();
            this.salvarButton = new System.Windows.Forms.Button();
            this.valorTotal2TextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.valorTotalTextBox = new System.Windows.Forms.TextBox();
            this.limparButton = new System.Windows.Forms.Button();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.panel.SuspendLayout();
            this.topPanel.SuspendLayout();
            this.midle1Panel.SuspendLayout();
            this.midle2Panel.SuspendLayout();
            this.bottomPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // idFuncionarioLabel
            // 
            this.idFuncionarioLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.idFuncionarioLabel.AutoSize = true;
            this.idFuncionarioLabel.Location = new System.Drawing.Point(398, 18);
            this.idFuncionarioLabel.Name = "idFuncionarioLabel";
            this.idFuncionarioLabel.Size = new System.Drawing.Size(77, 13);
            this.idFuncionarioLabel.TabIndex = 3;
            this.idFuncionarioLabel.Text = "Vendedor (F8):";
            // 
            // idLabel
            // 
            this.idLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.idLabel.AutoSize = true;
            this.idLabel.Location = new System.Drawing.Point(276, 18);
            this.idLabel.Name = "idLabel";
            this.idLabel.Size = new System.Drawing.Size(43, 13);
            this.idLabel.TabIndex = 1;
            this.idLabel.Text = "Código:";
            // 
            // dataLabel
            // 
            this.dataLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dataLabel.AutoSize = true;
            this.dataLabel.Location = new System.Drawing.Point(651, 18);
            this.dataLabel.Name = "dataLabel";
            this.dataLabel.Size = new System.Drawing.Size(33, 13);
            this.dataLabel.TabIndex = 6;
            this.dataLabel.Text = "Data:";
            // 
            // idClienteLabel
            // 
            this.idClienteLabel.AutoSize = true;
            this.idClienteLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.idClienteLabel.Location = new System.Drawing.Point(154, 42);
            this.idClienteLabel.Name = "idClienteLabel";
            this.idClienteLabel.Size = new System.Drawing.Size(65, 13);
            this.idClienteLabel.TabIndex = 3;
            this.idClienteLabel.Text = "Nome (F12):";
            // 
            // valorTotalLabel
            // 
            this.valorTotalLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.valorTotalLabel.AutoSize = true;
            this.valorTotalLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.valorTotalLabel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.valorTotalLabel.Location = new System.Drawing.Point(513, 13);
            this.valorTotalLabel.Name = "valorTotalLabel";
            this.valorTotalLabel.Size = new System.Drawing.Size(56, 24);
            this.valorTotalLabel.TabIndex = 3;
            this.valorTotalLabel.Text = "Total:";
            this.valorTotalLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // panel
            // 
            this.panel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel.Controls.Add(this.topPanel);
            this.panel.Controls.Add(this.midle1Panel);
            this.panel.Controls.Add(this.midle2Panel);
            this.panel.Controls.Add(this.bottomPanel);
            this.panel.Location = new System.Drawing.Point(0, 0);
            this.panel.Margin = new System.Windows.Forms.Padding(0);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(822, 574);
            this.panel.TabIndex = 0;
            // 
            // topPanel
            // 
            this.topPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.topPanel.BackColor = System.Drawing.Color.Silver;
            this.topPanel.Controls.Add(this.orcamentoLabel);
            this.topPanel.Controls.Add(this.funcionarioButton);
            this.topPanel.Controls.Add(this.idFuncionarioLabel);
            this.topPanel.Controls.Add(this.codigoTB);
            this.topPanel.Controls.Add(this.idLabel);
            this.topPanel.Controls.Add(this.dataLabel);
            this.topPanel.Controls.Add(this.funcionarioCB);
            this.topPanel.Controls.Add(this.dataTB);
            this.topPanel.Location = new System.Drawing.Point(0, 0);
            this.topPanel.Margin = new System.Windows.Forms.Padding(0);
            this.topPanel.Name = "topPanel";
            this.topPanel.Size = new System.Drawing.Size(822, 72);
            this.topPanel.TabIndex = 0;
            // 
            // orcamentoLabel
            // 
            this.orcamentoLabel.AutoSize = true;
            this.orcamentoLabel.Font = new System.Drawing.Font("Verdana", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.orcamentoLabel.Location = new System.Drawing.Point(41, 18);
            this.orcamentoLabel.Name = "orcamentoLabel";
            this.orcamentoLabel.Size = new System.Drawing.Size(225, 38);
            this.orcamentoLabel.TabIndex = 0;
            this.orcamentoLabel.Text = "Condicional";
            // 
            // funcionarioButton
            // 
            this.funcionarioButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.funcionarioButton.Image = ((System.Drawing.Image)(resources.GetObject("funcionarioButton.Image")));
            this.funcionarioButton.Location = new System.Drawing.Point(606, 33);
            this.funcionarioButton.Margin = new System.Windows.Forms.Padding(3, 3, 19, 5);
            this.funcionarioButton.Name = "funcionarioButton";
            this.funcionarioButton.Size = new System.Drawing.Size(23, 23);
            this.funcionarioButton.TabIndex = 5;
            this.funcionarioButton.UseVisualStyleBackColor = true;
            this.funcionarioButton.Click += new System.EventHandler(this.funcionarioButton_Click);
            // 
            // codigoTB
            // 
            this.codigoTB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.codigoTB.BackColor = System.Drawing.SystemColors.ControlLight;
            this.codigoTB.Location = new System.Drawing.Point(276, 34);
            this.codigoTB.Margin = new System.Windows.Forms.Padding(3, 3, 19, 5);
            this.codigoTB.Multiline = true;
            this.codigoTB.Name = "codigoTB";
            this.codigoTB.ReadOnly = true;
            this.codigoTB.Size = new System.Drawing.Size(100, 21);
            this.codigoTB.TabIndex = 2;
            // 
            // funcionarioCB
            // 
            this.funcionarioCB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.funcionarioCB.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.funcionarioCB.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.funcionarioCB.BackColor = System.Drawing.SystemColors.Window;
            this.funcionarioCB.DisplayMember = "id";
            this.funcionarioCB.FormattingEnabled = true;
            this.funcionarioCB.IntegralHeight = false;
            this.funcionarioCB.Location = new System.Drawing.Point(398, 34);
            this.funcionarioCB.Margin = new System.Windows.Forms.Padding(3, 3, 3, 5);
            this.funcionarioCB.Name = "funcionarioCB";
            this.funcionarioCB.Size = new System.Drawing.Size(202, 21);
            this.funcionarioCB.TabIndex = 4;
            this.funcionarioCB.ValueMember = "id";
            this.funcionarioCB.Validating += new System.ComponentModel.CancelEventHandler(this.funcionarioCB_Validating);
            // 
            // dataTB
            // 
            this.dataTB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dataTB.BackColor = System.Drawing.SystemColors.ControlLight;
            this.dataTB.Location = new System.Drawing.Point(651, 34);
            this.dataTB.Margin = new System.Windows.Forms.Padding(3, 3, 19, 5);
            this.dataTB.Multiline = true;
            this.dataTB.Name = "dataTB";
            this.dataTB.ReadOnly = true;
            this.dataTB.Size = new System.Drawing.Size(124, 21);
            this.dataTB.TabIndex = 7;
            // 
            // midle1Panel
            // 
            this.midle1Panel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.midle1Panel.BackColor = System.Drawing.SystemColors.Control;
            this.midle1Panel.Controls.Add(this.produtos1);
            this.midle1Panel.Location = new System.Drawing.Point(0, 73);
            this.midle1Panel.Margin = new System.Windows.Forms.Padding(0, 1, 0, 0);
            this.midle1Panel.Name = "midle1Panel";
            this.midle1Panel.Size = new System.Drawing.Size(822, 325);
            this.midle1Panel.TabIndex = 1;
            // 
            // produtos1
            // 
            this.produtos1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.produtos1.AVistaVisible = true;
            this.produtos1.Cursor = System.Windows.Forms.Cursors.Default;
            this.produtos1.Location = new System.Drawing.Point(48, 0);
            this.produtos1.Margin = new System.Windows.Forms.Padding(0);
            this.produtos1.Name = "produtos1";
            this.produtos1.Size = new System.Drawing.Size(728, 324);
            this.produtos1.TabIndex = 1;
            // 
            // midle2Panel
            // 
            this.midle2Panel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.midle2Panel.BackColor = System.Drawing.SystemColors.Control;
            this.midle2Panel.Controls.Add(this.label1);
            this.midle2Panel.Controls.Add(this.clienteButton);
            this.midle2Panel.Controls.Add(this.label5);
            this.midle2Panel.Controls.Add(this.idClienteTB);
            this.midle2Panel.Controls.Add(this.idClienteLabel);
            this.midle2Panel.Controls.Add(this.idClienteCB);
            this.midle2Panel.Location = new System.Drawing.Point(0, 399);
            this.midle2Panel.Margin = new System.Windows.Forms.Padding(0, 1, 0, 1);
            this.midle2Panel.Name = "midle2Panel";
            this.midle2Panel.Size = new System.Drawing.Size(822, 93);
            this.midle2Panel.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(45, 13);
            this.label1.Margin = new System.Windows.Forms.Padding(3, 15, 3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Cliente:";
            // 
            // clienteButton
            // 
            this.clienteButton.Image = ((System.Drawing.Image)(resources.GetObject("clienteButton.Image")));
            this.clienteButton.Location = new System.Drawing.Point(366, 57);
            this.clienteButton.Margin = new System.Windows.Forms.Padding(3, 3, 19, 5);
            this.clienteButton.Name = "clienteButton";
            this.clienteButton.Size = new System.Drawing.Size(23, 23);
            this.clienteButton.TabIndex = 5;
            this.clienteButton.UseVisualStyleBackColor = true;
            this.clienteButton.Click += new System.EventHandler(this.clienteButton_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(48, 43);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "Código";
            // 
            // idClienteTB
            // 
            this.idClienteTB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.idClienteTB.Location = new System.Drawing.Point(48, 58);
            this.idClienteTB.Name = "idClienteTB";
            this.idClienteTB.Size = new System.Drawing.Size(100, 20);
            this.idClienteTB.TabIndex = 2;
            this.idClienteTB.KeyUp += new System.Windows.Forms.KeyEventHandler(this.idClienteTB_KeyUp);
            this.idClienteTB.Leave += new System.EventHandler(this.idClienteTB_Leave);
            this.idClienteTB.Validating += new System.ComponentModel.CancelEventHandler(this.idClienteTB_Validating);
            // 
            // idClienteCB
            // 
            this.idClienteCB.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.idClienteCB.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.idClienteCB.DisplayMember = "id";
            this.idClienteCB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.idClienteCB.FormattingEnabled = true;
            this.idClienteCB.Location = new System.Drawing.Point(154, 58);
            this.idClienteCB.Margin = new System.Windows.Forms.Padding(3, 3, 3, 5);
            this.idClienteCB.Name = "idClienteCB";
            this.idClienteCB.Size = new System.Drawing.Size(206, 21);
            this.idClienteCB.TabIndex = 4;
            this.idClienteCB.ValueMember = "id";
            this.idClienteCB.SelectedIndexChanged += new System.EventHandler(this.idClienteCB_SelectedIndexChanged);
            this.idClienteCB.Validating += new System.ComponentModel.CancelEventHandler(this.idClienteCB_Validating);
            // 
            // bottomPanel
            // 
            this.bottomPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.bottomPanel.BackColor = System.Drawing.Color.Silver;
            this.bottomPanel.Controls.Add(this.salvarButton);
            this.bottomPanel.Controls.Add(this.valorTotal2TextBox);
            this.bottomPanel.Controls.Add(this.label2);
            this.bottomPanel.Controls.Add(this.valorTotalTextBox);
            this.bottomPanel.Controls.Add(this.valorTotalLabel);
            this.bottomPanel.Controls.Add(this.limparButton);
            this.bottomPanel.Location = new System.Drawing.Point(0, 493);
            this.bottomPanel.Margin = new System.Windows.Forms.Padding(0);
            this.bottomPanel.Name = "bottomPanel";
            this.bottomPanel.Size = new System.Drawing.Size(822, 81);
            this.bottomPanel.TabIndex = 3;
            // 
            // salvarButton
            // 
            this.salvarButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.salvarButton.Image = ((System.Drawing.Image)(resources.GetObject("salvarButton.Image")));
            this.salvarButton.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.salvarButton.Location = new System.Drawing.Point(48, 10);
            this.salvarButton.Name = "salvarButton";
            this.salvarButton.Size = new System.Drawing.Size(60, 60);
            this.salvarButton.TabIndex = 0;
            this.salvarButton.Text = "&Salvar";
            this.salvarButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.salvarButton.UseVisualStyleBackColor = true;
            this.salvarButton.Click += new System.EventHandler(this.salvarButton_Click);
            // 
            // valorTotal2TextBox
            // 
            this.valorTotal2TextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.valorTotal2TextBox.BackColor = System.Drawing.SystemColors.ControlLight;
            this.valorTotal2TextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.valorTotal2TextBox.ForeColor = System.Drawing.Color.Red;
            this.valorTotal2TextBox.Location = new System.Drawing.Point(575, 42);
            this.valorTotal2TextBox.Margin = new System.Windows.Forms.Padding(3, 3, 19, 5);
            this.valorTotal2TextBox.Name = "valorTotal2TextBox";
            this.valorTotal2TextBox.ReadOnly = true;
            this.valorTotal2TextBox.Size = new System.Drawing.Size(200, 29);
            this.valorTotal2TextBox.TabIndex = 4;
            this.valorTotal2TextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(457, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 24);
            this.label2.TabIndex = 3;
            this.label2.Text = "Total à vista:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // valorTotalTextBox
            // 
            this.valorTotalTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.valorTotalTextBox.BackColor = System.Drawing.SystemColors.ControlLight;
            this.valorTotalTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.valorTotalTextBox.ForeColor = System.Drawing.Color.Red;
            this.valorTotalTextBox.Location = new System.Drawing.Point(575, 10);
            this.valorTotalTextBox.Margin = new System.Windows.Forms.Padding(3, 3, 19, 5);
            this.valorTotalTextBox.Name = "valorTotalTextBox";
            this.valorTotalTextBox.ReadOnly = true;
            this.valorTotalTextBox.Size = new System.Drawing.Size(200, 29);
            this.valorTotalTextBox.TabIndex = 4;
            this.valorTotalTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // limparButton
            // 
            this.limparButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.limparButton.Image = ((System.Drawing.Image)(resources.GetObject("limparButton.Image")));
            this.limparButton.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.limparButton.Location = new System.Drawing.Point(114, 10);
            this.limparButton.Name = "limparButton";
            this.limparButton.Size = new System.Drawing.Size(60, 60);
            this.limparButton.TabIndex = 2;
            this.limparButton.Text = "&Limpar";
            this.limparButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.limparButton.UseVisualStyleBackColor = true;
            this.limparButton.Click += new System.EventHandler(this.limparButton_Click);
            // 
            // errorProvider
            // 
            this.errorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProvider.ContainerControl = this;
            this.errorProvider.Icon = ((System.Drawing.Icon)(resources.GetObject("errorProvider.Icon")));
            // 
            // timer
            // 
            this.timer.Enabled = true;
            this.timer.Interval = 1000;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 574);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(822, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // Orcamento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(822, 596);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.panel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MinimumSize = new System.Drawing.Size(830, 440);
            this.Name = "Orcamento";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Condicional";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Orcamento_FormClosed);
            this.Load += new System.EventHandler(this.Orcamento_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Orcamento_KeyDown);
            this.panel.ResumeLayout(false);
            this.topPanel.ResumeLayout(false);
            this.topPanel.PerformLayout();
            this.midle1Panel.ResumeLayout(false);
            this.midle2Panel.ResumeLayout(false);
            this.midle2Panel.PerformLayout();
            this.bottomPanel.ResumeLayout(false);
            this.bottomPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Panel panel;
        private Label orcamentoLabel;
        private TextBox dataTB;
        private ComboBox funcionarioCB;
        private TextBox codigoTB;
        private Button salvarButton;
        private Button limparButton;
        private TextBox valorTotalTextBox;
        private ErrorProvider errorProvider;
        private Panel midle1Panel;
        private Panel topPanel;
        private Panel midle2Panel;
        private Panel bottomPanel;
        private Label label5;
        private TextBox idClienteTB;
        private ComboBox idClienteCB;
        private Button clienteButton;
        private Label label1;
        private Button funcionarioButton;
        private Timer timer;
        private StatusStrip statusStrip1;
        private Produto.Produtos produtos1;
        private Label idFuncionarioLabel;
        private Label idLabel;
        private Label dataLabel;
        private Label idClienteLabel;
        private Label valorTotalLabel;
        private TextBox valorTotal2TextBox;
        private Label label2;
    }
}