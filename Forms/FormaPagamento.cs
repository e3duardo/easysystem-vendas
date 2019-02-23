using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Library.Converter;


namespace Forms
{
    public partial class FormaPagamento : Form
    {



        //in
        public decimal ValorTotal { get; set; }
        public decimal ValorTotalAVista { get; set; }
        public bool aptoAPrazo { get; set; }
        public int diaPagamento { get; set; }


        //out
        public string Forma { get; set; }

        public DataGridView ParcelasDGV { get; set; }
        public decimal Entrada { get; set; }
        public int Quantidade { get; set; }

        public DateTime ChequeData { get; set; }
        public string ChequeNumero { get; set; }

        public string CartaoTipo { get; set; }

        public decimal ValorTotalTextBox
        {
            get
            {
                return this.valorTotalTB.Text.ConvertToDecimal();
            }
        }



        public FormaPagamento()
        {
            InitializeComponent();
        }


        private void vendaFormaPagamento_Load(object sender, EventArgs e)
        {
            try
            {
                this.valorTotalTB.Text = this.ValorTotalAVista.ConvertToMoneyString();

                //dataParcelaDTP.Value = DateTime.Today.AddMonths(1);

                ToggleSelection("avista");
                avistaRecebidoTB.Text = "";


                //this.dataParcelaDTP.Value = DateTime.Now;

                DateTime data;

                int hoje = DateTime.Today.Day;

                if (diaPagamento <= hoje)
                {
                    data = new DateTime(DateTime.Today.Year, (DateTime.Today.Month + 1), diaPagamento);
                }
                else
                {
                    data = new DateTime(DateTime.Today.Year, DateTime.Today.Month, diaPagamento);
                }
                this.dataParcelaDTP.Value = data;

                percentTextBox1.Text = "";
            }
            catch (Exception ex)
            {
                Library.Diagnostics.Logger.Error(ex);
            }

        }


        private void avistaP_Click(object sender, EventArgs e)
        {
            ToggleSelection("avista");
            this.valorTotalTB.Text = this.ValorTotalAVista.ConvertToMoneyString();
        }

        private void aprazoP_Click(object sender, EventArgs e)
        {
            ToggleSelection("aprazo");
            this.valorTotalTB.Text = this.ValorTotal.ConvertToMoneyString();
        }

        private void cartaoP_Click(object sender, EventArgs e)
        {
            ToggleSelection("cartao");
            this.valorTotalTB.Text = this.ValorTotal.ConvertToMoneyString();
        }

        private void chequeP_Click(object sender, EventArgs e)
        {
            ToggleSelection("cheque");
            this.valorTotalTB.Text = this.ValorTotal.ConvertToMoneyString();
        }


        private void gerarParcelasButton_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                this.aprazoParcelasDGV.Rows.Clear();

                int quantidade = 0;
                int.TryParse(quantidadeTextBox.Text, out quantidade);

                decimal entradaTMP = 0;
                decimal.TryParse(entradaTextBox.Text, out entradaTMP);


                if (quantidade != 0)
                {
                    if (entradaTMP < this.valorTotalTB.Text.ConvertToDecimal())
                    {
                        DateTime dataParcela = this.dataParcelaDTP.Value.AddMonths(-1);

                        decimal valorParcela = (this.ValorTotal - entradaTMP) / quantidade;

                        for (int i = 0; i < quantidade; i++)
                        {
                            dataParcela = dataParcela.AddMonths(1);

                            this.aprazoParcelasDGV.Rows.Add(new object[] { valorParcela, dataParcela.ToString("dd/MM/yyyy") });
                        }

                        this.ParcelasDGV = aprazoParcelasDGV;
                        this.Entrada = entradaTMP;
                    }
                    else
                    {
                        MessageBox.Show("Entrada maior que valor total.", "Aviso!", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Digite a quantidade de parcelas.", "Aviso!", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                }

            }
            catch (Exception ex)
            {
                //Library.Diagnostics.Logger.Error(ex.Message,ex.StackTrace,ex.HelpLink,ex);;
                Library.Diagnostics.Logger.Error(ex);
            }
            this.Cursor = Cursors.Default;
        }

        private void salvarButton_Click(object sender, EventArgs e)
        {
            if (this.aVistaRB.Checked == true)
            {
                this.Forma = "avista";
                this.DialogResult = DialogResult.OK;
            }
            else if (this.aPrazoRB.Checked == true)
            {
                this.Forma = "aprazo";
                this.DialogResult = DialogResult.OK;
            }
            else if (this.cartaoRB.Checked == true)
            {
                this.Entrada = cartaoEntradaTB.Text.ConvertToInt();
                this.Quantidade = cartaoQuantidadeTB.Text.ConvertToInt();
                this.Forma = "cartao";
                if (this.cartaoCreditoRB.Checked)
                    this.CartaoTipo = "Crédito";
                else
                    this.CartaoTipo = "Débito";
                this.DialogResult = DialogResult.OK;
            }
            else if (this.chequeRB.Checked == true)
            {
                this.Forma = "cheque";
                this.ChequeData = chequeDTP.Value;
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("Deve escolher uma forma de pagamento");
            }
        }

        private void cancelarButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }


        private void Venda_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F5:
                    this.salvarButton.PerformClick();
                    break;
                case Keys.F6:
                    this.cancelarButton.PerformClick();
                    break;

                case Keys.F9:
                    ToggleSelection("avista");
                    break;
                case Keys.F10:
                    ToggleSelection("aprazo");
                    break;
                case Keys.F11:
                    ToggleSelection("cartao");
                    break;
                case Keys.F12:
                    ToggleSelection("avista");
                    break;
            }
        }


        private void avistaRecebidoTB_KeyUp(object sender, KeyEventArgs e)
        {
            decimal valorTotal = this.valorTotalTB.Text.ConvertToDecimal();
            decimal valorPago = this.avistaRecebidoTB.Text.ConvertToDecimal();

            if (valorPago >= valorTotal)
                this.avistaTrocoTB.Text = (valorTotal - valorPago).ConvertToMoneyString();
        }


        private void chequeGerarParcelas_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                this.chequeParcelasDGV.Rows.Clear();

                int quantidade = 0;
                int.TryParse(chequeQuantidadeTB.Text, out quantidade);

                decimal entradaTMP = 0;
                decimal.TryParse(chequeEntradaTB.Text, out entradaTMP);

                if (quantidade != 0)
                {
                    if (entradaTMP < this.valorTotalTB.Text.ConvertToDecimal())
                    {
                        DateTime dataParcela = this.chequeDTP.Value.AddMonths(-1);

                        decimal valorParcela = (this.ValorTotal - entradaTMP) / quantidade;

                        for (int i = 0; i < quantidade; i++)
                        {
                            dataParcela = dataParcela.AddMonths(1);

                            this.chequeParcelasDGV.Rows.Add("", valorParcela, dataParcela.ToString("dd/MM/yyyy"));
                        }

                        this.ParcelasDGV = chequeParcelasDGV;
                        this.Entrada = entradaTMP;
                    }
                    else
                    {
                        MessageBox.Show("Entrada maior que valor total.", "Aviso!", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Digite a quantidade de parcelas.", "Aviso!", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                }

            }
            catch (Exception ex)
            {
                Library.Diagnostics.Logger.Error(ex);
            }
            this.Cursor = Cursors.Default;
        }


        /*private void cartaoGerarParcelas_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                this.cartaoParcelasDGV.Rows.Clear();

                int quantidade = 0;
                int.TryParse(cartaoQuantidadeTB.Text, out quantidade);

                decimal entradaTMP = 0;
                decimal.TryParse(cartaoEntradaTB.Text, out entradaTMP);

                if (quantidade != 0)
                {
                    if (entradaTMP < this.valorTotalTB.Text.ConvertToDecimal())
                    {
                        DateTime dataParcela = this.cartaoDTP.Value.AddMonths(-1);

                        decimal valorParcela = (this.ValorTotal - entradaTMP) / quantidade;

                        for (int i = 0; i < quantidade; i++)
                        {
                            dataParcela = dataParcela.AddMonths(1);

                            this.cartaoParcelasDGV.Rows.Add(valorParcela, dataParcela.ToString("dd/MM/yyyy"));
                        }

                        this.ParcelasDGV = cartaoParcelasDGV;
                        this.Entrada = entradaTMP;
                    }
                    else
                    {
                        MessageBox.Show("Entrada maior que valor total.", "Aviso!", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Digite a quantidade de parcelas.", "Aviso!", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                }

            }
            catch (Exception ex)
            {
                Library.Diagnostics.Logger.Error(ex);
            }
            this.Cursor = Cursors.Default;
        }*/


        private void buttonCalcular_Click(object sender, EventArgs e)
        {
            decimal preco = this.ValorTotalAVista;
            decimal desconto = this.percentTextBox1.Value;

            decimal porcentagem = 0;
            decimal precoVendaComDesconto = 0;

            porcentagem = preco * (desconto / 100);
            precoVendaComDesconto = preco - porcentagem;

            this.valorTotalTB.Text = precoVendaComDesconto.ConvertToMoneyString();
        }

        private void cartaoDebitoRB_CheckedChanged(object sender, EventArgs e)
        {
            if (cartaoCreditoRB.Checked)
                cartaoParcelasP.Enabled = true;
            else
                cartaoParcelasP.Enabled = false;
        }

        private void cartaoCreditoRB_CheckedChanged(object sender, EventArgs e)
        {
            if (cartaoCreditoRB.Checked)
                cartaoParcelasP.Enabled = true;
            else
                cartaoParcelasP.Enabled = false;
        }

        private void ToggleSelection(string teste)
        {
            //this.Height = 480;
            //panel5.Location = new System.Drawing.Point(0, 360);

            switch (teste)
            {
                case "avista":
                    this.avistaP.Height = 150;
                    this.aprazoP.Height = 52;
                    this.cartaoP.Height = 52;
                    this.chequeP.Height = 52;

                    this.avistaP.Location = new System.Drawing.Point(0, 0);
                    this.aprazoP.Location = new System.Drawing.Point(0, 151);
                    this.cartaoP.Location = new System.Drawing.Point(0, 204);
                    this.chequeP.Location = new System.Drawing.Point(0, 257);

                    this.avistaTITLE.BackColor = SystemColors.ControlLight;
                    this.aprazoTITLE.BackColor = SystemColors.Control;
                    this.cartaoTITLE.BackColor = SystemColors.Control;
                    this.chequeTITLE.BackColor = SystemColors.Control;

                    this.aVistaRB.Checked = true;
                    this.aPrazoRB.Checked = false;
                    this.cartaoRB.Checked = false;
                    this.chequeRB.Checked = false;

                    this.Forma = "avista";

                    this.Height = 430;
                    break;

                case "aprazo":
                    if (aptoAPrazo)
                    {
                        this.avistaP.Height = 52;
                        this.aprazoP.Height = 200;
                        this.cartaoP.Height = 52;
                        this.chequeP.Height = 52;

                        this.avistaP.Location = new System.Drawing.Point(0, 0);
                        this.aprazoP.Location = new System.Drawing.Point(0, 53);
                        this.cartaoP.Location = new System.Drawing.Point(0, 254);
                        this.chequeP.Location = new System.Drawing.Point(0, 307);

                        this.avistaTITLE.BackColor = SystemColors.Control;
                        this.aprazoTITLE.BackColor = SystemColors.ControlLight;
                        this.cartaoTITLE.BackColor = SystemColors.Control;
                        this.chequeTITLE.BackColor = SystemColors.Control;

                        this.aVistaRB.Checked = false;
                        this.aPrazoRB.Checked = true;
                        this.cartaoRB.Checked = false;
                        this.chequeRB.Checked = false;

                        this.Forma = "aprazo";

                        this.Height = 480;
                    }
                    else
                    {
                        MessageBox.Show("Este cliente não está apto a parcelamento.");
                        this.aPrazoRB.Checked = false;
                    }

                    break;

                case "cartao":
                    this.avistaP.Height = 52;
                    this.aprazoP.Height = 52;
                    this.cartaoP.Height = 166;//250//84
                    this.chequeP.Height = 52;

                    this.avistaP.Location = new System.Drawing.Point(0, 0);
                    this.aprazoP.Location = new System.Drawing.Point(0, 53);
                    this.cartaoP.Location = new System.Drawing.Point(0, 106);
                    this.chequeP.Location = new System.Drawing.Point(0, 273);//357);

                    this.avistaTITLE.BackColor = SystemColors.Control;
                    this.aprazoTITLE.BackColor = SystemColors.Control;
                    this.cartaoTITLE.BackColor = SystemColors.ControlLight;
                    this.chequeTITLE.BackColor = SystemColors.Control;

                    this.aVistaRB.Checked = false;
                    this.aPrazoRB.Checked = false;
                    this.cartaoRB.Checked = true;
                    this.chequeRB.Checked = false;

                    this.Forma = "cartao";

                    this.Height = 446;//530;
                    break;

                case "cheque":
                    this.avistaP.Height = 52;
                    this.aprazoP.Height = 52;
                    this.cartaoP.Height = 52;
                    this.chequeP.Height = 200;

                    this.avistaP.Location = new System.Drawing.Point(0, 0);
                    this.aprazoP.Location = new System.Drawing.Point(0, 53);
                    this.cartaoP.Location = new System.Drawing.Point(0, 106);
                    this.chequeP.Location = new System.Drawing.Point(0, 159);

                    this.avistaTITLE.BackColor = SystemColors.Control;
                    this.aprazoTITLE.BackColor = SystemColors.Control;
                    this.cartaoTITLE.BackColor = SystemColors.Control;
                    this.chequeTITLE.BackColor = SystemColors.ControlLight;

                    this.aVistaRB.Checked = false;
                    this.aPrazoRB.Checked = false;
                    this.cartaoRB.Checked = false;
                    this.chequeRB.Checked = true;

                    this.Forma = "cheque";

                    this.Height = 480;
                    break;

                default:
                    break;
            }
        }
    }
}
